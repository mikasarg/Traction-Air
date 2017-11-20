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
    public partial class SpeedSimulationForm : Form
    {
        public SpeedSimulationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sends the entered data to the device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simulateButton_Click(object sender, EventArgs e)
        {
            if (speedNumericUpDown.Text == "")
            {
                speedNumericUpDown.Text = "0"; //If there is no text, replace it with 0
            }
            //TODO send the simulated speed to the device
        }

        /// <summary>
        /// Cancels the speed simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
