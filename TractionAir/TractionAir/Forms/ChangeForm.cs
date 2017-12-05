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
        private string connectionString;
        private SqlConnection connection;

        private List<Tuple<string, string>> changedBoxes; //List of boxes which have been altered
        private HashSet<string> previouslyVisited;

        public ChangeForm(int boardCode)
        {
            this.boardCode = boardCode;
            changedBoxes = new List<Tuple<string, string>>();
            previouslyVisited = new HashSet<string>();

            this.connectionString = ECU_Manager.connection("ecuSettingsDB_CS");

            InitializeComponent();
        }

        /// <summary>
        /// Loads data from the database and assigns values for the boxes in the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.programVersionTable' table. You can move, or remove it, as needed.
            this.programVersionTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.programVersionTable);
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.countryCodeTable' table. You can move, or remove it, as needed.
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.customerTable' table. You can move, or remove it, as needed.
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.pressureGroupsTable' table. You can move, or remove it, as needed.
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.mainSettingsTable' table. You can move, or remove it, as needed.
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
            serialNumberTextbox.Text = stringNullCheck(ecu.SerialNumber);
            bottomSerialNumberTextbox.Text = stringNullCheck(ecu.SerialCodeBot);
            programVersionComboBox.SelectedIndex = programVersionComboBox.FindStringExact(ecu.Version);
            pressureGroupComboBox.SelectedIndex = pressureGroupComboBox.FindStringExact(ecu.PressureGroup);
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(ecu.Owner);
            buildDateTextbox.Text = (ecu.BuildDate).ToString("dd/MM/yyyy");
            installDateTextbox.Text = (ecu.DateMod).ToString();
            vehicleRefTextbox.Text = ecu.VehicleRef;
            pressureCellTextbox.Text = stringNullCheck(ecu.PressureCell);
            pt1SerialTextbox.Text = stringNullCheck(ecu.PT1Serial);
            pt2SerialTextbox.Text = stringNullCheck(ecu.PT2Serial);
            pt3SerialTextbox.Text = stringNullCheck(ecu.PT3Serial);
            pt4SerialTextbox.Text = stringNullCheck(ecu.PT4Serial);
            pt5SerialTextbox.Text = stringNullCheck(ecu.PT5Serial);
            pt6SerialTextbox.Text = stringNullCheck(ecu.PT6Serial);
            pt7SerialTextbox.Text = stringNullCheck(ecu.PT7Serial);
            pt8SerialTextbox.Text = stringNullCheck(ecu.PT8Serial);
            descriptionTextbox.Text = stringNullCheck(ecu.Description);
            notesRichTextbox.Text = stringNullCheck(ecu.Notes);
            countryComboBox.SelectedIndex = countryComboBox.FindStringExact(ecu.Country);

            //Manual Database Update section
            speedControlComboBox.SelectedIndex = speedControlComboBox.FindStringExact(ecu.SpeedStages);
            loadedOffRoadTextbox.Text = stringNullCheck(ecu.LoadedOffRoad);
            loadedOnRoadTextbox.Text = stringNullCheck(ecu.LoadedOnRoad);
            notLoadedTextbox.Text = stringNullCheck(ecu.UnloadedOnRoad);
            maxTractionTextbox.Text = stringNullCheck(ecu.MaxTraction);
            stepUpDelayTextbox.Text = stringNullCheck(ecu.StepUpDelay);
            beepCheckBox.Checked = ecu.MaxTractionBeep;
            gpsButtonCheckBox.Checked = ecu.EnableGPSButtons;
            gpsOverrideCheckBox.Checked = ecu.EnableGPSOverride;

            changedBoxes.Clear();
        }

        /// <summary>
        /// Returns a string version of the object and makes it "" instead of null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string stringNullCheck(object s)
        {
            if (s == null)
            {
                return "";
            }
            return s.ToString();
        }

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (changedBoxes.Count == 0) //No changes were made, so exit
            {
                this.Close();
                return;
            }

            previouslyVisited.Clear();

            string update = "UPDATE mainSettingsTable SET ";

            for (int j = changedBoxes.Count - 1; j >= 0; j--) //Decrements through the list to obtain the most recent changes first
            {
                string s1 = changedBoxes[j].Item1;
                string s2 = changedBoxes[j].Item2;

                if (previouslyVisited.Contains(s1)) //Checks to make sure it only saves the most recent change to the entry
                {
                    continue;
                }
                previouslyVisited.Add(s1);

                if (s1.Equals("Notes")) //notes
                {
                    update += s1 + " = '" + s2 + "'";
                }
                else if (s1.Equals("BuildDate") || s1.Equals("DateMod")) //dates
                {
                    DateTime dt;
                    if (DateTime.TryParse(s2, out dt)) {
                        update +=  s1 + " = '" + dt.Date + "'";
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' should be a date", "Invalid input");
                        return;
                    }
                }
                else if (s1.Equals("PressureCell") || s1.Equals("LoadedOffRoad") || s1.Equals("UnloadedOnRoad") || s1.Equals("MaxTraction") || s1.Equals("LoadedOnRoad") || s1.Equals("StepUpDelay")) //ints
                {
                    int k;
                    if (Int32.TryParse(s2, out k))
                    {
                        update += s1 + " = " + k;
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' should be an integer", "Invalid input");
                        return;
                    }
                }
                else if (s1.Equals("Version") || s1.Equals("PressureGroup") || s1.Equals("SpeedStages") || s1.Equals("Owner")) //comboboxes
                {
                    //TODO as of now accepts any input under 50 characters. Could be changed to only accept items found in the dropdown list. Depends on spec
                    if (s2.Length <= 50)
                    {
                        update += s1 + " = '" + s2 + "'";
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' is too long", "Invalid input");
                        return;
                    }
                }
                else if (s1.Equals("MaxTractionBeep") || s1.Equals("EnableGPSButtons") || s1.Equals("EnableGPSOverride")) //checkboxes
                {
                    if (s2.Equals("True"))
                    {
                        update += s1 + " = " + 1;
                    }
                    else //false
                    {
                        update += s1 + " = " + 0;
                    }
                }
                else //strings
                {
                    if (s2.Length <= 50)
                    {
                        update += s1 + " = '" + s2 + "'";
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' is too long", "Invalid input");
                        return;
                    }
                }

                update += ", ";
            }

            update = update.Substring(0, update.Length - 2); //remove final ", "
            update += " WHERE boardCode = '" + boardCode + "'";

            using (IDbConnection iDbCon = new SqlConnection(connectionString))
            {
                iDbCon.Execute(update);
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
            if (changedBoxes.Count > 0) { //Changes have been made
                DialogResult dialogResult = MessageBox.Show("You have made changes that will not be saved if you cancel. Cancel without saving?", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        //All methods below add tuples to the list when a textbox is altered, with the relevant column number and the altered text.
        #region eventListeners
        private void serialNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("SerialNumber", serialNumberTextbox.Text));
        }

        private void programVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Version", programVersionComboBox.Text));
        }

        private void pressureGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PressureGroup", pressureGroupComboBox.Text));
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Owner", customerComboBox.Text));
        }

        private void buildDateTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("BuildDate", buildDateTextbox.Text));
        }

        private void installDateTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("DateMod", installDateTextbox.Text));
        }

        private void vehicleRefTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("VehicleRef", vehicleRefTextbox.Text));
        }

        private void pressureCellTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PressureCell", pressureCellTextbox.Text));
        }

        private void pt1SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT1Serial", pt1SerialTextbox.Text));
        }

        private void pt2SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT2Serial", pt2SerialTextbox.Text));
        }

        private void pt3SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT3Serial", pt3SerialTextbox.Text));
        }

        private void pt4SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT4Serial", pt4SerialTextbox.Text));
        }

        private void pt5SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT5Serial", pt5SerialTextbox.Text));
        }

        private void pt6SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT6Serial", pt6SerialTextbox.Text));
        }

        private void pt7SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT7Serial", pt7SerialTextbox.Text));
        }

        private void pt8SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PT8Serial", pt8SerialTextbox.Text));
        }

        private void descriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Description", descriptionTextbox.Text));
        }

        private void notesRichTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Notes", notesRichTextbox.Text));
        }

        private void speedControlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("SpeedStages", speedControlComboBox.Text));
        }

        private void loadedOffRoadTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("LoadedOffRoad", loadedOffRoadTextbox.Text));
        }

        private void notLoadedTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("UnloadedOnRoad", notLoadedTextbox.Text));
        }

        private void maxTractionTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("MaxTraction", maxTractionTextbox.Text));
        }

        private void loadedOnRoadTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("LoadedOnRoad", loadedOnRoadTextbox.Text));
        }

        private void bottomSerialNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("SerialCodeBot", bottomSerialNumberTextbox.Text));
        }

        private void stepUpDelayTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("StepUpDelay", stepUpDelayTextbox.Text));
        }

        private void beepCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("MaxTractionBeep", beepCheckBox.Checked.ToString()));
        }

        private void gpsButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("EnableGPSButtons", gpsButtonCheckBox.Checked.ToString()));
        }

        private void gpsOverrideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("EnableGPSOverride", gpsOverrideCheckBox.Checked.ToString()));
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Country", countryComboBox.Text));
        }
        #endregion
    }
}
