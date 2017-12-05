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
        private string connectionString;
        private SqlConnection connection;

        private List<Tuple<string, string>> changedBoxes; //List of boxes which have been altered
        private HashSet<string> previouslyVisited;

        public ViewForm(int boardCode)
        {
            this.boardCode = boardCode;
            changedBoxes = new List<Tuple<string, string>>();
            previouslyVisited = new HashSet<string>();

            this.connectionString = ECU_Manager.connection("ecuSettingsDB_CS");

            InitializeComponent();
        }
        /// <summary>
        /// Loads the databases and fills the boxes with their respective values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.programVersionTable' table. You can move, or remove it, as needed.
            this.programVersionTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.programVersionTable);
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.countryCodeTable' table. You can move, or remove it, as needed.
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            this.mainSettingsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.mainSettingsTable);
            String query = "SELECT * FROM mainSettingsTable WHERE BoardCode = '" + boardCode + "'";

            ECU_MainSettings ecu;

            using (IDbConnection iDbCon = new SqlConnection(connectionString))
            {
                ECU_MainSettings[] ecus = iDbCon.Query<ECU_MainSettings>(query).ToArray();
                ecu = ecus[0];
            }

            try
            {
                //Sets the text for the boxes to be their equivalents in the selected entry
                boardNumberTextbox.Text = boardCode.ToString();
                serialNumberTextbox.Text = ECU_Manager.stringNullCheck(ecu.SerialNumber);
                bottomSerialNumberTextbox.Text = ECU_Manager.stringNullCheck(ecu.SerialCodeBot);
                programVersionComboBox.SelectedIndex = programVersionComboBox.FindStringExact(ecu.Version);
                pressureGroupComboBox.SelectedIndex = pressureGroupComboBox.FindStringExact(ecu.PressureGroup);
                customerComboBox.SelectedIndex = customerComboBox.FindStringExact(ecu.Owner);
                buildDateTextbox.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
                installDateTextbox.Text = (ecu.DateMod).ToString();
                vehicleRefTextbox.Text = ecu.VehicleRef;
                pressureCellTextbox.Text = ECU_Manager.stringNullCheck(ecu.PressureCell);
                pt1SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT1Serial);
                pt2SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT2Serial);
                pt3SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT3Serial);
                pt4SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT4Serial);
                pt5SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT5Serial);
                pt6SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT6Serial);
                pt7SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT7Serial);
                pt8SerialTextbox.Text = ECU_Manager.stringNullCheck(ecu.PT8Serial);
                descriptionTextbox.Text = ECU_Manager.stringNullCheck(ecu.Description);
                notesRichTextbox.Text = ECU_Manager.stringNullCheck(ecu.Notes);
                countryComboBox.SelectedIndex = countryComboBox.FindStringExact(ecu.Country);

                //Manual Database Update section
                speedControlComboBox.SelectedIndex = speedControlComboBox.FindStringExact(ecu.SpeedStages);
                loadedOffRoadTextbox.Text = ECU_Manager.stringNullCheck(ecu.LoadedOffRoad);
                loadedOnRoadTextbox.Text = ECU_Manager.stringNullCheck(ecu.LoadedOnRoad);
                notLoadedTextbox.Text = ECU_Manager.stringNullCheck(ecu.UnloadedOnRoad);
                maxTractionTextbox.Text = ECU_Manager.stringNullCheck(ecu.MaxTraction);
                stepUpDelayTextbox.Text = ECU_Manager.stringNullCheck(ecu.StepUpDelay);
                beepCheckBox.Checked = ecu.MaxTractionBeep;
                gpsButtonCheckBox.Checked = ecu.EnableGPSButtons;
                gpsOverrideCheckBox.Checked = ecu.EnableGPSOverride;
            }
            catch (NullReferenceException nrex)
            {
                MessageBox.Show("An error occurred when trying to load the selected entry: " + nrex.Message, "Error");
            }

            changedBoxes.Clear();
        }
    }
}
