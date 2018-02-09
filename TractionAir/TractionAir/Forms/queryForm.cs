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
                query += "BoardCode " + operatorButton1.Text + " @boardCode AND ";
            }
            if (!ownerTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "Owner LIKE '%@owner%' AND ";
            }
            if (!descriptionTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "Description LIKE '%@description%' AND ";
            }
            if (!vehicleRefTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "VehicleRef LIKE '%@vehicleRef%' AND ";
            }
            if (!distanceTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "Distance " + operatorButton3.Text + " @distance AND ";
            }
            if (!pressureCellTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PressureCell " + operatorButton4.Text + " @pressureCell AND ";
            }
            if (!pt1CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT1Serial LIKE '%@pt1Code%' AND ";
            }
            if (!pt2CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT2Serial LIKE '%@pt2Code%' AND ";
            }
            if (!pt3CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT3Serial LIKE '%@pt3Code%' AND ";
            }
            if (!pt4CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT4Serial LIKE '%@pt4Code%' AND ";
            }
            if (!pt5CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT5Serial LIKE '%@pt5Code%' AND ";
            }
            if (!pt6CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT6Serial LIKE '%@pt6Code%' AND ";
            }
            if (!pt7CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT7Serial LIKE '%@pt7Code%' AND ";
            }
            if (!pt8CodeTextbox.Text.Equals(""))
            {
                conditions = true;
                query += "PT8Serial LIKE '%@pt8Code%' AND ";
            }

            if (!conditions) //nothing entered
            {
                clearButton_Click(null, null);
            }

            query = query.Substring(0, query.Length - 5); //removes the last " AND "

            try
            {
                SqlConnection con = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS"));
                SqlCommand command = new SqlCommand(query, con);

                //ADDING PARAMETERS

                if (!boardCodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@boardCode", SqlDbType.Int);
                    command.Parameters["@boardCode"].Value = boardCodeTextbox.Text;
                }
                if (!ownerTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@owner", SqlDbType.NVarChar);
                    command.Parameters["@owner"].Value = ownerTextbox.Text;
                }
                if (!descriptionTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@description", SqlDbType.NVarChar);
                    command.Parameters["@description"].Value = descriptionTextbox.Text;
                }
                if (!vehicleRefTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@vehicleRef", SqlDbType.NVarChar);
                    command.Parameters["@vehicleRef"].Value = vehicleRefTextbox.Text;
                }
                if (!distanceTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@distance", SqlDbType.Int);
                    command.Parameters["@distance"].Value = distanceTextbox.Text;
                }
                if (!pressureCellTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pressureCell", SqlDbType.Int);
                    command.Parameters["@pressureCell"].Value = pressureCellTextbox.Text;
                }
                if (!pt1CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt1Code", SqlDbType.NVarChar);
                    command.Parameters["@pt1Code"].Value = pt1CodeTextbox.Text;
                }
                if (!pt2CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt2Code", SqlDbType.NVarChar);
                    command.Parameters["@pt2Code"].Value = pt2CodeTextbox.Text;
                }
                if (!pt3CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt3Code", SqlDbType.NVarChar);
                    command.Parameters["@pt3Code"].Value = pt3CodeTextbox.Text;
                }
                if (!pt4CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt4Code", SqlDbType.NVarChar);
                    command.Parameters["@pt4Code"].Value = pt4CodeTextbox.Text;
                }
                if (!pt5CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt5Code", SqlDbType.NVarChar);
                    command.Parameters["@pt5Code"].Value = pt5CodeTextbox.Text;
                }
                if (!pt6CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt6Code", SqlDbType.NVarChar);
                    command.Parameters["@pt6Code"].Value = pt6CodeTextbox.Text;
                }
                if (!pt7CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt7Code", SqlDbType.NVarChar);
                    command.Parameters["@pt7Code"].Value = pt7CodeTextbox.Text;
                }
                if (!pt8CodeTextbox.Text.Equals(""))
                {
                    command.Parameters.Add("@pt8Code", SqlDbType.NVarChar);
                    command.Parameters["@pt8Code"].Value = pt8CodeTextbox.Text;
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable ecus = new DataTable();
                    adapter.Fill(ecus);
                    if (ecus.Rows.Count == 0)
                    {
                        MessageBox.Show("No results found for the given query");
                        return;
                    }
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
