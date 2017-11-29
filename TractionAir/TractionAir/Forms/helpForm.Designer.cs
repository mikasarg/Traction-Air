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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Queries");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Data", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Pressure Setup");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Speed Setup");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Setup", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Access Code");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Enter Server Address");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Speed Simulate");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Read Error Data");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("ECx Report");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Tools", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Browse");
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
            treeNode2.Name = "queriesNode";
            treeNode2.Text = "Queries";
            treeNode3.Name = "dataNode";
            treeNode3.Text = "Data";
            treeNode4.Name = "pressureSetupNode";
            treeNode4.Text = "Pressure Setup";
            treeNode5.Name = "speedSetupNode";
            treeNode5.Text = "Speed Setup";
            treeNode6.Name = "setupNode";
            treeNode6.Text = "Setup";
            treeNode7.Name = "accessCodeNode";
            treeNode7.Text = "Access Code";
            treeNode8.Name = "enterServerAddressNode";
            treeNode8.Text = "Enter Server Address";
            treeNode9.Name = "speedSimulateNode";
            treeNode9.Text = "Speed Simulate";
            treeNode10.Name = "readErrorDataNode";
            treeNode10.Text = "Read Error Data";
            treeNode11.Name = "ecxReportNode";
            treeNode11.Text = "ECx Report";
            treeNode12.Name = "toolsNode";
            treeNode12.Text = "Tools";
            treeNode13.Name = "browseNode";
            treeNode13.Text = "Browse";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode6,
            treeNode12,
            treeNode13});
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