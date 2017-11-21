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
    public partial class ViewForm : Form
    {

        public ViewForm(DataGridViewRow row)
        {
            InitializeComponent();

            boardNumberTextbox.Text = row.Cells[3].Value.ToString();
            serialNumberTextbox.Text = row.Cells[1].Value.ToString();
            programVersionComboBox.Text = row.Cells[4].Value.ToString();
            pressureGroupComboBox.Text = row.Cells[2].Value.ToString();
            customerComboBox.Text = row.Cells[5].Value.ToString();
            buildDateTextbox.Text = row.Cells[16].Value.ToString();
            installDateTextbox.Text = row.Cells[16].Value.ToString();
            vehicleRefTextbox.Text = row.Cells[7].Value.ToString();
            pressureCellTextbox.Text = row.Cells[12].Value.ToString();
            pt1SerialTextbox.Text = row.Cells[13].Value.ToString();
            pt2SerialTextbox.Text = row.Cells[14].Value.ToString();
            descriptionTextbox.Text = row.Cells[6].Value.ToString();
            notesRichTextbox.Text = row.Cells[18].Value.ToString();
        }
    }
}
