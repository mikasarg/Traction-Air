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
            this.pressureGroupsDataSet = new TractionAir.pressureGroupsDataSet();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableTableAdapter = new TractionAir.pressureGroupsDataSetTableAdapters.TableTableAdapter();
            this.tableAdapterManager = new TractionAir.pressureGroupsDataSetTableAdapters.TableAdapterManager();
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.ecuSettingsDatabaseDataSet = new TractionAir.ecuSettingsDatabaseDataSet();
            this.pressureGroupsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pressureGroupsTableTableAdapter = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.pressureGroupsTableTableAdapter();
            this.tableAdapterManager1 = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadedOnRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadedOffRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unloadedOnRoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxTractionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsTableBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TableTableAdapter = this.tableTableAdapter;
            this.tableAdapterManager.UpdateOrder = TractionAir.pressureGroupsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.AllowUserToAddRows = false;
            this.tableDataGridView.AllowUserToDeleteRows = false;
            this.tableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableDataGridView.AutoGenerateColumns = false;
            this.tableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.loadedOnRoadDataGridViewTextBoxColumn,
            this.loadedOffRoadDataGridViewTextBoxColumn,
            this.unloadedOnRoadDataGridViewTextBoxColumn,
            this.maxTractionDataGridViewTextBoxColumn,
            this.dateModDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.tableDataGridView.DataSource = this.pressureGroupsTableBindingSource;
            this.tableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tableDataGridView.MultiSelect = false;
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.ReadOnly = true;
            this.tableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableDataGridView.Size = new System.Drawing.Size(898, 479);
            this.tableDataGridView.TabIndex = 1;
            // 
            // insertButton
            // 
            this.insertButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.insertButton.Location = new System.Drawing.Point(304, 485);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 2;
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
            this.changeButton.TabIndex = 4;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // ecuSettingsDatabaseDataSet
            // 
            this.ecuSettingsDatabaseDataSet.DataSetName = "ecuSettingsDatabaseDataSet";
            this.ecuSettingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pressureGroupsTableBindingSource
            // 
            this.pressureGroupsTableBindingSource.DataMember = "pressureGroupsTable";
            this.pressureGroupsTableBindingSource.DataSource = this.ecuSettingsDatabaseDataSet;
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
            this.tableAdapterManager1.ecuToCustomerTableAdapter = null;
            this.tableAdapterManager1.ecuToPressureGroupTableAdapter = null;
            this.tableAdapterManager1.ecuToVersionTableTableAdapter = null;
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
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // PressureGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 517);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.tableDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PressureGroupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browse the Setup Pressures (PSI)";
            this.Load += new System.EventHandler(this.PressureGroupsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureGroupsTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private pressureGroupsDataSet pressureGroupsDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private pressureGroupsDataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private pressureGroupsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView tableDataGridView;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn maxTractionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    }
}