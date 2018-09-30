using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractionAir.Serial_Classes
{
    public static class readWriteHelper
    {
        /// <summary>
        /// Generates output based on the given values
        /// </summary>
        /// <param name="boardCode"></param>
        /// <param name="speedControl"></param>
        /// <param name="notLoaded"></param>
        /// <param name="loadedOnRoad"></param>
        /// <param name="loadedOffRoad"></param>
        /// <param name="maxTraction"></param>
        /// <param name="stepUpDelay"></param>
        /// <param name="maxTractionBeep"></param>
        /// <param name="enableGPSButtons"></param>
        /// <param name="enableGPSOverride"></param>
        /// <returns></returns>
        public static string generateOutput(int boardCode, string speedControl,
            int loadedOffRoad, int notLoaded, int unloadedOffRoad, int maxTraction, int psiLoadedOnRoad,
            int psiLoadedOffRoad, int psiNotLoaded, int psiUnloadedOffRoad, int psiMaxTraction, int stepUpDelay, bool maxTractionBeep, 
            bool enableGPSButtons, bool airFaultBeep, bool gpsSpeedUp, bool gpsSpeedSafety, int airFaultBeepTimeLimit)
        {
            string output = "";

            output = appendValue(output, string.Format("{0:000000}", boardCode));

            if (speedControl.Equals("No Speed Control"))
            {
                output = appendValue(output, "NSC");
            }
            else if (speedControl.Equals("Only Max Traction"))
            {
                output = appendValue(output, "OMT");
            }
            else if (speedControl.Equals("Lower Two Pressures"))
            {
                output = appendValue(output, "L2P");
            }
            else if (speedControl.Equals("Lower Three Pressures"))
            {
                output = appendValue(output, "L3P");
            }
            else //Lower Four Pressures
            {
                output = appendValue(output, "L4P");
            }

            output = appendValue(output, string.Format("{0:000}", loadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", notLoaded));

            output = appendValue(output, string.Format("{0:000}", unloadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", maxTraction));

            output = appendValue(output, string.Format("{0:000}", psiLoadedOnRoad));

            output = appendValue(output, string.Format("{0:000}", psiLoadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", psiNotLoaded));

            output = appendValue(output, string.Format("{0:000}", psiUnloadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", psiMaxTraction));

            if(enableGPSButtons)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            if (gpsSpeedUp)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            if (gpsSpeedSafety)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            output = appendValue(output, string.Format("{0:0}", stepUpDelay));

            if (maxTractionBeep)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }
            if (airFaultBeep)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            output = appendValue(output, string.Format("{0:0}", airFaultBeepTimeLimit));

            return appendCRC(output);
        }

        /// <summary>
        /// Reads the input and converts it to an object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static settingsFromECU readInput(string input)
        {
            if (!input.Substring(0, 6).Equals("000000")) //TODO REMOVE No point checking if CRCs match if this is a new board
            {
                if (!checkCRCsMatch(input))
                {
                    throw new InvalidOperationException("CRCs did not match - could be caused by noise in the connection. Please try again.");
                }
            }

            settingsFromECU sfe = new settingsFromECU();
            List<string> values = input.Split(',').ToList();

            sfe.boardCode = ECU_Manager.Check5Int("Board Code", values[0], false);
            sfe.boardVersion = CheckVersion("Board Version", values[1], false);
            sfe.version = CheckVersion("Code Version", values[2], false);
            sfe.speedControl = ECU_Manager.CodeToSpeedControl(values[3]);
            sfe.loadedOffRoad = ECU_Manager.Check3Int("Loaded Off Road", values[4], false);
            sfe.notLoaded = ECU_Manager.Check3Int("Unloaded On Road", values[5], false);
            sfe.unloadedOffRoad = ECU_Manager.Check3Int("Unloaded Off Road", values[6], false);
            sfe.maxTraction = ECU_Manager.Check3Int("Max Traction", values[7], false);
            sfe.psiLoadedOnRoad = ECU_Manager.Check3Int("Loaded On Road Pressure", values[8], false);
            sfe.psiLoadedOffRoad = ECU_Manager.Check3Int("Loaded Off Road Pressure", values[9], false);
            sfe.psiNotLoaded = ECU_Manager.Check3Int("Unloaded On Road Pressure", values[10], false);
            sfe.psiUnloadedOffRoad = ECU_Manager.Check3Int("Unloaded Off Road Pressure", values[11], false);
            sfe.psiMaxTraction = ECU_Manager.Check3Int("Max Traction Pressure", values[12], false);
            if (values[13].Equals("0"))
            {
                sfe.enableGPSButtons = false;
            }
            else
            {
                sfe.enableGPSButtons = true;
            }
            if (values[14].Equals("0"))
            {
                sfe.GPSSpeedUp = false;
            }
            else
            {
                sfe.GPSSpeedUp = true;
            }
            if (values[15].Equals("0"))
            {
                sfe.GPSSpeedSafety = false;
            }
            else
            {
                sfe.GPSSpeedSafety = true;
            }
            sfe.stepUpDelay = ECU_Manager.Check1Int("Step Up Delay", values[16], false);
            if (values[17].Equals("0"))
            {
                sfe.maxTractionBeep = false;
            }
            else
            {
                sfe.maxTractionBeep = true;
            }
            if (values[18].Equals("0"))
            {
                sfe.AirFaultBeep = false;
            }
            else
            {
                sfe.AirFaultBeep = true;
            }
            sfe.AirFaultBeepTimeLimit = ECU_Manager.Check1Int("Air Fault Beep Time Limit", values[19], false);
            sfe.crc = ECU_Manager.Check3Int("CRC", values[20].Substring(0,3), false); //gets first 3 characters of final entry - separates CRC from carraige return

            return sfe;
        }

        /// <summary>
        /// Appends a value to the end of the given string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string appendValue(string input, string value)
        {
            return input + value + ",";
        }

        /// <summary>
        /// Appends the CRC to the end of the string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string appendCRC(string input)
        {
            string output = "";
            byte CRC = 000;
            foreach (char c in input.ToCharArray())
            {
                if (c != ',')
                {
                    CRC = calculateCRC(CRC, Convert.ToByte(c));
                }
                output += c;
            }
            if (output.Length > 10) //(LF) for data, (CR) for GET
            {
                return output + string.Format("{0:000}", CRC) + (char)10; //TODO still unsure if correct
            }
            return output + string.Format("{0:000}", CRC) + (char)13; //TODO still unsure if correct
        }

        /// <summary>
        /// Checks that our calculated CRC matches the CRC in the input string
        /// </summary>
        /// <returns></returns>
        public static bool checkCRCsMatch(string input)
        {
            if (input.Equals(appendCRC(input.Substring(0, input.Length - 4)))){ //Manually appends the CRC and checks if the 2 strings match
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the CRC based on the input byte
        /// </summary>
        /// <param name="CRC"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte calculateCRC(byte CRC, byte input)
        {
            for (byte count = 0; count < 8; count++)
            {
                if (((CRC & 0x01) ^ (input & 0x01)) != 0)
                {
                    CRC ^= 0x70;
                    CRC >>= 1;
                    CRC |= 0x80;
                }
                else
                {
                    CRC >>= 1;
                    CRC &= 0x7F;
                }
                input >>= 1;
            }
            return CRC;
        }

        /// <summary>
        /// Checks that the version is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckVersion(string name, string s, bool allowNull)
        {
            if ((s == null || s.Equals("")) && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            if ((s == null || s.Equals("")) && allowNull)
            {
                return "";
            }
            if (s.Length != 3)
            {
                throw new InvalidOperationException(name + ": Input '" + s + "' should be 3 characters long!");
            }
            string output = s.Substring(0, 1) + "." + s.Substring(1, 2); //adds the decimal place in the version
            return output;
        }
    }
}
