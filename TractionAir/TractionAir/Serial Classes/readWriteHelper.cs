using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractionAir.Serial_Classes
{
    public static class readWriteHelper
    {
        public static string generateOutput(int boardCode, string topSerial, 
            string botSerial, string speedControl, int notLoaded, int loadedOnRoad, 
            int loadedOffRoad, int maxTraction, int stepUpDelay, bool maxTractionBeep, 
            bool enableGPSButtons, bool enableGPSOverride)
        {
            string output = "";

            output = appendValue(output, string.Format("{0:000000}", boardCode));

            output = appendValue(output, "top");//TODO output = appendValue(output, topSerial);

            output = appendValue(output, "bot");//TODO output = appendValue(output, botSerial);

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

            output = appendValue(output, string.Format("{0:000}", notLoaded));

            output = appendValue(output, string.Format("{0:000}", loadedOnRoad));

            output = appendValue(output, string.Format("{0:000}", loadedOffRoad));

            output = appendValue(output, string.Format("{0:000}", maxTraction));

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

        public static settingsFromECU readInput(string input)
        {
            settingsFromECU sfe = new settingsFromECU();
            List<string> values = input.Split(',').ToList();

            sfe.boardCode = ECU_Manager.CheckInt(values[0], false);
            sfe.topSerial = ECU_Manager.CheckString(values[1], false); //TODO can these be null?
            sfe.botSerial = ECU_Manager.CheckString(values[2], false);
            sfe.speedControl = ECU_Manager.CheckString(values[3], false);
            sfe.notLoaded = ECU_Manager.CheckInt(values[4], false);
            sfe.loadedOnRoad = ECU_Manager.CheckInt(values[5], false);
            sfe.loadedOffRoad = ECU_Manager.CheckInt(values[6], false);
            sfe.maxTraction = ECU_Manager.CheckInt(values[7], false);
            sfe.stepUpDelay = ECU_Manager.CheckInt(values[8], false);
            if (values[9].Equals("0"))
            {
                sfe.maxTractionBeep = false;
            }
            else
            {
                sfe.maxTractionBeep = true;
            }
            if (values[10].Equals("0"))
            {
                sfe.enableGPSButtons = false;
            }
            else
            {
                sfe.enableGPSButtons = true;
            }
            if (values[11].Equals("0"))
            {
                sfe.enableGPSOverride = false;
            }
            else
            {
                sfe.enableGPSOverride = true;
            }

            return sfe;
        }

        public static string appendValue(string input, string value)
        {
            return input + value + ",";
        }

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

        public static string addChar(char c, string s)
        {
            s += c;

            return s;
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
