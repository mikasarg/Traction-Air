using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractionAir
{
    /// <summary>
    /// Static helper class
    /// </summary>
    static class ECU_Manager
    {
        public static SerialPort ECU_SerialPort;

        public static string connection(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Returns a string version of the object and makes it "" instead of null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string stringNullCheck(object s)
        {
            if (s == null)
            {
                return "";
            }
            return s.ToString();
        }

        /// <summary>
        /// Checks to make sure the user wishes to cancel out of an operation
        /// </summary>
        /// <returns></returns>
        public static bool wishToCancel()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return false;
            }
            return true;
        }

        public static bool wishToDelete()
        {
            DialogResult dr = MessageBox.Show("Are you sure you wish to delete the selected row?", "Are You Sure?", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                return true;
            }
            return false;
        }
    }
}
