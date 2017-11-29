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
    public partial class PressureSetupForm : Form
    {
        public PressureSetupForm()
        {
            InitializeComponent();
        }

        private void readDataButton_Click(object sender, EventArgs e)
        {
            //TODO read data
        }

        private void pressureGroupButton_Click(object sender, EventArgs e)
        {
            SelectPressureForm selectPressure = new SelectPressureForm();
            selectPressure.Show();

        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            //TODO download
        }

        private void addToRecordsButton_Click(object sender, EventArgs e)
        {
            //TODO add to records
        }

        private void newGroupButton_Click(object sender, EventArgs e)
        {
            PressureGroupsForm pressureGroups = new PressureGroupsForm();
            pressureGroups.Show();
        }
    }
}
