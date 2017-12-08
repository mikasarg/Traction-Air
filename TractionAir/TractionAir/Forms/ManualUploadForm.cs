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
    public partial class ManualUploadForm : Form
    {
        private int boardCode;
        private string connectionString;

        public ManualUploadForm()
        {
            this.connectionString = ECU_Manager.connection("ecuSettingsDB_CS");

            InitializeComponent();
            buildDateTimePicker.Value = DateTime.Now; //Set the datetimepickers to have a default value of the current time
            installDateTimePicker.Value = DateTime.Now;
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
        }

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                boardCode = ECU_Manager.CheckInt(boardNumberTextbox.Text, false);
                ECU_Manager.CheckForDuplicates(boardCode.ToString(), "BoardCode", "mainSettingsTable", -1);
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid input");
                return;
            }

            string insert = "INSERT INTO mainSettingsTable VALUES(";

            try
            {
                //IMPORTANT: This order must be exact. Code is messy and long, but couldn't think of a more efficient way to do it.
                //Makes liberal use of the helper methods in ECU_Manager.cs
                //A loop with the values in a list is not feasible as each textbox/combobox etc requires different parsing
                //Creating if statements to detect the intended type of each string is possible, but seemed unwieldy - and even then,
                //some values need to be allowed to be null, and some must not be null. 
                //This seemed cleaner than lines and lines of if statements
                insert += boardCode + ", ";

                string pressureGroup = ECU_Manager.CheckString(pressureGroupComboBox.Text, false);
                insert += ECU_Manager.enclose(pressureGroup) + ", ";

                string customer = ECU_Manager.CheckString(customerComboBox.Text, false);
                insert += ECU_Manager.enclose(customer) + ", ";

                string country = ECU_Manager.CheckString(countryComboBox.Text, false);
                insert += ECU_Manager.enclose(country) + ", ";

                string buildDate = ECU_Manager.CheckDate(buildDateTimePicker.Text, false);
                insert += ECU_Manager.enclose(buildDate) + ", ";

                string programVersion = ECU_Manager.CheckString(programVersionComboBox.Text, false);
                insert += ECU_Manager.enclose(programVersion) + ", ";

                string description = ECU_Manager.CheckString(descriptionTextbox.Text, true);
                insert += ECU_Manager.enclose(description) + ", ";

                string vehicleRef = ECU_Manager.CheckString(vehicleRefTextbox.Text, false);
                insert += ECU_Manager.enclose(vehicleRef) + ", ";

                string speedControl = ECU_Manager.CheckString(speedControlComboBox.Text, true);
                insert += ECU_Manager.enclose(speedControl) + ", ";

                string installDate = ECU_Manager.CheckDateTime(installDateTimePicker.Value.ToString("dd/MM/yyyy HH:mm"), false);
                insert += ECU_Manager.enclose(installDate) + ", ";

                string notes = ECU_Manager.CheckLongString(notesRichTextbox.Text, true);
                insert += ECU_Manager.enclose(notes) + ", ";

                string serialNumber = ECU_Manager.CheckString(serialNumberTextbox.Text, true);
                insert += ECU_Manager.enclose(serialNumber) + ", ";

                insert += ECU_Manager.CheckInt(pressureCellTextbox.Text, true) + ", ";

                string pt1Serial = ECU_Manager.CheckString(pt1SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt1Serial) + ", ";

                string pt2Serial = ECU_Manager.CheckString(pt2SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt2Serial) + ", ";

                string pt3Serial = ECU_Manager.CheckString(pt3SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt3Serial) + ", ";

                string pt4Serial = ECU_Manager.CheckString(pt4SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt4Serial) + ", ";

                string pt5Serial = ECU_Manager.CheckString(pt5SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt5Serial) + ", ";

                string pt6Serial = ECU_Manager.CheckString(pt6SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt6Serial) + ", ";

                string pt7Serial = ECU_Manager.CheckString(pt7SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt7Serial) + ", ";

                string pt8Serial = ECU_Manager.CheckString(pt8SerialTextbox.Text, true);
                insert += ECU_Manager.enclose(pt8Serial) + ", ";

                insert += ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, true) + ", ";

                insert += ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, true) + ", ";

                insert += ECU_Manager.CheckInt(notLoadedTextbox.Text, true) + ", ";

                insert += ECU_Manager.CheckInt(maxTractionTextbox.Text, true) + ", ";

                string bottomSerialNumber = ECU_Manager.CheckString(bottomSerialNumberTextbox.Text, true);
                insert += ECU_Manager.enclose(bottomSerialNumber) + ", ";

                insert += ECU_Manager.CheckBit(beepCheckBox.Checked) + ", ";

                insert += ECU_Manager.CheckInt(stepUpDelayTextbox.Text, true) + ", ";

                insert += ECU_Manager.CheckBit(gpsButtonCheckBox.Checked) + ", ";

                insert += ECU_Manager.CheckBit(gpsOverrideCheckBox.Checked) + ", ";

                insert += ECU_Manager.CheckInt(distanceTextbox.Text, true) + ");";
            }
            catch(InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }

            ECU_Manager.Insert(insert); //this methiod handles the errors
            
            this.Close();
        }

        /// <summary>
        /// Closes the window and does not save the changes the user made to the entry
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
    }
}
