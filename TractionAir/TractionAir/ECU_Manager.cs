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
        /// <summary>
        /// Takes a board code and returns a version ID
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static int EcuToVersion(int boardCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT VersionID FROM ecuToVersion WHERE BoardCode = @bc";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@bc", SqlDbType.Int);
                command.Parameters["@bc"].Value = boardCode;
                Int32 versionId = (Int32)command.ExecuteScalar();
                con.Close();
                return versionId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Takes a board code and returns a board version ID
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static int EcuToBoardVersion(int boardCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT VersionID FROM ecuToBoardVersion WHERE BoardCode = @bc";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@bc", SqlDbType.Int);
                command.Parameters["@bc"].Value = boardCode;
                Int32 versionId = (Int32)command.ExecuteScalar();
                con.Close();
                return versionId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Returns the country that an ecu belongs to
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static int EcuToCountry(int boardCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT CountryID FROM ecuToCountry WHERE BoardCode = @bc";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@bc", SqlDbType.Int);
                command.Parameters["@bc"].Value = boardCode;
                Int32 countryId = (Int32)command.ExecuteScalar();
                con.Close();
                return countryId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Returns the speedcontrolID for a given ECU
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static int EcuToSpeedControl(int boardCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT SpeedControlID FROM ecuToSpeedControl WHERE BoardCode = @bc";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@bc", SqlDbType.Int);
                command.Parameters["@bc"].Value = boardCode;
                Int32 speedControlId = (Int32)command.ExecuteScalar();
                con.Close();
                return speedControlId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Returns a pressure group ID for a given ECU
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static int EcuToPressureGroup(int boardCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT PressureGroupID FROM ecuToPressureGroup WHERE BoardCode = @bc";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@bc", SqlDbType.Int);
                command.Parameters["@bc"].Value = boardCode;
                Int32 pressureGroupId = (Int32)command.ExecuteScalar();
                con.Close();
                return pressureGroupId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Returns the customer ID for the owner of the given ecu
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static int EcuToCustomer(int boardCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT CustomerID FROM ecuToCustomer WHERE BoardCode = @bc";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@bc", SqlDbType.Int);
                command.Parameters["@bc"].Value = boardCode;
                Int32 customerId = (Int32)command.ExecuteScalar();
                con.Close();
                return customerId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Returns the country ID that a given customer is based in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int CustomerToCountry(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                string query = "SELECT CountryID FROM customerToCountry WHERE CustomerID = @id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                Int32 countryId = (Int32)command.ExecuteScalar();
                con.Close();
                return countryId;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to locate ID of connected table row: " + e.Message);
            }
        }

        /// <summary>
        /// Adds the given board version number to the table if it doesn't exist already
        /// </summary>
        public static void AddBoardVersionIfDoesntExist(string version)
        {

            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                String boardversion = "V" + version;
                String query = "SELECT * FROM boardVersionTable WHERE Version = @version";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@version", SqlDbType.NVarChar);
                command.Parameters["@version"].Value = boardversion;
                try
                {
                    Int32 countryId = (Int32)command.ExecuteScalar();
                }
                catch (Exception e) //version not found, must insert new version
                {
                    String insert = "INSERT INTO boardVersionTable VALUES (@version);";
                    SqlCommand command2 = new SqlCommand(insert, con);
                    command2.Parameters.Add("@version", SqlDbType.NVarChar);
                    command2.Parameters["@version"].Value = boardversion;
                    command2.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to insert new board version: " + e.Message);
            }
        }

        /// <summary>
        /// Adds the given version number to the table if it doesn't exist already
        /// </summary>
        public static void AddVersionIfDoesntExist(string version)
        {

            try
            {
                SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
                con.Open();
                String progversion = "V" + version;
                String query = "SELECT * FROM programVersionTable WHERE Version = @version";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add("@version", SqlDbType.NVarChar);
                command.Parameters["@version"].Value = progversion;
                try
                {
                    Int32 countryId = (Int32)command.ExecuteScalar();
                }
                catch (Exception e) //version not found, must insert new version
                {
                    String insert = "INSERT INTO programVersionTable VALUES (@version);";
                    SqlCommand command2 = new SqlCommand(insert, con);
                    command2.Parameters.Add("@version", SqlDbType.NVarChar);
                    command2.Parameters["@version"].Value = progversion;
                    command2.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Unable to insert new program version: " + e.Message);
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

        #region get object methods
        /// <summary>
        /// Returns an ecu object based on the given boardCode
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static ECU_MainSettings getECUByBC(int boardCode)
        {
            String query = $"SELECT * FROM mainSettingsTable WHERE BoardCode = '{ boardCode }'";

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
            String query = $"SELECT * FROM pressureGroupsTable WHERE Id = '{ Id }'";

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
            String query = $"SELECT * FROM customerTable WHERE Id = '{ Id }'";

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
            String query = $"SELECT * FROM countryCodeTable WHERE Id = '{ id }'";

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

        /// <summary>
        /// Returns the latest pressureGroup to be added
        /// </summary>
        /// <param name="boardCode"></param>
        /// <returns></returns>
        public static PressureGroupObject getLatestPG()
        {
            String query = $"SELECT * FROM pressureGroupsTable";
            int max = 0;
            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                PressureGroupObject[] pgs = iDbCon.Query<PressureGroupObject>(query).ToArray();
                foreach (PressureGroupObject pg in pgs)
                {
                    if (pg.Id > max)
                    {
                        max = pg.Id;
                    }
                }
            }
            return getPGByID(max);
        }

        /// <summary>
        /// Returns a pressure group ID based on the given PSI values
        /// </summary>
        /// <param name="loadedOn"></param>
        /// <param name="loadedOff"></param>
        /// <param name="unloadedOn"></param>
        /// <param name="unloadedOff"></param>
        /// <param name="maxTraction"></param>
        /// <returns></returns>
        public static int FindPressureGroupByPSIs(int loadedOn, int loadedOff, int unloadedOn, int unloadedOff, int maxTraction)
        {
            String query = $"SELECT * FROM pressureGroupsTable WHERE loadedOnRoad = '{ loadedOn }' AND loadedOffRoad = '{ loadedOff }' AND unloadedOnRoad = '{ unloadedOn }' AND unloadedOffRoad = '{ unloadedOff }' AND maxTraction = '{ maxTraction }'";

            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                PressureGroupObject[] pgs = iDbCon.Query<PressureGroupObject>(query).ToArray();
                if (pgs.Length != 0)
                {
                    return pgs[0].Id;
                }
                else
                {
                    return -1; //no pressure group with given psis found
                }
            }
        }
        #endregion

        #region check methods
        /// <summary>
        /// Converts a given 3-letter code to the relevant speed control.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CodeToSpeedControl(string code)
        {
            if (code.Equals("NSC"))
            {
                return "No Speed Control";
            }
            else if (code.Equals("L2P"))
            {
                return "Lower Two Pressures";
            }
            else if (code.Equals("L3P"))
            {
                return "Lower Three Pressures";
            }
            else if (code.Equals("L4P"))
            {
                return "Lower Four Pressures";
            }
            else if (code.Equals("OMT"))
            {
                return "Only Max Traction";
            }
            throw new InvalidOperationException("Speed Control '" + code + "' does not exist");
        }

        /// <summary>
        /// Checks that the string is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckString(string name, string s, bool allowNull)
        {
            if ((s == null || s.Equals("")) && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            if ((s == null || s.Equals("")) && allowNull)
            {
                return "";
            }
            if (s.Length > 50)
            {
                throw new InvalidOperationException(name + ": Input '" + s + "' is too long!");
            }
            return s;
        }

        /// <summary>
        /// Checks that the string is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckLongString(string name, string s, bool allowNull)
        {
            if ((s == null || s.Equals("")) && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            if ((s == null || s.Equals("")) && allowNull)
            {
                return "";
            }
            return s;
        }

        /// <summary>
        /// Checks that the int is valid and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int CheckBigInt(string name, string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            int i;
            if (!Int32.TryParse(s, out i))
            {
                throw new InvalidOperationException(name + ": Input '" + s + "' is not an integer");
            }
            return i;
        }

        /// <summary>
        /// Checks that the int is valid (1 digit) and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int Check1Int(string name, string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            int i;
            if (!Int32.TryParse(s, out i))
            {
                throw new InvalidOperationException(name + ": Input '" + s + "' is not an integer");
            }
            if (i < 0 || i > 9)
            {
                throw new InvalidOperationException(name + ": Input '" + i + "' must be between 0 and 9");
            }
            return i;
        }

        /// <summary>
        /// Checks that the int is valid (3 digits) and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int Check3Int(string name, string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            int i;
            if (!Int32.TryParse(s, out i))
            {
                throw new InvalidOperationException(name + ": Input '" + s + "' is not an integer");
            }
            if (i < 0 || i > 1000)
            {
                throw new InvalidOperationException(name + ": Input '" + i + "' must be up to 3 digits");
            }
            return i;
        }

        /// <summary>
        /// Checks that the int is valid (6 digits) and returns it
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int Check6Int(string name, string s, bool allowNull)
        {
            if (s == null && !allowNull)
            {
                throw new InvalidOperationException(name + ": A required input is null");
            }
            int i;
            if (!Int32.TryParse(s, out i))
            {
                throw new InvalidOperationException(name + ": Input '" + s + "' is not an integer");
            }
            if (i < 0 || i > 1000000)
            {
                throw new InvalidOperationException(name + ": Input '" + i + "' must be up to 6 digits");
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
        /// Checks that the country code is valid and returns it
        /// This must be used instead of the regular CheckString method as the code must be 3 characters
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CheckCountryCode(string code)
        {
            if (code == null)
            {
                throw new InvalidOperationException("Country Code cannot be null!");
            }
            if (code.Length != 3)
            {
                throw new InvalidOperationException("Code '" + code + "' is the incorrect length (needs to be 3 characters)");
            }
            return code;
        }

        /// <summary>
        /// Checks to see if there already exists an ecu with the given board code
        /// </summary>
        /// <param name="bc"></param>
        public static void CheckDuplicateECU(int bc)
        {
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
            SqlCommand cmd = new SqlCommand("SELECT * FROM mainSettingsTable WHERE BoardCode = @bc;");
            cmd.Connection = con;
            cmd.Parameters.Add("@bc", SqlDbType.Int);
            cmd.Parameters["@bc"].Value = bc;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //Duplicates were found
                {
                    throw new InvalidOperationException("ECU with board code " + bc + " already exists");
                }
                con.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Error");
            }
        }

        /// <summary>
        /// Checks to see if a pressure group with the given descrption already exists
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="id"></param>
        public static void CheckDuplicatePressureGroup(string desc, int id)
        {
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
            SqlCommand cmd = new SqlCommand("SELECT * FROM pressureGroupsTable WHERE Description = @desc AND Id != @id;");
            cmd.Connection = con;
            cmd.Parameters.Add("@desc", SqlDbType.NVarChar);
            cmd.Parameters["@desc"].Value = desc;
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //Duplicates were found
                {
                    throw new InvalidOperationException("Pressure group with name " + desc + " already exists");
                }
                con.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Error");
            }
        }

        /// <summary>
        /// Checks to see if a customer with the given name already exists
        /// </summary>
        /// <param name="company"></param>
        /// <param name="id"></param>
        public static void CheckDuplicateCustomer(string company, int id)
        {
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Company = @company AND Id != @id;");
            cmd.Connection = con;
            cmd.Parameters.Add("@company", SqlDbType.NVarChar);
            cmd.Parameters["@company"].Value = company;
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //Duplicates were found
                {
                    throw new InvalidOperationException("Customer with company name " + company + " already exists");
                }
                con.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Error");
            }
        }

        /// <summary>
        /// Checks to see if a country with the given code already exists
        /// </summary>
        /// <param name="code"></param>
        /// <param name="id"></param>
        public static void CheckDuplicateCountry(string code, int id)
        {
            SqlConnection con = new SqlConnection(connection("ecuSettingsDB_CS"));
            SqlCommand cmd = new SqlCommand("SELECT * FROM countryCodeTable WHERE Code = @code AND Id != @id;");
            cmd.Connection = con;
            cmd.Parameters.Add("@code", SqlDbType.NVarChar);
            cmd.Parameters["@code"].Value = code;
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //Duplicates were found
                {
                    throw new InvalidOperationException("Country with code " + code + " already exists");
                }
                con.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Error");
            }
        }

        /// <summary>
        /// Checks to see if the given values differ from the default for the pressure group
        /// </summary>
        /// <returns></returns>
        public static bool CheckDifferentPSIs(int id, int loadedOn, int loadedOff, int unloadedOn, int unloadedOff, int maxTraction)
        {
            PressureGroupObject pg = getPGByID(id);

            if (pg.LoadedOnRoad != loadedOn || pg.LoadedOffRoad != loadedOff || pg.UnloadedOnRoad != unloadedOn || pg.UnloadedOffRoad != unloadedOff || pg.MaxTraction != maxTraction)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the number of pressure groups in the table
        /// </summary>
        /// <returns></returns>
        public static int NumberOfPGs()
        {
            String query = $"SELECT * FROM pressureGroupsTable";

            using (IDbConnection iDbCon = new SqlConnection(connection("ecuSettingsDB_CS")))
            {
                PressureGroupObject[] pgs = iDbCon.Query<PressureGroupObject>(query).ToArray();
                return pgs.Length;
            }

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
