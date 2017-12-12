﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            loadValuesFromECU();

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
                MessageBox.Show(ioex.Message, "Invalid Input");
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
            SerialManager.WriteLine(output);
        }

        /// <summary>
        /// Updates the database with new info for an already existing ECU
        /// </summary>
        private void updateDB()
        {
            string update = "UPDATE mainSettingsTable SET ";

            string pressureGroup = ECU_Manager.CheckString(pressureGroupComboBox.Text, false);
            update += "PressureGroup = " + ECU_Manager.enclose(pressureGroup) + ", ";

            string customer = ECU_Manager.CheckString(customerComboBox.Text, false);
            update += "Owner = " + ECU_Manager.enclose(customer) + ", ";

            string country = ECU_Manager.CheckString(countryComboBox.Text, false);
            update += "Country = " + ECU_Manager.enclose(country) + ", ";

            string buildDate = ECU_Manager.CheckDate(buildDateTimePicker.Text, false);
            update += "BuildDate = " + ECU_Manager.enclose(buildDate) + ", ";

            string programVersion = ECU_Manager.CheckString(programVersionComboBox.Text, false);
            update += "Version = " + ECU_Manager.enclose(programVersion) + ", ";

            string description = ECU_Manager.CheckString(descriptionTextbox.Text, true);
            update += "Description = " + ECU_Manager.enclose(description) + ", ";

            string vehicleRef = ECU_Manager.CheckString(vehicleRefTextbox.Text, false);
            update += "VehicleRef = " + ECU_Manager.enclose(vehicleRef) + ", ";

            string speedControl = ECU_Manager.CheckString(speedControlComboBox.Text, true);
            update += "SpeedStages = " + ECU_Manager.enclose(speedControl) + ", ";

            string installDate = ECU_Manager.CheckDateTime(installDateTimePicker.Value.ToString("dd/MM/yyyy HH:mm"), false);
            update += "DateMod = " + ECU_Manager.enclose(installDate) + ", ";

            string notes = ECU_Manager.CheckLongString(notesRichTextbox.Text, true);
            update += "Notes = " + ECU_Manager.enclose(notes) + ", ";

            string serialNumber = ECU_Manager.CheckString(serialNumberTextbox.Text, true);
            update += "SerialNumber = " + ECU_Manager.enclose(serialNumber) + ", ";

            update += "PressureCell = " + ECU_Manager.CheckInt(pressureCellTextbox.Text, true) + ", ";

            string pt1Serial = ECU_Manager.CheckString(pt1SerialTextbox.Text, true);
            update += "PT1Serial = " + ECU_Manager.enclose(pt1Serial) + ", ";

            string pt2Serial = ECU_Manager.CheckString(pt2SerialTextbox.Text, true);
            update += "PT2Serial = " + ECU_Manager.enclose(pt2Serial) + ", ";

            string pt3Serial = ECU_Manager.CheckString(pt3SerialTextbox.Text, true);
            update += "PT3Serial = " + ECU_Manager.enclose(pt3Serial) + ", ";

            string pt4Serial = ECU_Manager.CheckString(pt4SerialTextbox.Text, true);
            update += "PT4Serial = " + ECU_Manager.enclose(pt4Serial) + ", ";

            string pt5Serial = ECU_Manager.CheckString(pt5SerialTextbox.Text, true);
            update += "PT5Serial = " + ECU_Manager.enclose(pt5Serial) + ", ";

            string pt6Serial = ECU_Manager.CheckString(pt6SerialTextbox.Text, true);
            update += "PT6Serial = " + ECU_Manager.enclose(pt6Serial) + ", ";

            string pt7Serial = ECU_Manager.CheckString(pt7SerialTextbox.Text, true);
            update += "PT7Serial = " + ECU_Manager.enclose(pt7Serial) + ", ";

            string pt8Serial = ECU_Manager.CheckString(pt8SerialTextbox.Text, true);
            update += "PT8Serial = " + ECU_Manager.enclose(pt8Serial) + ", ";

            update += "LoadedOffRoad = " + ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, true) + ", ";

            update += "LoadedOnRoad = " + ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, true) + ", ";

            update += "UnloadedOnRoad = " + ECU_Manager.CheckInt(notLoadedTextbox.Text, true) + ", ";

            update += "MaxTraction = " + ECU_Manager.CheckInt(maxTractionTextbox.Text, true) + ", ";

            string bottomSerialNumber = ECU_Manager.CheckString(bottomSerialNumberTextbox.Text, true);
            update += "SerialCodeBot = " + ECU_Manager.enclose(bottomSerialNumber) + ", ";

            update += "MaxTractionBeep = " + ECU_Manager.CheckBit(beepCheckBox.Checked) + ", ";

            update += "StepUpDelay = " + ECU_Manager.CheckInt(stepUpDelayTextbox.Text, true) + ", ";

            update += "EnableGPSButtons = " + ECU_Manager.CheckBit(gpsButtonCheckBox.Checked) + ", ";

            update += "EnableGPSOverride = " + ECU_Manager.CheckBit(gpsOverrideCheckBox.Checked) + ", ";

            update += "Distance = " + ECU_Manager.CheckInt(distanceTextbox.Text, true);

            update += " WHERE BoardCode = " + ECU_Manager.connectedBoard;

            ECU_Manager.update(update); //ECU manager handles sql execution
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
            SerialManager.WriteLine(readWriteHelper.appendCRC("GET,"));
            //TODO code below is correct but ECU does not respond yet
            /*string input = SerialManager.ReadLine();
            settingsFromECU settings = readWriteHelper.readInput(input);
            ECU_Manager.connectedBoard = settings.boardCode;*/
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

        }
    }
}
