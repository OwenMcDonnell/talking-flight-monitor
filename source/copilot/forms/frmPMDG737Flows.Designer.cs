namespace tfm.copilot
{
    partial class frmPMDG737Flows
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
            this.components = new System.ComponentModel.Container();
            this.VerticalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.HorizontalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GrpElectricalPower = new System.Windows.Forms.GroupBox();
            this.ElectricalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPanelSetup = new System.Windows.Forms.Button();
            this.btnAPU = new System.Windows.Forms.Button();
            this.btnGPU = new System.Windows.Forms.Button();
            this.btnIRS = new System.Windows.Forms.Button();
            this.grpTests = new System.Windows.Forms.GroupBox();
            this.TestFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGPWS = new System.Windows.Forms.Button();
            this.btnFireTest = new System.Windows.Forms.Button();
            this.btnCVRTest = new System.Windows.Forms.Button();
            this.btnOverspeed = new System.Windows.Forms.Button();
            this.btnStallTest = new System.Windows.Forms.Button();
            this.tmrFlowStatus = new System.Windows.Forms.Timer(this.components);
            this.VerticalFlowPanel.SuspendLayout();
            this.HorizontalFlowPanel.SuspendLayout();
            this.GrpElectricalPower.SuspendLayout();
            this.ElectricalFlowPanel.SuspendLayout();
            this.grpTests.SuspendLayout();
            this.TestFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalFlowPanel
            // 
            this.VerticalFlowPanel.AutoSize = true;
            this.VerticalFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VerticalFlowPanel.Controls.Add(this.txtStatus);
            this.VerticalFlowPanel.Controls.Add(this.HorizontalFlowPanel);
            this.VerticalFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.VerticalFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.VerticalFlowPanel.Name = "VerticalFlowPanel";
            this.VerticalFlowPanel.Size = new System.Drawing.Size(806, 412);
            this.VerticalFlowPanel.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.AccessibleName = "Flow Status";
            this.txtStatus.Location = new System.Drawing.Point(3, 3);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(800, 300);
            this.txtStatus.TabIndex = 0;
            // 
            // HorizontalFlowPanel
            // 
            this.HorizontalFlowPanel.Controls.Add(this.GrpElectricalPower);
            this.HorizontalFlowPanel.Controls.Add(this.grpTests);
            this.HorizontalFlowPanel.Location = new System.Drawing.Point(3, 309);
            this.HorizontalFlowPanel.Name = "HorizontalFlowPanel";
            this.HorizontalFlowPanel.Size = new System.Drawing.Size(200, 100);
            this.HorizontalFlowPanel.TabIndex = 1;
            // 
            // GrpElectricalPower
            // 
            this.GrpElectricalPower.AutoSize = true;
            this.GrpElectricalPower.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpElectricalPower.Controls.Add(this.ElectricalFlowPanel);
            this.GrpElectricalPower.Location = new System.Drawing.Point(3, 3);
            this.GrpElectricalPower.Name = "GrpElectricalPower";
            this.GrpElectricalPower.Size = new System.Drawing.Size(209, 165);
            this.GrpElectricalPower.TabIndex = 0;
            this.GrpElectricalPower.TabStop = false;
            this.GrpElectricalPower.Text = "&Electrical Power";
            // 
            // ElectricalFlowPanel
            // 
            this.ElectricalFlowPanel.Controls.Add(this.btnPanelSetup);
            this.ElectricalFlowPanel.Controls.Add(this.btnAPU);
            this.ElectricalFlowPanel.Controls.Add(this.btnGPU);
            this.ElectricalFlowPanel.Controls.Add(this.btnIRS);
            this.ElectricalFlowPanel.Location = new System.Drawing.Point(3, 31);
            this.ElectricalFlowPanel.Name = "ElectricalFlowPanel";
            this.ElectricalFlowPanel.Size = new System.Drawing.Size(200, 100);
            this.ElectricalFlowPanel.TabIndex = 0;
            // 
            // btnPanelSetup
            // 
            this.btnPanelSetup.Location = new System.Drawing.Point(3, 3);
            this.btnPanelSetup.Name = "btnPanelSetup";
            this.btnPanelSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPanelSetup.TabIndex = 6;
            this.btnPanelSetup.Text = "Panel setup";
            this.btnPanelSetup.UseVisualStyleBackColor = true;
            this.btnPanelSetup.Click += new System.EventHandler(this.btnPanelSetup_Click);
            // 
            // btnAPU
            // 
            this.btnAPU.AutoSize = true;
            this.btnAPU.Location = new System.Drawing.Point(3, 32);
            this.btnAPU.Name = "btnAPU";
            this.btnAPU.Size = new System.Drawing.Size(301, 39);
            this.btnAPU.TabIndex = 0;
            this.btnAPU.Text = "Electrical Power with APU";
            this.btnAPU.UseVisualStyleBackColor = true;
            this.btnAPU.Click += new System.EventHandler(this.btnAPU_Click);
            // 
            // btnGPU
            // 
            this.btnGPU.AutoSize = true;
            this.btnGPU.Location = new System.Drawing.Point(3, 77);
            this.btnGPU.Name = "btnGPU";
            this.btnGPU.Size = new System.Drawing.Size(304, 39);
            this.btnGPU.TabIndex = 1;
            this.btnGPU.Text = "Electrical Power with GPU";
            this.btnGPU.UseVisualStyleBackColor = true;
            this.btnGPU.Click += new System.EventHandler(this.btnGPU_Click);
            // 
            // btnIRS
            // 
            this.btnIRS.Location = new System.Drawing.Point(3, 122);
            this.btnIRS.Name = "btnIRS";
            this.btnIRS.Size = new System.Drawing.Size(75, 23);
            this.btnIRS.TabIndex = 2;
            this.btnIRS.Text = "Setup IRS";
            this.btnIRS.UseVisualStyleBackColor = true;
            this.btnIRS.Click += new System.EventHandler(this.btnIRS_Click);
            // 
            // grpTests
            // 
            this.grpTests.Controls.Add(this.TestFlowPanel);
            this.grpTests.Location = new System.Drawing.Point(3, 174);
            this.grpTests.Name = "grpTests";
            this.grpTests.Size = new System.Drawing.Size(200, 100);
            this.grpTests.TabIndex = 6;
            this.grpTests.TabStop = false;
            this.grpTests.Text = "System &Tests";
            // 
            // TestFlowPanel
            // 
            this.TestFlowPanel.Controls.Add(this.btnGPWS);
            this.TestFlowPanel.Controls.Add(this.btnFireTest);
            this.TestFlowPanel.Controls.Add(this.btnCVRTest);
            this.TestFlowPanel.Controls.Add(this.btnOverspeed);
            this.TestFlowPanel.Controls.Add(this.btnStallTest);
            this.TestFlowPanel.Location = new System.Drawing.Point(3, 32);
            this.TestFlowPanel.Name = "TestFlowPanel";
            this.TestFlowPanel.Size = new System.Drawing.Size(200, 100);
            this.TestFlowPanel.TabIndex = 5;
            // 
            // btnGPWS
            // 
            this.btnGPWS.AutoSize = true;
            this.btnGPWS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGPWS.Location = new System.Drawing.Point(3, 3);
            this.btnGPWS.Name = "btnGPWS";
            this.btnGPWS.Size = new System.Drawing.Size(139, 39);
            this.btnGPWS.TabIndex = 4;
            this.btnGPWS.Text = "GPWS test";
            this.btnGPWS.UseVisualStyleBackColor = true;
            // 
            // btnFireTest
            // 
            this.btnFireTest.AutoSize = true;
            this.btnFireTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFireTest.Location = new System.Drawing.Point(3, 48);
            this.btnFireTest.Name = "btnFireTest";
            this.btnFireTest.Size = new System.Drawing.Size(122, 39);
            this.btnFireTest.TabIndex = 3;
            this.btnFireTest.Text = "Fire tests";
            this.btnFireTest.UseVisualStyleBackColor = true;
            // 
            // btnCVRTest
            // 
            this.btnCVRTest.Location = new System.Drawing.Point(3, 93);
            this.btnCVRTest.Name = "btnCVRTest";
            this.btnCVRTest.Size = new System.Drawing.Size(75, 23);
            this.btnCVRTest.TabIndex = 5;
            this.btnCVRTest.Text = "Cockpit Voice Recorder Test";
            this.btnCVRTest.UseVisualStyleBackColor = true;
            // 
            // btnOverspeed
            // 
            this.btnOverspeed.Location = new System.Drawing.Point(84, 93);
            this.btnOverspeed.Name = "btnOverspeed";
            this.btnOverspeed.Size = new System.Drawing.Size(75, 23);
            this.btnOverspeed.TabIndex = 6;
            this.btnOverspeed.Text = "Overspeed Test";
            this.btnOverspeed.UseVisualStyleBackColor = true;
            // 
            // btnStallTest
            // 
            this.btnStallTest.Location = new System.Drawing.Point(3, 122);
            this.btnStallTest.Name = "btnStallTest";
            this.btnStallTest.Size = new System.Drawing.Size(75, 23);
            this.btnStallTest.TabIndex = 7;
            this.btnStallTest.Text = "Stall Warning Test";
            this.btnStallTest.UseVisualStyleBackColor = true;
            // 
            // tmrFlowStatus
            // 
            this.tmrFlowStatus.Interval = 500;
            this.tmrFlowStatus.Tick += new System.EventHandler(this.tmrFlowStatus_Tick);
            // 
            // frmPMDG737Flows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1244, 652);
            this.Controls.Add(this.VerticalFlowPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmPMDG737Flows";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PMDG737 Flows";
            this.Load += new System.EventHandler(this.frmPMDG737Flows_Load);
            this.VerticalFlowPanel.ResumeLayout(false);
            this.VerticalFlowPanel.PerformLayout();
            this.HorizontalFlowPanel.ResumeLayout(false);
            this.HorizontalFlowPanel.PerformLayout();
            this.GrpElectricalPower.ResumeLayout(false);
            this.ElectricalFlowPanel.ResumeLayout(false);
            this.ElectricalFlowPanel.PerformLayout();
            this.grpTests.ResumeLayout(false);
            this.TestFlowPanel.ResumeLayout(false);
            this.TestFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel VerticalFlowPanel;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.FlowLayoutPanel HorizontalFlowPanel;
        private System.Windows.Forms.GroupBox GrpElectricalPower;
        private System.Windows.Forms.FlowLayoutPanel ElectricalFlowPanel;
        private System.Windows.Forms.Button btnAPU;
        private System.Windows.Forms.Timer tmrFlowStatus;
        private System.Windows.Forms.Button btnGPU;
        private System.Windows.Forms.Button btnIRS;
        private System.Windows.Forms.Button btnPanelSetup;
        private System.Windows.Forms.GroupBox grpTests;
        private System.Windows.Forms.FlowLayoutPanel TestFlowPanel;
        private System.Windows.Forms.Button btnGPWS;
        private System.Windows.Forms.Button btnFireTest;
        private System.Windows.Forms.Button btnCVRTest;
        private System.Windows.Forms.Button btnOverspeed;
        private System.Windows.Forms.Button btnStallTest;
    }
}