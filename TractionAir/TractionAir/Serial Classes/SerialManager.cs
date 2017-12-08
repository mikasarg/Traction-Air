using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using TractionAir.Forms;

namespace TractionAir.Serial_Classes
{
    static class SerialManager
    {
        private static List<string> LastAvailableSerialPorts = new List<string>();
        private static List<string> CurrentAvailableSerialPorts = new List<string>();
        //TODO private static SerialDownloadProcessor SerialDataProcessor = new SerialDownloadProcessor();
        private static float statusPerc = 0;
        private static int linesReceived = 0;
        private static int previousLinesReceived = 0;
        private static string statusText = "";
        public static string downloadStream = "";

        public static bool CommandRequestSent = false;
        public static bool DownloadAllowed = false;
        public static bool UploadAllowed = false;

        public static EventHandler Event_ECU_StatusChange = delegate { };
        public static EventHandler Event_ECU_DownloadDisconnect = delegate { };
        public static EventHandler Event_DownloadStarted = delegate { };
        public static EventHandler Event_DownloadStopped = delegate { };
        public static EventHandler Event_DownloadComplete = delegate { };
        public static EventHandler Event_DownloadInvalid = delegate { };
        public static EventHandler Event_DataLineReceived = delegate { };
        public static EventHandler Event_AvailableSerialPorts_Changed = delegate { };

        static float timeSinceLastLineReceived = 0;


        public static void SetTimeout()
        {
            //TODO set timeout for ECU?
        }

        public static string ECU_Connection_Port()
        {
            return Properties.Settings.Default.ConnectionPort;
        }

        public static void Initialize()
        {
            //TODO ??
            statusText = "ECU Connected on " + Properties.Settings.Default.ConnectionPort;
        }

        public static void StartDownload()
        {
            //TODO set this up for the ECU
            DownloadAllowed = true;
            timeSinceLastLineReceived = 0;
            linesReceived = 0;
            previousLinesReceived = -1;

            try
            {
                if (!Properties.Settings.Default.SerialPortOpen)
                {
                    OpenSerialPort();
                }

                //Serial port must have been opened by now
                // Clear previous download data before starting (can only be cleared when serial port is open!)   
                ClearDownloadData();
                DiscardEcuInBuffer(); //Empty the serial port buffer in case there is any left over data from previous download

                Event_DownloadStarted(null, EventArgs.Empty);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception thrown when trying to start download : " + e.ToString(), "Error");
            }

            //TODO start download
        }
        public static void StopDownload()
        {
            //TODO cancel download

            ClearDownloadedData();
            CloseSerialPort();
            DownloadAllowed = false;
            downloadStream = "";
            ResetDownloadProgress();
        }
        public static void ClearDownloadData()
        {
            ResetDownloadProgress();
            ClearDownloadedData();
        }

        public static int LinesReceived()
        {
            return linesReceived;
        }

        public static int DownloadStatusPercent()
        {
            return (int)statusPerc;
        }

        public static string EcuStatusText
        {
            get { return statusText; }
            set
            {
                statusText = value;
                Event_ECU_StatusChange(null, EventArgs.Empty);
            }
        }

