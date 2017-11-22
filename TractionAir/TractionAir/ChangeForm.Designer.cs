namespace TractionAir
{
    partial class ChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeForm));
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pressureGroupComboBox = new System.Windows.Forms.ComboBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.programVersionComboBox = new System.Windows.Forms.ComboBox();
            this.installDateTextbox = new System.Windows.Forms.TextBox();
            this.boardNumberTextbox = new System.Windows.Forms.TextBox();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.pt2SerialTextbox = new System.Windows.Forms.TextBox();
            this.pt1SerialTextbox = new System.Windows.Forms.TextBox();
            this.pressureCellTextbox = new System.Windows.Forms.TextBox();
            this.vehicleRefTextbox = new System.Windows.Forms.TextBox();
            this.serialNumberTextbox = new System.Windows.Forms.TextBox();
            this.buildDateTextbox = new System.Windows.Forms.TextBox();
            this.notesRichTextbox = new System.Windows.Forms.RichTextBox();
            this.pressureGroupsDataSet = new TractionAir.pressureGroupsDataSet();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableTableAdapter = new TractionAir.pressureGroupsDataSetTableAdapters.TableTableAdapter();
            this.tableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sampleDBDataSet1 = new TractionAir.sampleDBDataSet1();
            this.sampleDBDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eCUdataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eCUdataTableAdapter = new TractionAir.sampleDBDataSet1TableAdapters.ECUdataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 172);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Install Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 274);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "PT2 Serial";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 251);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "PT1 Serial";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 226);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Pressure Cell";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Notes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 200);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Vehicle Ref";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 300);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 121);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 67);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Program Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 15);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Board Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 94);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Pressure Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Serial Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 147);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Build Date";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(128, 482);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 55;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(218, 482);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 56;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pressureGroupComboBox
            // 
            this.pressureGroupComboBox.DataSource = this.tableBindingSource;
            this.pressureGroupComboBox.DisplayMember = "Description";
            this.pressureGroupComboBox.FormattingEnabled = true;
            this.pressureGroupComboBox.Location = new System.Drawing.Point(103, 91);
            this.pressureGroupComboBox.Name = "pressureGroupComboBox";
            this.pressureGroupComboBox.Size = new System.Drawing.Size(181, 21);
            this.pressureGroupComboBox.TabIndex = 69;
            this.pressureGroupComboBox.ValueMember = "Description";
            this.pressureGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.pressureGroupComboBox_SelectedIndexChanged);
            this.pressureGroupComboBox.TextChanged += new System.EventHandler(this.pressureGroupComboBox_SelectedIndexChanged);
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataSource = this.eCUdataBindingSource;
            this.customerComboBox.DisplayMember = "Owner";
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(103, 118);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(181, 21);
            this.customerComboBox.TabIndex = 68;
            this.customerComboBox.ValueMember = "Owner";
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            this.customerComboBox.TextChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            // 
            // programVersionComboBox
            // 
            this.programVersionComboBox.DataSource = this.eCUdataBindingSource;
            this.programVersionComboBox.DisplayMember = "Version";
            this.programVersionComboBox.FormattingEnabled = true;
            this.programVersionComboBox.Location = new System.Drawing.Point(103, 64);
            this.programVersionComboBox.Name = "programVersionComboBox";
            this.programVersionComboBox.Size = new System.Drawing.Size(70, 21);
            this.programVersionComboBox.TabIndex = 67;
            this.programVersionComboBox.ValueMember = "Version";
            this.programVersionComboBox.SelectedIndexChanged += new System.EventHandler(this.programVersionComboBox_SelectedIndexChanged);
            this.programVersionComboBox.TextChanged += new System.EventHandler(this.programVersionComboBox_SelectedIndexChanged);
            // 
            // installDateTextbox
            // 
            this.installDateTextbox.Location = new System.Drawing.Point(103, 169);
            this.installDateTextbox.Name = "installDateTextbox";
            this.installDateTextbox.Size = new System.Drawing.Size(160, 20);
            this.installDateTextbox.TabIndex = 66;
            this.installDateTextbox.TextChanged += new System.EventHandler(this.installDateTextbox_TextChanged);
            // 
            // boardNumberTextbox
            // 
            this.boardNumberTextbox.Location = new System.Drawing.Point(103, 12);
            this.boardNumberTextbox.Name = "boardNumberTextbox";
            this.boardNumberTextbox.ReadOnly = true;
            this.boardNumberTextbox.Size = new System.Drawing.Size(55, 20);
            this.boardNumberTextbox.TabIndex = 65;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(103, 297);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(160, 20);
            this.descriptionTextbox.TabIndex = 64;
            this.descriptionTextbox.TextChanged += new System.EventHandler(this.descriptionTextbox_TextChanged);
            // 
            // pt2SerialTextbox
            // 
            this.pt2SerialTextbox.Location = new System.Drawing.Point(103, 271);
            this.pt2SerialTextbox.Name = "pt2SerialTextbox";
            this.pt2SerialTextbox.Size = new System.Drawing.Size(160, 20);
            this.pt2SerialTextbox.TabIndex = 63;
            this.pt2SerialTextbox.TextChanged += new System.EventHandler(this.pt2SerialTextbox_TextChanged);
            // 
            // pt1SerialTextbox
            // 
            this.pt1SerialTextbox.Location = new System.Drawing.Point(103, 248);
            this.pt1SerialTextbox.Name = "pt1SerialTextbox";
            this.pt1SerialTextbox.Size = new System.Drawing.Size(160, 20);
            this.pt1SerialTextbox.TabIndex = 62;
            this.pt1SerialTextbox.TextChanged += new System.EventHandler(this.pt1SerialTextbox_TextChanged);
            // 
            // pressureCellTextbox
            // 
            this.pressureCellTextbox.Location = new System.Drawing.Point(103, 223);
            this.pressureCellTextbox.Name = "pressureCellTextbox";
            this.pressureCellTextbox.Size = new System.Drawing.Size(160, 20);
            this.pressureCellTextbox.TabIndex = 61;
            this.pressureCellTextbox.TextChanged += new System.EventHandler(this.pressureCellTextbox_TextChanged);
            // 
            // vehicleRefTextbox
            // 
            this.vehicleRefTextbox.Location = new System.Drawing.Point(103, 197);
            this.vehicleRefTextbox.Name = "vehicleRefTextbox";
            this.vehicleRefTextbox.Size = new System.Drawing.Size(160, 20);
            this.vehicleRefTextbox.TabIndex = 60;
            this.vehicleRefTextbox.TextChanged += new System.EventHandler(this.vehicleRefTextbox_TextChanged);
            // 
            // serialNumberTextbox
            // 
            this.serialNumberTextbox.Location = new System.Drawing.Point(103, 38);
            this.serialNumberTextbox.Name = "serialNumberTextbox";
            this.serialNumberTextbox.Size = new System.Drawing.Size(83, 20);
            this.serialNumberTextbox.TabIndex = 59;
            this.serialNumberTextbox.TextChanged += new System.EventHandler(this.serialNumberTextbox_TextChanged);
            // 
            // buildDateTextbox
            // 
            this.buildDateTextbox.Location = new System.Drawing.Point(103, 144);
            this.buildDateTextbox.Name = "buildDateTextbox";
            this.buildDateTextbox.Size = new System.Drawing.Size(160, 20);
            this.buildDateTextbox.TabIndex = 58;
            this.buildDateTextbox.TextChanged += new System.EventHandler(this.buildDateTextbox_TextChanged);
            // 
            // notesRichTextbox
            // 
            this.notesRichTextbox.Location = new System.Drawing.Point(12, 346);
            this.notesRichTextbox.Name = "notesRichTextbox";
            this.notesRichTextbox.Size = new System.Drawing.Size(474, 116);
            this.notesRichTextbox.TabIndex = 57;
            this.notesRichTextbox.Text = "";
            this.notesRichTextbox.TextChanged += new System.EventHandler(this.notesRichTextbox_TextChanged);
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
            // tableBindingSource1
            // 
            this.tableBindingSource1.DataMember = "Table";
            this.tableBindingSource1.DataSource = this.pressureGroupsDataSet;
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
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 517);
            this.Controls.Add(this.pressureGroupComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.programVersionComboBox);
            this.Controls.Add(this.installDateTextbox);
            this.Controls.Add(this.boardNumberTextbox);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.pt2SerialTextbox);
            this.Controls.Add(this.pt1SerialTextbox);
            this.Controls.Add(this.pressureCellTextbox);
            this.Controls.Add(this.vehicleRefTextbox);
            this.Controls.Add(this.serialNumberTextbox);
            this.Controls.Add(this.buildDateTextbox);
            this.Controls.Add(this.notesRichTextbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
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
            this.Name = "ChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change";
            this.Load += new System.EventHandler(this.ChangeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox pressureGroupComboBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox programVersionComboBox;
        private System.Windows.Forms.TextBox installDateTextbox;
        private System.Windows.Forms.TextBox boardNumberTextbox;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.TextBox pt2SerialTextbox;
        private System.Windows.Forms.TextBox pt1SerialTextbox;
        private System.Windows.Forms.TextBox pressureCellTextbox;
        private System.Windows.Forms.TextBox vehicleRefTextbox;
        private System.Windows.Forms.TextBox serialNumberTextbox;
        private System.Windows.Forms.TextBox buildDateTextbox;
        private System.Windows.Forms.RichTextBox notesRichTextbox;
        private pressureGroupsDataSet pressureGroupsDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private pressureGroupsDataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.BindingSource tableBindingSource1;
        private System.Windows.Forms.BindingSource sampleDBDataSet1BindingSource;
        private sampleDBDataSet1 sampleDBDataSet1;
        private System.Windows.Forms.BindingSource eCUdataBindingSource;
        private sampleDBDataSet1TableAdapters.ECUdataTableAdapter eCUdataTableAdapter;
    }
}