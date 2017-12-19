using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;

namespace TractionAir
{
    public partial class ViewForm : Form
    {
        private int boardCode;

        public ViewForm(int boardCode)
        {
            this.boardCode = boardCode;

            InitializeComponent();
        }
        /// <summary>
        /// Loads the databases and fills the boxes with their respective values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewForm_Load(object sender, EventArgs e)
        {
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

                //Sets the text for the boxes to be their equivalents in the selected entry
                boardNumberTextbox.Text = boardCode.ToString();
                serialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialNumber, true);
                bottomSerialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialCodeBot, true);
                programVersionComboBox.SelectedValue = ECU_Manager.EcuToVersion(boardCode);
                pressureGroupComboBox.SelectedValue = ECU_Manager.EcuToPressureGroup(boardCode);
                customerComboBox.SelectedValue = ECU_Manager.EcuToCustomer(boardCode);
                buildDateTimePicker.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
                installDateTimePicker.Value = DateTime.Now; //current time
                vehicleRefTextbox.Text = ECU_Manager.CheckString(ecu.VehicleRef, false);
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
                countryComboBox.SelectedValue = ECU_Manager.EcuToCountry(boardCode);

                //Manual Database Update section
                speedControlComboBox.SelectedValue = ECU_Manager.EcuToSpeedControl(boardCode);
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
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show("An error occurred when trying to load the selected entry: " + ioex.Message, "Error");
            }
        }

    }
}
