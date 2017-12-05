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

        private void countryCodeTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.countryCodeTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ecuSettingsDatabaseDataSet);

        }

        private void CountriesListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.countryCodeTable' table. You can move, or remove it, as needed.
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);

        }

        /// <summary>
        /// Inserts a new country code into the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            insertCountryForm insertCountry = new insertCountryForm();
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
            if (ECU_Manager.wishToDelete())
            {
                if (countryCodeTableDataGridView.SelectedRows.Count == 0)
                {
                    return;
                }
                DataGridViewRow selectedRow = countryCodeTableDataGridView.SelectedRows[0];
                String code = selectedRow.Cells["codeColumn"].Value.ToString();
                delete(code);
            }
            else
            {
                return;
            }
            refreshTable();
        }

        /// <summary>
        /// Deletes the selected entry
        /// </summary>
        /// <param name="code"></param>
        private void delete(string code)
        {
            string delete = "DELETE FROM countryCodeTable WHERE Code = '" + code + "'";
            using (IDbConnection iDbCon = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
            {
                try
                {
                    iDbCon.Execute(delete);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("An error occurred when trying to delete: " + sqlex.Message, "Error");
                    return;
                }
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            //TODO open up a change form

            refreshTable();
        }

        /// <summary>
        /// Refreshes the table
        /// </summary>
        private void refreshTable()
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            countryCodeTableDataGridView.Update();
            countryCodeTableDataGridView.Refresh();
        }
    }
}
