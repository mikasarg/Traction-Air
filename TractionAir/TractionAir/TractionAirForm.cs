using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractionAir
{
    public partial class TractionAirForm : Form
    {
        private bool online;
        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_VOLUME = 0x00000002;

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
            MessageBox.Show("TractionAir Desktop " + Properties.Settings.Default.TractionAirDesktopVersion, "Version");
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
            speedSim.ShowDialog();
        }

        /// <summary>
        /// Loads the data into the sampleDB table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TractionAirForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDBDataSet.setupTable' table. You can move, or remove it, as needed.
            this.setupTableTableAdapter.Fill(this.sampleDBDataSet.setupTable);
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
            pressureGroups.ShowDialog();
        }

        /// <summary>
        /// Displays a window which has a list of owners in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ownerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OwnerListForm ownerList = new OwnerListForm();
            ownerList.ShowDialog();
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
                viewEntry.ShowDialog();
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
                changeEntry.ShowDialog();
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
            accessCode.ShowDialog();
        }

        /// <summary>
        /// Allows a user to enter an IP address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterServerAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerAddressForm serverAddress = new ServerAddressForm();
            serverAddress.ShowDialog();
        }

        /// <summary>
        /// Displays a help window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpForm help = new helpForm();
            help.Show();
        }

        /// <summary>
        /// Opens the pressure setup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pressureSetupButton_Click(object sender, EventArgs e)
        {
            PressureSetupForm pressureSetup = new PressureSetupForm();
            pressureSetup.ShowDialog();
        }

        /// <summary>
        /// Opens the speed setup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speedSetupButton_Click(object sender, EventArgs e)
        {
            SpeedSetupForm speedSetup = new SpeedSetupForm();
            speedSetup.ShowDialog();
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

        /// <summary>
        /// Opens up a query window for the user to enter and save queries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryButton_Click(object sender, EventArgs e)
        {
            //TODO query - VERY HARD by the looks of things?? Have to write in SQL???
            queryForm query = new queryForm();
            query.ShowDialog();
        }

        /// <summary>
        /// Overrides the windows proc method (for interacting with USB devices)
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch(m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            //Device arrived

                            int devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_VOLUME) //storage device
                            {
                                DevBroadcastVolume vol;
                                vol = (DevBroadcastVolume)Marshal.PtrToStructure(m.LParam,
                                   typeof(DevBroadcastVolume));
                                //Device mask is vol.Mask
                                
                            }
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:
                            //Device removed
                            break;
                    }
                    break;

            }
        }

        /// <summary>
        /// Allows the user to change the selected entry in the setup table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton2_Click(object sender, EventArgs e)
        {
            int selectedCellCount = ecuDatabase.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = setupTableDataGridView.SelectedCells[0].OwningRow;
                setupChangeForm setupChange = new setupChangeForm(row);
                setupChange.ShowDialog();
            }
        }

        private void setupDataButton_Click(object sender, EventArgs e)
        {
            //TODO find out what this does
        }

        private void boardCodeButton_Click(object sender, EventArgs e)
        {
            //TODO find out what this does + when it is active
        }

        //TODO queries and saving queries
        //TODO make the progress bar work
        //TODO make the connected board text work
        //TODO make the COM Port number work
        //TODO all menu functions
    }
}
