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
            this.eCUdataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sampleDBDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sampleDBDataSet1 = new TractionAir.sampleDBDataSet1();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.pressureGroupComboBox = new System.Windows.Forms.ComboBox();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pressureGroupsDataSet = new TractionAir.pressureGroupsDataSet();
            this.eCUdataTableAdapter = new TractionAir.sampleDBDataSet1TableAdapters.ECUdataTableAdapter();
            this.tableTableAdapter = new TractionAir.pressureGroupsDataSetTableAdapters.TableTableAdapter();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.loadedOffRoadTextbox = new System.Windows.Forms.TextBox();
            this.notLoadedTextbox = new System.Windows.Forms.TextBox();
            this.maxTractionTextbox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.speedControlComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 144);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Build Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 38);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pressure Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 12);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Board Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 64);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Program Version";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 118);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 297);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 197);
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
            this.notesRichTextbox.Size = new System.Drawing.Size(512, 116);
            this.notesRichTextbox.TabIndex = 12;
            this.notesRichTextbox.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 223);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Pressure Cell";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 248);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "PT1 Serial";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 272);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "PT2 Serial";
            // 
            // buildDateTextbox
            // 
            this.buildDateTextbox.Location = new System.Drawing.Point(103, 141);
            this.buildDateTextbox.Name = "buildDateTextbox";
            this.buildDateTextbox.ReadOnly = true;
            this.buildDateTextbox.Size = new System.Drawing.Size(160, 20);
            this.buildDateTextbox.TabIndex = 16;
            // 
            // serialNumberTextbox
            // 
            this.serialNumberTextbox.Location = new System.Drawing.Point(103, 35);
            this.serialNumberTextbox.Name = "serialNumberTextbox";
            this.serialNumberTextbox.ReadOnly = true;
            this.serialNumberTextbox.Size = new System.Drawing.Size(160, 20);
            this.serialNumberTextbox.TabIndex = 17;
            // 
            // vehicleRefTextbox
            // 
            this.vehicleRefTextbox.Location = new System.Drawing.Point(103, 194);
            this.vehicleRefTextbox.Name = "vehicleRefTextbox";
            this.vehicleRefTextbox.ReadOnly = true;
            this.vehicleRefTextbox.Size = new System.Drawing.Size(160, 20);
            this.vehicleRefTextbox.TabIndex = 18;
            // 
            // pressureCellTextbox
            // 
            this.pressureCellTextbox.Location = new System.Drawing.Point(103, 220);
            this.pressureCellTextbox.Name = "pressureCellTextbox";
            this.pressureCellTextbox.ReadOnly = true;
            this.pressureCellTextbox.Size = new System.Drawing.Size(160, 20);
            this.pressureCellTextbox.TabIndex = 19;
            // 
            // pt1SerialTextbox
            // 
            this.pt1SerialTextbox.Location = new System.Drawing.Point(103, 245);
            this.pt1SerialTextbox.Name = "pt1SerialTextbox";
            this.pt1SerialTextbox.ReadOnly = true;
            this.pt1SerialTextbox.Size = new System.Drawing.Size(160, 20);
            this.pt1SerialTextbox.TabIndex = 20;
            // 
            // pt2SerialTextbox
            // 
            this.pt2SerialTextbox.Location = new System.Drawing.Point(103, 269);
            this.pt2SerialTextbox.Name = "pt2SerialTextbox";
            this.pt2SerialTextbox.ReadOnly = true;
            this.pt2SerialTextbox.Size = new System.Drawing.Size(160, 20);
            this.pt2SerialTextbox.TabIndex = 21;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(103, 294);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.ReadOnly = true;
            this.descriptionTextbox.Size = new System.Drawing.Size(160, 20);
            this.descriptionTextbox.TabIndex = 22;
            // 
            // boardNumberTextbox
            // 
            this.boardNumberTextbox.Location = new System.Drawing.Point(103, 9);
            this.boardNumberTextbox.Name = "boardNumberTextbox";
            this.boardNumberTextbox.ReadOnly = true;
            this.boardNumberTextbox.Size = new System.Drawing.Size(160, 20);
            this.boardNumberTextbox.TabIndex = 23;
            // 
            // installDateTextbox
            // 
            this.installDateTextbox.Location = new System.Drawing.Point(103, 166);
            this.installDateTextbox.Name = "installDateTextbox";
            this.installDateTextbox.ReadOnly = true;
            this.installDateTextbox.Size = new System.Drawing.Size(160, 20);
            this.installDateTextbox.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 169);
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
            this.programVersionComboBox.Enabled = false;
            this.programVersionComboBox.FormattingEnabled = true;
            this.programVersionComboBox.Location = new System.Drawing.Point(103, 61);
            this.programVersionComboBox.Name = "programVersionComboBox";
            this.programVersionComboBox.Size = new System.Drawing.Size(70, 21);
            this.programVersionComboBox.TabIndex = 26;
            this.programVersionComboBox.ValueMember = "Version";
            // 
            // eCUdataBindingSource
            // 
            this.eCUdataBindingSource.DataMember = "ECUdata";
            this.eCUdataBindingSource.DataSource = this.sampleDBDataSet1BindingSource;
            // 
            // sampleDBDataSet1BindingSource
            // 
            this.sampleDBDataSet1BindingSource.DataSource = this.sampleDBDataSet1;
            this.sampleDBDataSet1BindingSource.Position = 0;
            // 
            // sampleDBDataSet1
            // 
            this.sampleDBDataSet1.DataSetName = "sampleDBDataSet1";
            this.sampleDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataSource = this.eCUdataBindingSource;
            this.customerComboBox.DisplayMember = "Owner";
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.Enabled = false;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(103, 115);
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
            this.pressureGroupComboBox.Enabled = false;
            this.pressureGroupComboBox.FormattingEnabled = true;
            this.pressureGroupComboBox.Location = new System.Drawing.Point(103, 88);
            this.pressureGroupComboBox.Name = "pressureGroupComboBox";
            this.pressureGroupComboBox.Size = new System.Drawing.Size(181, 21);
            this.pressureGroupComboBox.TabIndex = 28;
            this.pressureGroupComboBox.ValueMember = "Description";
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.pressureGroupsDataSet;
            // 
            // pressureGroupsDataSet
            // 
            this.pressureGroupsDataSet.DataSetName = "pressureGroupsDataSet";
            this.pressureGroupsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eCUdataTableAdapter
            // 
            this.eCUdataTableAdapter.ClearBeforeFill = true;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(278, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Manual Database Update";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(278, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "SpeedUp Function:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(288, 248);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Loaded Off Road";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(308, 297);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Max Traction";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(314, 272);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Not Loaded";
            // 
            // loadedOffRoadTextbox
            // 
            this.loadedOffRoadTextbox.Location = new System.Drawing.Point(383, 245);
            this.loadedOffRoadTextbox.Name = "loadedOffRoadTextbox";
            this.loadedOffRoadTextbox.ReadOnly = true;
            this.loadedOffRoadTextbox.Size = new System.Drawing.Size(38, 20);
            this.loadedOffRoadTextbox.TabIndex = 35;
            this.loadedOffRoadTextbox.Text = "0";
            // 
            // notLoadedTextbox
            // 
            this.notLoadedTextbox.Location = new System.Drawing.Point(383, 269);
            this.notLoadedTextbox.Name = "notLoadedTextbox";
            this.notLoadedTextbox.ReadOnly = true;
            this.notLoadedTextbox.Size = new System.Drawing.Size(38, 20);
            this.notLoadedTextbox.TabIndex = 36;
            this.notLoadedTextbox.Text = "0";
            // 
            // maxTractionTextbox
            // 
            this.maxTractionTextbox.Location = new System.Drawing.Point(383, 294);
            this.maxTractionTextbox.Name = "maxTractionTextbox";
            this.maxTractionTextbox.ReadOnly = true;
            this.maxTractionTextbox.Size = new System.Drawing.Size(38, 20);
            this.maxTractionTextbox.TabIndex = 37;
            this.maxTractionTextbox.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(425, 248);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "km/h";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(425, 272);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 39;
            this.label20.Text = "km/h";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(425, 297);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "km/h";
            // 
            // speedControlComboBox
            // 
            this.speedControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedControlComboBox.Enabled = false;
            this.speedControlComboBox.FormattingEnabled = true;
            this.speedControlComboBox.Items.AddRange(new object[] {
            "No Speed Control",
            "Only Max Traction",
            "Lower Two Pressures",
            "Lower Three Pressures"});
            this.speedControlComboBox.Location = new System.Drawing.Point(383, 220);
            this.speedControlComboBox.Name = "speedControlComboBox";
            this.speedControlComboBox.Size = new System.Drawing.Size(135, 21);
            this.speedControlComboBox.TabIndex = 41;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 470);
            this.Controls.Add(this.speedControlComboBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.maxTractionTextbox);
            this.Controls.Add(this.notLoadedTextbox);
            this.Controls.Add(this.loadedOffRoadTextbox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).EndInit();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox loadedOffRoadTextbox;
        private System.Windows.Forms.TextBox notLoadedTextbox;
        private System.Windows.Forms.TextBox maxTractionTextbox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox speedControlComboBox;
    }
}