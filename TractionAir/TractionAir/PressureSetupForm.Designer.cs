namespace TractionAir
{
    partial class PressureSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PressureSetupForm));
            this.readDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kmTextBox = new System.Windows.Forms.TextBox();
            this.versionTextbox = new System.Windows.Forms.TextBox();
            this.boardCodeTextbox = new System.Windows.Forms.TextBox();
            this.serialNumberTextbox = new System.Windows.Forms.TextBox();
            this.kmLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.boardCodeLabel = new System.Windows.Forms.Label();
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxTractionLabel = new System.Windows.Forms.Label();
            this.unloadedOnLabel = new System.Windows.Forms.Label();
            this.loadedOffLabel = new System.Windows.Forms.Label();
            this.loadedOnLabel = new System.Windows.Forms.Label();
            this.pressureGroupLabel = new System.Windows.Forms.Label();
            this.dataReadLabel = new System.Windows.Forms.Label();
            this.pressureGroupButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.addToRecordsButton = new System.Windows.Forms.Button();
            this.newGroupButton = new System.Windows.Forms.Button();
            this.inDatabaseLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // readDataButton
            // 
            this.readDataButton.Location = new System.Drawing.Point(32, 22);
            this.readDataButton.Name = "readDataButton";
            this.readDataButton.Size = new System.Drawing.Size(120, 23);
            this.readDataButton.TabIndex = 0;
            this.readDataButton.Text = "Read data from TairX";
            this.readDataButton.UseVisualStyleBackColor = true;
            this.readDataButton.Click += new System.EventHandler(this.readDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kmTextBox);
            this.groupBox1.Controls.Add(this.versionTextbox);
            this.groupBox1.Controls.Add(this.boardCodeTextbox);
            this.groupBox1.Controls.Add(this.serialNumberTextbox);
            this.groupBox1.Controls.Add(this.kmLabel);
            this.groupBox1.Controls.Add(this.versionLabel);
            this.groupBox1.Controls.Add(this.boardCodeLabel);
            this.groupBox1.Controls.Add(this.serialNumberLabel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.pressureGroupLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // kmTextBox
            // 
            this.kmTextBox.Location = new System.Drawing.Point(303, 182);
            this.kmTextBox.Name = "kmTextBox";
            this.kmTextBox.Size = new System.Drawing.Size(100, 20);
            this.kmTextBox.TabIndex = 14;
            // 
            // versionTextbox
            // 
            this.versionTextbox.Location = new System.Drawing.Point(303, 152);
            this.versionTextbox.Name = "versionTextbox";
            this.versionTextbox.Size = new System.Drawing.Size(100, 20);
            this.versionTextbox.TabIndex = 13;
            // 
            // boardCodeTextbox
            // 
            this.boardCodeTextbox.Location = new System.Drawing.Point(303, 115);
            this.boardCodeTextbox.Name = "boardCodeTextbox";
            this.boardCodeTextbox.Size = new System.Drawing.Size(100, 20);
            this.boardCodeTextbox.TabIndex = 12;
            // 
            // serialNumberTextbox
            // 
            this.serialNumberTextbox.Location = new System.Drawing.Point(303, 82);
            this.serialNumberTextbox.Name = "serialNumberTextbox";
            this.serialNumberTextbox.Size = new System.Drawing.Size(100, 20);
            this.serialNumberTextbox.TabIndex = 11;
            // 
            // kmLabel
            // 
            this.kmLabel.AutoSize = true;
            this.kmLabel.Location = new System.Drawing.Point(212, 185);
            this.kmLabel.Name = "kmLabel";
            this.kmLabel.Size = new System.Drawing.Size(72, 13);
            this.kmLabel.TabIndex = 7;
            this.kmLabel.Text = "Km Travelled:";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(197, 155);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(87, 13);
            this.versionLabel.TabIndex = 8;
            this.versionLabel.Text = "Program Version:";
            // 
            // boardCodeLabel
            // 
            this.boardCodeLabel.AutoSize = true;
            this.boardCodeLabel.Location = new System.Drawing.Point(218, 118);
            this.boardCodeLabel.Name = "boardCodeLabel";
            this.boardCodeLabel.Size = new System.Drawing.Size(66, 13);
            this.boardCodeLabel.TabIndex = 9;
            this.boardCodeLabel.Text = "Board Code:";
            // 
            // serialNumberLabel
            // 
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.Location = new System.Drawing.Point(200, 85);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(84, 13);
            this.serialNumberLabel.TabIndex = 10;
            this.serialNumberLabel.Text = "TAEC Serial No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxTractionLabel);
            this.groupBox2.Controls.Add(this.unloadedOnLabel);
            this.groupBox2.Controls.Add(this.loadedOffLabel);
            this.groupBox2.Controls.Add(this.loadedOnLabel);
            this.groupBox2.Location = new System.Drawing.Point(20, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 181);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // maxTractionLabel
            // 
            this.maxTractionLabel.AutoSize = true;
            this.maxTractionLabel.Location = new System.Drawing.Point(17, 154);
            this.maxTractionLabel.Name = "maxTractionLabel";
            this.maxTractionLabel.Size = new System.Drawing.Size(72, 13);
            this.maxTractionLabel.TabIndex = 6;
            this.maxTractionLabel.Text = "Max Traction:";
            // 
            // unloadedOnLabel
            // 
            this.unloadedOnLabel.AutoSize = true;
            this.unloadedOnLabel.Location = new System.Drawing.Point(17, 111);
            this.unloadedOnLabel.Name = "unloadedOnLabel";
            this.unloadedOnLabel.Size = new System.Drawing.Size(104, 13);
            this.unloadedOnLabel.TabIndex = 3;
            this.unloadedOnLabel.Text = "Unloaded ON Road:";
            // 
            // loadedOffLabel
            // 
            this.loadedOffLabel.AutoSize = true;
            this.loadedOffLabel.Location = new System.Drawing.Point(17, 69);
            this.loadedOffLabel.Name = "loadedOffLabel";
            this.loadedOffLabel.Size = new System.Drawing.Size(98, 13);
            this.loadedOffLabel.TabIndex = 4;
            this.loadedOffLabel.Text = "Loaded OFF Road:";
            // 
            // loadedOnLabel
            // 
            this.loadedOnLabel.AutoSize = true;
            this.loadedOnLabel.Location = new System.Drawing.Point(17, 33);
            this.loadedOnLabel.Name = "loadedOnLabel";
            this.loadedOnLabel.Size = new System.Drawing.Size(97, 13);
            this.loadedOnLabel.TabIndex = 5;
            this.loadedOnLabel.Text = "Loaded ON Road: ";
            // 
            // pressureGroupLabel
            // 
            this.pressureGroupLabel.AutoSize = true;
            this.pressureGroupLabel.Location = new System.Drawing.Point(37, 27);
            this.pressureGroupLabel.Name = "pressureGroupLabel";
            this.pressureGroupLabel.Size = new System.Drawing.Size(83, 13);
            this.pressureGroupLabel.TabIndex = 5;
            this.pressureGroupLabel.Text = "Pressure Group:";
            // 
            // dataReadLabel
            // 
            this.dataReadLabel.AutoSize = true;
            this.dataReadLabel.Location = new System.Drawing.Point(170, 27);
            this.dataReadLabel.Name = "dataReadLabel";
            this.dataReadLabel.Size = new System.Drawing.Size(107, 13);
            this.dataReadLabel.TabIndex = 2;
            this.dataReadLabel.Text = "Data read successful";
            // 
            // pressureGroupButton
            // 
            this.pressureGroupButton.Location = new System.Drawing.Point(32, 350);
            this.pressureGroupButton.Name = "pressureGroupButton";
            this.pressureGroupButton.Size = new System.Drawing.Size(132, 23);
            this.pressureGroupButton.TabIndex = 3;
            this.pressureGroupButton.Text = "Select a Pressure Group";
            this.pressureGroupButton.UseVisualStyleBackColor = true;
            this.pressureGroupButton.Click += new System.EventHandler(this.pressureGroupButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(202, 350);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // addToRecordsButton
            // 
            this.addToRecordsButton.Location = new System.Drawing.Point(315, 350);
            this.addToRecordsButton.Name = "addToRecordsButton";
            this.addToRecordsButton.Size = new System.Drawing.Size(96, 23);
            this.addToRecordsButton.TabIndex = 5;
            this.addToRecordsButton.Text = "Add to records";
            this.addToRecordsButton.UseVisualStyleBackColor = true;
            this.addToRecordsButton.Click += new System.EventHandler(this.addToRecordsButton_Click);
            // 
            // newGroupButton
            // 
            this.newGroupButton.Location = new System.Drawing.Point(32, 395);
            this.newGroupButton.Name = "newGroupButton";
            this.newGroupButton.Size = new System.Drawing.Size(114, 23);
            this.newGroupButton.TabIndex = 6;
            this.newGroupButton.Text = "New Pressure Group";
            this.newGroupButton.UseVisualStyleBackColor = true;
            this.newGroupButton.Click += new System.EventHandler(this.newGroupButton_Click);
            // 
            // inDatabaseLabel
            // 
            this.inDatabaseLabel.AutoSize = true;
            this.inDatabaseLabel.Location = new System.Drawing.Point(321, 380);
            this.inDatabaseLabel.Name = "inDatabaseLabel";
            this.inDatabaseLabel.Size = new System.Drawing.Size(82, 13);
            this.inDatabaseLabel.TabIndex = 7;
            this.inDatabaseLabel.Text = "Not in database";
            // 
            // PressureSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 446);
            this.Controls.Add(this.inDatabaseLabel);
            this.Controls.Add(this.newGroupButton);
            this.Controls.Add(this.addToRecordsButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.pressureGroupButton);
            this.Controls.Add(this.dataReadLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.readDataButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PressureSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pressure Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readDataButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label dataReadLabel;
        private System.Windows.Forms.Label unloadedOnLabel;
        private System.Windows.Forms.Label loadedOffLabel;
        private System.Windows.Forms.Label pressureGroupLabel;
        private System.Windows.Forms.TextBox kmTextBox;
        private System.Windows.Forms.TextBox versionTextbox;
        private System.Windows.Forms.TextBox boardCodeTextbox;
        private System.Windows.Forms.TextBox serialNumberTextbox;
        private System.Windows.Forms.Label kmLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label boardCodeLabel;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label maxTractionLabel;
        private System.Windows.Forms.Label loadedOnLabel;
        private System.Windows.Forms.Button pressureGroupButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button addToRecordsButton;
        private System.Windows.Forms.Button newGroupButton;
        private System.Windows.Forms.Label inDatabaseLabel;
    }
}