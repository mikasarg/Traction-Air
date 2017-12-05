namespace TractionAir
{
    partial class OwnerListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerListForm));
            this.ecuSettingsDatabaseDataSet = new TractionAir.ecuSettingsDatabaseDataSet();
            this.customerTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableTableAdapter = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.customerTableTableAdapter();
            this.tableAdapterManager = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager();
            this.customerTableDataGridView = new System.Windows.Forms.DataGridView();
            this.changeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ecuSettingsDatabaseDataSet
            // 
            this.ecuSettingsDatabaseDataSet.DataSetName = "ecuSettingsDatabaseDataSet";
            this.ecuSettingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerTableBindingSource
            // 
            this.customerTableBindingSource.DataMember = "customerTable";
            this.customerTableBindingSource.DataSource = this.ecuSettingsDatabaseDataSet;
            // 
            // customerTableTableAdapter
            // 
            this.customerTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.countryCodeTableTableAdapter = null;
            this.tableAdapterManager.customerTableTableAdapter = this.customerTableTableAdapter;
            this.tableAdapterManager.ecuToCustomerTableAdapter = null;
            this.tableAdapterManager.ecuToPressureGroupTableAdapter = null;
            this.tableAdapterManager.ecuToVersionTableTableAdapter = null;
            this.tableAdapterManager.mainSettingsTableTableAdapter = null;
            this.tableAdapterManager.pressureGroupsTableTableAdapter = null;
            this.tableAdapterManager.programVersionTableTableAdapter = null;
            this.tableAdapterManager.speedControlTableTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TractionAir.ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // customerTableDataGridView
            // 
            this.customerTableDataGridView.AllowUserToAddRows = false;
            this.customerTableDataGridView.AllowUserToDeleteRows = false;
            this.customerTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerTableDataGridView.AutoGenerateColumns = false;
            this.customerTableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.customerTableDataGridView.DataSource = this.customerTableBindingSource;
            this.customerTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.customerTableDataGridView.Name = "customerTableDataGridView";
            this.customerTableDataGridView.ReadOnly = true;
            this.customerTableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerTableDataGridView.Size = new System.Drawing.Size(830, 425);
            this.customerTableDataGridView.TabIndex = 1;
            // 
            // changeButton
            // 
            this.changeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.changeButton.Location = new System.Drawing.Point(380, 441);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 7;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteButton.Location = new System.Drawing.Point(479, 441);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.insertButton.Location = new System.Drawing.Point(276, 441);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 5;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Company";
            this.dataGridViewTextBoxColumn1.HeaderText = "Company";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "City";
            this.dataGridViewTextBoxColumn2.HeaderText = "City";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Country";
            this.dataGridViewTextBoxColumn3.HeaderText = "Country";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn4.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn5.HeaderText = "Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Address1";
            this.dataGridViewTextBoxColumn6.HeaderText = "Address1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Address2";
            this.dataGridViewTextBoxColumn7.HeaderText = "Address2";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn8.HeaderText = "Id";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // OwnerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 476);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.customerTableDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OwnerListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browse Owners";
            this.Load += new System.EventHandler(this.OwnerListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerTableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ecuSettingsDatabaseDataSet ecuSettingsDatabaseDataSet;
        private System.Windows.Forms.BindingSource customerTableBindingSource;
        private ecuSettingsDatabaseDataSetTableAdapters.customerTableTableAdapter customerTableTableAdapter;
        private ecuSettingsDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView customerTableDataGridView;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}