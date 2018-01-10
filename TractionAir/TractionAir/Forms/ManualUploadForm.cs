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
    public partial class ManualUploadForm : Form
    {
        private string connectionString;

        public ManualUploadForm()
        {
            this.connectionString = ECU_Manager.connection("ecuSettingsDB_CS");

            InitializeComponent();
            buildDateTimePicker.Value = DateTime.Now; //Set the datetimepickers to have a default value of the current time
            installDateTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Loads data from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeForm_Load(object sender, EventArgs e)
        {
            this.speedControlTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.speedControlTable);
            this.programVersionTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.programVersionTable);
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            this.mainSettingsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.mainSettingsTable);
        }

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            string insert1 = "INSERT INTO mainSettingsTable VALUES(@boardCode, @pressureGroup, @owner, " +
    "@country, @buildDate, @version, @description, @vehicleRef, " +
    "@speedStages, @dateMod, @notes, @serialNumber, @pressureCell, " +
    "@pt1Serial, @pt2Serial, @pt3Serial, @pt4Serial, @pt5Serial, " +
    " @pt6Serial, @pt7Serial, @pt8Serial, @loadedOffRoad, @loadedOnRoad, " +
    " @unloadedOnRoad, @maxTraction, @serialCodeBot, @maxTractionBeep, " +
    " @stepUpDelay, @enableGpsButtons, @enableGpsOverride, @distance, @unloadedOffRoad);";
            string insert2 = "INSERT INTO ecuToCountry VALUES (@boardCode, @countryId);"; //Have to update the connections as well
            string insert3 = "INSERT INTO ecuToCustomer VALUES (@boardCode, @customerId);";
            string insert4 = "INSERT INTO ecuToPressureGroup VALUES (@boardCode, @pressureGroupId);";
            string insert5 = "INSERT INTO ecuToVersion VALUES (@boardCode, @versionId);";
            string insert6 = "INSERT INTO ecuToSpeedControl VALUES (@boardCode, @speedControlId);";

            try
            {
                int boardCode = ECU_Manager.CheckInt(boardNumberTextbox.Text, false);
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    //TEST TO SEE IF BOARD ALREADY EXISTS
                    ECU_Manager.CheckDuplicateECU(boardCode);

                    SqlCommand command1 = new SqlCommand(insert1, connection);
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
                    command1.Parameters["@vehicleRef"].Value = ECU_Manager.CheckString(vehicleRefTextbox.Text, true);
                    command1.Parameters.Add("@speedStages", SqlDbType.NVarChar);
                    command1.Parameters["@speedStages"].Value = ECU_Manager.CheckString(speedControlComboBox.Text, false);
                    command1.Parameters.Add("@dateMod", SqlDbType.DateTime);
                    command1.Parameters["@dateMod"].Value = DateTime.Now;
                    command1.Parameters.Add("@notes", SqlDbType.NVarChar);
                    command1.Parameters["@notes"].Value = ECU_Manager.CheckLongString(notesRichTextbox.Text, true);
                    command1.Parameters.Add("@serialNumber", SqlDbType.NVarChar);
                    command1.Parameters["@serialNumber"].Value = ECU_Manager.CheckString(serialNumberTextbox.Text, false);
                    command1.Parameters.Add("@pressureCell", SqlDbType.SmallInt);
                    command1.Parameters["@pressureCell"].Value = ECU_Manager.CheckInt(pressureCellTextbox.Text, false);
                    command1.Parameters.Add("@pt1Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt1Serial"].Value = ECU_Manager.CheckString(pt1SerialTextbox.Text, false);
                    command1.Parameters.Add("@pt2Serial", SqlDbType.NVarChar);
                    command1.Parameters["@pt2Serial"].Value = ECU_Manager.CheckString(pt2SerialTextbox.Text, false);
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
                    command1.Parameters["@loadedOffRoad"].Value = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, false);
                    command1.Parameters.Add("@loadedOnRoad", SqlDbType.Int);
                    command1.Parameters["@loadedOnRoad"].Value = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, false);
                    command1.Parameters.Add("@unloadedOnRoad", SqlDbType.Int);
                    command1.Parameters["@unloadedOnRoad"].Value = ECU_Manager.CheckInt(notLoadedTextbox.Text, false);
                    command1.Parameters.Add("@maxTraction", SqlDbType.Int);
                    command1.Parameters["@maxTraction"].Value = ECU_Manager.CheckInt(maxTractionTextbox.Text, false);
                    command1.Parameters.Add("@serialCodeBot", SqlDbType.NVarChar);
                    command1.Parameters["@serialCodeBot"].Value = ECU_Manager.CheckString(bottomSerialNumberTextbox.Text, true);
                    command1.Parameters.Add("@maxTractionBeep", SqlDbType.Bit);
                    command1.Parameters["@maxTractionBeep"].Value = ECU_Manager.CheckBit(beepCheckBox.Checked);
                    command1.Parameters.Add("@stepUpDelay", SqlDbType.Int);
                    command1.Parameters["@stepUpDelay"].Value = ECU_Manager.CheckInt(stepUpDelayTextbox.Text, false);
                    command1.Parameters.Add("@enableGpsButtons", SqlDbType.Bit);
                    command1.Parameters["@enableGpsButtons"].Value = ECU_Manager.CheckBit(gpsButtonCheckBox.Checked);
                    command1.Parameters.Add("@enableGpsOverride", SqlDbType.Bit);
                    command1.Parameters["@enableGpsOverride"].Value = ECU_Manager.CheckBit(gpsOverrideCheckBox.Checked);
                    command1.Parameters.Add("@distance", SqlDbType.Int);
                    command1.Parameters["@distance"].Value = ECU_Manager.CheckInt(distanceTextbox.Text, false);
                    command1.Parameters.Add("@unloadedOffRoad", SqlDbType.Int);
                    command1.Parameters["@unloadedOffRoad"].Value = ECU_Manager.CheckInt(unloadedOffRoadTextbox.Text, false);

                    SqlCommand command2 = new SqlCommand(insert2, connection);
                    command2.Parameters.Add("@boardCode", SqlDbType.Int);
                    command2.Parameters["@boardCode"].Value = boardCode;
                    command2.Parameters.Add("@countryId", SqlDbType.Int);
                    command2.Parameters["@countryId"].Value = countryComboBox.SelectedValue;

                    SqlCommand command3 = new SqlCommand(insert3, connection);
                    command3.Parameters.Add("@boardCode", SqlDbType.Int);
                    command3.Parameters["@boardCode"].Value = boardCode;
                    command3.Parameters.Add("@customerId", SqlDbType.Int);
                    command3.Parameters["@customerId"].Value = customerComboBox.SelectedValue;

                    SqlCommand command4 = new SqlCommand(insert4, connection);
                    command4.Parameters.Add("@boardCode", SqlDbType.Int);
                    command4.Parameters["@boardCode"].Value = boardCode;
                    command4.Parameters.Add("@pressureGroupId", SqlDbType.Int);
                    command4.Parameters["@pressureGroupId"].Value = pressureGroupComboBox.SelectedValue;

                    SqlCommand command5 = new SqlCommand(insert5, connection);
                    command5.Parameters.Add("@boardCode", SqlDbType.Int);
                    command5.Parameters["@boardCode"].Value = boardCode;
                    command5.Parameters.Add("@versionId", SqlDbType.Int);
                    command5.Parameters["@versionId"].Value = programVersionComboBox.SelectedValue;

                    SqlCommand command6 = new SqlCommand(insert6, connection);
                    command6.Parameters.Add("@boardCode", SqlDbType.Int);
                    command6.Parameters["@boardCode"].Value = boardCode;
                    command6.Parameters.Add("@speedControlId", SqlDbType.Int);
                    command6.Parameters["@speedControlId"].Value = speedControlComboBox.SelectedValue;

                    try
                    {
                        int loadedOn = ECU_Manager.CheckInt(psiLoadedOnTextbox.Text, false);
                        int loadedOff = ECU_Manager.CheckInt(psiLoadedOffTextbox.Text, false);
                        int unloadedOn = ECU_Manager.CheckInt(psiUnloadedOnTextbox.Text, false);
                        int unloadedOff = ECU_Manager.CheckInt(psiUnloadedOffTextbox.Text, false);
                        int maxTraction = ECU_Manager.CheckInt(psiMaxTractionTextbox.Text, false);

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
                        }

                        connection.Open();
                        command1.ExecuteScalar();
                        command2.ExecuteScalar();
                        command3.ExecuteScalar();
                        command4.ExecuteScalar();
                        command5.ExecuteScalar();
                        command6.ExecuteScalar();
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