        public static void Update(float deltaTime)
        {
            UpdateConnections();

            //Update SerialManager comport
            if (!Properties.Settings.Default.SerialPortOpen)
            {
                ECU_Manager.ECU_SerialPort.PortName = Properties.Settings.Default.ConnectionPort;
            }

            #region Update Download Status   
            if (DownloadAllowed)
            {
                    //Check if the line count has increased since last update. If not, increment the timeout counter
                    if (previousLinesReceived == linesReceived)
                    {
                        timeSinceLastLineReceived += deltaTime;
                    }
                    else
                    {
                        timeSinceLastLineReceived = 0;
                    }

                    //TODO Determine if download has finished somehow             
                    if (false)  //TODO fix condition
                    {
                        ProcessDownloadCompletion();
                    }

                previousLinesReceived = linesReceived;
            }
            #endregion

            #region Update UI           

            // Update status message          
            UpdateConnections();
            if (Properties.Settings.Default.EcuConnected)
            {
                EcuStatusText = "ECU connected on " + Properties.Settings.Default.ConnectionPort;
                ecuConnectedForm ecuConnected = new ecuConnectedForm();
                ecuConnected.ShowDialog();
            }
            else //ECU disconnected
            {
                EcuStatusText = "ECU disconnected";
            }
            #endregion          
        }
        private static void UpdateConnections()
        {
            // Check ports for plugged/unplugged connections
            CurrentAvailableSerialPorts = SerialPort.GetPortNames().ToList().OrderBy(x => x).ToList();

            //If something has been plugged in or disconnected, check if ECU is still connected
            if (!CurrentAvailableSerialPorts.OrderBy(x => x).SequenceEqual(LastAvailableSerialPorts.OrderBy(x => x)))
            {
                Event_AvailableSerialPorts_Changed(null, EventArgs.Empty);
            }

            if (CurrentAvailableSerialPorts.Contains(Properties.Settings.Default.ConnectionPort))
            {
                Properties.Settings.Default.EcuConnected = true;
            }
            else
            {
                Properties.Settings.Default.EcuConnected = false;
            }

            //Record which ports were available this update (for next update to see).
            LastAvailableSerialPorts = CurrentAvailableSerialPorts;
        }

        public static void HandleIncomingData(object sender, SerialDataReceivedEventArgs e)
        {
            string incomingString = "";

            //Handle responses to requests           
            if (DownloadAllowed)
            {
                try
                {
                    incomingString = ReadLine();

                    if (false) //TODO download cancelled by ECU
                    {
                        Event_DownloadStopped(null, EventArgs.Empty);
                        MessageBox.Show("Download was cancelled by the ECU.");
                    }

                    linesReceived++;
                    downloadStream += incomingString;
                }
                catch (InvalidOperationException invalidOpEx)
                {
                    MessageBox.Show("Download could not be completed (port is closed): " + invalidOpEx.Message, "Error" );
                    StopDownload();
                    return;
                }
                catch (TimeoutException timeoutEx)
                {
                    MessageBox.Show("Download timed out: " + timeoutEx.ToString(), "Error");
                    StopDownload();
                    return;
                }
                catch (IOException ioex)
                {
                    MessageBox.Show("An error occured during the download (was the ECU disconnected?): " + e.ToString(), "Error");
                }
                //TODO SerialDataProcessor.AddData(incomingString);

                //TODO Check that the data received starts as we would expect
                
                // Add download progress to status bar

                //Alert download window that a line has been received
                Event_DataLineReceived(null, EventArgs.Empty);
            }
        }

        public static void ProcessDownloadCompletion()
        {
            // reset line counter
            ResetDownloadProgress();

            //TODO Check data is invalid
            if (false)//TODO !SerialDataProcessor.FinalDataIsValid())
            {
                //Fire invalid data alert event
                Event_DownloadInvalid(null, EventArgs.Empty);

                MessageBox.Show("Invalid data received. Please disconnect the ECU and try again.", "Error");
                return;
            }
            else
            {
                //TODO Store complete data in csv file 
                //SerialDataProcessor.WriteInputDataToCSVFile();
            }

            //End download
            StopDownload();

            // Inform the user
            Event_DownloadComplete(null, EventArgs.Empty);
        }

        private static void DiscardEcuInBuffer()
        {
            try
            {
                ECU_Manager.ECU_SerialPort.DiscardInBuffer();
            }
            catch (InvalidOperationException invalidOpEx)
            {
                //TODO throw exception serial port is closed
            }
            catch (IOException ioEx)
            {
                //TODO throw error serial port name is invalid
            }
        }
        private static void ResetDownloadProgress()
        {
            linesReceived = 0;
            statusPerc = 0;
        }

        public static void ClearDownloadedData()
        {
            //TODO SerialDataProcessor.ClearData();
        }

        /// <summary>
        /// Called when the COM Port has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnAvailableSerialPortsChanged(Object sender, EventArgs e)
        {

            //If we are currently downloading...
            if (DownloadAllowed)
            {
                if (!CurrentAvailableSerialPorts.Contains(Properties.Settings.Default.ConnectionPort))
                {
                    StopDownload();
                    Event_ECU_DownloadDisconnect(null, EventArgs.Empty);
                }
            }
        }

