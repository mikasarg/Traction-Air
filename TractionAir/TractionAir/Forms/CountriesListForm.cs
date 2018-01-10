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
    public partial class CountriesListForm : Form
    {
        public CountriesListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the data into the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountriesListForm_Load(object sender, EventArgs e)
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
        }

        #region buttons
        /// <summary>
        /// Inserts a new country code into the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            insertCountryForm insertCountry = new insertCountryForm(); //loads a form to insert an entry
            insertCountry.ShowDialog();
            refreshTable();
        }

        /// <summary>
        /// Deletes the selected row from the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!ECU_Manager.wishToDelete())
            {
                return;
            }
            if (countryCodeTableDataGridView.SelectedRows.Count == 0) //no selected rows
            {
                return;
            }
            DataGridViewRow selectedRow = countryCodeTableDataGridView.SelectedRows[0];
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out int id))
            {
                string delete = "DELETE FROM countryCodeTable WHERE Id = @countryId;";
                try
                {
                    using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                    {
                        SqlCommand command = new SqlCommand(delete, connection);
                        command.Parameters.Add("@countryId", SqlDbType.Int);
                        command.Parameters["@countryId"].Value = ECU_Manager.CheckInt(id.ToString(), false);

                        try
                        {
                            connection.Open();
                            command.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not delete the country. Make sure no ECUs or Customers belong to this country.", "Error");
                        }
                    }
                }
                catch (InvalidOperationException ioex)
                {
                    MessageBox.Show(ioex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Could not delete selected entry as its ID was in the incorrect format.", "Error");
            }
            refreshTable();
        }

        /// <summary>
        /// Loads a change form to alter the selected entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            if (countryCodeTableDataGridView.SelectedRows.Count == 0) //no selected rows
            {
                return;
            }
            DataGridViewRow selectedRow = countryCodeTableDataGridView.SelectedRows[0];
            int id;
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out id))
            {
                changeCountryForm changeCountry = new changeCountryForm(id); //loads a form to change the entry
                changeCountry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not change selected entry as its ID was in the incorrect format.");
            }
            refreshTable();
        }
        #endregion

        /// <summary>
        /// Refreshes the table
        /// </summary>
        private void refreshTable()
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            countryCodeTableDataGridView.Update();
            countryCodeTableDataGridView.Refresh();
        }

        private void countryCodeTableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeButton_Click(sender, e);
        }
    }
}
