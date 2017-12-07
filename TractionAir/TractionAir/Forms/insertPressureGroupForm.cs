using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractionAir
{
    public partial class insertPressureGroupForm : Form
    {

        public insertPressureGroupForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inserts the new record into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
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
            this.Close();
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
