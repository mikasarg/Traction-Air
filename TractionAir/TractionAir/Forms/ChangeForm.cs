using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;

namespace TractionAir
{
    public partial class ChangeForm : Form
    {
        private int boardCode;

        public ChangeForm(int boardCode)
        {
            this.boardCode = boardCode;

            InitializeComponent();
        }

        /// <summary>
        /// Loads data from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.boardVersionTable' table. You can move, or remove it, as needed.
            this.boardVersionTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.boardVersionTable);
            this.speedControlTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.speedControlTable);
            this.programVersionTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.programVersionTable);
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            this.mainSettingsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.mainSettingsTable);

            loadValues();
        }

        /// <summary>
        /// Loads the table values into the boxes
        /// </summary>
        private void loadValues()
        {
            try
            {
                ECU_MainSettings ecu = ECU_Manager.getECUByBC(boardCode);
                int pgId = ECU_Manager.EcuToPressureGroup(boardCode);

                //Sets the text for the boxes to be their equivalents in the selected entry
                boardNumberTextbox.Text = boardCode.ToString();
                serialNumberTextbox.Text = ECU_Manager.CheckString("Serial Number", ecu.SerialNumber, false);
                bottomSerialNumberTextbox.Text = ECU_Manager.CheckString("Bottom Serial Number", ecu.SerialCodeBot, true);
                boardVersionComboBox.SelectedValue = ECU_Manager.EcuToBoardVersion(boardCode);
                programVersionComboBox.SelectedValue = ECU_Manager.EcuToVersion(boardCode);
                pressureGroupComboBox.SelectedValue = pgId;
                customerComboBox.SelectedValue = ECU_Manager.EcuToCustomer(boardCode);
                buildDateTimePicker.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
                installDateTimePicker.Value = DateTime.Now; //current time
                vehicleRefTextbox.Text = ECU_Manager.CheckString("Vehicle Ref", ecu.VehicleRef, true);
                pressureCellTextbox.Text = ECU_Manager.CheckBigInt("Pressure Cell", ecu.PressureCell.ToString(), false).ToString();
                pt1SerialTextbox.Text = ECU_Manager.CheckString("Pt1 Serial", ecu.PT1Serial, false);
                pt2SerialTextbox.Text = ECU_Manager.CheckString("Pt2 Serial", ecu.PT2Serial, false);
                pt3SerialTextbox.Text = ECU_Manager.CheckString("Pt3 Serial", ecu.PT3Serial, true);
                pt4SerialTextbox.Text = ECU_Manager.CheckString("Pt4 Serial", ecu.PT4Serial, true);
                pt5SerialTextbox.Text = ECU_Manager.CheckString("Pt5 Serial", ecu.PT5Serial, true);
                pt6SerialTextbox.Text = ECU_Manager.CheckString("Pt6 Serial", ecu.PT6Serial, true);
                pt7SerialTextbox.Text = ECU_Manager.CheckString("Pt7 Serial", ecu.PT7Serial, true);
                pt8SerialTextbox.Text = ECU_Manager.CheckString("Pt8 Serial", ecu.PT8Serial, true);
                descriptionTextbox.Text = ECU_Manager.CheckString("Description", ecu.Description, true);
                notesRichTextbox.Text = ECU_Manager.CheckString("Notes", ecu.Notes, true);
                countryComboBox.SelectedValue = ECU_Manager.EcuToCountry(boardCode);

                //Manual Database Update section
                speedControlComboBox.SelectedValue = ECU_Manager.EcuToSpeedControl(boardCode);
                loadedOffRoadTextbox.Text = ECU_Manager.CheckString("Loaded Off Road", ecu.LoadedOffRoad.ToString(), false);
                notLoadedTextbox.Text = ECU_Manager.CheckString("Unloaded On Road", ecu.UnloadedOnRoad.ToString(), false);
                unloadedOffRoadTextbox.Text = ECU_Manager.CheckString("Unloaded Off Road", ecu.UnloadedOffRoad.ToString(), false);
                maxTractionTextbox.Text = ECU_Manager.CheckString("Max Traction", ecu.MaxTraction.ToString(), false);
                stepUpDelayTextbox.Text = ECU_Manager.CheckString("Step Up Delay", ecu.StepUpDelay.ToString(), false);
                beepCheckBox.Checked = ecu.MaxTractionBeep;
                gpsButtonCheckBox.Checked = ecu.EnableGPSButtons;
                distanceTextbox.Text = ECU_Manager.CheckBigInt("Distance", ecu.Distance.ToString(), false).ToString();

                PressureGroupObject pg = ECU_Manager.getPGByID(pgId);
                psiLoadedOnTextbox.Text = ECU_Manager.Check3Int("Loaded On Road Pressure", pg.LoadedOnRoad.ToString(), false).ToString();
                psiLoadedOffTextbox.Text = ECU_Manager.Check3Int("Loaded Off Road Pressure", pg.LoadedOffRoad.ToString(), false).ToString();
                psiUnloadedOnTextbox.Text = ECU_Manager.Check3Int("Unloaded On Road Pressure", pg.UnloadedOnRoad.ToString(), false).ToString();
                psiUnloadedOffTextbox.Text = ECU_Manager.Check3Int("Unloaded Off Road Pressure", pg.UnloadedOffRoad.ToString(), false).ToString();
                psiMaxTractionTextbox.Text = ECU_Manager.Check3Int("Max Traction Pressure", pg.MaxTraction.ToString(), false).ToString();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show("An error occurred when trying to load the selected entry: " + ioex.Message, "Error");
            }
        }

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            save();
        }

        /// <summary>
        /// Closes the window and does not save the changes the user made to the entry
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

        /// <summary>
        /// Creates the SQL command for the update
        /// </summary>
        private void save()
        {
            string update1 = "UPDATE mainSettingsTable SET BoardCode = @boardCode, PressureGroup = @pressureGroup, Owner = @owner, " +
                "Country = @country, BuildDate = @buildDate, Version = @version, Description = @description, VehicleRef = @vehicleRef, " +
                "SpeedStages = @speedStages, DateMod = @dateMod, Notes = @notes, SerialNumber = @serialNumber, PressureCell = @pressureCell, " +
                "PT1Serial = @pt1Serial, PT2Serial = @pt2Serial, PT3Serial = @pt3Serial, PT4Serial = @pt4Serial, PT5Serial = @pt5Serial, " +
                "PT6Serial = @pt6Serial, PT7Serial = @pt7Serial, PT8Serial = @pt8Serial, LoadedOffRoad = @loadedOffRoad, " +
                "UnloadedOnRoad = @unloadedOnRoad, MaxTraction = @maxTraction, SerialCodeBot = @serialCodeBot, MaxTractionBeep = @maxTractionBeep, " +
                "StepUpDelay = @stepUpDelay, EnableGPSButtons = @enableGpsButtons, Distance = @distance, UnloadedOffRoad = @unloadedOffRoad " +
                "WHERE BoardCode = @boardCode;";
            string update2 = "UPDATE ecuToCountry SET CountryID = @countryId WHERE BoardCode = @boardCode;"; //Have to update the connections as well
            string update3 = "UPDATE ecuToCustomer SET CustomerID = @customerId WHERE BoardCode = @boardCode;";
            string update4 = "UPDATE ecuToPressureGroup SET PressureGroupID = @pressureGroupId WHERE BoardCode = @boardCode;";
            string update5 = "UPDATE ecuToVersion SET VersionID = @versionId WHERE BoardCode = @boardCode;";
            string update6 = "UPDATE ecuToSpeedControl SET SpeedControlID = @speedControlId WHERE BoardCode = @boardCode;";
            string update7 = "UPDATE ecuToBoardVersion SET VersionID = @versionId WHERE BoardCode = @boardCode;";

            try
            {
                int boardCode = ECU_Manager.Check6Int("Board Code", boardNumberTextbox.Text, false);
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command1 = new SqlCommand(update1, connection);
                    command1.Parameters.Add("@boardCode", SqlDbType.Int);
                    command1.Parameters["@boardCode"].Value = boardCode;
                    command1.Parameters.Add("@pressureGroup", SqlDbType.NVarChar);
                    command1.Parameters["@pressureGroup"].Value = ECU_Manager.CheckString("Pressure Group", pressureGroupComboBox.Text, false);
                    command1.Parameters.Add("@owner", SqlDbType.NVarChar);
                    command1.Parameters["@owner"].Value = ECU_Manager.CheckString("Onwer", customerComboBox.Text, false);
                    command1.Parameters.Add("@country", SqlDbType.NVarChar);
                    command1.Parameters["@country"].Value = ECU_Manager.CheckCountryCode(countryComboBox.Text);
                    command1.Parameters.Add("@buildDate", SqlDbType.Date);
                    command1.Parameters["@buildDate"].Value = buildDateTimePicker.Value;
                    command1.Parameters.Add("@version", SqlDbType.NVarChar);
                    command1.Parameters["@version"].Value = ECU_Manager.CheckString("Program Version", programVersionComboBox.Text, false);
                    command1.Parameters.Add("@description", SqlDbType.NVarChar);
                    command1.Parameters["@description"].Value = ECU_Manager.CheckString("Description", descriptionTextbox.Text, true);
                    command1.Parameters.Add("@vehicleRef", SqlDbType.NVarChar);
                    command1.Parameters["@vehicleRef"].Value = ECU_Manager.CheckString("Vehicle Ref", vehicleRefTextbox.Text, true);
                    command1.Parameters.Add("@speedStages", SqlDbType.NVarChar);
                    command1.Parameters["@speedStages"].Value = ECU_Manager.CheckString("Speed Stages", speedControlComboBox.Text, false);
                    command1.Parameters.Add("@dateMod", SqlDbType.DateTime);
                    command1.Parameters["@dateMod"].Value = DateTime.Now;
                    command1.Parameters.Add("@notes", SqlDbType.NVarChar);
                    command1.Parameters["@notes"].Value = ECU_Manager.CheckLongString("Notes", notesRichTextbox.Text, true);
                    command1.Parameters.Add("@serialNumber", SqlDbType.NVarChar);
                    command1.Parameters["@serialNumber"].Value = ECU_Manager.CheckString("Serial Number", serialNumberTextbox.Text, false);
                    command1.Parameters.Add("@pressureCell", SqlDbType.SmallInt);
                    command1.Parameters["@pressureCell"].Value = ECU_Manager.CheckBigInt("Pressure Cell", pressureCellTextbox.Text, false);
                    command1.Parameters.Add("@pt1Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt1Serial"].Value = ECU_Manager.CheckString("Pt1 Serial", pt1SerialTextbox.Text, false);
                    command1.Parameters.Add("@pt2Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt2Serial"].Value = ECU_Manager.CheckString("Pt2 Serial", pt2SerialTextbox.Text, false);
                    command1.Parameters.Add("@pt3Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt3Serial"].Value = ECU_Manager.CheckString("Pt3 Serial", pt3SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt4Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt4Serial"].Value = ECU_Manager.CheckString("Pt4 Serial", pt4SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt5Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt5Serial"].Value = ECU_Manager.CheckString("Pt5 Serial", pt5SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt6Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt6Serial"].Value = ECU_Manager.CheckString("Pt6 Serial", pt6SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt7Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt7Serial"].Value = ECU_Manager.CheckString("Pt7 Serial", pt7SerialTextbox.Text, true);
                    command1.Parameters.Add("@pt8Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt8Serial"].Value = ECU_Manager.CheckString("Pt8 Serial", pt8SerialTextbox.Text, true);
                    command1.Parameters.Add("@loadedOffRoad", SqlDbType.Int);
                    command1.Parameters["@loadedOffRoad"].Value = ECU_Manager.Check3Int("Loaded Off Road", loadedOffRoadTextbox.Text, false);
                    command1.Parameters.Add("@unloadedOnRoad", SqlDbType.Int);
                    command1.Parameters["@unloadedOnRoad"].Value = ECU_Manager.Check3Int("Unloaded On Road", notLoadedTextbox.Text, false);
                    command1.Parameters.Add("@maxTraction", SqlDbType.Int);
                    command1.Parameters["@maxTraction"].Value = ECU_Manager.Check3Int("Max Traction", maxTractionTextbox.Text, false);
                    command1.Parameters.Add("@serialCodeBot", SqlDbType.NVarChar);
                    command1.Parameters["@serialCodeBot"].Value = ECU_Manager.CheckString("Bottom Serial Number", bottomSerialNumberTextbox.Text, true);
                    command1.Parameters.Add("@maxTractionBeep", SqlDbType.Bit);
                    command1.Parameters["@maxTractionBeep"].Value = ECU_Manager.CheckBit(beepCheckBox.Checked);
                    command1.Parameters.Add("@stepUpDelay", SqlDbType.Int);
                    command1.Parameters["@stepUpDelay"].Value = ECU_Manager.Check1Int("Step Up Delay", stepUpDelayTextbox.Text, false);
                    command1.Parameters.Add("@enableGpsButtons", SqlDbType.Bit);
                    command1.Parameters["@enableGpsButtons"].Value = ECU_Manager.CheckBit(gpsButtonCheckBox.Checked);
                    command1.Parameters.Add("@distance", SqlDbType.Int);
                    command1.Parameters["@distance"].Value = ECU_Manager.CheckBigInt("Distance", distanceTextbox.Text, false);
                    command1.Parameters.Add("@unloadedOffRoad", SqlDbType.Int);
                    command1.Parameters["@unloadedOffRoad"].Value = ECU_Manager.Check3Int("Unloaded Off Road", unloadedOffRoadTextbox.Text, false);

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

                    SqlCommand command6 = new SqlCommand(update6, connection);
                    command6.Parameters.Add("@boardCode", SqlDbType.Int);
                    command6.Parameters["@boardCode"].Value = boardCode;
                    command6.Parameters.Add("@speedControlId", SqlDbType.Int);
                    command6.Parameters["@speedControlId"].Value = speedControlComboBox.SelectedValue;

                    SqlCommand command7 = new SqlCommand(update7, connection);
                    command7.Parameters.Add("@boardCode", SqlDbType.Int);
                    command7.Parameters["@boardCode"].Value = boardCode;
                    command7.Parameters.Add("@versionId", SqlDbType.Int);
                    command7.Parameters["@versionId"].Value = boardVersionComboBox.SelectedValue;

                    int loadedOn = ECU_Manager.Check3Int("Loaded On Road Pressure", psiLoadedOnTextbox.Text, false);
                    int loadedOff = ECU_Manager.Check3Int("Loaded Off Road Pressure", psiLoadedOffTextbox.Text, false);
                    int unloadedOn = ECU_Manager.Check3Int("Unloaded On Road Pressure", psiUnloadedOnTextbox.Text, false);
                    int unloadedOff = ECU_Manager.Check3Int("Unloaded Off Road Pressure", psiUnloadedOffTextbox.Text, false);
                    int maxTraction = ECU_Manager.Check3Int("Max Traction Pressure", psiMaxTractionTextbox.Text, false);

                    try
                    {
                        if (ECU_Manager.CheckDifferentPSIs((int)pressureGroupComboBox.SelectedValue, loadedOn, loadedOff, unloadedOn, unloadedOff, maxTraction))
                        {
                            int before = ECU_Manager.NumberOfPGs();
                            insertPressureGroupForm insertPressureGroup = new insertPressureGroupForm(boardCode.ToString(), loadedOn, loadedOff, unloadedOn, unloadedOff, maxTraction);
                            insertPressureGroup.ShowDialog();
                            if (before != ECU_Manager.NumberOfPGs()) //A new pressure group was added
                            {
                                PressureGroupObject pg = ECU_Manager.getLatestPG();
                                MessageBox.Show("New pressure group " + pg.Description + " added successfully");
                                command1.Parameters["@pressureGroup"].Value = pg.Description;
                                command4.Parameters["@pressureGroupId"].Value = pg.Id;
                            }
                            else //new pressure group WAS NOT added
                            {
                                return;
                            }
                        }

                        connection.Open();
                        command1.ExecuteScalar();
                        command2.ExecuteScalar();
                        command3.ExecuteScalar();
                        command4.ExecuteScalar();
                        command5.ExecuteScalar();
                        command6.ExecuteScalar();
                        command7.ExecuteScalar();
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
        /// Called when a new pressure group is selected in the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressureGroupComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (pressureGroupComboBox.SelectedValue == null)
            {
                return;
            }
            PressureGroupObject pg = ECU_Manager.getPGByID((int)pressureGroupComboBox.SelectedValue);
            psiLoadedOnTextbox.Text = pg.LoadedOnRoad.ToString();
            psiLoadedOffTextbox.Text = pg.LoadedOffRoad.ToString();
            psiUnloadedOnTextbox.Text = pg.UnloadedOnRoad.ToString();
            psiUnloadedOffTextbox.Text = pg.UnloadedOffRoad.ToString();
            psiMaxTractionTextbox.Text = pg.MaxTraction.ToString();
        }
    }
}
