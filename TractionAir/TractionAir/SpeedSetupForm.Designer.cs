namespace TractionAir
{
    partial class SpeedSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeedSetupForm));
            this.uploadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.speedControlComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxTractionTextbox = new System.Windows.Forms.TextBox();
            this.loadedOffRoadTextbox = new System.Windows.Forms.TextBox();
            this.notLoadedTextbox = new System.Windows.Forms.TextBox();
            this.serialNumberTextbox = new System.Windows.Forms.TextBox();
            this.ecuMatchSelectionLabel = new System.Windows.Forms.Label();
            this.defaultSpeedSetupButton = new System.Windows.Forms.Button();
            this.downloadAndSaveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(26, 21);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.speedControlComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maxTractionTextbox);
            this.groupBox1.Controls.Add(this.loadedOffRoadTextbox);
            this.groupBox1.Controls.Add(this.notLoadedTextbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 217);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(259, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 42);
            this.label8.TabIndex = 20;
            this.label8.Text = "Speed must be less than this to manually select Max Traction";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(213, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "km/h";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "km/h";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "km/h";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(259, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 31);
            this.label7.TabIndex = 15;
            this.label7.Text = "Speed must be less than this to manually select Loaded Off Road";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Select Pressures for Speed Control";
            // 
            // speedControlComboBox
            // 
            this.speedControlComboBox.FormattingEnabled = true;
            this.speedControlComboBox.Items.AddRange(new object[] {
            "No Speed Control",
            "Only Max Traction",
            "Lower Two Pressures",
            "Lower Three Pressures"});
            this.speedControlComboBox.Location = new System.Drawing.Point(15, 181);
            this.speedControlComboBox.Name = "speedControlComboBox";
            this.speedControlComboBox.Size = new System.Drawing.Size(135, 21);
            this.speedControlComboBox.TabIndex = 13;
            this.speedControlComboBox.Text = "No Speed Control";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Speeds for Change to Higher Pressure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Max Traction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Not Loaded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Loaded Off Road";
            // 
            // maxTractionTextbox
            // 
            this.maxTractionTextbox.Location = new System.Drawing.Point(107, 117);
            this.maxTractionTextbox.Name = "maxTractionTextbox";
            this.maxTractionTextbox.Size = new System.Drawing.Size(100, 20);
            this.maxTractionTextbox.TabIndex = 9;
            // 
            // loadedOffRoadTextbox
            // 
            this.loadedOffRoadTextbox.Location = new System.Drawing.Point(107, 46);
            this.loadedOffRoadTextbox.Name = "loadedOffRoadTextbox";
            this.loadedOffRoadTextbox.Size = new System.Drawing.Size(100, 20);
            this.loadedOffRoadTextbox.TabIndex = 6;
            // 
            // notLoadedTextbox
            // 
            this.notLoadedTextbox.Location = new System.Drawing.Point(107, 81);
            this.notLoadedTextbox.Name = "notLoadedTextbox";
            this.notLoadedTextbox.Size = new System.Drawing.Size(100, 20);
            this.notLoadedTextbox.TabIndex = 7;
            // 
            // serialNumberTextbox
            // 
            this.serialNumberTextbox.Location = new System.Drawing.Point(137, 24);
            this.serialNumberTextbox.Name = "serialNumberTextbox";
            this.serialNumberTextbox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextbox.TabIndex = 0;
            // 
            // ecuMatchSelectionLabel
            // 
            this.ecuMatchSelectionLabel.AutoSize = true;
            this.ecuMatchSelectionLabel.Location = new System.Drawing.Point(259, 26);
            this.ecuMatchSelectionLabel.Name = "ecuMatchSelectionLabel";
            this.ecuMatchSelectionLabel.Size = new System.Drawing.Size(150, 13);
            this.ecuMatchSelectionLabel.TabIndex = 1;
            this.ecuMatchSelectionLabel.Text = "ECU does not match selection";
            // 
            // defaultSpeedSetupButton
            // 
            this.defaultSpeedSetupButton.Location = new System.Drawing.Point(26, 300);
            this.defaultSpeedSetupButton.Name = "defaultSpeedSetupButton";
            this.defaultSpeedSetupButton.Size = new System.Drawing.Size(114, 23);
            this.defaultSpeedSetupButton.TabIndex = 2;
            this.defaultSpeedSetupButton.Text = "Default Speed Setup";
            this.defaultSpeedSetupButton.UseVisualStyleBackColor = true;
            this.defaultSpeedSetupButton.Click += new System.EventHandler(this.defaultSpeedSetupButton_Click);
            // 
            // downloadAndSaveButton
            // 
            this.downloadAndSaveButton.Location = new System.Drawing.Point(26, 344);
            this.downloadAndSaveButton.Name = "downloadAndSaveButton";
            this.downloadAndSaveButton.Size = new System.Drawing.Size(114, 23);
            this.downloadAndSaveButton.TabIndex = 3;
            this.downloadAndSaveButton.Text = "Download and Save";
            this.downloadAndSaveButton.UseVisualStyleBackColor = true;
            this.downloadAndSaveButton.Click += new System.EventHandler(this.downloadAndSaveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(194, 344);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(316, 344);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SpeedSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 394);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.downloadAndSaveButton);
            this.Controls.Add(this.defaultSpeedSetupButton);
            this.Controls.Add(this.ecuMatchSelectionLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serialNumberTextbox);
            this.Controls.Add(this.uploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpeedSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speed Setup Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox speedControlComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxTractionTextbox;
        private System.Windows.Forms.TextBox loadedOffRoadTextbox;
        private System.Windows.Forms.TextBox notLoadedTextbox;
        private System.Windows.Forms.TextBox serialNumberTextbox;
        private System.Windows.Forms.Label ecuMatchSelectionLabel;
        private System.Windows.Forms.Button defaultSpeedSetupButton;
        private System.Windows.Forms.Button downloadAndSaveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
    }
}