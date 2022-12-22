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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Navigation/Displays");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Buses");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Electrical", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("APU");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Wipers");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Forward Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Anti-ice");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Hydraulics");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Air Systems");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Center Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Engines");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Lights");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Bottom Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("AFS");
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
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("MCP");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("DU");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Standby");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Speed");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Brakes");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Flaps");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Gear");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Forward", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Lower Forward");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("CDU");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Trim");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Pedestal");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Fire protection");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Cargo fire protection");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Transponder");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Control Stand", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44,
            treeNode45,
            treeNode46,
            treeNode47,
            treeNode48});
            this.tvPanels = new System.Windows.Forms.TreeView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tvPanels
            // 
            this.tvPanels.AccessibleName = "panels";
            this.tvPanels.Location = new System.Drawing.Point(-3, 47);
            this.tvPanels.Margin = new System.Windows.Forms.Padding(5);
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
            treeNode13.Name = "busesNode";
            treeNode13.Text = "Buses";
            treeNode14.Name = "electricalNode";
            treeNode14.Text = "Electrical";
            treeNode15.Name = "apuNode";
            treeNode15.Text = "APU";
            treeNode16.Name = "wipersNode";
            treeNode16.Text = "Wipers";
            treeNode17.Name = "forwardOverheadNode";
            treeNode17.Text = "Forward Overhead";
            treeNode18.Name = "antiIceNode";
            treeNode18.Text = "Anti-ice";
            treeNode19.Name = "hydraulicsNode";
            treeNode19.Text = "Hydraulics";
            treeNode20.Name = "airSystemsNode";
            treeNode20.Text = "Air Systems";
            treeNode21.Name = "centerOverheadNode";
            treeNode21.Text = "Center Overhead";
            treeNode22.Name = "enginesNode";
            treeNode22.Text = "Engines";
            treeNode23.Name = "lightsNode";
            treeNode23.Text = "Lights";
            treeNode24.Name = "Node0";
            treeNode24.Text = "Bottom Overhead";
            treeNode25.Name = "afsNode";
            treeNode25.Text = "AFS";
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
            treeNode34.Name = "forwardMcpNode";
            treeNode34.Text = "MCP";
            treeNode35.Name = "duNode";
            treeNode35.Text = "DU";
            treeNode36.Name = "standbyNode";
            treeNode36.Text = "Standby";
            treeNode37.Name = "forwardSpeedNode";
            treeNode37.Text = "Speed";
            treeNode38.Name = "brakesNode";
            treeNode38.Text = "Brakes";
            treeNode39.Name = "flapsNode";
            treeNode39.Text = "Flaps";
            treeNode40.Name = "forwardGearNode";
            treeNode40.Text = "Gear";
            treeNode41.Name = "forwardNode";
            treeNode41.Text = "Forward";
            treeNode42.Name = "lowerForwardNode";
            treeNode42.Text = "Lower Forward";
            treeNode43.Name = "controlStandCDUNode";
            treeNode43.Text = "CDU";
            treeNode44.Name = "controlStandTrimNode";
            treeNode44.Text = "Trim";
            treeNode45.Name = "pedestalNode";
            treeNode45.Text = "Pedestal";
            treeNode46.Name = "fireNode";
            treeNode46.Text = "Fire protection";
            treeNode47.Name = "cargoFireNode";
            treeNode47.Text = "Cargo fire protection";
            treeNode48.Name = "transponderNode";
            treeNode48.Text = "Transponder";
            treeNode49.Name = "controlStandNode";
            treeNode49.Text = "Control Stand";
            this.tvPanels.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode17,
            treeNode21,
            treeNode24,
            treeNode25,
            treeNode33,
            treeNode41,
            treeNode42,
            treeNode49});
            this.tvPanels.Size = new System.Drawing.Size(300, 700);
            this.tvPanels.TabIndex = 1;
            this.tvPanels.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPanels_AfterSelect);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.Location = new System.Drawing.Point(297, 5);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(0, 0);
            this.pnlContent.TabIndex = 2;
            // 
            // frmCockpitPanels
            // 
            this.AccessibleName = "Cockpit panels";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 744);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tvPanels);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
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