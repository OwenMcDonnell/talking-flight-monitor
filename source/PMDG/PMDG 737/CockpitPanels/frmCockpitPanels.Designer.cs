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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Service interphone");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Dome lights");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("EEC");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Oxygen");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Gear");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Flight recorder");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Aft Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Flight Controls");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Forward Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Flight Controls");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Electrical");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("MCP");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("IRU");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Engines");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Hydraulics");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("air systems");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Anti-ice");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Pressurization");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
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
            treeNode3.Name = "serviceInterPhoneNode";
            treeNode3.Text = "Service interphone";
            treeNode4.Name = "domeLightsNode";
            treeNode4.Text = "Dome lights";
            treeNode5.Name = "eecNode";
            treeNode5.Text = "EEC";
            treeNode6.Name = "oxygenNode";
            treeNode6.Text = "Oxygen";
            treeNode7.Name = "gearNode";
            treeNode7.Text = "Gear";
            treeNode8.Name = "flightRecorderNode";
            treeNode8.Text = "Flight recorder";
            treeNode9.Name = "AftOvhdNode";
            treeNode9.Text = "Aft Overhead";
            treeNode10.Name = "flightControlsNode";
            treeNode10.Text = "Flight Controls";
            treeNode11.Name = "forwardOverheadNode";
            treeNode11.Text = "Forward Overhead";
            treeNode12.Name = "nodFlightControls";
            treeNode12.Text = "Flight Controls";
            treeNode13.Name = "nodElectrical";
            treeNode13.Text = "Electrical";
            treeNode14.Name = "nodFuel";
            treeNode14.Text = "Fuel";
            treeNode15.Name = "nodMCP";
            treeNode15.Text = "MCP";
            treeNode16.Name = "nodIRU";
            treeNode16.Text = "IRU";
            treeNode17.Name = "nodEngines";
            treeNode17.Text = "Engines";
            treeNode18.Name = "nodHydraulics";
            treeNode18.Text = "Hydraulics";
            treeNode19.Name = "nodAirSystems";
            treeNode19.Text = "air systems";
            treeNode20.Name = "nodAntiIce";
            treeNode20.Text = "Anti-ice";
            treeNode21.Name = "nodPressurization";
            treeNode21.Text = "Pressurization";
            treeNode22.Name = "nodOverhead";
            treeNode22.Text = "Overhead";
            this.tvPanels.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode11,
            treeNode22});
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