﻿namespace TractionAir
{
    partial class insertionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(insertionForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loadedOnRoadTextbox = new System.Windows.Forms.TextBox();
            this.loadedOffRoadTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.unloadedOnRoadTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxTractionTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descriptionTextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.maxTractionTextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.unloadedOnRoadTextbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.loadedOffRoadTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.loadedOnRoadTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(133, 187);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 1;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(231, 187);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loaded On Road:";
            // 
            // loadedOnRoadTextbox
            // 
            this.loadedOnRoadTextbox.Location = new System.Drawing.Point(121, 45);
            this.loadedOnRoadTextbox.Name = "loadedOnRoadTextbox";
            this.loadedOnRoadTextbox.Size = new System.Drawing.Size(100, 20);
            this.loadedOnRoadTextbox.TabIndex = 1;
            this.loadedOnRoadTextbox.Text = "0";
            // 
            // loadedOffRoadTextbox
            // 
            this.loadedOffRoadTextbox.Location = new System.Drawing.Point(121, 71);
            this.loadedOffRoadTextbox.Name = "loadedOffRoadTextbox";
            this.loadedOffRoadTextbox.Size = new System.Drawing.Size(100, 20);
            this.loadedOffRoadTextbox.TabIndex = 3;
            this.loadedOffRoadTextbox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loaded Off Road:";
            // 
            // unloadedOnRoadTextbox
            // 
            this.unloadedOnRoadTextbox.Location = new System.Drawing.Point(121, 97);
            this.unloadedOnRoadTextbox.Name = "unloadedOnRoadTextbox";
            this.unloadedOnRoadTextbox.Size = new System.Drawing.Size(100, 20);
            this.unloadedOnRoadTextbox.TabIndex = 5;
            this.unloadedOnRoadTextbox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unloaded On Road:";
            // 
            // maxTractionTextbox
            // 
            this.maxTractionTextbox.Location = new System.Drawing.Point(121, 123);
            this.maxTractionTextbox.Name = "maxTractionTextbox";
            this.maxTractionTextbox.Size = new System.Drawing.Size(100, 20);
            this.maxTractionTextbox.TabIndex = 7;
            this.maxTractionTextbox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Traction:";
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(121, 19);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(286, 20);
            this.descriptionTextbox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Description:";
            // 
            // insertionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 226);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "insertionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert a new Pressure Group";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxTractionTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox unloadedOnRoadTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox loadedOffRoadTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loadedOnRoadTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button cancelButton;
    }
}