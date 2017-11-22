namespace TractionAir
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.notesRichTextbox = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.buildDateTextbox = new System.Windows.Forms.TextBox();
            this.serialNumberTextbox = new System.Windows.Forms.TextBox();
            this.vehicleRefTextbox = new System.Windows.Forms.TextBox();
            this.pressureCellTextbox = new System.Windows.Forms.TextBox();
            this.pt1SerialTextbox = new System.Windows.Forms.TextBox();
            this.pt2SerialTextbox = new System.Windows.Forms.TextBox();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.boardNumberTextbox = new System.Windows.Forms.TextBox();
            this.installDateTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.programVersionComboBox = new System.Windows.Forms.ComboBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.pressureGroupComboBox = new System.Windows.Forms.ComboBox();
            this.sampleDBDataSet1 = new TractionAir.sampleDBDataSet1();
            this.sampleDBDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eCUdataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eCUdataTableAdapter = new TractionAir.sampleDBDataSet1TableAdapters.ECUdataTableAdapter();
            this.pressureGroupsDataSet = new TractionAir.pressureGroupsDataSet();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableTableAdapter = new TractionAir.pressureGroupsDataSetTableAdapters.TableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 142);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Build Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 36);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 89);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pressure Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 10);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Board Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 62);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Program Version";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 116);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 295);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 195);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Vehicle Ref";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Notes";
            // 
            // notesRichTextbox
            // 
            this.notesRichTextbox.Location = new System.Drawing.Point(12, 341);
            this.notesRichTextbox.Name = "notesRichTextbox";
            this.notesRichTextbox.ReadOnly = true;
            this.notesRichTextbox.Size = new System.Drawing.Size(474, 116);
            this.notesRichTextbox.TabIndex = 12;
            this.notesRichTextbox.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 221);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Pressure Cell";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 246);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "PT1 Serial";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 269);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "PT2 Serial";
            // 
            // buildDateTextbox
            // 
            this.buildDateTextbox.Location = new System.Drawing.Point(103, 139);
            this.buildDateTextbox.Name = "buildDateTextbox";
            this.buildDateTextbox.ReadOnly = true;
            this.buildDateTextbox.Size = new System.Drawing.Size(160, 20);
            this.buildDateTextbox.TabIndex = 16;
            // 
            // serialNumberTextbox
            // 
            this.serialNumberTextbox.Location = new System.Drawing.Point(103, 33);
            this.serialNumberTextbox.Name = "serialNumberTextbox";
            this.serialNumberTextbox.ReadOnly = true;
            this.serialNumberTextbox.Size = new System.Drawing.Size(83, 20);
            this.serialNumberTextbox.TabIndex = 17;
            // 
            // vehicleRefTextbox
            // 
            this.vehicleRefTextbox.Location = new System.Drawing.Point(103, 192);
            this.vehicleRefTextbox.Name = "vehicleRefTextbox";
            this.vehicleRefTextbox.ReadOnly = true;
            this.vehicleRefTextbox.Size = new System.Drawing.Size(160, 20);
            this.vehicleRefTextbox.TabIndex = 18;
            // 
            // pressureCellTextbox
            // 
            this.pressureCellTextbox.Location = new System.Drawing.Point(103, 218);
            this.pressureCellTextbox.Name = "pressureCellTextbox";
            this.pressureCellTextbox.ReadOnly = true;
            this.pressureCellTextbox.Size = new System.Drawing.Size(160, 20);
            this.pressureCellTextbox.TabIndex = 19;
            // 
            // pt1SerialTextbox
            // 
            this.pt1SerialTextbox.Location = new System.Drawing.Point(103, 243);
            this.pt1SerialTextbox.Name = "pt1SerialTextbox";
            this.pt1SerialTextbox.ReadOnly = true;
            this.pt1SerialTextbox.Size = new System.Drawing.Size(160, 20);
            this.pt1SerialTextbox.TabIndex = 20;
            // 
            // pt2SerialTextbox
            // 
            this.pt2SerialTextbox.Location = new System.Drawing.Point(103, 266);
            this.pt2SerialTextbox.Name = "pt2SerialTextbox";
            this.pt2SerialTextbox.ReadOnly = true;
            this.pt2SerialTextbox.Size = new System.Drawing.Size(160, 20);
            this.pt2SerialTextbox.TabIndex = 21;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(103, 292);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.ReadOnly = true;
            this.descriptionTextbox.Size = new System.Drawing.Size(160, 20);
            this.descriptionTextbox.TabIndex = 22;
            // 
            // boardNumberTextbox
            // 
            this.boardNumberTextbox.Location = new System.Drawing.Point(103, 7);
            this.boardNumberTextbox.Name = "boardNumberTextbox";
            this.boardNumberTextbox.ReadOnly = true;
            this.boardNumberTextbox.Size = new System.Drawing.Size(55, 20);
            this.boardNumberTextbox.TabIndex = 23;
            // 
            // installDateTextbox
            // 
            this.installDateTextbox.Location = new System.Drawing.Point(103, 164);
            this.installDateTextbox.Name = "installDateTextbox";
            this.installDateTextbox.ReadOnly = true;
            this.installDateTextbox.Size = new System.Drawing.Size(160, 20);
            this.installDateTextbox.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 167);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Install Date";
            // 
            // programVersionComboBox
            // 
            this.programVersionComboBox.DataSource = this.eCUdataBindingSource;
            this.programVersionComboBox.DisplayMember = "Version";
            this.programVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.programVersionComboBox.FormattingEnabled = true;
            this.programVersionComboBox.Location = new System.Drawing.Point(103, 59);
            this.programVersionComboBox.Name = "programVersionComboBox";
            this.programVersionComboBox.Size = new System.Drawing.Size(70, 21);
            this.programVersionComboBox.TabIndex = 26;
            this.programVersionComboBox.ValueMember = "Version";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataSource = this.eCUdataBindingSource;
            this.customerComboBox.DisplayMember = "Owner";
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(103, 113);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(181, 21);
            this.customerComboBox.TabIndex = 27;
            this.customerComboBox.ValueMember = "Owner";
            // 
            // pressureGroupComboBox
            // 
            this.pressureGroupComboBox.DataSource = this.tableBindingSource;
            this.pressureGroupComboBox.DisplayMember = "Description";
            this.pressureGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pressureGroupComboBox.FormattingEnabled = true;
            this.pressureGroupComboBox.Location = new System.Drawing.Point(103, 86);
            this.pressureGroupComboBox.Name = "pressureGroupComboBox";
            this.pressureGroupComboBox.Size = new System.Drawing.Size(181, 21);
            this.pressureGroupComboBox.TabIndex = 28;
            this.pressureGroupComboBox.ValueMember = "Description";
            // 
            // sampleDBDataSet1
            // 
            this.sampleDBDataSet1.DataSetName = "sampleDBDataSet1";
            this.sampleDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sampleDBDataSet1BindingSource
            // 
            this.sampleDBDataSet1BindingSource.DataSource = this.sampleDBDataSet1;
            this.sampleDBDataSet1BindingSource.Position = 0;
            // 
            // eCUdataBindingSource
            // 
            this.eCUdataBindingSource.DataMember = "ECUdata";
            this.eCUdataBindingSource.DataSource = this.sampleDBDataSet1BindingSource;
            // 
            // eCUdataTableAdapter
            // 
            this.eCUdataTableAdapter.ClearBeforeFill = true;
            // 
            // pressureGroupsDataSet
            // 
            this.pressureGroupsDataSet.DataSetName = "pressureGroupsDataSet";
            this.pressureGroupsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.pressureGroupsDataSet;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 470);
            this.Controls.Add(this.pressureGroupComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.programVersionComboBox);
            this.Controls.Add(this.installDateTextbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.boardNumberTextbox);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.pt2SerialTextbox);
            this.Controls.Add(this.pt1SerialTextbox);
            this.Controls.Add(this.pressureCellTextbox);
            this.Controls.Add(this.vehicleRefTextbox);
            this.Controls.Add(this.serialNumberTextbox);
            this.Controls.Add(this.buildDateTextbox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.notesRichTextbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.Load += new System.EventHandler(this.ViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox notesRichTextbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox buildDateTextbox;
        private System.Windows.Forms.TextBox serialNumberTextbox;
        private System.Windows.Forms.TextBox vehicleRefTextbox;
        private System.Windows.Forms.TextBox pressureCellTextbox;
        private System.Windows.Forms.TextBox pt1SerialTextbox;
        private System.Windows.Forms.TextBox pt2SerialTextbox;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.TextBox boardNumberTextbox;
        private System.Windows.Forms.TextBox installDateTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox programVersionComboBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox pressureGroupComboBox;
        private System.Windows.Forms.BindingSource sampleDBDataSet1BindingSource;
        private sampleDBDataSet1 sampleDBDataSet1;
        private System.Windows.Forms.BindingSource eCUdataBindingSource;
        private sampleDBDataSet1TableAdapters.ECUdataTableAdapter eCUdataTableAdapter;
        private pressureGroupsDataSet pressureGroupsDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private pressureGroupsDataSetTableAdapters.TableTableAdapter tableTableAdapter;
    }
}