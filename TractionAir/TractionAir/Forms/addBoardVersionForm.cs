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
    public partial class addBoardVersionForm : Form
    {
        public addBoardVersionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cancels the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Adds the given program version
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            //Check for duplicates
            string version = "V" + numericUpDown1.Value.ToString("0.0");
            try
            {
                ECU_Manager.CheckDuplicateBoardVersion(version);
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            string insert = "INSERT INTO boardVersionTable VALUES (@version);";
            try
            {
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command = new SqlCommand(insert, connection);
                    command.Parameters.Add("@version", SqlDbType.NVarChar);
                    command.Parameters["@version"].Value = version;
                    connection.Open();
                    command.ExecuteScalar();
                }
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when attempting to add the version: " + ex.Message, "Error");
            }
        }
    }
}
