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
            String query = "SELECT * FROM mainSettingsTable WHERE \"BoardCode\" = '" + boardCode + "'";
            String extraQuery = "SELECT * FROM extraSettingsTable WHERE \"BoardCode\" = '" + boardCode + "'";

            ECU_MainSettings ecuMain;
            ECU_ExtraSettings ecuExtra;

            using (IDbConnection iDbCon = new SqlConnection(connectionString))
            {
                ECU_MainSettings[] ecusMain = iDbCon.Query<ECU_MainSettings>(query).ToArray();
                ecuMain = ecusMain[0];

                ECU_ExtraSettings[] ecusExtra = iDbCon.Query<ECU_ExtraSettings>(extraQuery).ToArray();
                ecuExtra = ecusExtra[0];
            }


            //Sets the text for the boxes to be their equivalents in the selected entry
            boardNumberTextbox.Text = boardCode.ToString();
            serialNumberTextbox.Text = ecuExtra.SerialNumber;
            programVersionComboBox.SelectedIndex = programVersionComboBox.FindStringExact(ecuMain.Version);
            pressureGroupComboBox.SelectedIndex = pressureGroupComboBox.FindStringExact(ecuMain.PressureGroup);
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(ecuMain.Owner);
            buildDateTextbox.Text = (ecuMain.BuildDate).ToString("dd/MM/yyyy");
            installDateTextbox.Text = (ecuMain.DateMod).ToString();
            vehicleRefTextbox.Text = ecuMain.VehicleRef;
            pressureCellTextbox.Text = ecuExtra.pressureCell.ToString();
            pt1SerialTextbox.Text = ecuExtra.PT1Serial.ToString();
            pt2SerialTextbox.Text = ecuExtra.PT2Serial.ToString();
            descriptionTextbox.Text = ecuMain.Description;
            notesRichTextbox.Text = ecuMain.Notes;

            speedControlComboBox.SelectedIndex = speedControlComboBox.FindStringExact(ecuMain.SpeedStages);
            loadedOffRoadTextbox.Text = ecuExtra.LoadedOffRoad.ToString();
            notLoadedTextbox.Text = ecuExtra.UnloadedOnRoad.ToString();
            maxTractionTextbox.Text = ecuExtra.MaxTraction.ToString();

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

                }
                else if (s1.Equals("BuildDate") || s1.Equals("DateMod")) //dates
                {
                    DateTime dt;
                    if (DateTime.TryParse(s2, out dt)) {
                        //row.Cells[i].Value = dt.Date;
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' should be a date", "Invalid input");
                        return;
                    }
                }
                else if (s1.Equals("PressureCell") || s1.Equals("LoadedOffRoad") || s1.Equals("UnloadedOnRoad") || s1.Equals("MaxTraction")) //ints
                {
                    int k;
                    if (Int32.TryParse(s2, out k))
                    {
                        //row.Cells[i].Value = k;
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
                        //row.Cells[i].Value = s;
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' is too long", "Invalid input");
                        return;
                    }
                }
                else //strings
                {
                    if (s2.Length <= 50)
                    {
                        //row.Cells[i].Value = s;
                    }
                    else
                    {
                        MessageBox.Show("'" + s2 + "' is too long", "Invalid input");
                        return;
                    }
                }

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
    }
}
