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
                update += "Code = " + ECU_Manager.CheckCountryCode(codeTextbox.Text, id) + ", ";
                string country = ECU_Manager.CheckString(countryTextbox.Text, false);
                country = ECU_Manager.CheckForDuplicates(country, "Country", "countryCodeTable", id);
                update += "Country = " + country + " WHERE Id = " + id;
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Invalid Input");
                return;
            }
            ECU_Manager.update(update);
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

        private void changeCountryForm_Load(object sender, EventArgs e)
        {
            this.countryCodeTableTableAdapter.Fill(this.ecuSettingsDatabaseDataSet.countryCodeTable);

            String query = "SELECT * FROM countryCodeTable WHERE Id = '" + id + "'";

            CountryObject country;

            using (IDbConnection iDbCon = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS")))
            {
                CountryObject[] countries = iDbCon.Query<CountryObject>(query).ToArray();
                country = countries[0];
            }
            codeTextbox.Text = country.Code;
            countryTextbox.Text = country.Country;
        }
    }
}
