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

        /// <summary>
        /// Inserts the given values into the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO countryCodeTable VALUES (";
            try
            {
                //Check the values are valid
                string code = ECU_Manager.CheckCountryCode(codeTextbox.Text);
                ECU_Manager.CheckForDuplicates(code, "Code", "countryCodeTable", -1); //given ID is -1 as we want to find any and all duplicates
                insert += ECU_Manager.enclose(code) + ", ";
                string country = ECU_Manager.CheckString(countryTextbox.Text, false);
                ECU_Manager.CheckForDuplicates(country, "Country", "countryCodeTable", -1);
                insert += ECU_Manager.enclose(country) + ")";
            }
            catch(InvalidOperationException ioex)
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
