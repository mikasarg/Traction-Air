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
    public partial class TractionAirForm : Form
    {
        private bool online;

        /// <summary>
        /// Constructor
        /// </summary>
        public TractionAirForm()
        {
            online = false;
            InitializeComponent();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Displays the current version number for the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TractionAir Desktop " + Program.Version, "Version");
        }

        /// <summary>
        /// Changes to offline mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (online)
            {
                online = false;
                offlineToolStripMenuItem.Checked = true;
                onlineToolStripMenuItem.Checked = false;
                onlineLabel.Text = "Offline ...";
                //TODO change it to offline mode
            }
        }

        /// <summary>
        /// Changes to online mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!online)
            {
                online = true;
                onlineToolStripMenuItem.Checked = true;
                offlineToolStripMenuItem.Checked = false;
                onlineLabel.Text = "Online ...";
                //TODO change it to online mode
            }
        }

        /// <summary>
        /// Cuts the selected text to the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl is TextBox)
            {
                Clipboard.SetDataObject(((TextBox)this.ActiveControl).SelectedText, true);
                ((TextBox)this.ActiveControl).SelectedText = "";
            }
            else if (this.ActiveControl is ComboBox)
            {
                Clipboard.SetDataObject(((ComboBox)this.ActiveControl).SelectedText, true);
                ((ComboBox)this.ActiveControl).SelectedText = "";
            }
        }

        /// <summary>
        /// Copies the selected text to the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl is TextBox)
            {
                Clipboard.SetDataObject(((TextBox)this.ActiveControl).SelectedText, true);
            }
            else if (this.ActiveControl is ComboBox)
            {
                Clipboard.SetDataObject(((ComboBox)this.ActiveControl).SelectedText, true);
            }
        }

        /// <summary>
        /// Pastes the text on the clipboard into the selected text or combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl is TextBox)
            {
                int nCursorPosition = ((TextBox)this.ActiveControl).SelectionStart;
                this.ActiveControl.Text = this.ActiveControl.Text.Insert(nCursorPosition, Clipboard.GetText());
            }
            else if (this.ActiveControl is ComboBox)
            {
                int nCursorPosition = ((ComboBox)this.ActiveControl).SelectionStart;
                this.ActiveControl.Text = this.ActiveControl.Text.Insert(nCursorPosition, Clipboard.GetText());
            }
        }

        /// <summary>
        /// Sends the connected device a simulated speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speedSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpeedSimulationForm speedSim = new SpeedSimulationForm();
            speedSim.Show();
        }
    }
}
