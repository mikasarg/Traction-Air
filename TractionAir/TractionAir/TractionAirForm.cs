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

        /// <summary>
        /// Loads the data into the sampleDB table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TractionAirForm_Load(object sender, EventArgs e)
        {
            this.eCUdataTableAdapter1.Fill(this.sampleDBDataSet1.ECUdata);

            int selectedCellCount = ecuDatabase.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = ecuDatabase.SelectedCells[0].OwningRow;
                notesRichTextbox.Text = row.Cells[18].Value.ToString();
            }

            ecuCountLabel.Text = "ECU Count: " + ecuDatabase.RowCount;
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

        /// <summary>
        /// Allows a user to enter a function access code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accessCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccessCodeForm accessCode = new AccessCodeForm();
            accessCode.Show();
        }

        /// <summary>
        /// Allows a user to enter an IP address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterServerAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerAddressForm serverAddress = new ServerAddressForm();
            serverAddress.Show();
        }

        /// <summary>
        /// Displays a help window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO create a help window and have content in it
        }

        private void pressureSetupButton_Click(object sender, EventArgs e)
        {
            PressureSetupForm pressureSetup = new PressureSetupForm();
            pressureSetup.Show();
        }

        private void speedSetupButton_Click(object sender, EventArgs e)
        {
            SpeedSetupForm speedSetup = new SpeedSetupForm();
            speedSetup.Show();
        }

        /// <summary>
        /// Updates the notes textbox to reflect changes in selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ecuDatabase_SelectionChanged(object sender, EventArgs e)
        {
            int selectedCellCount = ecuDatabase.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = ecuDatabase.SelectedCells[0].OwningRow;
                notesRichTextbox.Text = row.Cells[18].Value.ToString();
            }
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            //TODO query - VERY HARD by the looks of things?? Have to write in SQL???
            queryForm query = new queryForm();
            query.Show();
        }

        //TODO add the manual database update group to view and change forms
        //TODO be able to insert, change and delete pressure group entries
        //TODO queries and saving queries
        //TODO progress bar and text next to it
        //TODO connected board text
        //TODO COM Port number
        //TODO all menu functions
        //TODO setup tab
    }
}
