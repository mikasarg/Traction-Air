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
    public partial class insertCountryForm : Form
    {
        public insertCountryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inserts the given values into the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO countryCodeTable VALUES (@code, @country);";
            try
            {
                string code = ECU_Manager.CheckCountryCode(codeTextbox.Text);
                ECU_Manager.CheckDuplicateCountry(code, -1); //check for an existing entry
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command = new SqlCommand(insert, connection);
                    command.Parameters.Add("@code", SqlDbType.NVarChar);
                    command.Parameters["@code"].Value = ECU_Manager.CheckCountryCode(codeTextbox.Text);
                    command.Parameters.Add("@country", SqlDbType.NVarChar);
                    command.Parameters["@country"].Value = ECU_Manager.CheckString("Country", countryTextbox.Text, false);
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
    }
}
