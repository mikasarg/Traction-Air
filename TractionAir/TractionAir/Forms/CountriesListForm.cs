﻿using Dapper;
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
                int id;
                if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out id))
                {
                    ECU_Manager.delete(id.ToString(), "Id", "countryCodeTable");
                }
                else
                {
                    MessageBox.Show("Could not delete selected entry as its ID was in the incorrect format.");
                }
            }
            else
            {
                return;
            }
            refreshTable();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (countryCodeTableDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectedRow = countryCodeTableDataGridView.SelectedRows[0];
            int id;
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out id))
            {
                changeCountryForm changeCountry = new changeCountryForm(id);
                changeCountry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not change selected entry as its ID was in the incorrect format.");
            }
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
