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
    public partial class setupChangeForm : Form
    {
        DataGridViewRow row;

        public setupChangeForm(DataGridViewRow row)
        {
            this.row = row;

            InitializeComponent();

            analogReferenceTextbox.Text = row.Cells[8].Value.ToString();
            lcdTextbox.Text = row.Cells[6].Value.ToString();
            psiKpaTextbox.Text = row.Cells[9].Value.ToString();
            setPointOffsetTextbox.Text = row.Cells[7].Value.ToString();
            stepUpDelayTextbox.Text = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value.ToString() == "1") {
                maxTractionBeepCheckBox.Checked = true;
            }
            if (row.Cells[5].Value.ToString() == "1")
            {
                enableGpsButtonsCheckBox.Checked = true;
            }
            if (row.Cells[2].Value.ToString() == "1")
            {
                userProgrammingCheckBox.Checked = true;
            }
            if (row.Cells[4].Value.ToString() == "1") //TODO unknown where this value should come from
            {
                fillExhaustInfoCheckBox.Checked = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //TODO update selected entry
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
