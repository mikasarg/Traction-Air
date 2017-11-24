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
    public partial class SelectPressureForm : Form
    {
        public SelectPressureForm()
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
        /// Loads the database data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPressureForm_Load(object sender, EventArgs e)
        {
            this.tableTableAdapter.Fill(this.pressureGroupsDataSet.Table);

        }

        /// <summary>
        /// Returns the selected pressure group to the Pressure Setup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            //TODO return selected pressure group
        }

        /// <summary>
        /// Cancels without selecting a pressure group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
