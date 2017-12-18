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

namespace TractionAir.Forms
{
    public partial class changePressureGroupForm : Form
    {
        private int id;

        public changePressureGroupForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        /// <summary>
        /// Updates the table with the given changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            string update = "UPDATE pressureGroupsTable SET Description = @description, LoadedOnRoad = @loadedOnRoad, LoadedOffRoad = @loadedOffRoad, UnloadedOnRoad = @unloadedOnRoad, MaxTraction = @maxTraction, DateMod = @dateMod WHERE Id = @id;";
            try
            {
                using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                {
                    SqlCommand command = new SqlCommand(update, connection);
                    command.Parameters.Add("@description", SqlDbType.NVarChar);
                    command.Parameters["@description"].Value = ECU_Manager.CheckString(descriptionTextbox.Text, false);
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
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters["@id"].Value = id;

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
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Cancels the change operation
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

        private void changePressureGroupForm_Load(object sender, EventArgs e)
        {
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            try
            {
                PressureGroupObject pressureGroup = ECU_Manager.getPGByID(id); //Obtains a pressureGroupObject
                descriptionTextbox.Text = pressureGroup.Description;
                loadedOnRoadTextbox.Text = pressureGroup.LoadedOnRoad.ToString();
                loadedOffRoadTextbox.Text = pressureGroup.LoadedOffRoad.ToString();
                unloadedOnRoadTextbox.Text = pressureGroup.UnloadedOnRoad.ToString();
                maxTractionTextbox.Text = pressureGroup.MaxTraction.ToString();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Error");
            }
        }
    }
}
