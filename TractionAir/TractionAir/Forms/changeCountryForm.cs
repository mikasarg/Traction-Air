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
    public partial class changeCountryForm : Form
    {
        private int id;

        public changeCountryForm(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        /// <summary>
        /// Updates the table with the given changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            string update = "UPDATE countryCodeTable SET ";
            try
            {
                string code = ECU_Manager.CheckCountryCode(codeTextbox.Text);
                ECU_Manager.CheckForDuplicates(code, "Code", "countryCodeTable", id); //checks for no duplicates - unless they have the same ID
                update += "Code = " + ECU_Manager.enclose(code) + ", "; 
                string country = ECU_Manager.CheckString(countryTextbox.Text, false);
                ECU_Manager.CheckForDuplicates(country, "Country", "countryCodeTable", id);
                update += "Country = " + ECU_Manager.enclose(country) + " WHERE Id = " + id; 
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            ECU_Manager.update(update); //ecu manager handles sql command
            this.Close();
        }

        /// <summary>
        /// Cancels the change operation
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

        /// <summary>
        /// loads the values from the selected row into the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeCountryForm_Load(object sender, EventArgs e)
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);
            try
            {
                CountryObject country = ECU_Manager.getCountryByID(id); //Obtains a countryObject
                codeTextbox.Text = country.Code;
                countryTextbox.Text = country.Country;
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Error");
            }

        }
    }
}
