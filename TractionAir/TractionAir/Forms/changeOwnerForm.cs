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
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command1 = new SqlCommand(update1, connection);
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
                    /*
                    string company = ECU_Manager.CheckString(companyTextbox.Text, false);
                    ECU_Manager.CheckForDuplicates(company, "Company", "customerTable", id); //checks for no duplicates - unless they have the same ID
                    update += "Company = " + ECU_Manager.enclose(company) + ", ";

                    string address1 = ECU_Manager.CheckString(address1Textbox.Text, false);
                    update += "Address1 = " + ECU_Manager.enclose(address1) + ", ";

                    string address2 = ECU_Manager.CheckString(address2Textbox.Text, false);
                    update += "Address2 = " + ECU_Manager.enclose(address2) + ", ";

                    string city = ECU_Manager.CheckString(cityTextbox.Text, false);
                    update += "City = " + ECU_Manager.enclose(city) + ", ";

                    string country = ECU_Manager.CheckString(countryComboBox.Text, false);
                    update += "Country = " + ECU_Manager.enclose(country) + ", ";

                    string phone = ECU_Manager.CheckString(phoneTextbox.Text, false);
                    update += "Phone = " + ECU_Manager.enclose(phone) + ", ";

                    string date = ECU_Manager.CheckDate(DateTime.Now.ToString("dd/MM/yyyy"), false);
                    update += "Date = " + ECU_Manager.enclose(date) + " WHERE Id = " + id;

                    ECU_Manager.updateChildID(id, (int)countryComboBox.SelectedValue, "customerToCountry");
                    */
                }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            //ECU_Manager.update(update); //ecu manager handles sql command
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
                countryComboBox.SelectedValue = ECU_Manager.getChildIdByParentId(id, "customerToCountry");
                phoneTextbox.Text = customer.Phone;
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Error");
            }
        }
    }
}
