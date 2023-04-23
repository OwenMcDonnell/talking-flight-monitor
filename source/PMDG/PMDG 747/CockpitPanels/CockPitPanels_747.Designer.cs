
namespace tfm
{
    partial class CockPitPanels_747
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Electrical");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Overhead Maint", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Electrical");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("MCP");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.cockpitPanelsTree = new System.Windows.Forms.TreeView();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cockpitPanelsTree
            // 
            this.cockpitPanelsTree.AccessibleName = "Cockpit panels";
            this.cockpitPanelsTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.cockpitPanelsTree.Location = new System.Drawing.Point(0, 0);
            this.cockpitPanelsTree.Margin = new System.Windows.Forms.Padding(5);
            this.cockpitPanelsTree.Name = "cockpitPanelsTree";
            treeNode1.Name = "overheadMaintElectricalNode";
            treeNode1.Text = "Electrical";
            treeNode2.Name = "overheadMaintFuelNode";
            treeNode2.Text = "Fuel";
            treeNode3.Name = "overheadMaintNode";
            treeNode3.Text = "Overhead Maint";
            treeNode4.Name = "electricalNode";
            treeNode4.Text = "Electrical";
            treeNode5.Name = "MCPNode";
            treeNode5.Text = "MCP";
            treeNode6.Name = "overheadNode";
            treeNode6.Text = "Overhead";
            this.cockpitPanelsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.cockpitPanelsTree.Size = new System.Drawing.Size(199, 742);
            this.cockpitPanelsTree.TabIndex = 0;
            this.cockpitPanelsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.cockpitPanelsTree_AfterSelect);
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(199, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(5);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1134, 742);
            this.contentPanel.TabIndex = 1;
            // 
            // CockPitPanels_747
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 742);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.cockpitPanelsTree);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CockPitPanels_747";
            this.Text = "747 cockpit panels";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView cockpitPanelsTree;
        private System.Windows.Forms.Panel contentPanel;
    }
}