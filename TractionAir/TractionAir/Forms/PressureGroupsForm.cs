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
    public partial class PressureGroupsForm : Form
    {
        public PressureGroupsForm()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pressureGroupsDataSet);

        }

        /// <summary>
        /// loads the pressure groups data into the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressureGroupsForm_Load(object sender, EventArgs e)
        {
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
        }

        /// <summary>
        /// Opens an insert window for the user to specify a new pressure group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            insertPressureGroupForm insertion = new insertPressureGroupForm("", 0, 0, 0, 0, 0);
            insertion.ShowDialog();
            refreshTable();
        }

        /// <summary>
        /// Deletes the selected pressure group from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!ECU_Manager.wishToDelete())
            {
                return;
            }
            if (pressureGroupsTableDataGridView.SelectedRows.Count == 0) //no selected rows
            {
                return;
            }
            DataGridViewRow selectedRow = pressureGroupsTableDataGridView.SelectedRows[0];
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out int id))
            {
                string delete = "DELETE FROM pressureGroupsTable WHERE Id = @pressureGroupId;";
                try
                {
                    using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                    {
                        SqlCommand command = new SqlCommand(delete, connection);
                        command.Parameters.Add("@pressureGroupId", SqlDbType.Int);
                        command.Parameters["@pressureGroupId"].Value = ECU_Manager.CheckBigInt("Pressure Group ID", id.ToString(), false);

                        try
                        {
                            connection.Open();
                            command.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not delete the pressure group. Make sure no ECUs have this group listed as theirs.", "Error");
                        }
                    }
                }
                catch (InvalidOperationException ioex)
                {
                    MessageBox.Show(ioex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Could not delete selected entry as its ID was in the incorrect format.", "Error");
            }
            refreshTable();
        }

        /// <summary>
        /// Allows the user to change the selected entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            if (pressureGroupsTableDataGridView.SelectedRows.Count == 0) //no selected rows
            {
                return;
            }
            DataGridViewRow selectedRow = pressureGroupsTableDataGridView.SelectedRows[0];
            int id;
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out id))
            {
                changePressureGroupForm changePressureGroup = new changePressureGroupForm(id); //loads a form to change the entry
                changePressureGroup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not change selected entry as its ID was in the incorrect format.");
            }
            refreshTable();
        }

        /// <summary>
        /// Refreshes the datagridview
        /// </summary>
        private void refreshTable()
        {
            this.pressureGroupsTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.pressureGroupsTable);
            pressureGroupsTableDataGridView.Update();
            pressureGroupsTableDataGridView.Refresh();
        }

        private void pressureGroupsTableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeButton_Click(sender, e);
        }
    }
}
