using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            string update = "UPDATE pressureGroupsTable SET ";
            try
            {
                string description = ECU_Manager.CheckString(descriptionTextbox.Text, false);
                ECU_Manager.CheckForDuplicates(description, "Description", "pressureGroupsTable", id); //checks for no duplicates - unless they have the same ID
                update += "Description = " + ECU_Manager.enclose(description) + ", ";

                int loadedOnRoad = ECU_Manager.CheckInt(loadedOnRoadTextbox.Text, true);
                update += "LoadedOnRoad = " + loadedOnRoad + ", ";

                int loadedOffRoad = ECU_Manager.CheckInt(loadedOffRoadTextbox.Text, true);
                update += "LoadedOffRoad = " + loadedOffRoad + ", ";

                int unloadedOnRoad = ECU_Manager.CheckInt(unloadedOnRoadTextbox.Text, true);
                update += "UnloadedOnRoad = " + unloadedOnRoad + ", ";

                int maxTraction = ECU_Manager.CheckInt(maxTractionTextbox.Text, true);
                update += "MaxTraction = " + maxTraction + ", ";

                string dateMod = ECU_Manager.CheckDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), false);
                update += "DateMod = " + ECU_Manager.enclose(dateMod) + " WHERE Id = " + id;
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            ECU_Manager.update(update); //ecu manager handles sql command
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
