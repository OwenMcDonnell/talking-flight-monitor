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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("PSEU");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Aft Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Flight Controls");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Electrical");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("MCP");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("IRU");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Engines");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Hydraulics");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("air systems");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Anti-ice");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Pressurization");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
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
            treeNode2.Name = "PSEUNode";
            treeNode2.Text = "PSEU";
            treeNode3.Name = "AftOvhdNode";
            treeNode3.Text = "Aft Overhead";
            treeNode4.Name = "nodFlightControls";
            treeNode4.Text = "Flight Controls";
            treeNode5.Name = "nodElectrical";
            treeNode5.Text = "Electrical";
            treeNode6.Name = "nodFuel";
            treeNode6.Text = "Fuel";
            treeNode7.Name = "nodMCP";
            treeNode7.Text = "MCP";
            treeNode8.Name = "nodIRU";
            treeNode8.Text = "IRU";
            treeNode9.Name = "nodEngines";
            treeNode9.Text = "Engines";
            treeNode10.Name = "nodHydraulics";
            treeNode10.Text = "Hydraulics";
            treeNode11.Name = "nodAirSystems";
            treeNode11.Text = "air systems";
            treeNode12.Name = "nodAntiIce";
            treeNode12.Text = "Anti-ice";
            treeNode13.Name = "nodPressurization";
            treeNode13.Text = "Pressurization";
            treeNode14.Name = "nodOverhead";
            treeNode14.Text = "Overhead";
            this.tvPanels.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode14});
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