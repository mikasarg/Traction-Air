using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TractionAir.Serial_Classes;

namespace TractionAir.Forms
{
    public partial class ecuConnectedForm : Form
    {
        private bool alreadyExists; //true if the connected ecu is already in the DB

        public ecuConnectedForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads data from the database tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ecuConnectedForm_Load(object sender, EventArgs e)
        {
            this.speedControlTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.speedControlTable);
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            this.programVersionTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.programVersionTable);
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);

            try
            {
                loadValuesFromECU();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Failed to Load Values from ECU");
                Close();
            }

            alreadyExists = false;
            try
            {
                ECU_Manager.CheckForDuplicates(ECU_Manager.connectedBoard.ToString(), "BoardCode", "mainSettingsTable", -1);
            }
            catch (InvalidOperationException ioex)
            {
                alreadyExists = true;
                loadValuesFromDB();
            }
        }

        /// <summary>
        /// Saves the ECU to the database and uploads relevant data to the ECU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveECU();
                if (alreadyExists)
                {
                    updateDB();
                }
                else //new entry
                {
                    saveToDB();
                }
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input/Failed to Write to ECU");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Cancels the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (ECU_Manager.wishToCancel())
            {
                this.Close();
            }
            return;
        }

        private void saveECU()
        {
            string speedControl = speedControlComboBox.Text;
            int notLoaded = ECU_Manager.CheckInt(notLoadedTextbox.Text, false);
            int loadedOnRoad = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, false);
            int loadedOffRoad = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, false);
            int maxTraction = ECU_Manager.CheckInt(maxTractionTextbox.Text, false);
            int stepUpDelay = ECU_Manager.CheckInt(stepUpDelayTextbox.Text, false);
            bool maxTractionBeep = beepCheckBox.Checked;
            bool enableGPSButtons = gpsButtonCheckBox.Checked;
            bool enableGPSOverride = gpsOverrideCheckBox.Checked;
            string output = readWriteHelper.generateOutput(ECU_Manager.connectedBoard, speedControl, notLoaded, loadedOnRoad, loadedOffRoad, maxTraction, stepUpDelay, maxTractionBeep, enableGPSButtons, enableGPSOverride);
            try
            {
                SerialManager.WriteLine(output);
            }
            catch(System.IO.IOException ioex)
            {
                throw new InvalidOperationException("Error when saving data to ECU: " + ioex.Message);
            }
            catch (TimeoutException toex)
            {
                throw new InvalidOperationException("Error when saving data to ECU: " + toex.Message);
            }
        }

        /// <summary>
        /// Updates the database with new info for an already existing ECU
        /// </summary>
        private void updateDB()
        {
            string update1 = "UPDATE mainSettingsTable SET BoardCode = @boardCode, PressureGroup = @pressureGroup, Owner = @owner, " +
    "Country = @country, BuildDate = @buildDate, Version = @version, Description = @description, VehicleRef = @vehicleRef, " +
    "SpeedStages = @speedStages, DateMod = @dateMod, Notes = @notes, SerialNumber = @serialNumber, PressureCell = @pressureCell, " +
    "PT1Serial = @pt1Serial, PT2Serial = @pt2Serial, PT3Serial = @pt3Serial, PT4Serial = @pt4Serial, PT5Serial = @pt5Serial, " +
    "PT6Serial = @pt6Serial, PT7Serial = @pt7Serial, PT8Serial = @pt8Serial, LoadedOffRoad = @loadedOffRoad, LoadedOnRoad = @loadedOnRoad, " +
    "UnloadedOnRoad = @unloadedOnRoad, MaxTraction = @maxTraction, SerialCodeBot = @serialCodeBot, MaxTractionBeep = @maxTractionBeep, " +
    "StepUpDelay = @stepUpDelay, EnableGPSButtons = @enableGpsButtons, EnableGPSOverride = @enableGpsOverride, Distance = @distance " +
    "WHERE BoardCode = @boardCode;";
            string update2 = "UPDATE ecuToCountry SET CountryID = @countryId WHERE BoardCode = @boardCode;";
            string update3 = "UPDATE ecuToCustomer SET CustomerID = @customerId WHERE BoardCode = @boardCode;";
            string update4 = "UPDATE ecuToPressureGroup SET PressureGroupID = @pressureGroupId WHERE BoardCode = @boardCode;";
            string update5 = "UPDATE ecuToVersion SET VersionID = @versionId WHERE BoardCode = @boardCode;";

            try
            {
                int boardCode = ECU_Manager.CheckInt(boardNumberTextbox.Text, false);
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command1 = new SqlCommand(update1, connection);
                    command1.Parameters.Add("@boardCode", SqlDbType.Int);
                    command1.Parameters["@boardCode"].Value = boardCode;
                    command1.Parameters.Add("@pressureGroup", SqlDbType.NVarChar);
                    command1.Parameters["@pressureGroup"].Value = ECU_Manager.CheckString(pressureGroupComboBox.Text, false);
                    command1.Parameters.Add("@owner", SqlDbType.NVarChar);
                    command1.Parameters["@owner"].Value = ECU_Manager.CheckString(customerComboBox.Text, false);
                    command1.Parameters.Add("@country", SqlDbType.NVarChar);
                    command1.Parameters["@country"].Value = ECU_Manager.CheckCountryCode(countryComboBox.Text);
                    command1.Parameters.Add("@buildDate", SqlDbType.Date);
                    command1.Parameters["@buildDate"].Value = buildDateTimePicker.Value;
                    command1.Parameters.Add("@version", SqlDbType.NVarChar);
                    command1.Parameters["@version"].Value = ECU_Manager.CheckString(programVersionComboBox.Text, false);
                    command1.Parameters.Add("@description", SqlDbType.NVarChar);
                    command1.Parameters["@description"].Value = ECU_Manager.CheckString(descriptionTextbox.Text, true);
                    command1.Parameters.Add("@vehicleRef", SqlDbType.NVarChar);
                    command1.Parameters["@vehicleRef"].Value = ECU_Manager.CheckString(vehicleRefTextbox.Text, false);
                    command1.Parameters.Add("@speedStages", SqlDbType.NVarChar);
                    command1.Parameters["@speedStages"].Value = ECU_Manager.CheckString(speedControlComboBox.Text, false);
                    command1.Parameters.Add("@dateMod", SqlDbType.DateTime);
                    command1.Parameters["@dateMod"].Value = DateTime.Now;
                    command1.Parameters.Add("@notes", SqlDbType.NVarChar);
                    command1.Parameters["@notes"].Value = ECU_Manager.CheckLongString(notesRichTextbox.Text, true);
                    command1.Parameters.Add("@serialNumber", SqlDbType.NVarChar);
                    command1.Parameters["@serialNumber"].Value = ECU_Manager.CheckString(serialNumberTextbox.Text, true);
                    command1.Parameters.Add("@pressureCell", SqlDbType.SmallInt);
                    command1.Parameters["@pressureCell"].Value = ECU_Manager.CheckString(pressureCellTextbox.Text, true);
                    command1.Parameters.Add("@pt1Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt1Serial"].Value = ECU_Manager.CheckString(pt1SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt2Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt2Serial"].Value = ECU_Manager.CheckString(pt2SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt3Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt3Serial"].Value = ECU_Manager.CheckString(pt3SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt4Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt4Serial"].Value = ECU_Manager.CheckString(pt4SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt5Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt5Serial"].Value = ECU_Manager.CheckString(pt5SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt6Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt6Serial"].Value = ECU_Manager.CheckString(pt6SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt7Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt7Serial"].Value = ECU_Manager.CheckString(pt7SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt8Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt8Serial"].Value = ECU_Manager.CheckString(pt8SerialTextbox.Text, true);
                    command1.Parameters.Add("@loadedOffRoad", SqlDbType.Int);
                    command1.Parameters["@loadedOffRoad"].Value = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, true);
                    command1.Parameters.Add("@loadedOnRoad", SqlDbType.Int);
                    command1.Parameters["@loadedOnRoad"].Value = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, true);
                    command1.Parameters.Add("@unloadedOnRoad", SqlDbType.Int);
                    command1.Parameters["@unloadedOnRoad"].Value = ECU_Manager.CheckInt(notLoadedTextbox.Text, true);
                    command1.Parameters.Add("@maxTraction", SqlDbType.Int);
                    command1.Parameters["@maxTraction"].Value = ECU_Manager.CheckInt(maxTractionTextbox.Text, true);
                    command1.Parameters.Add("@serialCodeBot", SqlDbType.NVarChar);
                    command1.Parameters["@serialCodeBot"].Value = ECU_Manager.CheckString(bottomSerialNumberTextbox.Text, true);
                    command1.Parameters.Add("@maxTractionBeep", SqlDbType.Bit);
                    command1.Parameters["@maxTractionBeep"].Value = ECU_Manager.CheckBit(beepCheckBox.Checked);
                    command1.Parameters.Add("@stepUpDelay", SqlDbType.Int);
                    command1.Parameters["@stepUpDelay"].Value = ECU_Manager.CheckInt(stepUpDelayTextbox.Text, true);
                    command1.Parameters.Add("@enableGpsButtons", SqlDbType.Bit);
                    command1.Parameters["@enableGpsButtons"].Value = ECU_Manager.CheckBit(gpsButtonCheckBox.Checked);
                    command1.Parameters.Add("@enableGpsOverride", SqlDbType.Bit);
                    command1.Parameters["@enableGpsOverride"].Value = ECU_Manager.CheckBit(gpsOverrideCheckBox.Checked);
                    command1.Parameters.Add("@distance", SqlDbType.Int);
                    command1.Parameters["@distance"].Value = ECU_Manager.CheckInt(distanceTextbox.Text, true);

                    SqlCommand command2 = new SqlCommand(update2, connection);
                    command2.Parameters.Add("@boardCode", SqlDbType.Int);
                    command2.Parameters["@boardCode"].Value = boardCode;
                    command2.Parameters.Add("@countryId", SqlDbType.Int);
                    command2.Parameters["@countryId"].Value = countryComboBox.SelectedValue;

                    SqlCommand command3 = new SqlCommand(update3, connection);
                    command3.Parameters.Add("@boardCode", SqlDbType.Int);
                    command3.Parameters["@boardCode"].Value = boardCode;
                    command3.Parameters.Add("@customerId", SqlDbType.Int);
                    command3.Parameters["@customerId"].Value = customerComboBox.SelectedValue;

                    SqlCommand command4 = new SqlCommand(update4, connection);
                    command4.Parameters.Add("@boardCode", SqlDbType.Int);
                    command4.Parameters["@boardCode"].Value = boardCode;
                    command4.Parameters.Add("@pressureGroupId", SqlDbType.Int);
                    command4.Parameters["@pressureGroupId"].Value = pressureGroupComboBox.SelectedValue;

                    SqlCommand command5 = new SqlCommand(update5, connection);
                    command5.Parameters.Add("@boardCode", SqlDbType.Int);
                    command5.Parameters["@boardCode"].Value = boardCode;
                    command5.Parameters.Add("@versionId", SqlDbType.Int);
                    command5.Parameters["@versionId"].Value = programVersionComboBox.SelectedValue;

                    try
                    {
                        connection.Open();
                        command1.ExecuteScalar();
                        command2.ExecuteScalar();
                        command3.ExecuteScalar();
                        command4.ExecuteScalar();
                        command5.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Saves the ecu settings to the mainSettingsTable
        /// </summary>
        private void saveToDB()
        {
            string insert = "INSERT INTO mainSettingsTable VALUES(";

            //IMPORTANT: This order must be exact. Code is messy and long, but couldn't think of a more efficient way to do it.
            //Makes liberal use of the helper methods in ECU_Manager.cs
            //A loop with the values in a list is not feasible as each textbox/combobox etc requires different parsing
            //Creating if statements to detect the intended type of each string is possible, but seemed unwieldy - and even then,
            //some values need to be allowed to be null, and some must not be null. 
            //This seemed cleaner than lines and lines of if statements
            ECU_Manager.CheckForDuplicates(ECU_Manager.connectedBoard.ToString(), "BoardCode", "mainSettingsTable", -1);
            insert += ECU_Manager.connectedBoard + ", ";

            string pressureGroup = ECU_Manager.CheckString(pressureGroupComboBox.Text, false);
            insert += ECU_Manager.enclose(pressureGroup) + ", ";

            string customer = ECU_Manager.CheckString(customerComboBox.Text, false);
            insert += ECU_Manager.enclose(customer) + ", ";

            string country = ECU_Manager.CheckString(countryComboBox.Text, false);
            insert += ECU_Manager.enclose(country) + ", ";

            string buildDate = ECU_Manager.CheckDate(buildDateTimePicker.Text, false);
            insert += ECU_Manager.enclose(buildDate) + ", ";

            string programVersion = ECU_Manager.CheckString(programVersionComboBox.Text, false);
            insert += ECU_Manager.enclose(programVersion) + ", ";

            string description = ECU_Manager.CheckString(descriptionTextbox.Text, true);
            insert += ECU_Manager.enclose(description) + ", ";

            string vehicleRef = ECU_Manager.CheckString(vehicleRefTextbox.Text, false);
            insert += ECU_Manager.enclose(vehicleRef) + ", ";

            string speedControl = ECU_Manager.CheckString(speedControlComboBox.Text, true);
            insert += ECU_Manager.enclose(speedControl) + ", ";

            string installDate = ECU_Manager.CheckDateTime(installDateTimePicker.Value.ToString("dd/MM/yyyy HH:mm"), false);
            insert += ECU_Manager.enclose(installDate) + ", ";

            string notes = ECU_Manager.CheckLongString(notesRichTextbox.Text, true);
            insert += ECU_Manager.enclose(notes) + ", ";

            string serialNumber = ECU_Manager.CheckString(serialNumberTextbox.Text, true);
            insert += ECU_Manager.enclose(serialNumber) + ", ";

            insert += ECU_Manager.CheckInt(pressureCellTextbox.Text, true) + ", ";

            string pt1Serial = ECU_Manager.CheckString(pt1SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt1Serial) + ", ";

            string pt2Serial = ECU_Manager.CheckString(pt2SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt2Serial) + ", ";

            string pt3Serial = ECU_Manager.CheckString(pt3SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt3Serial) + ", ";

            string pt4Serial = ECU_Manager.CheckString(pt4SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt4Serial) + ", ";

            string pt5Serial = ECU_Manager.CheckString(pt5SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt5Serial) + ", ";

            string pt6Serial = ECU_Manager.CheckString(pt6SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt6Serial) + ", ";

            string pt7Serial = ECU_Manager.CheckString(pt7SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt7Serial) + ", ";

            string pt8Serial = ECU_Manager.CheckString(pt8SerialTextbox.Text, true);
            insert += ECU_Manager.enclose(pt8Serial) + ", ";

            insert += ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, true) + ", ";

            insert += ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, true) + ", ";

            insert += ECU_Manager.CheckInt(notLoadedTextbox.Text, true) + ", ";

            insert += ECU_Manager.CheckInt(maxTractionTextbox.Text, true) + ", ";

            string bottomSerialNumber = ECU_Manager.CheckString(bottomSerialNumberTextbox.Text, true);
            insert += ECU_Manager.enclose(bottomSerialNumber) + ", ";

            insert += ECU_Manager.CheckBit(beepCheckBox.Checked) + ", ";

            insert += ECU_Manager.CheckInt(stepUpDelayTextbox.Text, true) + ", ";

            insert += ECU_Manager.CheckBit(gpsButtonCheckBox.Checked) + ", ";

            insert += ECU_Manager.CheckBit(gpsOverrideCheckBox.Checked) + ", ";

            insert += ECU_Manager.CheckInt(distanceTextbox.Text, true) + ");";


            ECU_Manager.Insert(insert); //this method handles the errors
        }

        /// <summary>
        /// Loads values read from the ecu into the relevant controls
        /// </summary>
        private void loadValuesFromECU()
        {
            //TODO read data from ecu and put values in controls
            try
            {
                SerialManager.WriteLine(readWriteHelper.appendCRC("GET,"));
            }
            catch (System.IO.IOException ioex)
            {
                throw new InvalidOperationException("Error when asking for data from ECU: " + ioex.Message);
            }
            catch (TimeoutException toex)
            {
                throw new InvalidOperationException("Error when asking for data from ECU: " + toex.Message);
            }
            //TODO code below is correct but ECU does not respond yet
            /*string input = SerialManager.ReadLine();
            try
            {
                settingsFromECU settings = readWriteHelper.readInput(input);
            }
            catch (InvalidOperationException ioex)
            {
                throw new InvalidOperationException("Error when reading data from ECU: " + ioex.Message);
            }
            catch (TimeoutException toex)
            {
                throw new InvalidOperationException("Error when reading data from ECU: " + toex.Message);
            }
            ECU_Manager.connectedBoard = settings.boardCode;
            
            TODO fill controls with the data
             
            */
            ECU_Manager.connectedBoard = 1000;
        }

        /// <summary>
        /// Load values from the DB if the ecu already exists in the table
        /// </summary>
        private void loadValuesFromDB()
        {
            ECU_MainSettings ecu = ECU_Manager.getECUByBC(ECU_Manager.connectedBoard);

            //Sets the text for the boxes to be their equivalents in the selected entry
            boardNumberTextbox.Text = ECU_Manager.connectedBoard.ToString();
            serialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialNumber, true);
            bottomSerialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialCodeBot, true);
            programVersionComboBox.SelectedIndex = programVersionComboBox.FindStringExact(ecu.Version);
            pressureGroupComboBox.SelectedIndex = pressureGroupComboBox.FindStringExact(ecu.PressureGroup);
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(ecu.Owner);
            buildDateTimePicker.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
            installDateTimePicker.Value = DateTime.Now; //current time
            vehicleRefTextbox.Text = ecu.VehicleRef;
            pressureCellTextbox.Text = ECU_Manager.CheckInt(ecu.PressureCell.ToString(), true).ToString();
            pt1SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT1Serial, true);
            pt2SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT2Serial, true);
            pt3SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT3Serial, true);
            pt4SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT4Serial, true);
            pt5SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT5Serial, true);
            pt6SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT6Serial, true);
            pt7SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT7Serial, true);
            pt8SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT8Serial, true);
            descriptionTextbox.Text = ECU_Manager.CheckString(ecu.Description, true);
            notesRichTextbox.Text = ECU_Manager.CheckString(ecu.Notes, true);
            countryComboBox.SelectedIndex = countryComboBox.FindStringExact(ecu.Country);

            //Manual Database Update section
            speedControlComboBox.SelectedIndex = speedControlComboBox.FindStringExact(ecu.SpeedStages);
            loadedOffRoadTextbox.Text = ECU_Manager.CheckString(ecu.LoadedOffRoad.ToString(), true);
            loadedOnRoadTextbox.Text = ECU_Manager.CheckString(ecu.LoadedOnRoad.ToString(), true);
            notLoadedTextbox.Text = ECU_Manager.CheckString(ecu.UnloadedOnRoad.ToString(), true);
            maxTractionTextbox.Text = ECU_Manager.CheckString(ecu.MaxTraction.ToString(), true);
            stepUpDelayTextbox.Text = ECU_Manager.CheckString(ecu.StepUpDelay.ToString(), true);
            beepCheckBox.Checked = ecu.MaxTractionBeep;
            gpsButtonCheckBox.Checked = ecu.EnableGPSButtons;
            gpsOverrideCheckBox.Checked = ecu.EnableGPSOverride;
            distanceTextbox.Text = ECU_Manager.CheckInt(ecu.Distance.ToString(), true).ToString();
        }
    }
}
