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
    public partial class changeOwnerForm : Form
    {
        private int id;

        public changeOwnerForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        /// <summary>
        /// Updates the table with the given changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            string update1 = "UPDATE customerTable SET Company = @company, Address1 = @address1, Address2 = @address2, City = @city, Country = @country, Phone = @phone, Date = @date WHERE Id = @id;";
            string update2 = "UPDATE customerToCountry SET CountryID = @countryId WHERE CustomerID = @companyId;";
            try
            {
                string company = ECU_Manager.CheckString("Company", companyTextbox.Text, false);
                ECU_Manager.CheckDuplicateCustomer(company, id); //check for a duplicate company
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command1 = new SqlCommand(update1, connection);
                    command1.Parameters.Add("@company", SqlDbType.NVarChar);
                    command1.Parameters["@company"].Value = company;
                    command1.Parameters.Add("@address1", SqlDbType.NVarChar);
                    command1.Parameters["@address1"].Value = ECU_Manager.CheckString("Address 1", address1Textbox.Text, true);
                    command1.Parameters.Add("@address2", SqlDbType.NVarChar);
                    command1.Parameters["@address2"].Value = ECU_Manager.CheckString("Address 2", address2Textbox.Text, true);
                    command1.Parameters.Add("@city", SqlDbType.NVarChar);
                    command1.Parameters["@city"].Value = ECU_Manager.CheckString("City", cityTextbox.Text, true);
                    command1.Parameters.Add("@country", SqlDbType.NVarChar);
                    command1.Parameters["@country"].Value = ECU_Manager.CheckCountryCode(countryComboBox.Text);
                    command1.Parameters.Add("@phone", SqlDbType.NVarChar);
                    command1.Parameters["@phone"].Value = ECU_Manager.CheckString("Phone", phoneTextbox.Text, true);
                    command1.Parameters.Add("@date", SqlDbType.DateTime);
                    command1.Parameters["@date"].Value = DateTime.Now;
                    command1.Parameters.Add("@id", SqlDbType.Int);
                    command1.Parameters["@id"].Value = id;

                    SqlCommand command2 = new SqlCommand(update2, connection);
                    command2.Parameters.Add("@countryId", SqlDbType.Int);
                    command2.Parameters["@countryId"].Value = countryComboBox.SelectedValue;
                    command2.Parameters.Add("@companyId", SqlDbType.Int);
                    command2.Parameters["@companyId"].Value = id;

                    try
                    {
                        connection.Open();
                        command1.ExecuteScalar();
                        command2.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Cancels the change operation
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

        private void changeOwnerForm_Load(object sender, EventArgs e)
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            try
            {
                customerObject customer = ECU_Manager.getCustomerByID(id); //Obtains a customerObject
                companyTextbox.Text = customer.Company;
                address1Textbox.Text = customer.Address1;
                address2Textbox.Text = customer.Address2;
                cityTextbox.Text = customer.City;
                countryComboBox.SelectedValue = ECU_Manager.CustomerToCountry(id);
                phoneTextbox.Text = customer.Phone;
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Error");
            }
        }
    }
}
