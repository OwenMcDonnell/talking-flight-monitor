﻿namespace tfm
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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Navigation/Displays");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Electrical");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("APU");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Wipers");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Forward Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Anti-ice");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Hydraulics");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Air Systems");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Center Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Engines");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Lights");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Bottom Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("MCP");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Warnings");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Altitude");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Speed");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Heading");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Navigation");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Vertical speed");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("MCP", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Glare Shield", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode32});
            this.tvPanels = new System.Windows.Forms.TreeView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tvPanels
            // 
            this.tvPanels.AccessibleName = "panels";
            this.tvPanels.Location = new System.Drawing.Point(3, 2);
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
            treeNode11.Name = "navDisNode";
            treeNode11.Text = "Navigation/Displays";
            treeNode12.Name = "fuelNode";
            treeNode12.Text = "Fuel";
            treeNode13.Name = "electricalNode";
            treeNode13.Text = "Electrical";
            treeNode14.Name = "apuNode";
            treeNode14.Text = "APU";
            treeNode15.Name = "wipersNode";
            treeNode15.Text = "Wipers";
            treeNode16.Name = "forwardOverheadNode";
            treeNode16.Text = "Forward Overhead";
            treeNode17.Name = "antiIceNode";
            treeNode17.Text = "Anti-ice";
            treeNode18.Name = "hydraulicsNode";
            treeNode18.Text = "Hydraulics";
            treeNode19.Name = "airSystemsNode";
            treeNode19.Text = "Air Systems";
            treeNode20.Name = "centerOverheadNode";
            treeNode20.Text = "Center Overhead";
            treeNode21.Name = "enginesNode";
            treeNode21.Text = "Engines";
            treeNode22.Name = "lightsNode";
            treeNode22.Text = "Lights";
            treeNode23.Name = "Node0";
            treeNode23.Text = "Bottom Overhead";
            treeNode24.Name = "nodMCP";
            treeNode24.Text = "MCP";
            treeNode25.Name = "nodOverhead";
            treeNode25.Text = "Overhead";
            treeNode26.Name = "warningsNode";
            treeNode26.Text = "Warnings";
            treeNode27.Name = "mcpAltitudeNode";
            treeNode27.Text = "Altitude";
            treeNode28.Name = "mcpSpeedNode";
            treeNode28.Text = "Speed";
            treeNode29.Name = "mcpHeadingNode";
            treeNode29.Text = "Heading";
            treeNode30.Name = "mcpNavigationNode";
            treeNode30.Text = "Navigation";
            treeNode31.Name = "mcpVerticalSpeedNode";
            treeNode31.Text = "Vertical speed";
            treeNode32.Name = "mcpNode";
            treeNode32.Text = "MCP";
            treeNode33.Name = "glareShieldNode";
            treeNode33.Text = "Glare Shield";
            this.tvPanels.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode16,
            treeNode20,
            treeNode23,
            treeNode25,
            treeNode33});
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCockpitPanels_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPanels;
        private System.Windows.Forms.Panel pnlContent;
    }
}