        #region Upload Methods
        public static void StartUpload()
        {
            DownloadAllowed = false; //  Prevent download data coming into the program.
            UploadAllowed = true;
            OpenSerialPort();
        }

        public static bool EcuIsPoweredOn()
        {
            bool poweredOn = false;

            OpenSerialPort();

            try
            {
                //TODO implement this method
            }
            catch { }

            CloseSerialPort();

            return poweredOn;
        }

        public static void StopUpload()
        {
            UploadAllowed = false;
            uploadError = false;
        }

        public static bool uploadError = false;
        public static void UploadRowToECU(DataGridViewRow row)
        {
            // Send the upload string to the ecu
            try
            {
                ECU_Manager.ECU_SerialPort.Write(GeneratedUploadString(row));

                string response = ReadLine();

                if (false) //TODO check if response is bad
                {
                    MessageBox.Show("An error occured while uploading to the ECU. Please try again", "Upload Failed");
                    uploadError = true;
                    return;
                }
            }
            catch (InvalidOperationException invalidOpEx)
            {
                //TODO throw error port is closed
            }

            catch (Exception e)
            {
                //TODO throw error
                uploadError = true;
                return;
            }
        }

        private static String GeneratedUploadString(DataGridViewRow row)
        {
            string uploadString = "";

            //TODO whatever needs to be uploaded to the ECU

            return uploadString;
        }

        public static float GetECUFirmwareVersion()
        {
            DownloadAllowed = false;
            UploadAllowed = false;
            string firmwareVersion = "0";

            try
            {
                //Check comport is open and ready           
                int status = OpenSerialPort();

                SerialManager.ClearSerialBuffers();

                if (status != 0)    //Check there were no exceptions thrown by opening the serial port (when status = 0)
                {
                    return float.Parse(firmwareVersion);
                }

                //TODO Send a command to the ECU. It will reply with a string containing the version number.
                //TODO WriteLine("????");

                //TODO update the firmwareVersion
            }
            catch
            {
                //TODO error ECU might not be turned on
                return 0;
            }

            CloseSerialPort();
            return float.Parse(firmwareVersion);
        }

        public static void ClearSerialBuffers()
        {
            ECU_Manager.ECU_SerialPort.DiscardInBuffer();
            ECU_Manager.ECU_SerialPort.DiscardOutBuffer();
        }

        public static void WriteBytes(byte[] bytes)
        {
            ECU_Manager.ECU_SerialPort.Write(bytes, 0, bytes.Length);
        }

        public static void WriteLine(string line)
        {
            if (!ECU_Manager.ECU_SerialPort.IsOpen)
            {
                OpenSerialPort();
            }
            ECU_Manager.ECU_SerialPort.WriteLine(line);
        }

        public static string ReadLine()
        {
            if (!ECU_Manager.ECU_SerialPort.IsOpen)
            {
                OpenSerialPort();
            }
            return ECU_Manager.ECU_SerialPort.ReadLine();
        }

        public static int OpenSerialPort()
        {
            try
            {
                ECU_Manager.ECU_SerialPort.Open();
            }
            catch (InvalidOperationException invalidOpEx)
            {
                //TODO error serial port already opened
                return 0;   //Return as normal. Serial port already being open is not a problem.
            }
            catch (ArgumentException argEx)
            {
                //TODO error a property of the serial port was invalid
                return 2;
            }
            catch (UnauthorizedAccessException unAEx)
            {
                //TODO error access to serialport was denied
                return 3;
            }
            catch (IOException ioex)
            {
                //TODO error serial port in invalid state
                return 4;
            }
            catch (Exception e)
            {
                //TODO error serial port in invalid state
                return 5;
            }

            return 0;
        }

        public static void CloseSerialPort()
        {
            try
            {
                ECU_Manager.ECU_SerialPort.Close();
            }
            catch (Exception e)
            {
                //TODO error tried to close serialport but didn't work
            }
        }

        #endregion
    }
}
