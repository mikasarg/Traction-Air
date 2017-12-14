﻿using Dapper;
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
        public static int connectedBoard;

        public static void Initialise(ref SerialPort serialPort)
        {
            ECU_SerialPort = serialPort;
        }

        /// <summary>
        /// Returns the connection string based on the name given
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string connection(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        #region table connection methods
        public static int getChildIdByParentId(int parentId, string table)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "";
                if (table.Equals("ecuToCountry"))
                {
                    query = "SELECT CountryID FROM " + table + " WHERE BoardCode = " + parentId;
                }
                else if (table.Equals("customerToCountry"))
                {
                    query = "SELECT CountryID FROM " + table + " WHERE CustomerID = " + parentId;
                }
                SqlCommand command = new SqlCommand(query, con);
                Int32 countryID = (Int32)command.ExecuteScalar();
                con.Close();
                return countryID;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        public static void updateChildID(int parentId, int childId, string table)
        {
            try
            {
                string updateString = "";
                if (table.Equals("ecuToCountry"))
                {
                    updateString = "UPDATE " + table + " SET CountryID = " + childId + " WHERE BoardCode = " + parentId;
                }
                else if (table.Equals("customerToCountry"))
                {
                    updateString = "UPDATE " + table + " SET CountryID = " + childId + " WHERE CustomerID = " + parentId;
                }
                update(updateString);
            }
            catch (InvalidOperationException ioex)
            {
                throw new InvalidOperationException("Unable to update connections between tables: " + ioex.Message);
            }
        }


        public static void insertChildId(int parentId, int childId, string table)
        {
            try
            {
                Insert("INSERT INTO " + table + " OUTPUT INSERTED.ID VALUES (" + parentId + ", " + childId + ");");
            }
            catch (InvalidOperationException ioex)
            {
                throw new InvalidOperationException("Unable to new connection between tables: " + ioex.Message);
            }
        }
        #endregion

        #region messageBoxes
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
        #endregion

        #region sql commands
        /// <summary>
        /// Inserts the new entry into the table
        /// </summary>
        /// <param name="insert"></param>
        public static int Insert(string insert)
        {
            /*using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                try
                {
                    iDbCon.Execute(insert);
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("An error occurred when attempting to insert: " + sqlex.Message, "Error");
                }
            }*/
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
            using (SqlCommand cmd = new SqlCommand(insert, con))
            {
                con.Open();

                int modified = (int)cmd.ExecuteScalar();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                return modified;
            }
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
        #endregion

        #region get object methods
        /// <summary>
        /// Returns an ecu object based on the given boardCode
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static ECU_MainSettings getECUByBC(int boardCode)
        {
            String query = "SELECT * FROM mainSettingsTable WHERE BoardCode = '" + boardCode + "'";

            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                ECU_MainSettings[] ecus = iDbCon.Query<ECU_MainSettings>(query).ToArray();
                if (ecus.Length != 0)
                {
                    return ecus[0];
                }
                else
                {
                    throw new InvalidOperationException("ECU with board code " + boardCode + " not found");
                }
            }
        }

        /// <summary>
        /// Returns pressureGroup object based on the given id
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static PressureGroupObject getPGByID(int Id)
        {
            String query = "SELECT * FROM pressureGroupsTable WHERE Id = '" + Id + "'";

            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                PressureGroupObject[] pgs = iDbCon.Query<PressureGroupObject>(query).ToArray();
                if (pgs.Length != 0)
                {
                    return pgs[0];
                }
                else
                {
                    throw new InvalidOperationException("Pressure Group with ID " + Id + " not found");
                }
            }
        }

        /// <summary>
        /// Returns a customer object based on the given id
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static customerObject getCustomerByID(int Id)
        {
            String query = "SELECT * FROM customerTable WHERE Id = '" + Id + "'";

            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                customerObject[] customers = iDbCon.Query<customerObject>(query).ToArray();
                if (customers.Length != 0)
                {
                    return customers[0];
                }
                else
                {
                    throw new InvalidOperationException("Customer with ID " + Id + " not found");
                }
            }
        }


        /// <summary>
        /// Returns a countryObject based on the given ID
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static CountryObject getCountryByID(int id)
        {
            String query = "SELECT * FROM countryCodeTable WHERE Id = '" + id + "'";

            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                CountryObject[] countries = iDbCon.Query<CountryObject>(query).ToArray();
                if (countries.Length != 0)
                {
                    return countries[0];
                }
                else
                {
                    throw new InvalidOperationException("Country with ID " + id + " not found");
                }
            }
        }
        #endregion

        #region check methods
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
                return null;
            }
            if (s.Length > 50)
            {
                throw new InvalidOperationException("Input '" + s + "' is too long!");
            }
            return s;
        }

        /// <summary>
        /// Checks that the string is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckLongString(string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException("Country cannot be null!");
            }
            if (s == null && allowNull)
            {
                return null;
            }
            return s;
        }

        /// <summary>
        /// Checks that the string is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int CheckInt(string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException("Country cannot be null!");
            }
            int i;
            if (!Int32.TryParse(s, out i))
            {
                throw new InvalidOperationException("Input '" + s + "' is not an integer");
            }
            return i;
        }

        /// <summary>
        /// Doesn't check anything, just wanted to keep naming consistent.
        /// Returns 1 if true, 0 if false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CheckBit(bool check)
        {
            if (check)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks the date is valid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CheckDate(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            DateTime dt;
            if (!DateTime.TryParse(s, out dt))
            {
                throw new InvalidOperationException("Input '" + dt + "' is not a valid date");
            }
            return dt.Date.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Checks the dateTime is valid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CheckDateTime(string s, bool allowNulls)
        {
            if (s == null && !allowNulls)
            {
                throw new InvalidOperationException("One or more required fields were left empty");
            }
            DateTime dt;
            if (!DateTime.TryParse(s, out dt))
            {
                throw new InvalidOperationException("Input '" + dt + "' is not a valid date");
            }
            return dt.ToString("MM/dd/yyyy HH:mm");
        }

        /// <summary>
        /// Returns the given string enclosed in ''
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string enclose(string s)
        {
            return "'" + s + "'";
        }

        /// <summary>
        /// Checks for duplicates of the given string in the given table's given column
        /// </summary>
        /// <param name="s"></param>
        /// <param name="column"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static void CheckForDuplicates(string s, string column, string table, int id)
        {
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
            SqlCommand cmd;
            if (id == -1) //find ALL duplicates
            {
                cmd = new SqlCommand("SELECT * FROM " + table + " WHERE " + column + " = '" + s + "'");
            }
            else //find where the IDs do not match
            {
                cmd = new SqlCommand("SELECT * FROM " + table + " WHERE " + column + " = '" + s + "' AND Id != " + id, con);
            }
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //Duplicates were found
                {
                    throw new InvalidOperationException(column + " '" + s + "' already exists in the table");
                }
                con.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message ,"Error");
            }
        }

        /// <summary>
        /// Checks that the country code is valid and returns it
        /// This must be used instead of the regular CheckString method as the code must be 3 characters
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckCountryCode(string code)
        {
            if (code == null)
            {
                throw new InvalidOperationException("Code cannot be null!");
            }
            if (code.Length != 3)
            {
                throw new InvalidOperationException("Code '" + code + "' is the incorrect length (needs to be 3 characters)");
            }
            return code;
        }
        #endregion

        #region ASCII Conversion
        /// <summary>
        /// Converts an array of strings after turning it into a string of decimals
        /// </summary>
        /// <param name="input"></param>
        public static string convertToDecimal(List<string> input)
        {
            string output = "";
            foreach (string item in input)
            {
                char[] itemAsChars = item.ToCharArray();
                foreach (var value in itemAsChars)
                {
                    output += (decimal)value;
                }
                output += ",";
            }
            output += "13";
            return output;
        }
        #endregion
    }
}
