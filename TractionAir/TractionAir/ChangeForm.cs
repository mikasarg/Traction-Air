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
    public partial class ChangeForm : Form
    {
        DataGridViewRow row;
        List<Tuple<int, string>> changedBoxes;
        HashSet<int> previouslyVisited;

        public ChangeForm(DataGridViewRow row)
        {
            this.row = row;
            changedBoxes = new List<Tuple<int, string>>();
            previouslyVisited = new HashSet<int>();
            InitializeComponent();

            boardNumberTextbox.Text = row.Cells[3].Value.ToString();
            serialNumberTextbox.Text = row.Cells[1].Value.ToString();
            programVersionComboBox.Text = row.Cells[4].Value.ToString();
            pressureGroupComboBox.Text = row.Cells[2].Value.ToString();
            customerComboBox.Text = row.Cells[5].Value.ToString();
            buildDateTextbox.Text = row.Cells[0].Value.ToString();
            installDateTextbox.Text = row.Cells[16].Value.ToString();
            vehicleRefTextbox.Text = row.Cells[7].Value.ToString();
            pressureCellTextbox.Text = row.Cells[12].Value.ToString();
            pt1SerialTextbox.Text = row.Cells[13].Value.ToString();
            pt2SerialTextbox.Text = row.Cells[14].Value.ToString();
            descriptionTextbox.Text = row.Cells[6].Value.ToString();
            notesRichTextbox.Text = row.Cells[18].Value.ToString();
        }

        /// <summary>
        /// Saves the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO save the changes made to the database entry
            //TODO shouldn't exit if changes were unsuccessful

            if (changedBoxes.Count == 0)
            {
                this.Close();
                return;
            }

            for (int j = changedBoxes.Count-1; j >= 0; j--) //Decrements through the list to obtain the most recent changes first
            {
                int i = changedBoxes[j].Item1;
                string s = changedBoxes[j].Item2;

                if (previouslyVisited.Contains(j)) //Checks to make sure it only saves the most recent change to the entry
                {
                    continue;
                }
                previouslyVisited.Add(j);

                if (i == 18) //notes
                {
                    row.Cells[i].Value = s;
                }
                else if (i == 0 || i == 16) //dates
                {
                    DateTime dt;
                    if (DateTime.TryParse(s, out dt)){
                        row.Cells[i].Value = dt.Date;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' should be a date", "Invalid input");
                    }
                }
                else if (i == 3 || i == 12) //ints
                {
                    int k;
                    if (Int32.TryParse(s, out k))
                    {
                        row.Cells[i].Value = k;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' should be an integer", "Invalid input");
                    }
                }
                else if (i == 2 || i == 4 || i == 5) //comboboxes
                {
                    //TODO save combobox changes/have acceptable inputs in dropdown
                }
                else //strings
                {
                    if (s.Length <= 50)
                    {
                        row.Cells[i].Value = s;
                    }
                    else
                    {
                        MessageBox.Show("'" + s + "' is too long", "Invalid input");
                    }
                }

            }

            this.Close();
        }

        /// <summary>
        /// Closes the window and does not save the changes the user made to the entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boardNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(3, boardNumberTextbox.Text));
        }

        private void serialNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(1, serialNumberTextbox.Text));
        }

        private void programVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(4, programVersionComboBox.Text));
        }

        private void pressureGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(2, pressureGroupComboBox.Text));
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(5, customerComboBox.Text));
        }

        private void buildDateTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(0, buildDateTextbox.Text));
        }

        private void installDateTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(16, installDateTextbox.Text));
        }

        private void vehicleRefTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(7, vehicleRefTextbox.Text));
        }

        private void pressureCellTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(12, pressureCellTextbox.Text));
        }

        private void pt1SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(13, pt1SerialTextbox.Text));
        }

        private void pt2SerialTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(14, pt2SerialTextbox.Text));
        }

        private void descriptionTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(6, descriptionTextbox.Text));
        }

        private void notesRichTextbox_TextChanged(object sender, EventArgs e)
        {
            changedBoxes.Add(new Tuple<int, string>(18, notesRichTextbox.Text));
        }
    }
}
