namespace TractionAir.Forms
{
    partial class CountriesListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountriesListForm));
            this.ecuSettingsDatabaseDataSet = new TractionAir.ecuSettingsDatabaseDataSet();
            this.countryCodeTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryCodeTableTableAdapter = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.countryCodeTableTableAdapter();
            this.tableAdapterManager = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager();
            this.countryCodeTableDataGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryCodeTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryCodeTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ecuSettingsDatabaseDataSet
            // 
            this.ecuSettingsDatabaseDataSet.DataSetName = "ecuSettingsDatabaseDataSet";
            this.ecuSettingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // countryCodeTableBindingSource
            // 
            this.countryCodeTableBindingSource.DataMember = "countryCodeTable";
            this.countryCodeTableBindingSource.DataSource = this.ecuSettingsDatabaseDataSet;
            // 
            // countryCodeTableTableAdapter
            // 
            this.countryCodeTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.countryCodeTableTableAdapter = this.countryCodeTableTableAdapter;
            this.tableAdapterManager.customerTableTableAdapter = null;
            this.tableAdapterManager.customerToCountryTableAdapter = null;
            this.tableAdapterManager.ecuToCountryTableAdapter = null;
            this.tableAdapterManager.ecuToCustomerTableAdapter = null;
            this.tableAdapterManager.ecuToPressureGroupTableAdapter = null;
            this.tableAdapterManager.ecuToSpeedControlTableAdapter = null;
            this.tableAdapterManager.ecuToVersionTableAdapter = null;
            this.tableAdapterManager.mainSettingsTableTableAdapter = null;
            this.tableAdapterManager.pressureGroupsTableTableAdapter = null;
            this.tableAdapterManager.programVersionTableTableAdapter = null;
            this.tableAdapterManager.speedControlTableTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // countryCodeTableDataGridView
            // 
            this.countryCodeTableDataGridView.AllowUserToAddRows = false;
            this.countryCodeTableDataGridView.AllowUserToDeleteRows = false;
            this.countryCodeTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countryCodeTableDataGridView.AutoGenerateColumns = false;
            this.countryCodeTableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.countryCodeTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.countryCodeTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.idColumn});
            this.countryCodeTableDataGridView.DataSource = this.countryCodeTableBindingSource;
            this.countryCodeTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.countryCodeTableDataGridView.MultiSelect = false;
            this.countryCodeTableDataGridView.Name = "countryCodeTableDataGridView";
            this.countryCodeTableDataGridView.ReadOnly = true;
            this.countryCodeTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.countryCodeTableDataGridView.Size = new System.Drawing.Size(314, 217);
            this.countryCodeTableDataGridView.TabIndex = 0;
            this.countryCodeTableDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.countryCodeTableDataGridView_CellDoubleClick);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "Id";
            this.idColumn.HeaderText = "Id";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Visible = false;
            // 
            // insertButton
            // 
            this.insertButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.insertButton.Location = new System.Drawing.Point(39, 224);
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
            this.deleteButton.Location = new System.Drawing.Point(201, 224);
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
            this.changeButton.Location = new System.Drawing.Point(120, 224);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 2;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // CountriesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 254);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.countryCodeTableDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CountriesListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Countries";
            this.Load += new System.EventHandler(this.CountriesListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryCodeTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryCodeTableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ecuSettingsDatabaseDataSet ecuSettingsDatabaseDataSet;
        private System.Windows.Forms.BindingSource countryCodeTableBindingSource;
        private ecuSettingsDatabaseDataSetTableAdapters.countryCodeTableTableAdapter countryCodeTableTableAdapter;
        private ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView countryCodeTableDataGridView;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
    }
}