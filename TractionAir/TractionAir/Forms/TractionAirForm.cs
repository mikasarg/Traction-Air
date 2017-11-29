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
using System.IO.Ports;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace TractionAir
{
    public partial class TractionAirForm : Form
    {
        //TODO make the progress bar work
        //TODO make the connected board text work
        //TODO make the COM Port number work
        //TODO all menu functions
        //TODO connect and send data via USB
        //TODO connect to and edit the real database (online or offline)

        /// <summary>
        /// Constructor
        /// </summary>
        public TractionAirForm()
        {
            InitializeComponent();

            InitializeUSBPort();
        }

        /// <summary>
        /// Loads the data into the sampleDB table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TractionAirForm_Load(object sender, EventArgs e)
        {
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

        #region Menu
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
                onlineLabel.Text = "Online Mode";
                //TODO make this meaningful, and let them know if they are connected to the internet
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
        #endregion

        #region Buttons
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
        /// Opens up a query window for the user to enter and save queries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryButton_Click(object sender, EventArgs e)
        {
            queryForm query = new queryForm();
            query.ShowDialog();
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
        #endregion

        #region Database
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
                        }
                    }
                }
                //TODO Console.WriteLine("ECU autoconnected on " + Properties.Settings.Default.AutoConnectionPort);
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
                        }
                    }
                }
                //TODO Console.WriteLine("ECU autoconnected on " + Properties.Settings.Default.AutoConnectionPort);
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
                //TODO Console.WriteLine("ECU disconnected from usb");
            }
        }

        /// <summary>
        /// Compile an array of COM port names associated with given VID and PID
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
            return comports;
        }
        #endregion

        #region eventhandlers
        private void OnECUStatusChange(object sender, EventArgs e)
        {
            comPortLabel.Text = SerialManager.EcuStatusText;

            //StatusText1.BackColor = SerialManager.GrassMasterStatusColor;
        }
        #endregion

    }
}
