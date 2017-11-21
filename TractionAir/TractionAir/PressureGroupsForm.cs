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

        private void PressureGroupsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pressureGroupsDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.pressureGroupsDataSet.Table);

        }
    }
}
