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
                serialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialNumber, false);
                bottomSerialNumberTextbox.Text = ECU_Manager.CheckString(ecu.SerialCodeBot, true);
                boardVersionComboBox.SelectedValue = ECU_Manager.EcuToBoardVersion(boardCode);
                programVersionComboBox.SelectedValue = ECU_Manager.EcuToVersion(boardCode);
                pressureGroupComboBox.SelectedValue = pgId;
                customerComboBox.SelectedValue = ECU_Manager.EcuToCustomer(boardCode);
                buildDateTimePicker.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
                installDateTimePicker.Text = (ecu.DateMod).ToString("dd/MM/yyyy HH:mm");
                vehicleRefTextbox.Text = ECU_Manager.CheckString(ecu.VehicleRef, true);
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
                countryComboBox.SelectedValue = ECU_Manager.EcuToCountry(boardCode);

                //Manual Database Update section
                speedControlComboBox.SelectedValue = ECU_Manager.EcuToSpeedControl(boardCode);
                loadedOffRoadTextbox.Text = ECU_Manager.CheckString(ecu.LoadedOffRoad.ToString(), false);
                notLoadedTextbox.Text = ECU_Manager.CheckString(ecu.UnloadedOnRoad.ToString(), false);
                unloadedOffRoadTextbox.Text = ECU_Manager.CheckString(ecu.UnloadedOffRoad.ToString(), false);
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
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show("An error occurred when trying to load the selected entry: " + ioex.Message, "Error");
            }
        }

    }
}
