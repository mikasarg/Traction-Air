using System;
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
        public ecuConnectedForm()
        {
            InitializeComponent();
            //TODO contact the ecu and ask it for values? or do that somewhere else?
            SerialManager.WriteLine(readWriteHelper.appendCRC("GET,"));
            loadValues();
        }

        /// <summary>
        /// Saves the ECU to the database and uploads relevant data to the ECU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveECU();


            //SerialManager.WriteLine("setData");
            //SerialManager.WriteLine(input); TODO don't want to output anything yet
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
            //TODO save to mainSettingsTable

            int boardCode = ECU_Manager.CheckInt(boardNumberTextbox.Text, false);
            string topSerial = ECU_Manager.CheckString(serialNumberTextbox.Text, false); //TODO are these ok to be null?
            string botSerial = ECU_Manager.CheckString(bottomSerialNumberTextbox.Text, false);
            string speedControl = speedControlComboBox.Text;
            int notLoaded = ECU_Manager.CheckInt(notLoadedTextbox.Text, false);
            int loadedOnRoad = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, false);
            int loadedOffRoad = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, false);
            int maxTraction = ECU_Manager.CheckInt(maxTractionTextbox.Text, false);
            int stepUpDelay = ECU_Manager.CheckInt(stepUpDelayTextbox.Text, false);
            bool maxTractionBeep = beepCheckBox.Checked;
            bool enableGPSButtons = gpsButtonCheckBox.Checked;
            bool enableGPSOverride = gpsOverrideCheckBox.Checked;

            string output = readWriteHelper.generateOutput(boardCode, topSerial, botSerial, speedControl, notLoaded, loadedOnRoad, loadedOffRoad, maxTraction, stepUpDelay, maxTractionBeep, enableGPSButtons, enableGPSOverride);
            SerialManager.WriteLine(output);
        }

        /// <summary>
        /// Loads values read from the ecu into the relevant controls
        /// </summary>
        private void loadValues()
        {
            //TODO read data from ecu and put values in controls
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
