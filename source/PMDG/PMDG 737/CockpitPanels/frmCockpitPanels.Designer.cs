namespace tfm
{
    partial class frmCockpitPanels
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ADIRU");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Aft Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Flight Controls");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Electrical");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("MCP");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("IRU");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Engines");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Hydraulics");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("air systems");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Anti-ice");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Pressurization");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            this.tvPanels = new System.Windows.Forms.TreeView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tvPanels
            // 
            this.tvPanels.AccessibleName = "panels";
            this.tvPanels.Location = new System.Drawing.Point(3, 3);
            this.tvPanels.Name = "tvPanels";
            treeNode1.Name = "adiruNode";
            treeNode1.Text = "ADIRU";
            treeNode2.Name = "AftOvhdNode";
            treeNode2.Text = "Aft Overhead";
            treeNode3.Name = "nodFlightControls";
            treeNode3.Text = "Flight Controls";
            treeNode4.Name = "nodElectrical";
            treeNode4.Text = "Electrical";
            treeNode5.Name = "nodFuel";
            treeNode5.Text = "Fuel";
            treeNode6.Name = "nodMCP";
            treeNode6.Text = "MCP";
            treeNode7.Name = "nodIRU";
            treeNode7.Text = "IRU";
            treeNode8.Name = "nodEngines";
            treeNode8.Text = "Engines";
            treeNode9.Name = "nodHydraulics";
            treeNode9.Text = "Hydraulics";
            treeNode10.Name = "nodAirSystems";
            treeNode10.Text = "air systems";
            treeNode11.Name = "nodAntiIce";
            treeNode11.Text = "Anti-ice";
            treeNode12.Name = "nodPressurization";
            treeNode12.Text = "Pressurization";
            treeNode13.Name = "nodOverhead";
            treeNode13.Text = "Overhead";
            this.tvPanels.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode13});
            this.tvPanels.Size = new System.Drawing.Size(121, 97);
            this.tvPanels.TabIndex = 1;
            this.tvPanels.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPanels_AfterSelect);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.Location = new System.Drawing.Point(130, 3);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(0, 0);
            this.pnlContent.TabIndex = 2;
            // 
            // frmCockpitPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tvPanels);
            this.KeyPreview = true;
            this.Name = "frmCockpitPanels";
            this.Text = "737 Cockpit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPanels;
        private System.Windows.Forms.Panel pnlContent;
    }
}