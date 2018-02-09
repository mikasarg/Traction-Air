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
using System.IO;
using System.IO.Ports;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using TractionAir.Serial_Classes;
using System.Data.SqlClient;
using System.Configuration;
using TractionAir.Forms;
using System.Net;

namespace TractionAir
{
    public partial class TractionAirForm : Form
    {
        //TODO make the progress bar work
        //TODO all menu functions
        //TODO retrieve and send data via USB
        //TODO connect to and edit the real database (online or offline)
        //TODO disable copy if newer?
        private splashForm splash;

        /// <summary>
        /// Constructor
        /// </summary>
        public TractionAirForm(splashForm splash)
        {
            this.splash = splash;
            InitializeComponent();

            ECU_Manager.Initialise(ref serialPortECU);

            InitializeUSBPort();

            InitialiseMode();

            SerialManager.Initialize();

            SerialManager.Event_ECU_StatusChange += new EventHandler(OnECUStatusChange);

            connectionString = ECU_Manager.connection("ecuSettingsDB_CS");
        }

        /// <summary>
        /// Loads the data into the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TractionAirForm_Load(object sender, EventArgs e)
        { 
            this.mainSettingsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.mainSettingsTable);

            int selectedCellCount = mainSettingsTableDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow row = mainSettingsTableDataGridView.SelectedCells[0].OwningRow;
                notesRichTextbox.Text = row.Cells["notesColumn"].Value.ToString();
            }

            ecuCountLabel.Text = "ECU Count: " + mainSettingsTableDataGridView.RowCount;

