using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public queryForm()
        {
            InitializeComponent();
            //tabControl1.SelectedTab = queryTab; from when there was a "saved queries" tab
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

        /// <summary>
        /// Saves the query in the "Saved Queries" tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveQueryButton_Click(object sender, EventArgs e)
        {
            queryNameForm queryName = new queryNameForm();
            queryName.ShowDialog();
        }

        #region operator buttons
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

        private void operatorButton2_Click(object sender, EventArgs e)
        {
            string text = operatorButton2.Text;

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
            operatorButton2.Text = text;
        }

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
