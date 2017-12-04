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


            //Sets the text for the boxes to be their equivalents in the selected entry
            boardNumberTextbox.Text = boardCode.ToString();
            serialNumberTextbox.Text = ecu.SerialNumber;
            bottomSerialNumberTextbox.Text = ecu.SerialCodeBot;
            programVersionComboBox.SelectedIndex = programVersionComboBox.FindStringExact(ecu.Version);
            pressureGroupComboBox.SelectedIndex = pressureGroupComboBox.FindStringExact(ecu.PressureGroup);
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(ecu.Owner);
            buildDateTextbox.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
            installDateTextbox.Text = (ecu.DateMod).ToString();
            vehicleRefTextbox.Text = ecu.VehicleRef;
            pressureCellTextbox.Text = ecu.pressureCell.ToString();
            pt1SerialTextbox.Text = ecu.PT1Serial.ToString();
            pt2SerialTextbox.Text = ecu.PT2Serial.ToString();
            descriptionTextbox.Text = ecu.Description;
            notesRichTextbox.Text = ecu.Notes;

            //Manual Database Update section
            speedControlComboBox.SelectedIndex = speedControlComboBox.FindStringExact(ecu.SpeedStages);
            loadedOffRoadTextbox.Text = ecu.LoadedOffRoad.ToString();
            loadedOnRoadTextbox.Text = ecu.LoadedOnRoad.ToString();
            notLoadedTextbox.Text = ecu.UnloadedOnRoad.ToString();
            maxTractionTextbox.Text = ecu.MaxTraction.ToString();
            stepUpDelayTextbox.Text = ecu.StepUpDelay.ToString();
            beepCheckBox.Checked = ecu.MaxTractionBeep;
            gpsButtonCheckBox.Checked = ecu.EnableGPSButtons;
            gpsOverrideCheckBox.Checked = ecu.EnableGPSOverride;

            changedBoxes.Clear();
        }
    }
}
