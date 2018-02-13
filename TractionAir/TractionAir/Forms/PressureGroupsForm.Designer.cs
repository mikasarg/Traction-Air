namespace TractionAir
{
    partial class PressureGroupsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PressureGroupsForm));
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pressureGroupsTableDataGridView = new System.Windows.Forms.DataGridView();
            this.pressureGroupsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ecuSettingsDatabaseDataSet = new TractionAir.ecuSettingsDatabaseDataSet();
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.pressureGroupsTableTableAdapter = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.pressureGroupsTableTableAdapter();
            this.tableAdapterManager1 = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadedOnRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadedOffRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unloadedOnRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unloadedOffRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxTractionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pressureGroupsDataSet
            // 
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            // 
            // tableTableAdapter
            // 
            // 
            // tableAdapterManager
            // 
            // 
            // pressureGroupsTableDataGridView
            // 
            this.pressureGroupsTableDataGridView.AllowUserToAddRows = false;
            this.pressureGroupsTableDataGridView.AllowUserToDeleteRows = false;
            this.pressureGroupsTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pressureGroupsTableDataGridView.AutoGenerateColumns = false;
            this.pressureGroupsTableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pressureGroupsTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pressureGroupsTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.loadedOnRoadDataGridViewTextBoxColumn,
            this.loadedOffRoadDataGridViewTextBoxColumn,
            this.unloadedOnRoadDataGridViewTextBoxColumn,
            this.unloadedOffRoadDataGridViewTextBoxColumn,
            this.maxTractionDataGridViewTextBoxColumn,
            this.dateModDataGridViewTextBoxColumn,
            this.idColumn});
            this.pressureGroupsTableDataGridView.DataSource = this.pressureGroupsTableBindingSource;
            this.pressureGroupsTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.pressureGroupsTableDataGridView.MultiSelect = false;
            this.pressureGroupsTableDataGridView.Name = "pressureGroupsTableDataGridView";
            this.pressureGroupsTableDataGridView.ReadOnly = true;
            this.pressureGroupsTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pressureGroupsTableDataGridView.Size = new System.Drawing.Size(898, 479);
            this.pressureGroupsTableDataGridView.TabIndex = 0;
            this.pressureGroupsTableDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pressureGroupsTableDataGridView_CellDoubleClick);
            // 
            // pressureGroupsTableBindingSource
            // 
            this.pressureGroupsTableBindingSource.DataMember = "pressureGroupsTable";
            this.pressureGroupsTableBindingSource.DataSource = this.ecuSettingsDatabaseDataSet;
            // 
            // ecuSettingsDatabaseDataSet
            // 
            this.ecuSettingsDatabaseDataSet.DataSetName = "ecuSettingsDatabaseDataSet";
            this.ecuSettingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // insertButton
            // 
            this.insertButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.insertButton.Location = new System.Drawing.Point(304, 485);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 1;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteButton.Location = new System.Drawing.Point(507, 485);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.changeButton.Location = new System.Drawing.Point(408, 485);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 2;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // pressureGroupsTableTableAdapter
            // 
            this.pressureGroupsTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.countryCodeTableTableAdapter = null;
            this.tableAdapterManager1.customerTableTableAdapter = null;
            this.tableAdapterManager1.customerToCountryTableAdapter = null;
            this.tableAdapterManager1.ecuToCountryTableAdapter = null;
            this.tableAdapterManager1.ecuToCustomerTableAdapter = null;
            this.tableAdapterManager1.ecuToPressureGroupTableAdapter = null;
            this.tableAdapterManager1.ecuToSpeedControlTableAdapter = null;
            this.tableAdapterManager1.ecuToVersionTableAdapter = null;
            this.tableAdapterManager1.mainSettingsTableTableAdapter = null;
            this.tableAdapterManager1.pressureGroupsTableTableAdapter = this.pressureGroupsTableTableAdapter;
            this.tableAdapterManager1.programVersionTableTableAdapter = null;
            this.tableAdapterManager1.speedControlTableTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loadedOnRoadDataGridViewTextBoxColumn
            // 
            this.loadedOnRoadDataGridViewTextBoxColumn.DataPropertyName = "LoadedOnRoad";
            this.loadedOnRoadDataGridViewTextBoxColumn.HeaderText = "Loaded On Road";
            this.loadedOnRoadDataGridViewTextBoxColumn.Name = "loadedOnRoadDataGridViewTextBoxColumn";
            this.loadedOnRoadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loadedOffRoadDataGridViewTextBoxColumn
            // 
            this.loadedOffRoadDataGridViewTextBoxColumn.DataPropertyName = "LoadedOffRoad";
            this.loadedOffRoadDataGridViewTextBoxColumn.HeaderText = "Loaded Off Road";
            this.loadedOffRoadDataGridViewTextBoxColumn.Name = "loadedOffRoadDataGridViewTextBoxColumn";
            this.loadedOffRoadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unloadedOnRoadDataGridViewTextBoxColumn
            // 
            this.unloadedOnRoadDataGridViewTextBoxColumn.DataPropertyName = "UnloadedOnRoad";
            this.unloadedOnRoadDataGridViewTextBoxColumn.HeaderText = "Unloaded On Road";
            this.unloadedOnRoadDataGridViewTextBoxColumn.Name = "unloadedOnRoadDataGridViewTextBoxColumn";
            this.unloadedOnRoadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unloadedOffRoadDataGridViewTextBoxColumn
            // 
            this.unloadedOffRoadDataGridViewTextBoxColumn.DataPropertyName = "UnloadedOffRoad";
            this.unloadedOffRoadDataGridViewTextBoxColumn.HeaderText = "Unloaded Off Road";
            this.unloadedOffRoadDataGridViewTextBoxColumn.Name = "unloadedOffRoadDataGridViewTextBoxColumn";
            this.unloadedOffRoadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxTractionDataGridViewTextBoxColumn
            // 
            this.maxTractionDataGridViewTextBoxColumn.DataPropertyName = "MaxTraction";
            this.maxTractionDataGridViewTextBoxColumn.HeaderText = "Max Traction";
            this.maxTractionDataGridViewTextBoxColumn.Name = "maxTractionDataGridViewTextBoxColumn";
            this.maxTractionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateModDataGridViewTextBoxColumn
            // 
            this.dateModDataGridViewTextBoxColumn.DataPropertyName = "DateMod";
            this.dateModDataGridViewTextBoxColumn.HeaderText = "Date Mod";
            this.dateModDataGridViewTextBoxColumn.Name = "dateModDataGridViewTextBoxColumn";
            this.dateModDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "Id";
            this.idColumn.HeaderText = "Id";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Visible = false;
            // 
            // PressureGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 517);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.pressureGroupsTableDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PressureGroupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browse the Setup Pressures (PSI)";
            this.Load += new System.EventHandler(this.PressureGroupsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.DataGridView pressureGroupsTableDataGridView;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button changeButton;
        private ecuSettingsDatabaseDataSet ecuSettingsDatabaseDataSet;
        private System.Windows.Forms.BindingSource pressureGroupsTableBindingSource;
        private ecuSettingsDatabaseDataSetTableAdapters.pressureGroupsTableTableAdapter pressureGroupsTableTableAdapter;
        private ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadedOnRoadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadedOffRoadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unloadedOnRoadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unloadedOffRoadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxTractionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
    }
}