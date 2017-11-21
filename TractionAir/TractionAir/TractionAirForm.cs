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

        private void TractionAirForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDBDataSet1.ECUdata' table. You can move, or remove it, as needed.
            this.eCUdataTableAdapter1.Fill(this.sampleDBDataSet1.ECUdata);
        }

        /// <summary>
        /// Shows a window with a database of the pressure groups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressureGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PressureGroupsForm pressureGroups = new PressureGroupsForm();
            pressureGroups.Show();
        }

        /// <summary>
        /// Displays a window which has a list of owners in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ownerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OwnerListForm ownerList = new OwnerListForm();
            ownerList.Show();
            //TODO link the owner list form to a database of owners
        }

        /// <summary>
        /// Views the selected entry in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = ecuDatabase.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = ecuDatabase.SelectedCells[0].OwningRow;
                ViewForm viewEntry = new ViewForm(row);
                viewEntry.Show();
            }
        }

        /// <summary>
        /// Allows the user to make changes to the entry in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            int selectedCellCount = ecuDatabase.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = ecuDatabase.SelectedCells[0].OwningRow;
                ChangeForm changeEntry = new ChangeForm(row);
                changeEntry.Show();
            }
        }

        //TODO queries and saving queries
        //TODO changing entries
        //TODO dropdown lists in change form
        //TODO notes for entries and a box to view them
        //TODO add buttons for pressure and speed setup
        //TODO progress bar
        //TODO COM Port number
    }
}
