using Dapper;
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
    public partial class changeCountryForm : Form
    {
        private int id;

        public changeCountryForm(int id)
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
            string update = "UPDATE countryCodeTable SET Code = @code, Country = @country WHERE Id = @id;";
            try
            {
                string code = ECU_Manager.CheckCountryCode(codeTextbox.Text);
                ECU_Manager.CheckDuplicateCountry(code, id); //check for a duplicate entry
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command = new SqlCommand(update, connection);
                    command.Parameters.Add("@code", SqlDbType.NVarChar);
                    command.Parameters["@code"].Value = code;
                    command.Parameters.Add("@country", SqlDbType.NVarChar);
                    command.Parameters["@country"].Value = ECU_Manager.CheckString(countryTextbox.Text, false);
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters["@id"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteScalar();
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

        /// <summary>
        /// loads the values from the selected row into the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeCountryForm_Load(object sender, EventArgs e)
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            try
            {
                CountryObject country = ECU_Manager.getCountryByID(id); //Obtains a countryObject
                codeTextbox.Text = country.Code;
                countryTextbox.Text = country.Country;
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Error");
            }

        }
    }
}
