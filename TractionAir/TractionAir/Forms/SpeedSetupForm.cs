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
    public partial class SpeedSetupForm : Form
    {
        public SpeedSetupForm()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            //TODO upload
        }

        private void defaultSpeedSetupButton_Click(object sender, EventArgs e)
        {
            //TODO default speed setup
        }

        private void downloadAndSaveButton_Click(object sender, EventArgs e)
        {
            //TODO download and save
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO save
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
