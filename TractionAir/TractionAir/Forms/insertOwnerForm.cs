using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractionAir.Forms
{
    public partial class insertOwnerForm : Form
    {
        public insertOwnerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inserts the new record into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO customerTable VALUES (";
            try
            {
                //Check the values are valid
                string company = ECU_Manager.CheckString(companyTextbox.Text, false);
                ECU_Manager.CheckForDuplicates(company, "Company", "customerTable", -1); //given ID is -1 as we want to find any and all duplicates
                insert += ECU_Manager.enclose(company) + ", ";

                string address1 = ECU_Manager.CheckString(address1Textbox.Text, true);
                insert += ECU_Manager.enclose(address1) + ", ";

                string address2 = ECU_Manager.CheckString(address2Textbox.Text, true);
                insert += ECU_Manager.enclose(address2) + ", ";

                string city = ECU_Manager.CheckString(cityTextbox.Text, true);
                insert += ECU_Manager.enclose(city) + ", ";

                string country = ECU_Manager.CheckString(countryComboBox.Text, false);
                insert += ECU_Manager.enclose(country) + ", ";

                string phone = ECU_Manager.CheckString(phoneTextbox.Text, true);
                insert += ECU_Manager.enclose(phone) + ", ";

                string date = ECU_Manager.CheckDate(DateTime.Now.ToString("dd/MM/yyyy"), false);
                insert += ECU_Manager.enclose(date) + ")";
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            ECU_Manager.Insert(insert); //ECU manager handles the sql command
            this.Close();
        }

        /// <summary>
        /// Cancels the insertion
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

        private void insertOwnerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.countryCodeTable' table. You can move, or remove it, as needed.
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);

        }
    }
}
