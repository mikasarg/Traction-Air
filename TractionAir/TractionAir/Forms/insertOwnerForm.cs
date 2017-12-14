using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            string insert1 = "INSERT INTO customerTable OUTPUT INSERTED.ID VALUES (@company, @address1, @address2, @city, @country, @phone, @date);";
            string insert2 = "INSERT INTO customerToCountry VALUES (@companyId, @countryId);";
            try
            {
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command1 = new SqlCommand(insert1, connection);
                    command1.Parameters.Add("@company", SqlDbType.NVarChar);
                    command1.Parameters["@company"].Value = ECU_Manager.CheckString(companyTextbox.Text, false);
                    command1.Parameters.Add("@address1", SqlDbType.NVarChar);
                    command1.Parameters["@address1"].Value = ECU_Manager.CheckString(address1Textbox.Text, true);
                    command1.Parameters.Add("@address2", SqlDbType.NVarChar);
                    command1.Parameters["@address2"].Value = ECU_Manager.CheckString(address2Textbox.Text, true);
                    command1.Parameters.Add("@city", SqlDbType.NVarChar);
                    command1.Parameters["@city"].Value = ECU_Manager.CheckString(cityTextbox.Text, true);
                    command1.Parameters.Add("@country", SqlDbType.NVarChar);
                    command1.Parameters["@country"].Value = ECU_Manager.CheckCountryCode(countryComboBox.Text);
                    command1.Parameters.Add("@phone", SqlDbType.NVarChar);
                    command1.Parameters["@phone"].Value = ECU_Manager.CheckString(phoneTextbox.Text, true);
                    command1.Parameters.Add("@date", SqlDbType.DateTime);
                    command1.Parameters["@date"].Value = DateTime.Now;

                    //Command2 is to update the connections between the tables
                    SqlCommand command2 = new SqlCommand(insert2, connection);
                    command2.Parameters.Add("@countryId", SqlDbType.Int);
                    command2.Parameters["@countryId"].Value = countryComboBox.SelectedValue;
                    command2.Parameters.Add("@companyId", SqlDbType.Int);

                    try
                    {
                        connection.Open();
                        int id = (int)command1.ExecuteScalar();
                        command2.Parameters["@companyId"].Value = id;
                        command2.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                Close();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
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
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);

        }
    }
}
