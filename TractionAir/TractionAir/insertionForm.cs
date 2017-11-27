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
    public partial class insertionForm : Form
    {
        DataGridView tableDataGridView;

        public insertionForm(DataGridView tableDataGridView)
        {
            InitializeComponent();

            this.tableDataGridView = tableDataGridView;
        }

        /// <summary>
        /// Inserts the new record into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (descriptionTextbox.Text.Equals(""))
            {
                MessageBox.Show("Please enter a description", "Error");
            }
            else
            {
                //TODO make a new row
                
                row.Cells[0].Value = descriptionTextbox.Text;
                row.Cells[1].Value = loadedOnRoadTextbox.Text;
                row.Cells[2].Value = loadedOffRoadTextbox.Text;
                row.Cells[3].Value = unloadedOnRoadTextbox.Text;
                row.Cells[4].Value = maxTractionTextbox.Text;
                row.Cells[5].Value = DateTime.Now.Date.ToString("dd/MM/yyyy");
                row.Cells[6].Value = DateTime.Now.TimeOfDay.ToString();

                this.Close();
            }
        }

        /// <summary>
        /// Cancels the insertion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
