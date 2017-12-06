using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        /// <summary>
        /// Checks to make sure the user wishes to delete the selected entry
        /// </summary>
        /// <returns></returns>
        public static bool wishToDelete()
        {
            DialogResult dr = MessageBox.Show("Are you sure you wish to delete the selected row?", "Are You Sure?", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Inserts the new entry into the table
        /// </summary>
        /// <param name="insert"></param>
        public static void Insert(string insert)
        {
            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                try
                {
                    iDbCon.Execute(insert);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("An error occurred when attempting to insert: " + sqlex.Message, "Error");
                }
            }
        }

        /// <summary>
        /// Checks that the string is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckString(string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException("Country cannot be null!");
            }
            if (s == null && allowNull)
            {
                return "''";
            }
            if (s.Length > 50)
            {
                throw new InvalidOperationException("Input '" + s + "' is too long!");
            }
            return s;
        }

        /// <summary>
        /// Checks for duplicates of the given string in the given table's given column
        /// then returns it enclosed in ''
        /// </summary>
        /// <param name="s"></param>
        /// <param name="column"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string CheckForDuplicates(string s, string column, string table, int id)
        {
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));

            SqlCommand cmd = new SqlCommand("SELECT * FROM " + table + " WHERE " + column + " = '" + s + "' AND Id != " + id, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) //Duplicates were found
            {
                throw new InvalidOperationException(column + " '" + s + "' already exists in the table");
            }
            con.Close();
            return "'" + s + "'";
        }

        /// <summary>
        /// Updates the selected entry from the given database
        /// </summary>
        /// <param name="update"></param>
        public static void update(string update)
        {
            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                try
                {
                    iDbCon.Execute(update);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("An error occurred when attempting to update: " + sqlex.Message, "Error");
                }
            }
        }

        /// <summary>
        /// Deletes the selected entry from the given database
        /// </summary>
        /// <param name="s"></param>
        public static void delete(string s, string column, string table)
        {
            string delete = "DELETE FROM " + table + " WHERE " + column + " = '" + s + "'";
            using (IDbConnection iDbCon = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
            {
                try
                {
                    iDbCon.Execute(delete);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("An error occurred when trying to delete: " + sqlex.Message, "Error");
                    return;
                }
            }
        }

        /// <summary>
        /// Checks that the country code is valid and returns it
        /// This must be used instead of the regular CheckString method as the code must be 3 characters
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckCountryCode(string code, int id)
        {
            if (code == null)
            {
                throw new InvalidOperationException("Code cannot be null!");
            }
            if (code.Length != 3)
            {
                throw new InvalidOperationException("Code '" + code + "' is the incorrect length (needs to be 3 characters)");
            }
            code = ECU_Manager.CheckForDuplicates(code, "Code", "countryCodeTable", id);
            return code;
        }
    }
}
