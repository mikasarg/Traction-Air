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
        /// Loads data from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeForm_Load(object sender, EventArgs e)
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
                countryComboBox.SelectedValue = ECU_Manager.getChildIdByParentId(boardCode, "ecuToCountry");

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
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show("An error occurred when trying to load the selected entry: " + ioex.Message, "Error");
            }
            changedBoxes.Clear();
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

            installDateTimePicker.Value = DateTime.Now; //current time
            save();
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

        /// <summary>
        /// Creates the SQL command for the update
        /// This class was one I made very early on and as such it has a lot of unnecessary functionality,
        /// such as knowing which boxes have been altered and recording all changes made. I've kept it in as
        /// it works, and as such there's no reason to forcibly simplify it which would be time consuming
        /// </summary>
        private void save()
        {
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

                try
                {
                    if (s1.Equals("Notes")) //notes
                    {
                        s2 = ECU_Manager.CheckLongString(s2, true);
                        update += s1 + " = " + ECU_Manager.enclose(s2);
                    }
                    else if (s1.Equals("BuildDate")) //date
                    {
                        s2 = ECU_Manager.CheckDate(s2, false);
                        update += s1 + " = " + ECU_Manager.enclose(s2);
                    }
                    else if (s1.Equals("DateMod")) //dateTime
                    {
                        s2 = ECU_Manager.CheckDateTime(s2, false);
                        update += s1 + " = " + ECU_Manager.enclose(s2);
                    }
                    else if (s1.Equals("PressureCell") || s1.Equals("LoadedOffRoad") || s1.Equals("UnloadedOnRoad") || s1.Equals("MaxTraction") || s1.Equals("LoadedOnRoad") || s1.Equals("StepUpDelay")) //ints
                    {
                        int i = ECU_Manager.CheckInt(s2, true);
                        update += s1 + " = " + i;
                    }
                    else if (s1.Equals("Version") || s1.Equals("PressureGroup") || s1.Equals("SpeedStages") || s1.Equals("Owner") || s1.Equals("Country")) //comboboxes
                    {
                        update += s1 + " = " + ECU_Manager.enclose(s2);
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
                    else if (s1.Equals("VehicleRef")) //strings that cannot be null
                    {
                        s2 = ECU_Manager.CheckString(s2, false);
                        update += s1 + " = " + ECU_Manager.enclose(s2);
                    }
                    else //strings that can be null
                    {
                        s2 = ECU_Manager.CheckString(s2, true);
                        update += s1 + " = " + ECU_Manager.enclose(s2);
                    }
                }
                catch (InvalidOperationException ioex)
                {
                    MessageBox.Show(ioex.Message, "Error");
                }

                update += ", ";
            }

            update = update.Substring(0, update.Length - 2); //remove final ", "
            update += " WHERE BoardCode = '" + boardCode + "'";

            ECU_Manager.update(update); //ECU manager handles sql execution

            this.Close();
        }

        //All methods below add tuples to the list when a textbox is altered, with the relevant column name and the altered text.
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

        private void buildDateTimePicker_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("BuildDate", buildDateTimePicker.Text));
        }

        private void installDateTimePicker_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<string, string>("DateMod", installDateTimePicker.Value.ToString("dd/MM/yyyy HH:mm")));
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
