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

        private List<Tuple<int, string>> changedBoxes; //List of boxes which have been altered
        private HashSet<int> previouslyVisited;

        public ChangeForm(int boardCode)
        {
            this.boardCode = boardCode;
            changedBoxes = new List<Tuple<int, string>>();
            previouslyVisited = new HashSet<int>();

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
                int i = changedBoxes[j].Item1;
                string s = changedBoxes[j].Item2;

                if (previouslyVisited.Contains(i)) //Checks to make sure it only saves the most recent change to the entry
                {
                    continue;
                }
                previouslyVisited.Add(i);

                if (i == 18) //notes
                {
                    //row.Cells[i].Value = s;
                }
                else if (i == 0 || i == 16) //dates
                {
                    DateTime dt;
                    if (DateTime.TryParse(s, out dt)) {
                        //row.Cells[i].Value = dt.Date;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' should be a date", "Invalid input");
                        return;
                    }
                }
                else if (i == 12 || i == 9 || i == 10 || i == 11) //ints
                {
                    int k;
                    if (Int32.TryParse(s, out k))
                    {
                        //row.Cells[i].Value = k;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' should be an integer", "Invalid input");
                        return;
                    }
                }
                else if (i == 2 || i == 4 || i == 5 || i == 8) //comboboxes
                {
                    //TODO as of now accepts any input under 50 characters. Could be changed to only accept items found in the dropdown list. Depends on spec
                    if (s.Length <= 50)
                    {
                        //row.Cells[i].Value = s;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' is too long", "Invalid input");
                        return;
                    }
                }
                else //strings
                {
                    if (s.Length <= 50)
                    {
                        //row.Cells[i].Value = s;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' is too long", "Invalid input");
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
            changedBoxes.Add(new Tuple<int, string>(1, serialNumberTextbox.Text));
        }

        //Also called when its text is changed
        private void programVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(4, programVersionComboBox.Text));
        }

        //Also called when its text is changed
        private void pressureGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(2, pressureGroupComboBox.Text));
        }

        //Also called when its text is changed
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(5, customerComboBox.Text));
        }

        private void buildDateTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(0, buildDateTextbox.Text));
        }

        private void installDateTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(16, installDateTextbox.Text));
        }

        private void vehicleRefTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(7, vehicleRefTextbox.Text));
        }

        private void pressureCellTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(12, pressureCellTextbox.Text));
        }

        private void pt1SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(13, pt1SerialTextbox.Text));
        }

        private void pt2SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(14, pt2SerialTextbox.Text));
        }

        private void descriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(6, descriptionTextbox.Text));
        }

        private void notesRichTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(18, notesRichTextbox.Text));
        }

        //Also called when its text is changed
        private void speedControlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(8, speedControlComboBox.Text));
        }

        private void loadedOffRoadTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(9, loadedOffRoadTextbox.Text));
        }

        private void notLoadedTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(10, notLoadedTextbox.Text));
        }

        private void maxTractionTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(11, maxTractionTextbox.Text));
        }
    }
}
