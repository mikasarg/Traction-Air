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
        DataGridViewRow row;

        public ViewForm(DataGridViewRow row)
        {
            this.row = row;

            InitializeComponent();
        }

        /// <summary>
        /// Loads the databases and fills the boxes with their respective values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewForm_Load(object sender, EventArgs e)
        {
            this.tableTableAdapter.Fill(this.pressureGroupsDataSet.Table);
            this.eCUdataTableAdapter.Fill(this.sampleDBDataSet1.ECUdata);

            //Sets the text for the boxes to be their equivalents in the selected entry
            boardNumberTextbox.Text = row.Cells[3].Value.ToString();
            serialNumberTextbox.Text = row.Cells[1].Value.ToString();
            programVersionComboBox.SelectedIndex = programVersionComboBox.FindStringExact(row.Cells[4].Value.ToString());
            pressureGroupComboBox.SelectedIndex = pressureGroupComboBox.FindStringExact(row.Cells[2].Value.ToString());
            customerComboBox.SelectedIndex = customerComboBox.FindStringExact(row.Cells[5].Value.ToString());
            buildDateTextbox.Text = ((DateTime)row.Cells[0].Value).ToString("dd/MM/yyyy");
            installDateTextbox.Text = ((DateTime)row.Cells[16].Value).ToString("dd/MM/yyyy");
            vehicleRefTextbox.Text = row.Cells[7].Value.ToString();
            pressureCellTextbox.Text = row.Cells[12].Value.ToString();
            pt1SerialTextbox.Text = row.Cells[13].Value.ToString();
            pt2SerialTextbox.Text = row.Cells[14].Value.ToString();
            descriptionTextbox.Text = row.Cells[6].Value.ToString();
            notesRichTextbox.Text = row.Cells[18].Value.ToString();

            speedControlComboBox.SelectedIndex = speedControlComboBox.FindStringExact(row.Cells[8].Value.ToString());
            loadedOffRoadTextbox.Text = row.Cells[9].Value.ToString();
            notLoadedTextbox.Text = row.Cells[10].Value.ToString();
            maxTractionTextbox.Text = row.Cells[11].Value.ToString();
        }
    }
}
