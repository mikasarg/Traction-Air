using Dapper;
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
using TractionAir.Forms;

namespace TractionAir
{
    public partial class queryForm : Form
    {
        private DataGridView dgv;

        public queryForm(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        /// <summary>
        /// Queries the main settings table with the given values and conditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryButton_Click(object sender, EventArgs e)
        {
            bool conditions = false;
            string query = "SELECT * FROM mainSettingsTable WHERE ";

            if (!boardCodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "BoardCode " + operatorButton1.Text + " " + boardCodeTextbox.Text + " AND ";
            }
            if (!ownerTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "Owner LIKE '%" + ownerTextbox.Text + "%' AND ";
            }
            if (!descriptionTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "Description LIKE '%" + descriptionTextbox.Text + "%' AND ";
            }
            if (!vehicleRefTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "VehicleRef LIKE '%" + vehicleRefTextbox.Text + "%' AND ";
            }
            if (!gpsComboBox.Text.Equals(""))
            {
                conditions = true;
                if (gpsComboBox.Text.Equals("Yes"))
                {
                    query += "EnableGPSOverride = 1 AND ";
                }
                else //No
                {
                    query += "EnableGPSOverride = 0 AND ";
                }
            }
            if (!distanceTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "Distance " + operatorButton3.Text + " " + distanceTextbox.Text + " AND ";
            }
            if (!pressureCellTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PresureCell " + operatorButton4.Text + " " + pressureCellTextbox.Text + " AND ";
            }
            if (!pt1CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT1Serial LIKE '%" + pt1CodeTextbox.Text + "%' AND ";
            }
            if (!pt2CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT2Serial LIKE '%" + pt2CodeTextbox.Text + "%' AND ";
            }
            if (!pt3CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT3Serial LIKE '%" + pt3CodeTextbox.Text + "%' AND ";
            }
            if (!pt4CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT4Serial LIKE '%" + pt4CodeTextbox.Text + "%' AND ";
            }
            if (!pt5CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT5Serial LIKE '%" + pt5CodeTextbox.Text + "%' AND ";
            }
            if (!pt6CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT6Serial LIKE '%" + pt6CodeTextbox.Text + "%' AND ";
            }
            if (!pt7CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT7Serial LIKE '%" + pt7CodeTextbox.Text + "%' AND ";
            }
            if (!pt8CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT8Serial LIKE '%" + pt8CodeTextbox.Text + "%' AND ";
            }

            if (!conditions) //nothing entered
            {
                clearButton_Click(null, null);
            }

            query = query.Substring(0, query.Length - 5); //removes the last " AND "

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS"))))
                {
                    DataTable ecus = new DataTable();
                    adapter.Fill(ecus);
                    dgv.DataSource = ecus;
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Error");
                return;
            }

            this.Close();
        }

        /// <summary>
        /// Clears all textboxes in the window and reverts the datagridview back to normal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            DataTable mainSettingsTable = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM mainSettingsTable", new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS"))))
                {
                    adapter.Fill(mainSettingsTable);
                    dgv.DataSource = mainSettingsTable;
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Error");
                return;
            }

            this.Close();
        }

        /// <summary>
        /// Closes the window without querying anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region operator buttons
        // BOARD CODE
        private void operatorButton1_Click(object sender, EventArgs e)
        {
            string text = operatorButton1.Text;

            if (text.Equals("="))
            {
                text = ">";
            }
            else if (text.Equals(">"))
            {
                text = "<";
            }
            else //<
            {
                text = "=";
            }
            operatorButton1.Text = text;
        }

        // DISTANCE (KM)
        private void operatorButton3_Click(object sender, EventArgs e)
        {
            string text = operatorButton3.Text;

            if (text.Equals("="))
            {
                text = ">";
            }
            else if (text.Equals(">"))
            {
                text = "<";
            }
            else //<
            {
                text = "=";
            }
            operatorButton3.Text = text;
        }

        // PRESSURE CELL
        private void operatorButton4_Click(object sender, EventArgs e)
        {
            string text = operatorButton4.Text;

            if (text.Equals("="))
            {
                text = ">";
            }
            else if (text.Equals(">"))
            {
                text = "<";
            }
            else //<
            {
                text = "=";
            }
            operatorButton4.Text = text;
        }
        #endregion
    }
}