            //Closes the splash/loading screen
            splash.Close();
        }

        #region System Methods
        /// <summary>
        /// Updates the SerialManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_tick(object sender, EventArgs e)
        {
            SerialManager.Update(timer_update.Interval);
        }

        /// <summary>
        /// Refreshes the datagridview
        /// </summary>
        private void refreshTable()
        {
            this.mainSettingsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.mainSettingsTable);
            mainSettingsTableDataGridView.Update();
            mainSettingsTableDataGridView.Refresh();
            ecuCountLabel.Text = "ECU Count: " + mainSettingsTableDataGridView.RowCount;
        }

        /// <summary>
        /// Returns true if the program is connected to the internet; false otherwise
        /// </summary>
        /// <returns></returns>
        private bool connected()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("https://www.google.co.nz"))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region Menu
        /// <summary>
        /// Sets the correct mode option to be checked and the status text
        /// </summary>
        private void InitialiseMode()
        {
            if (Properties.Settings.Default.OnlineMode)
            {
                offlineToolStripMenuItem.Checked = false;
                onlineToolStripMenuItem.Checked = true;
                if (connected()) 
                {
                    onlineLabel.Text = "Online Mode: Connected";
                }
                else
                {
                    onlineLabel.Text = "Online Mode: Not Connected";
                }
            }
            else //Offline mode
            {
                offlineToolStripMenuItem.Checked = true;
                onlineToolStripMenuItem.Checked = false;
                onlineLabel.Text = "Offline Mode";
            }
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
            if (Properties.Settings.Default.OnlineMode)
            {
                Properties.Settings.Default.OnlineMode = false;
                offlineToolStripMenuItem.Checked = true;
                onlineToolStripMenuItem.Checked = false;
                onlineLabel.Text = "Offline Mode";
                //TODO make this meaningful
            }
        }

        /// <summary>
        /// Changes to online mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.OnlineMode)
            {
                Properties.Settings.Default.OnlineMode = true;
                onlineToolStripMenuItem.Checked = true;
                offlineToolStripMenuItem.Checked = false;
                if (connected())
                {
                    onlineLabel.Text = "Online Mode: Connected";
                }
                else
                {
                    onlineLabel.Text = "Online Mode: Not Connected";
                }
                //TODO make this meaningful
            }
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
            refreshTable();
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
            refreshTable();
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
        /// Displays a help window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpForm help = new helpForm();
            help.Show();
        }

        private void manualUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualUploadForm manualUpload = new ManualUploadForm();
            manualUpload.ShowDialog();
            refreshTable();
        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountriesListForm countriesList = new CountriesListForm();
            countriesList.Show();
            refreshTable();
        }
        #endregion

        #region Buttons
        /// <summary>
        /// Views the selected entry in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewButton_Click(object sender, EventArgs e)
        {
            if (mainSettingsTableDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectedRow = mainSettingsTableDataGridView.SelectedRows[0];
            int boardCode = (int)selectedRow.Cells[0].Value;
            ViewForm viewEntry = new ViewForm(boardCode);
            viewEntry.ShowDialog();
        }

        /// <summary>
        /// Allows the user to make changes to the entry in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            if (mainSettingsTableDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectedRow = mainSettingsTableDataGridView.SelectedRows[0];
            int boardCode = (int)selectedRow.Cells[0].Value;
            ChangeForm changeEntry = new ChangeForm(boardCode);
            changeEntry.ShowDialog();
            refreshTable();
        }

        /// <summary>
        /// Opens up a query window for the user to enter and save queries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryButton_Click(object sender, EventArgs e)
        {
            queryForm query = new queryForm(mainSettingsTableDataGridView);
            query.ShowDialog();
        }
        #endregion

        #region Database
        private SqlConnection connection;
        private string connectionString;

        /// <summary>
        /// Updates the notes textbox to reflect changes in selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainSettingsTableDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (mainSettingsTableDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectedRow = mainSettingsTableDataGridView.SelectedRows[0];
            notesRichTextbox.Text = selectedRow.Cells["notesColumn"].Value.ToString();
        }
        #endregion

        #region USB
        private USBClass USBPort;
        private List<USBClass.DeviceProperties> ListOfUSBDeviceProperties;

        private const string ECU_VID = "0403";
        private const string ECU_PID = "6015";
        private const string ECU_DEVID = "vid_0403&pid_6015";

        /// <summary>
        /// Overrides the windows proc method (for interacting with USB devices)
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            bool IsHandled = false;
            USBPort.ProcessWindowsMessage(m.Msg, m.WParam, m.LParam, ref IsHandled);
            base.WndProc(ref m);
        }

        private void InitializeUSBPort()
        {
            //Using the USBClassLibrary to detect ECU connections            
            USBPort = new USBClass();
            ListOfUSBDeviceProperties = new List<USBClass.DeviceProperties>();

            USBPort.USBDeviceAttached += new USBClass.USBDeviceEventHandler(USBPort_USBDeviceAttached);
            USBPort.USBDeviceRemoved += new USBClass.USBDeviceEventHandler(USBPort_USBDeviceRemoved);

            USBPort.RegisterForDeviceChange(true, this.Handle);

            //Check if ECU is already connected
            if (USBClass.GetUSBDevice(ECU_DEVID, ref ListOfUSBDeviceProperties, false))
            //TODO if (true)
            {
                //ECU is connected
                Properties.Settings.Default.EcuConnected = true;
                List<string> names = ComPortNames(ECU_VID, ECU_PID);

                if (names.Count > 0)
                {
                    foreach (String s in SerialPort.GetPortNames())
                    {
                        if (names.Contains(s))
                        {
                            Properties.Settings.Default.ConnectionPort = s;
                            serialPortECU.PortName = s;
                        }
                    }
                }
                ecuConnectedForm ecuConnected = new ecuConnectedForm();
                ecuConnected.ShowDialog();
                connectedBoardLabel.Text = "Connected Board: " + ECU_Manager.connectedBoard;
            }
        }

        //Implement Attach and Detach handlers:
        private void USBPort_USBDeviceAttached(object sender, USBClass.USBDeviceEventArgs e)
        {
            //Do nothing if ECU is already connected 
            if (Properties.Settings.Default.EcuConnected)
            {
                return;
            }

            if (USBClass.GetUSBDevice(ECU_DEVID, ref ListOfUSBDeviceProperties, false))
            {
                //ECU is connected
                Properties.Settings.Default.EcuConnected = true;

                List<string> names = ComPortNames(ECU_VID, ECU_PID);

                if (names.Count > 0)
                {
                    foreach (String s in SerialPort.GetPortNames())
                    {
                        if (names.Contains(s))
                        {
                            Properties.Settings.Default.ConnectionPort = s;
                            serialPortECU.PortName = s;
                        }
                    }
                }
                ecuConnectedForm ecuConnected = new ecuConnectedForm();
                ecuConnected.ShowDialog();
                connectedBoardLabel.Text = "Connected Board: " + ECU_Manager.connectedBoard;
            }
        }
        private void USBPort_USBDeviceRemoved(object sender, USBClass.USBDeviceEventArgs e)
        {
            //Do nothing if ECU is already disconnected 
            if (!Properties.Settings.Default.EcuConnected)
            {
                return;
            }

            if (!USBClass.GetUSBDevice(ECU_DEVID, ref ListOfUSBDeviceProperties, false))
            {
                //ECU is disconnected
                Properties.Settings.Default.EcuConnected = false;
                connectedBoardLabel.Text = "Connected Board: Disconnected";
            }
        }

        /// <summary>
        /// Compile a list of COM port names associated with given VID and PID
        /// from https://www.codeproject.com/Tips/349002/Select-a-USB-Serial-Device-via-its-VID-PID
        /// </summary>
        /// <param name="VID"></param>
        /// <param name="PID"></param>
        /// <returns></returns>
        List<string> ComPortNames(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            //TODO remove below line (for testing)
            //return new List<string>() { "COM3" };
            return comports;
        }
        #endregion

        #region eventhandlers
        private void OnECUStatusChange(object sender, EventArgs e)
        {
            comPortLabel.Text = SerialManager.EcuStatusText;
        }

        private void mainSettingsTableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeButton_Click(sender, e);
        }

        #endregion


    }
}
