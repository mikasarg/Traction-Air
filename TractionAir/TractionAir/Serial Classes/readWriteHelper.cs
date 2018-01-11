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
        public static string generateOutput(int boardCode, string speedControl, int loadedOnRoad, 
            int loadedOffRoad, int notLoaded, int unloadedOffRoad, int maxTraction, int psiLoadedOnRoad,
            int psiLoadedOffRoad, int psiNotLoaded, int psiUnloadedOffRoad, int psiMaxTraction, int stepUpDelay, bool maxTractionBeep, 
            bool enableGPSButtons, bool enableGPSOverride)
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
            else //Lower Three Pressures
            {
                output = appendValue(output, "L3P");
            }

            output = appendValue(output, string.Format("{0:000}", loadedOnRoad));

            output = appendValue(output, string.Format("{0:000}", loadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", notLoaded));

            output = appendValue(output, string.Format("{0:000}", unloadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", maxTraction));

            output = appendValue(output, string.Format("{0:00}", stepUpDelay));

            output = appendValue(output, string.Format("{0:000}", psiLoadedOnRoad));

            output = appendValue(output, string.Format("{0:000}", psiLoadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", psiNotLoaded));

            output = appendValue(output, string.Format("{0:000}", psiUnloadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", psiMaxTraction));

            output = appendValue(output, string.Format("{0:00}", stepUpDelay));

            if (maxTractionBeep)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            if (enableGPSButtons)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            if (enableGPSOverride)
            {
                output = appendValue(output, "1");
            }
            else
            {
                output = appendValue(output, "0");
            }

            return appendCRC(output);
        }

        /// <summary>
        /// Reads the input and converts it to an object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static settingsFromECU readInput(string input)
        {
            if (!checkCRCsMatch(input))
            {
                try
                {
                    SerialManager.WriteLine(appendCRC("ERR,")); //Send an error message to the ECU to let it know there was a mismatch in the CRCs
                }
                catch (TimeoutException toex)
                {
                    throw new InvalidOperationException("Error when reading data from ECU: " + toex.Message);
                }
                throw new InvalidOperationException("CRCs did not match - could be caused by noise in the connection. Please try again.");
            }

            settingsFromECU sfe = new settingsFromECU();
            List<string> values = input.Split(',').ToList();

            sfe.boardCode = ECU_Manager.CheckInt(values[0], false);
            sfe.speedControl = ECU_Manager.CheckString(values[1], false);
            sfe.loadedOnRoad = ECU_Manager.CheckInt(values[2], false);
            sfe.loadedOffRoad = ECU_Manager.CheckInt(values[3], false);
            sfe.notLoaded = ECU_Manager.CheckInt(values[4], false);
            sfe.unloadedOffRoad = ECU_Manager.CheckInt(values[5], false);
            sfe.maxTraction = ECU_Manager.CheckInt(values[6], false);
            sfe.loadedOnRoad = ECU_Manager.CheckInt(values[7], false);
            sfe.loadedOffRoad = ECU_Manager.CheckInt(values[8], false);
            sfe.notLoaded = ECU_Manager.CheckInt(values[9], false);
            sfe.unloadedOffRoad = ECU_Manager.CheckInt(values[10], false);
            sfe.maxTraction = ECU_Manager.CheckInt(values[11], false);
            sfe.stepUpDelay = ECU_Manager.CheckInt(values[12], false);
            if (values[13].Equals("0"))
            {
                sfe.maxTractionBeep = false;
            }
            else
            {
                sfe.maxTractionBeep = true;
            }
            if (values[14].Equals("0"))
            {
                sfe.enableGPSButtons = false;
            }
            else
            {
                sfe.enableGPSButtons = true;
            }
            if (values[15].Equals("0"))
            {
                sfe.enableGPSOverride = false;
            }
            else
            {
                sfe.enableGPSOverride = true;
            }

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
            return output + string.Format("{0:000}", CRC) + ",13"; //carraige return
        }
        
        /// <summary>
        /// Checks that our calculated CRC matches the CRC in the input string
        /// </summary>
        /// <returns></returns>
        public static bool checkCRCsMatch(string input)
        {
            if (input.Equals(appendCRC(input.Substring(0, input.Length - 7)))){ //Manually appends the CRC and checks if the 2 strings match
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
    }
}
