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
            //TODO insert a new country
        }

        /// <summary>
        /// Deletes the selected row from the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you wish to delete the selected row?", "Are You Sure?", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                //TODO delete the selected entry
            }
            else
            {
                return;
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            //TODO open up a change form
        }
    }
}
