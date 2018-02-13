namespace TractionAir
{
    partial class helpForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Introduction");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Access Code");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Manual Upload");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Add Program Version");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Add Board Version");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tools", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Owner List");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Pressure Groups");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Countries");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Browse", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Query");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helpForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "introductionNode";
            treeNode1.Text = "Introduction";
            treeNode2.Name = "accessCodeNode";
            treeNode2.Text = "Access Code";
            treeNode3.Name = "manualUploadNode";
            treeNode3.Text = "Manual Upload";
            treeNode4.Name = "addProgNode";
            treeNode4.Text = "Add Program Version";
            treeNode5.Name = "addBoardNode";
            treeNode5.Text = "Add Board Version";
            treeNode6.Name = "toolsNode";
            treeNode6.Text = "Tools";
            treeNode7.Name = "customersNode";
            treeNode7.Text = "Owner List";
            treeNode8.Name = "pressureGroupsNode";
            treeNode8.Text = "Pressure Groups";
            treeNode9.Name = "countriesNode";
            treeNode9.Text = "Countries";
            treeNode10.Name = "browseNode";
            treeNode10.Text = "Browse";
            treeNode11.Name = "queryNode";
            treeNode11.Text = "Query";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode10,
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(229, 482);
            this.treeView1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(260, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(472, 482);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Help contents coming soon!";
            // 
            // helpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 506);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "helpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}