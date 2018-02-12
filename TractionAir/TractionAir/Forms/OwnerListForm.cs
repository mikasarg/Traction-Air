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
    public partial class OwnerListForm : Form
    {
        public OwnerListForm()
        {
            InitializeComponent();
        }

        private void OwnerListForm_Load(object sender, EventArgs e)
        {
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            insertOwnerForm insertOwner = new insertOwnerForm();
            insertOwner.ShowDialog();
            refreshTable();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (customerTableDataGridView.SelectedRows.Count == 0) //no selected rows
            {
                return;
            }
            DataGridViewRow selectedRow = customerTableDataGridView.SelectedRows[0];
            int id;
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out id))
            {
                changeOwnerForm changeOwner = new changeOwnerForm(id); //loads a form to change the entry
                changeOwner.ShowDialog();
            }
            else
            {
                MessageBox.Show("Could not change selected entry as its ID was in the incorrect format.");
            }
            refreshTable();
        }

        /// <summary>
        /// Deletes the selected entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!ECU_Manager.wishToDelete())
            {
                return;
            }
            if (customerTableDataGridView.SelectedRows.Count == 0) //no selected rows
            {
                return;
            }
            DataGridViewRow selectedRow = customerTableDataGridView.SelectedRows[0];
            if (Int32.TryParse(selectedRow.Cells["idColumn"].Value.ToString(), out int id))
            {
                string delete1 = "DELETE FROM customerToCountry WHERE CustomerID = @customerId;";
                string delete2 = "DELETE FROM customerTable WHERE Id = @customerId;";
                try
                {
                    using (SqlConnection connection = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
                    {
                        SqlCommand command1 = new SqlCommand(delete1, connection);
                        command1.Parameters.Add("@customerId", SqlDbType.Int);
                        command1.Parameters["@customerId"].Value = ECU_Manager.CheckBigInt("Customer ID", id.ToString(), false);

                        SqlCommand command2 = new SqlCommand(delete2, connection);
                        command2.Parameters.Add("@customerId", SqlDbType.Int);
                        command2.Parameters["@customerId"].Value = ECU_Manager.CheckBigInt("Customer ID", id.ToString(), false);

                        try
                        {
                            connection.Open();
                            command1.ExecuteScalar(); //Must first delete connections in connecting table
                            command2.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Could not delete the customer. Make sure no ECUs have this customer listed as their owner.", "Error");
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
        /// Refreshes the datagridview
        /// </summary>
        private void refreshTable()
        {
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);
            customerTableDataGridView.Update();
            customerTableDataGridView.Refresh();
        }

        private void customerTableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeButton_Click(sender, e);
        }
    }
}
