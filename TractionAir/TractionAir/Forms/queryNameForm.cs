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
    public partial class queryNameForm : Form
    {
        public queryNameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves the query as the name given by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO check if valid input then check if already exists then save
            this.Close();
        }

        /// <summary>
        /// Cancels the query save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
