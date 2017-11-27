using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractionAir
{
    public partial class PressureGroupsForm : Form
    {
        public PressureGroupsForm()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pressureGroupsDataSet);

        }

        /// <summary>
        /// loads the pressure groups data into the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressureGroupsForm_Load(object sender, EventArgs e)
        {
            this.tableTableAdapter.Fill(this.pressureGroupsDataSet.Table);
        }

        /// <summary>
        /// Opens an insert window for the user to specify a new pressure group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            insertionForm insertion = new insertionForm(tableDataGridView);
            insertion.ShowDialog();
        }

        /// <summary>
        /// Deletes the selected pressure group from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = tableDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = tableDataGridView.SelectedCells[0].OwningRow;
                tableDataGridView.Rows.RemoveAt(row.Index);
            }
        }
    }
}
