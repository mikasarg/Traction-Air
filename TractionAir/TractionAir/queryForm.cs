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
    public partial class queryForm : Form
    {
        public queryForm()
        {
            InitializeComponent();
            tabControl1.SelectedTab = queryTab;
        }

        /// <summary>
        /// Queries the database with the given values and conditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryButton_Click(object sender, EventArgs e)
        {
            //TODO query the database
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
    }
}
