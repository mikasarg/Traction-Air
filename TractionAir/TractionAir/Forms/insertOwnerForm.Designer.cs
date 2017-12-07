namespace TractionAir.Forms
{
    partial class insertOwnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(insertOwnerForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phoneTextbox = new System.Windows.Forms.TextBox();
            this.cityTextbox = new System.Windows.Forms.TextBox();
            this.address2Textbox = new System.Windows.Forms.TextBox();
            this.address1Textbox = new System.Windows.Forms.TextBox();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.countryCodeTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ecuSettingsDatabaseDataSet = new TractionAir.ecuSettingsDatabaseDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.companyTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.countryCodeTableTableAdapter = new TractionAir.ecuSettingsDatabaseDataSetTableAdapters.countryCodeTableTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countryCodeTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(222, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(124, 225);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 1;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phoneTextbox);
            this.groupBox1.Controls.Add(this.cityTextbox);
            this.groupBox1.Controls.Add(this.address2Textbox);
            this.groupBox1.Controls.Add(this.address1Textbox);
            this.groupBox1.Controls.Add(this.countryComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.companyTextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // phoneTextbox
            // 
            this.phoneTextbox.Location = new System.Drawing.Point(87, 165);
            this.phoneTextbox.Name = "phoneTextbox";
            this.phoneTextbox.Size = new System.Drawing.Size(129, 20);
            this.phoneTextbox.TabIndex = 5;
            // 
            // cityTextbox
            // 
            this.cityTextbox.Location = new System.Drawing.Point(87, 106);
            this.cityTextbox.Name = "cityTextbox";
            this.cityTextbox.Size = new System.Drawing.Size(286, 20);
            this.cityTextbox.TabIndex = 3;
            // 
            // address2Textbox
            // 
            this.address2Textbox.Location = new System.Drawing.Point(87, 77);
            this.address2Textbox.Name = "address2Textbox";
            this.address2Textbox.Size = new System.Drawing.Size(286, 20);
            this.address2Textbox.TabIndex = 2;
            // 
            // address1Textbox
            // 
            this.address1Textbox.Location = new System.Drawing.Point(87, 48);
            this.address1Textbox.Name = "address1Textbox";
            this.address1Textbox.Size = new System.Drawing.Size(286, 20);
            this.address1Textbox.TabIndex = 1;
            // 
            // countryComboBox
            // 
            this.countryComboBox.DataSource = this.countryCodeTableBindingSource;
            this.countryComboBox.DisplayMember = "Code";
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(87, 135);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(68, 21);
            this.countryComboBox.TabIndex = 4;
            this.countryComboBox.ValueMember = "Id";
            // 
            // countryCodeTableBindingSource
            // 
            this.countryCodeTableBindingSource.DataMember = "countryCodeTable";
            this.countryCodeTableBindingSource.DataSource = this.ecuSettingsDatabaseDataSet;
            // 
            // ecuSettingsDatabaseDataSet
            // 
            this.ecuSettingsDatabaseDataSet.DataSetName = "ecuSettingsDatabaseDataSet";
            this.ecuSettingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Phone:";
            // 
            // companyTextbox
            // 
            this.companyTextbox.Location = new System.Drawing.Point(87, 19);
            this.companyTextbox.Name = "companyTextbox";
            this.companyTextbox.Size = new System.Drawing.Size(286, 20);
            this.companyTextbox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Company:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "City:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Country:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address 1:";
            // 
            // countryCodeTableTableAdapter
            // 
            this.countryCodeTableTableAdapter.ClearBeforeFill = true;
            // 
            // insertOwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 262);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "insertOwnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert a new Owner";
            this.Load += new System.EventHandler(this.insertOwnerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countryCodeTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecuSettingsDatabaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox companyTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox phoneTextbox;
        private System.Windows.Forms.TextBox cityTextbox;
        private System.Windows.Forms.TextBox address2Textbox;
        private System.Windows.Forms.TextBox address1Textbox;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Label label6;
        private ecuSettingsDatabaseDataSet ecuSettingsDatabaseDataSet;
        private System.Windows.Forms.BindingSource countryCodeTableBindingSource;
        private ecuSettingsDatabaseDataSetTableAdapters.countryCodeTableTableAdapter countryCodeTableTableAdapter;
    }
}