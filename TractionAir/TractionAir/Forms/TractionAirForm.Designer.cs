﻿namespace TractionAir
{
    partial class TractionAirForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TractionAirForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pressureGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ownerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eCxSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accessCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.comPortLabel = new System.Windows.Forms.Label();
            this.eCUdataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.queryButton = new System.Windows.Forms.Button();
            this.ecuCountLabel = new System.Windows.Forms.Label();
            this.conncectedBoardLabel = new System.Windows.Forms.Label();
            this.notesRichTextbox = new System.Windows.Forms.RichTextBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.eCUdataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sampleDBDataSet1 = new TractionAir.sampleDBDataSet1();
            this.setupTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sampleDBDataSet = new TractionAir.sampleDBDataSet();
            this.eCUdataTableAdapter1 = new TractionAir.sampleDBDataSet1TableAdapters.ECUdataTableAdapter();
            this.tableAdapterManager1 = new TractionAir.sampleDBDataSet1TableAdapters.TableAdapterManager();
            this.setupTableTableAdapter = new TractionAir.sampleDBDataSetTableAdapters.setupTableTableAdapter();
            this.tableAdapterManager = new TractionAir.sampleDBDataSetTableAdapters.TableAdapterManager();
            this.ecuSettingsDatabaseDataSet = new TractionAir.ecuSettingsDatabaseDataSet();
            this.mainSettingsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainSettingsTableTableAdapter = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.mainSettingsTableTableAdapter();
            this.tableAdapterManager2 = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager();
            this.mainSettingsTableDataGridView = new System.Windows.Forms.DataGridView();
            this.boardCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pressureGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleRefColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedStagesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setupTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSettingsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSettingsTableDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.browseToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1054, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSetupToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.printSetupToolStripMenuItem.Text = "Print Setup ...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem,
            this.offlineToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Checked = true;
            this.onlineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.onlineToolStripMenuItem.Text = "Online";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineToolStripMenuItem_Click);
            // 
            // offlineToolStripMenuItem
            // 
            this.offlineToolStripMenuItem.Name = "offlineToolStripMenuItem";
            this.offlineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.offlineToolStripMenuItem.Text = "Offline";
            this.offlineToolStripMenuItem.Click += new System.EventHandler(this.offlineToolStripMenuItem_Click);
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pressureGroupsToolStripMenuItem,
            this.ownerListToolStripMenuItem,
            this.eCxSoftwareToolStripMenuItem});
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.browseToolStripMenuItem.Text = "Browse";
            // 
            // pressureGroupsToolStripMenuItem
            // 
            this.pressureGroupsToolStripMenuItem.Name = "pressureGroupsToolStripMenuItem";
            this.pressureGroupsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.pressureGroupsToolStripMenuItem.Text = "Pressure Groups";
            this.pressureGroupsToolStripMenuItem.Click += new System.EventHandler(this.pressureGroupsToolStripMenuItem_Click);
            // 
            // ownerListToolStripMenuItem
            // 
            this.ownerListToolStripMenuItem.Name = "ownerListToolStripMenuItem";
            this.ownerListToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ownerListToolStripMenuItem.Text = "Owner List";
            this.ownerListToolStripMenuItem.Click += new System.EventHandler(this.ownerListToolStripMenuItem_Click);
            // 
            // eCxSoftwareToolStripMenuItem
            // 
            this.eCxSoftwareToolStripMenuItem.Name = "eCxSoftwareToolStripMenuItem";
            this.eCxSoftwareToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eCxSoftwareToolStripMenuItem.Text = "ECx Software";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accessCodeToolStripMenuItem,
            this.manualUploadToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // accessCodeToolStripMenuItem
            // 
            this.accessCodeToolStripMenuItem.Name = "accessCodeToolStripMenuItem";
            this.accessCodeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.accessCodeToolStripMenuItem.Text = "Access Code";
            this.accessCodeToolStripMenuItem.Click += new System.EventHandler(this.accessCodeToolStripMenuItem_Click);
            // 
            // manualUploadToolStripMenuItem
            // 
            this.manualUploadToolStripMenuItem.Name = "manualUploadToolStripMenuItem";
            this.manualUploadToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.manualUploadToolStripMenuItem.Text = "Manual Upload";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "Contents";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // onlineLabel
            // 
            this.onlineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Location = new System.Drawing.Point(106, 608);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(67, 13);
            this.onlineLabel.TabIndex = 3;
            this.onlineLabel.Text = "Online Mode";
            // 
            // comPortLabel
            // 
            this.comPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comPortLabel.Location = new System.Drawing.Point(865, 608);
            this.comPortLabel.Name = "comPortLabel";
            this.comPortLabel.Size = new System.Drawing.Size(166, 13);
            this.comPortLabel.TabIndex = 4;
            this.comPortLabel.Text = "COM Port: 0";
            this.comPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // eCUdataBindingSource
            // 
            this.eCUdataBindingSource.DataMember = "ECUdata";
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Tick += new System.EventHandler(this.UpdateTimer_tick);
            // 
            // queryButton
            // 
            this.queryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.queryButton.Location = new System.Drawing.Point(793, 478);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(110, 37);
            this.queryButton.TabIndex = 21;
            this.queryButton.Text = "Query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // ecuCountLabel
            // 
            this.ecuCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ecuCountLabel.AutoSize = true;
            this.ecuCountLabel.Location = new System.Drawing.Point(21, 105);
            this.ecuCountLabel.Name = "ecuCountLabel";
            this.ecuCountLabel.Size = new System.Drawing.Size(63, 13);
            this.ecuCountLabel.TabIndex = 20;
            this.ecuCountLabel.Text = "ECU Count:";
            // 
            // conncectedBoardLabel
            // 
            this.conncectedBoardLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.conncectedBoardLabel.AutoSize = true;
            this.conncectedBoardLabel.Location = new System.Drawing.Point(21, 77);
            this.conncectedBoardLabel.Name = "conncectedBoardLabel";
            this.conncectedBoardLabel.Size = new System.Drawing.Size(93, 13);
            this.conncectedBoardLabel.TabIndex = 19;
            this.conncectedBoardLabel.Text = "Connected Board:";
            // 
            // notesRichTextbox
            // 
            this.notesRichTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.notesRichTextbox.Location = new System.Drawing.Point(4, 459);
            this.notesRichTextbox.Name = "notesRichTextbox";
            this.notesRichTextbox.ReadOnly = true;
            this.notesRichTextbox.Size = new System.Drawing.Size(422, 141);
            this.notesRichTextbox.TabIndex = 16;
            this.notesRichTextbox.Text = "";
            // 
            // changeButton
            // 
            this.changeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeButton.Location = new System.Drawing.Point(164, 21);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(110, 37);
            this.changeButton.TabIndex = 15;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewButton.Location = new System.Drawing.Point(24, 21);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(110, 37);
            this.viewButton.TabIndex = 14;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // eCUdataBindingSource1
            // 
            this.eCUdataBindingSource1.DataMember = "ECUdata";
            this.eCUdataBindingSource1.DataSource = this.sampleDBDataSet1;
            // 
            // sampleDBDataSet1
            // 
            this.sampleDBDataSet1.DataSetName = "sampleDBDataSet1";
            this.sampleDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // setupTableBindingSource
            // 
            this.setupTableBindingSource.DataMember = "setupTable";
            this.setupTableBindingSource.DataSource = this.sampleDBDataSet;
            // 
            // sampleDBDataSet
            // 
            this.sampleDBDataSet.DataSetName = "sampleDBDataSet";
            this.sampleDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eCUdataTableAdapter1
            // 
            this.eCUdataTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.ECUdataTableAdapter = this.eCUdataTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = TractionAir.sampleDBDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // setupTableTableAdapter
            // 
            this.setupTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ECUdataTableAdapter = null;
            this.tableAdapterManager.setupTableTableAdapter = this.setupTableTableAdapter;
            this.tableAdapterManager.UpdateOrder = TractionAir.sampleDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ecuSettingsDatabaseDataSet
            // 
            this.ecuSettingsDatabaseDataSet.DataSetName = "ecuSettingsDatabaseDataSet";
            this.ecuSettingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainSettingsTableBindingSource
            // 
            this.mainSettingsTableBindingSource.DataMember = "mainSettingsTable";
            this.mainSettingsTableBindingSource.DataSource = this.ecuSettingsDatabaseDataSet;
            // 
            // mainSettingsTableTableAdapter
            // 
            this.mainSettingsTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.countryCodeTableTableAdapter = null;
            this.tableAdapterManager2.customerTableTableAdapter = null;
            this.tableAdapterManager2.mainSettingsTableTableAdapter = this.mainSettingsTableTableAdapter;
            this.tableAdapterManager2.pressureGroupsTableTableAdapter = null;
            this.tableAdapterManager2.UpdateOrder = TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mainSettingsTableDataGridView
            // 
            this.mainSettingsTableDataGridView.AllowUserToAddRows = false;
            this.mainSettingsTableDataGridView.AllowUserToDeleteRows = false;
            this.mainSettingsTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSettingsTableDataGridView.AutoGenerateColumns = false;
            this.mainSettingsTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainSettingsTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.boardCodeColumn,
            this.pressureGroupColumn,
            this.ownerColumn,
            this.countryColumn,
            this.buildDateColumn,
            this.versionColumn,
            this.descriptionColumn,
            this.vehicleRefColumn,
            this.speedStagesColumn,
            this.dateModColumn,
            this.notesColumn});
            this.mainSettingsTableDataGridView.DataSource = this.mainSettingsTableBindingSource;
            this.mainSettingsTableDataGridView.Location = new System.Drawing.Point(4, 27);
            this.mainSettingsTableDataGridView.MultiSelect = false;
            this.mainSettingsTableDataGridView.Name = "mainSettingsTableDataGridView";
            this.mainSettingsTableDataGridView.ReadOnly = true;
            this.mainSettingsTableDataGridView.Size = new System.Drawing.Size(1044, 426);
            this.mainSettingsTableDataGridView.TabIndex = 21;
            // 
            // boardCodeColumn
            // 
            this.boardCodeColumn.DataPropertyName = "Board Code";
            this.boardCodeColumn.HeaderText = "Board Code";
            this.boardCodeColumn.Name = "boardCodeColumn";
            this.boardCodeColumn.ReadOnly = true;
            // 
            // pressureGroupColumn
            // 
            this.pressureGroupColumn.DataPropertyName = "Pressure Group";
            this.pressureGroupColumn.HeaderText = "Pressure Group";
            this.pressureGroupColumn.Name = "pressureGroupColumn";
            this.pressureGroupColumn.ReadOnly = true;
            // 
            // ownerColumn
            // 
            this.ownerColumn.DataPropertyName = "Owner";
            this.ownerColumn.HeaderText = "Owner";
            this.ownerColumn.Name = "ownerColumn";
            this.ownerColumn.ReadOnly = true;
            // 
            // countryColumn
            // 
            this.countryColumn.DataPropertyName = "Country";
            this.countryColumn.HeaderText = "Country";
            this.countryColumn.Name = "countryColumn";
            this.countryColumn.ReadOnly = true;
            // 
            // buildDateColumn
            // 
            this.buildDateColumn.DataPropertyName = "Build Date";
            this.buildDateColumn.HeaderText = "Build Date";
            this.buildDateColumn.Name = "buildDateColumn";
            this.buildDateColumn.ReadOnly = true;
            // 
            // versionColumn
            // 
            this.versionColumn.DataPropertyName = "Version";
            this.versionColumn.HeaderText = "Version";
            this.versionColumn.Name = "versionColumn";
            this.versionColumn.ReadOnly = true;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "Description";
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            // 
            // vehicleRefColumn
            // 
            this.vehicleRefColumn.DataPropertyName = "Vehicle Ref";
            this.vehicleRefColumn.HeaderText = "Vehicle Ref";
            this.vehicleRefColumn.Name = "vehicleRefColumn";
            this.vehicleRefColumn.ReadOnly = true;
            // 
            // speedStagesColumn
            // 
            this.speedStagesColumn.DataPropertyName = "Speed Stages";
            this.speedStagesColumn.HeaderText = "Speed Stages";
            this.speedStagesColumn.Name = "speedStagesColumn";
            this.speedStagesColumn.ReadOnly = true;
            // 
            // dateModColumn
            // 
            this.dateModColumn.DataPropertyName = "Date Mod";
            this.dateModColumn.HeaderText = "Date Mod";
            this.dateModColumn.Name = "dateModColumn";
            this.dateModColumn.ReadOnly = true;
            // 
            // notesColumn
            // 
            this.notesColumn.DataPropertyName = "Notes";
            this.notesColumn.HeaderText = "Notes";
            this.notesColumn.Name = "notesColumn";
            this.notesColumn.ReadOnly = true;
            this.notesColumn.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1054, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.conncectedBoardLabel);
            this.groupBox1.Controls.Add(this.ecuCountLabel);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.viewButton);
            this.groupBox1.Location = new System.Drawing.Point(441, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 141);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // TractionAirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 625);
            this.Controls.Add(this.mainSettingsTableDataGridView);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.notesRichTextbox);
            this.Controls.Add(this.comPortLabel);
            this.Controls.Add(this.onlineLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TractionAirForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TractionAir Desktop";
            this.Load += new System.EventHandler(this.TractionAirForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCUdataBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setupTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSettingsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSettingsTableDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pressureGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ownerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eCxSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accessCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.Label comPortLabel;
        private System.Windows.Forms.BindingSource eCUdataBindingSource;
        private sampleDBDataSet1 sampleDBDataSet1;
        private System.Windows.Forms.BindingSource eCUdataBindingSource1;
        private sampleDBDataSet1TableAdapters.ECUdataTableAdapter eCUdataTableAdapter1;
        private sampleDBDataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private sampleDBDataSet sampleDBDataSet;
        private System.Windows.Forms.BindingSource setupTableBindingSource;
        private sampleDBDataSetTableAdapters.setupTableTableAdapter setupTableTableAdapter;
        private sampleDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.ToolStripMenuItem manualUploadToolStripMenuItem;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Label ecuCountLabel;
        private System.Windows.Forms.Label conncectedBoardLabel;
        private System.Windows.Forms.RichTextBox notesRichTextbox;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button viewButton;
        private ecuSettingsDatabaseDataSet ecuSettingsDatabaseDataSet;
        private System.Windows.Forms.BindingSource mainSettingsTableBindingSource;
        private ecuSettingsDatabaseDataSetTableAdapters.mainSettingsTableTableAdapter mainSettingsTableTableAdapter;
        private ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.DataGridView mainSettingsTableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pressureGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleRefColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedStagesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

