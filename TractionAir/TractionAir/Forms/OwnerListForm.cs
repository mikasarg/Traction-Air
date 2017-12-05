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
    public partial class OwnerListForm : Form
    {
        public OwnerListForm()
        {
            InitializeComponent();
        }

        private void customerTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ecuSettingsDatabaseDataSet);

        }

        private void OwnerListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuSettingsDatabaseDataSet.customerTable' table. You can move, or remove it, as needed.
            this.customerTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.customerTable);

        }

        private void insertButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Deletes the selected entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (ECU_Manager.wishToDelete())
            {
                //TODO delete the selected entry
            }
            else
            {
                return;
            }
        }
    }
}
