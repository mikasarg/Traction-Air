using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractionAir
{
    public partial class insertPressureGroupForm : Form
    {

        public insertPressureGroupForm(string desc, int loadedOn, int loadedOff, int unloadedOn, int unloadedOff, int maxTraction)
        {
            InitializeComponent();

            descriptionTextbox.Text = desc;
            loadedOnRoadTextbox.Text = loadedOn.ToString();
            loadedOffRoadTextbox.Text = loadedOff.ToString();
            unloadedOnRoadTextbox.Text = unloadedOn.ToString();
            unloadedOffRoadTextbox.Text = unloadedOff.ToString();
            maxTractionTextbox.Text = maxTraction.ToString();
        }

        /// <summary>
        /// Inserts the new record into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO pressureGroupsTable VALUES (@description, @loadedOnRoad, @loadedOffRoad, @unloadedOnRoad, @maxTraction, @dateMod, @unloadedOffRoad);";
            try
            {
                string description = ECU_Manager.CheckString(descriptionTextbox.Text, false);
                ECU_Manager.CheckDuplicatePressureGroup(description, -1); //check for a duplicate description
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command = new SqlCommand(insert, connection);
                    command.Parameters.Add("@description", SqlDbType.NVarChar);
                    command.Parameters["@description"].Value = description;
                    command.Parameters.Add("@loadedOnRoad", SqlDbType.SmallInt);
                    command.Parameters["@loadedOnRoad"].Value = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, false);
                    command.Parameters.Add("@loadedOffRoad", SqlDbType.SmallInt);
                    command.Parameters["@loadedOffRoad"].Value = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, false);
                    command.Parameters.Add("@unloadedOnRoad", SqlDbType.SmallInt);
                    command.Parameters["@unloadedOnRoad"].Value = ECU_Manager.CheckInt(unloadedOnRoadTextbox.Text, false);
                    command.Parameters.Add("@maxTraction", SqlDbType.SmallInt);
                    command.Parameters["@maxTraction"].Value = ECU_Manager.CheckInt(maxTractionTextbox.Text, false);
                    command.Parameters.Add("@dateMod", SqlDbType.DateTime);
                    command.Parameters["@dateMod"].Value = DateTime.Now;
                    command.Parameters.Add("@unloadedOffRoad", SqlDbType.SmallInt);
                    command.Parameters["@unloadedOffRoad"].Value = ECU_Manager.CheckInt(unloadedOffRoadTextbox.Text, false);
                    try
                    {
                        connection.Open();
                        command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                Close();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            /*
            string insert = "INSERT INTO pressureGroupsTable VALUES (";
            try
            {
                //Check the values are valid
                string description = ECU_Manager.CheckString(descriptionTextbox.Text, false);
                ECU_Manager.CheckForDuplicates(description, "Description", "pressureGroupsTable", -1); //given ID is -1 as we want to find any and all duplicates
                insert += ECU_Manager.enclose(description) + ", ";

                int loadedOnRoad = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, true);
                insert += loadedOnRoad + ", ";

                int loadedOffRoad = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, true);
                insert += loadedOffRoad + ", ";

                int unloadedOnRoad = ECU_Manager.CheckInt(unloadedOnRoadTextbox.Text, true);
                insert += unloadedOnRoad + ", ";

                int maxTraction = ECU_Manager.CheckInt(maxTractionTextbox.Text, true);
                insert += maxTraction + ", ";

                string dateMod = ECU_Manager.CheckDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), false);
                insert += ECU_Manager.enclose(dateMod) + ")";
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            ECU_Manager.Insert(insert); //ECU manager handles the sql command
            this.Close();*/
        }

        /// <summary>
        /// Cancels the insertion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (ECU_Manager.wishToCancel())
            {
                this.Close();
            }
            return;
        }
    }
}
