namespace tfm
{
    partial class frmSettings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Output");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Timing (requires TFM restart)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Airports database");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Aircraft");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("User interface");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ADIRU");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("PSEU");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Service interphone");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Dome lights");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("EEC");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Oxygen");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Gear");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Flight recorder");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Aft Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Flight Controls");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Navigation/Displays");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Fuel");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Forward Overhead", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("737 speech events", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("PMDG", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.tvCategories = new System.Windows.Forms.TreeView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCategories
            // 
            this.tvCategories.AccessibleName = "Settings categories";
            this.tvCategories.Location = new System.Drawing.Point(-1, 0);
            this.tvCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvCategories.Name = "tvCategories";
            treeNode1.Name = "nodGeneral";
            treeNode1.Text = "General";
            treeNode2.Name = "nodSpeechOutput";
            treeNode2.Text = "Output";
            treeNode3.Name = "nodTiming";
            treeNode3.Text = "Timing (requires TFM restart)";
            treeNode4.Name = "airportsDatabaseNode";
            treeNode4.Text = "Airports database";
            treeNode5.Name = "nodAircraft";
            treeNode5.Text = "Aircraft";
            treeNode6.Name = "nodeUserInterface";
            treeNode6.Text = "User interface";
            treeNode7.Name = "737AdiruNode";
            treeNode7.Text = "ADIRU";
            treeNode8.Name = "737PseuNode";
            treeNode8.Text = "PSEU";
            treeNode9.Name = "737ServiceInterPhoneNode";
            treeNode9.Text = "Service interphone";
            treeNode10.Name = "737DomeLightsNode";
            treeNode10.Text = "Dome lights";
            treeNode11.Name = "737EecNode";
            treeNode11.Text = "EEC";
            treeNode12.Name = "737OxygenNode";
            treeNode12.Text = "Oxygen";
            treeNode13.Name = "737GearNode";
            treeNode13.Text = "Gear";
            treeNode14.Name = "737FlightRecorderNode";
            treeNode14.Text = "Flight recorder";
            treeNode15.Name = "aftOverheadNode";
            treeNode15.Text = "Aft Overhead";
            treeNode16.Name = "737FlightControlsNode";
            treeNode16.Text = "Flight Controls";
            treeNode17.Name = "737NavDisNode";
            treeNode17.Text = "Navigation/Displays";
            treeNode18.Name = "737FuelNode";
            treeNode18.Text = "Fuel";
            treeNode19.Name = "forwardOverheadNode";
            treeNode19.Text = "Forward Overhead";
            treeNode20.Name = "Pmdg737Node";
            treeNode20.Text = "737 speech events";
            treeNode21.Name = "nodPMDG";
            treeNode21.Text = "PMDG";
            this.tvCategories.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode21});
            this.tvCategories.Size = new System.Drawing.Size(180, 146);
            this.tvCategories.TabIndex = 0;
            this.tvCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCategory_AfterSelect);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 692);
            this.pnlContent.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 538);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1200, 154);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleName = "Ok";
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(4, 5);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 35);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(124, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tvCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TFM Settings";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCategories;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}