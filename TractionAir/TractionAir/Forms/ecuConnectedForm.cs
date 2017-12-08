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
    public partial class ecuConnectedForm : Form
    {
        public ecuConnectedForm()
        {
            InitializeComponent();
            loadValues();
        }

        /// <summary>
        /// Saves the ECU to the database and uploads relevant data to the ECU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        /// <summary>
        /// Cancels the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (ECU_Manager.wishToCancel())
            {
                this.Close();
            }
            return;
        }

        /// <summary>
        /// Loads values read from the ecu into the relevant controls
        /// </summary>
        private void loadValues()
        {
            //TODO put values in controls
        }
    }
}
