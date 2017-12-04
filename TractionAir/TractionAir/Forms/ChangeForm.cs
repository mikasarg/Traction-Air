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

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO save the changes made to the actual database

            if (changedBoxes.Count == 0) //No changes were made, so exit
            {
                this.Close();
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

        private void serialNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("SerialNumber", serialNumberTextbox.Text));
        }

        //Also called when its text is changed
        private void programVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Version", programVersionComboBox.Text));
        }

        //Also called when its text is changed
        private void pressureGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("PressureGroup", pressureGroupComboBox.Text));
        }

        //Also called when its text is changed
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

        private void descriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Description", descriptionTextbox.Text));
        }

        private void notesRichTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("Notes", notesRichTextbox.Text));
        }

        //Also called when its text is changed
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
    }
}
