using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TractionAir.Forms
{
    public partial class backupRestoreForm : Form
    {
        SqlConnection con = new SqlConnection(ECU_Manager.connection("ecuSettingsDB_CS"));
        ToolStripProgressBar progressBar;

        public backupRestoreForm(ToolStripProgressBar progressBar)
        {
            this.progressBar = progressBar;
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                backupLocationTextbox.Text = dlg.SelectedPath;
                backupButton.Enabled = true;
            }
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            try
            {
                if (backupLocationTextbox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter backup file location", "Invalid Input");
                }
                else
                {
                    progressBar.Value = 10;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    string database = con.Database.ToString();
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + backupLocationTextbox.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                    using(SqlCommand command = new SqlCommand(cmd, con))
                    {
                        progressBar.Value = 20;
                        command.ExecuteNonQuery();
                        con.Close();
                        progressBar.Value = 100;
                        MessageBox.Show("Database backup completed successfully");
                        backupButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            progressBar.Value = 0;
        }

        private void browseButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database Restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                restoreLocationTextbox.Text = dlg.FileName;
                restoreButton.Enabled = true;
            }
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            try
            {
                progressBar.Value = 10;
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                string database = con.Database.ToString();

                progressBar.Value = 30;
                string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                progressBar.Value = 50;
                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + restoreLocationTextbox.Text + "'WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                progressBar.Value = 70;
                string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();

                progressBar.Value = 100;
                MessageBox.Show("Database restoration completed successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            progressBar.Value = 0;
        }
    }
}
