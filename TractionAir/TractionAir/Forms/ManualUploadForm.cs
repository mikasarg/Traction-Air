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
        private SqlConnection connection;

        public ManualUploadForm()
        {
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
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.speedControlTable' table. You can move, or remove it, as needed.
            this.speedControlTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.speedControlTable);
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
        }

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            int bc;
            if (Int32.TryParse(boardNumberTextbox.Text, out bc))
            {
                boardCode = bc;
            }
            else
            {
                MessageBox.Show("Board Code " + boardNumberTextbox.Text + " is invalid", "Invalid input");
                return;
            }
            String query = "SELECT * FROM mainSettingsTable WHERE BoardCode = '" + boardCode + "'";

            ECU_MainSettings ecu;

            using (IDbConnection iDbCon = new SqlConnection(connectionString))
            {
                if (iDbCon.Query<ECU_MainSettings>(query).ToArray().Length != 0)
                {
                    MessageBox.Show("Board with code '" + bc + "' already exists", "Invalid input");
                    return;
                }
            }

            string insert = "INSERT INTO mainSettingsTable VALUES(";

            try
            {
                insert += boardCode + ", ";

                insert += checkValidString(pressureGroupComboBox.Text, false) + ", ";

                insert += checkValidString(customerComboBox.Text, false) + ", ";

                insert += checkValidString(countryComboBox.Text, false) + ", ";

                insert += checkValidDate(buildDateTextbox.Text, false) + ", ";

                insert += checkValidString(programVersionComboBox.Text, false) + ", ";

                insert += checkValidString(descriptionTextbox.Text, true) + ", ";

                insert += checkValidString(vehicleRefTextbox.Text, false) + ", ";

                insert += checkValidString(speedControlComboBox.Text, true) + ", ";

                insert += checkValidDateTime(installDateTextbox.Text, false) + ", ";

                insert += checkValidString(notesRichTextbox.Text, true) + ", ";

                insert += checkValidString(serialNumberTextbox.Text, true) + ", ";

                insert += checkValidInt(pressureCellTextbox.Text, true) + ", ";

                insert += checkValidString(pt1SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt2SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt3SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt4SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt5SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt6SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt7SerialTextbox.Text, true) + ", ";

                insert += checkValidString(pt8SerialTextbox.Text, true) + ", ";

                insert += checkValidInt(loadedOffRoadTextbox.Text, true) + ", ";

                insert += checkValidInt(loadedOnRoadTextbox.Text, true) + ", ";

                insert += checkValidInt(notLoadedTextbox.Text, true) + ", ";

                insert += checkValidInt(maxTractionTextbox.Text, true) + ", ";

                insert += checkValidString(bottomSerialNumberTextbox.Text, true) + ", ";

                insert += checkValidBit(beepCheckBox.Text, true) + ", ";

                insert += checkValidInt(stepUpDelayTextbox.Text, true) + ", ";

                insert += checkValidBit(gpsButtonCheckBox.Text, true) + ", ";

                insert += checkValidBit(gpsOverrideCheckBox.Text, true) + ");"; //TODO TESTING
            }
            catch(InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }

            using (IDbConnection iDbCon = new SqlConnection(connectionString))
            {
                try
                {
                    iDbCon.Execute(insert);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("An error occurred when trying to manually upload: " + sqlex.Message, "Error");
                    return;
                }
            }
            
            this.Close();
        }

        /// <summary>
        /// Checks the string is valid and encloses it in ''
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string checkValidString(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            if (s.Length > 50)
            {
                throw new InvalidOperationException("Input '" + s + "' is too long!");
            }
            return "'" + s + "'";
        }

        /// <summary>
        /// Checks the int is valid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int checkValidInt(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            int i;
            if (!Int32.TryParse(s, out i))
            {
                throw new InvalidOperationException("Input '" + s + "' is not a valid integer");
            }
            return i;
        }

        /// <summary>
        /// Checks the date is valid and encloses it in ''
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string checkValidDate(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            DateTime dt;
            if (!DateTime.TryParse(s, out dt))
            {
                throw new InvalidOperationException("Input '" + dt + "' is not a valid date");
            }
            return "'" + dt.Date.ToString() + "'";
        }

        /// <summary>
        /// Checks the date is valid and encloses it in ''
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string checkValidDateTime(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            DateTime dt;
            if (!DateTime.TryParse(s, out dt))
            {
                throw new InvalidOperationException("Input '" + dt + "' is not a valid date");
            }
            return "'" + dt.ToString() + "'";
        }

        /// <summary>
        /// Checks the bit is valid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int checkValidBit(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            if (s.Equals("true"))
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Closes the window and does not save the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel?", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            this.Close();
        }
    }
}
