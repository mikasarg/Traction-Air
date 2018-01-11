﻿using System;
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
                try
                {
                    ECU_Manager.CheckDuplicateECU(ECU_Manager.connectedBoard);
                }
                catch (InvalidOperationException ioex)
                {
                    alreadyExists = true;
                    loadValuesFromDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Saves the ECU to the database and uploads relevant data to the ECU, then closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to save this data to the ECU?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
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
            int loadedOnRoad = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, false);
            int loadedOffRoad = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, false);
            int notLoaded = ECU_Manager.CheckInt(notLoadedTextbox.Text, false);
            int unloadedOffRoad = ECU_Manager.CheckInt(unloadedOffRoadTextbox.Text, false);
            int maxTraction = ECU_Manager.CheckInt(maxTractionTextbox.Text, false);
            int psiLoadedOnRoad = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, false);
            int psiLoadedOffRoad = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, false);
            int psiNotLoaded = ECU_Manager.CheckInt(notLoadedTextbox.Text, false);
            int psiUnloadedOffRoad = ECU_Manager.CheckInt(unloadedOffRoadTextbox.Text, false);
            int psiMaxTraction = ECU_Manager.CheckInt(maxTractionTextbox.Text, false);
            int stepUpDelay = ECU_Manager.CheckInt(stepUpDelayTextbox.Text, false);
            bool maxTractionBeep = beepCheckBox.Checked;
            bool enableGPSButtons = gpsButtonCheckBox.Checked;
            bool enableGPSOverride = gpsOverrideCheckBox.Checked;
            string output = readWriteHelper.generateOutput(ECU_Manager.connectedBoard, speedControl, loadedOnRoad, loadedOffRoad, 
                notLoaded, unloadedOffRoad, maxTraction, psiLoadedOnRoad, psiLoadedOffRoad, psiNotLoaded, psiUnloadedOffRoad, 
                psiMaxTraction, stepUpDelay, maxTractionBeep, enableGPSButtons, enableGPSOverride);
            try
            {
                SerialManager.WriteLine(output);
                settingsFromECU settings = readWriteHelper.readInput(SerialManager.ReadLine());
                if (/*TODO Board code*/ settings.speedControl.Equals(speedControl) && settings.loadedOnRoad == loadedOnRoad && settings.loadedOffRoad == loadedOffRoad 
                    && settings.notLoaded == notLoaded && settings.maxTraction == maxTraction && settings.psiLoadedOnRoad == psiLoadedOnRoad && settings.psiLoadedOffRoad == psiLoadedOffRoad
                    && settings.psiNotLoaded == psiNotLoaded && settings.psiMaxTraction == psiMaxTraction && settings.stepUpDelay == stepUpDelay 
                    && settings.maxTractionBeep == maxTractionBeep && settings.enableGPSButtons == enableGPSButtons 
                    && settings.enableGPSOverride == enableGPSOverride && settings.unloadedOffRoad == unloadedOffRoad/*TODO PSIS??!!?!??!!?! AND CRC*/)
                {
                    MessageBox.Show("Data successfully written to ECU", "Download Complete");
                }
                else
                {
                    throw new System.IO.IOException("Data mismatch between ECU settings and given values");
                }
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
                "StepUpDelay = @stepUpDelay, EnableGPSButtons = @enableGpsButtons, EnableGPSOverride = @enableGpsOverride, Distance = @distance, UnloadedOffRoad = @unloadedOffRoad " +
                "WHERE BoardCode = @boardCode;";
            string update2 = "UPDATE ecuToCountry SET CountryID = @countryId WHERE BoardCode = @boardCode;"; //Have to update the connections as well
            string update3 = "UPDATE ecuToCustomer SET CustomerID = @customerId WHERE BoardCode = @boardCode;";
            string update4 = "UPDATE ecuToPressureGroup SET PressureGroupID = @pressureGroupId WHERE BoardCode = @boardCode;";
            string update5 = "UPDATE ecuToVersion SET VersionID = @versionId WHERE BoardCode = @boardCode;";
            string update6 = "UPDATE ecuToSpeedControl SET SpeedControlID = @speedControlId WHERE BoardCode = @boardCode;";

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
        /// Saves the ecu settings to the mainSettingsTable
        /// </summary>
        private void saveToDB()
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
        /// Loads values read from the ecu into the relevant controls
        /// </summary>
        private void loadValuesFromECU()
        {
            //TODO test this somehow
            settingsFromECU settings;
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
            string input = SerialManager.ReadLine();
            try
            {
                settings = readWriteHelper.readInput(input);
                SerialManager.WriteLine(readWriteHelper.appendCRC("RCV,")); //Let ecu know that data was received
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
            boardNumberTextbox.Text = settings.boardCode.ToString();
            speedControlComboBox.SelectedValue = speedControlComboBox.FindStringExact(settings.speedControl);
            loadedOnRoadTextbox.Text = settings.loadedOnRoad.ToString();
            loadedOffRoadTextbox.Text = settings.loadedOffRoad.ToString();
            notLoadedTextbox.Text = settings.notLoaded.ToString();
            unloadedOffRoadTextbox.Text = settings.unloadedOffRoad.ToString();
            maxTractionTextbox.Text = settings.maxTraction.ToString();
            stepUpDelayTextbox.Text = settings.stepUpDelay.ToString();
            if (settings.maxTractionBeep.Equals("0"))
            {
                beepCheckBox.Checked = false;
            }
            else
            {
                beepCheckBox.Checked = true;
            }
            if (settings.enableGPSButtons.Equals("0"))
            {
                gpsButtonCheckBox.Checked = false;
            }
            else
            {
                gpsButtonCheckBox.Checked = true;
            }
            if (settings.enableGPSOverride.Equals("0"))
            {
                gpsOverrideCheckBox.Checked = false;
            }
            else
            {
                gpsOverrideCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Load values from the DB if the ecu already exists in the table
        /// </summary>
        private void loadValuesFromDB()
        {
            ECU_MainSettings ecu = ECU_Manager.getECUByBC(ECU_Manager.connectedBoard);
            int pgId = ECU_Manager.EcuToPressureGroup(ECU_Manager.connectedBoard);

            //Sets the text for the boxes to be their equivalents in the selected entry
            boardNumberTextbox.Text = ECU_Manager.connectedBoard.ToString();
            serialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialNumber, false);
            bottomSerialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialCodeBot, true);
            programVersionComboBox.SelectedValue = ECU_Manager.EcuToVersion(ECU_Manager.connectedBoard);
            pressureGroupComboBox.SelectedValue = pgId;
            customerComboBox.SelectedValue = ECU_Manager.EcuToCustomer(ECU_Manager.connectedBoard);
            buildDateTimePicker.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
            installDateTimePicker.Value = DateTime.Now; //current time
            vehicleRefTextbox.Text = ecu.VehicleRef;
            pressureCellTextbox.Text = ECU_Manager.CheckInt(ecu.PressureCell.ToString(), false).ToString();
            pt1SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT1Serial, false);
            pt2SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT2Serial, false);
            pt3SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT3Serial, true);
            pt4SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT4Serial, true);
            pt5SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT5Serial, true);
            pt6SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT6Serial, true);
            pt7SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT7Serial, true);
            pt8SerialTextbox.Text = ECU_Manager.CheckString(ecu.PT8Serial, true);
            descriptionTextbox.Text = ECU_Manager.CheckString(ecu.Description, true);
            notesRichTextbox.Text = ECU_Manager.CheckString(ecu.Notes, true);
            countryComboBox.SelectedValue = ECU_Manager.EcuToCountry(ECU_Manager.connectedBoard);

            //Manual Database Update section
            speedControlComboBox.SelectedValue = ECU_Manager.EcuToSpeedControl(ECU_Manager.connectedBoard);
            loadedOffRoadTextbox.Text = ECU_Manager.CheckString(ecu.LoadedOffRoad.ToString(), false);
            loadedOnRoadTextbox.Text = ECU_Manager.CheckString(ecu.LoadedOnRoad.ToString(), false);
            notLoadedTextbox.Text = ECU_Manager.CheckString(ecu.UnloadedOnRoad.ToString(), false);
            maxTractionTextbox.Text = ECU_Manager.CheckString(ecu.MaxTraction.ToString(), false);
            stepUpDelayTextbox.Text = ECU_Manager.CheckString(ecu.StepUpDelay.ToString(), false);
            beepCheckBox.Checked = ecu.MaxTractionBeep;
            gpsButtonCheckBox.Checked = ecu.EnableGPSButtons;
            gpsOverrideCheckBox.Checked = ecu.EnableGPSOverride;
            distanceTextbox.Text = ECU_Manager.CheckInt(ecu.Distance.ToString(), false).ToString();

            PressureGroupObject pg = ECU_Manager.getPGByID(pgId);
            psiLoadedOnTextbox.Text = ECU_Manager.CheckInt(pg.LoadedOnRoad.ToString(), false).ToString();
            psiLoadedOffTextbox.Text = ECU_Manager.CheckInt(pg.LoadedOffRoad.ToString(), false).ToString();
            psiUnloadedOnTextbox.Text = ECU_Manager.CheckInt(pg.UnloadedOnRoad.ToString(), false).ToString();
            psiUnloadedOffTextbox.Text = ECU_Manager.CheckInt(pg.UnloadedOffRoad.ToString(), false).ToString();
            psiMaxTractionTextbox.Text = ECU_Manager.CheckInt(pg.MaxTraction.ToString(), false).ToString();
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
