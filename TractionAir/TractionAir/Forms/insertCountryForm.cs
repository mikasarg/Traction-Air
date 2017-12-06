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

namespace TractionAir.Forms
{
    public partial class insertCountryForm : Form
    {
        public insertCountryForm()
        {
            InitializeComponent();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO countryCodeTable VALUES (";
            try
            {
                insert += ECU_Manager.CheckCountryCode(codeTextbox.Text, -1) + ", ";
                string country = ECU_Manager.CheckString(countryTextbox.Text, false);
                country = ECU_Manager.CheckForDuplicates(country, "Country", "countryCodeTable", -1);
                insert += country + ")";
            }
            catch(InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            ECU_Manager.Insert(insert);
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
