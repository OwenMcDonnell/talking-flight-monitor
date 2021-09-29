namespace tfm
{
    partial class ctlHydraulics_777
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrHydraulics = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkEng1 = new System.Windows.Forms.CheckBox();
            this.chkEng2 = new System.Windows.Forms.CheckBox();
            this.grpCenter = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkElec1 = new System.Windows.Forms.CheckBox();
            this.chkElec2 = new System.Windows.Forms.CheckBox();
            this.grpAirDemand1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.radAirDemand1Off = new System.Windows.Forms.RadioButton();
            this.radAirDemand1Auto = new System.Windows.Forms.RadioButton();
            this.radAirDemand1On = new System.Windows.Forms.RadioButton();
            this.grpAirDemand2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.radAirDemand2Off = new System.Windows.Forms.RadioButton();
            this.radAirDemand2Auto = new System.Windows.Forms.RadioButton();
            this.radAirDemand2On = new System.Windows.Forms.RadioButton();
            this.grpLeftDemand = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radLeftDemandOff = new System.Windows.Forms.RadioButton();
            this.radLeftDemandAuto = new System.Windows.Forms.RadioButton();
            this.radLeftDemandOn = new System.Windows.Forms.RadioButton();
            this.grpRightDemand = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.radRightDemandPumpOff = new System.Windows.Forms.RadioButton();
            this.radRightDemandPumpAuto = new System.Windows.Forms.RadioButton();
            this.radRightDemandPumpOn = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.grpCenter.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.grpAirDemand1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.grpAirDemand2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.grpLeftDemand.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.grpRightDemand.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrHydraulics
            // 
            this.tmrHydraulics.Interval = 500;
            this.tmrHydraulics.Tick += new System.EventHandler(this.tmrHydraulics_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.chkEng1);
            this.flowLayoutPanel1.Controls.Add(this.chkEng2);
            this.flowLayoutPanel1.Controls.Add(this.grpCenter);
            this.flowLayoutPanel1.Controls.Add(this.grpLeftDemand);
            this.flowLayoutPanel1.Controls.Add(this.grpRightDemand);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1507, 159);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkEng1
            // 
            this.chkEng1.AutoSize = true;
            this.chkEng1.Location = new System.Drawing.Point(4, 5);
            this.chkEng1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEng1.Name = "chkEng1";
            this.chkEng1.Size = new System.Drawing.Size(98, 24);
            this.chkEng1.TabIndex = 2;
            this.chkEng1.Text = "Engine 1";
            this.chkEng1.UseVisualStyleBackColor = true;
            this.chkEng1.CheckedChanged += new System.EventHandler(this.chkEng1_CheckedChanged);
            // 
            // chkEng2
            // 
            this.chkEng2.AutoSize = true;
            this.chkEng2.Location = new System.Drawing.Point(110, 5);
            this.chkEng2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEng2.Name = "chkEng2";
            this.chkEng2.Size = new System.Drawing.Size(98, 24);
            this.chkEng2.TabIndex = 3;
            this.chkEng2.Text = "Engine 2";
            this.chkEng2.UseVisualStyleBackColor = true;
            this.chkEng2.CheckedChanged += new System.EventHandler(this.chkEng2_CheckedChanged);
            // 
            // grpCenter
            // 
            this.grpCenter.AutoSize = true;
            this.grpCenter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpCenter.Controls.Add(this.flowLayoutPanel2);
            this.grpCenter.Location = new System.Drawing.Point(215, 3);
            this.grpCenter.Name = "grpCenter";
            this.grpCenter.Size = new System.Drawing.Size(877, 153);
            this.grpCenter.TabIndex = 0;
            this.grpCenter.TabStop = false;
            this.grpCenter.Text = "Center";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.chkElec1);
            this.flowLayoutPanel2.Controls.Add(this.chkElec2);
            this.flowLayoutPanel2.Controls.Add(this.grpAirDemand1);
            this.flowLayoutPanel2.Controls.Add(this.grpAirDemand2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(868, 106);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // chkElec1
            // 
            this.chkElec1.AutoSize = true;
            this.chkElec1.Location = new System.Drawing.Point(4, 5);
            this.chkElec1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkElec1.Name = "chkElec1";
            this.chkElec1.Size = new System.Drawing.Size(220, 24);
            this.chkElec1.TabIndex = 1;
            this.chkElec1.Text = "Center Primary Electrical 1";
            this.chkElec1.UseVisualStyleBackColor = true;
            this.chkElec1.CheckedChanged += new System.EventHandler(this.chkElec1_CheckedChanged);
            // 
            // chkElec2
            // 
            this.chkElec2.AutoSize = true;
            this.chkElec2.Location = new System.Drawing.Point(232, 5);
            this.chkElec2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkElec2.Name = "chkElec2";
            this.chkElec2.Size = new System.Drawing.Size(220, 24);
            this.chkElec2.TabIndex = 2;
            this.chkElec2.Text = "Center Primary Electrical 2";
            this.chkElec2.UseVisualStyleBackColor = true;
            this.chkElec2.CheckedChanged += new System.EventHandler(this.chkElec2_CheckedChanged);
            // 
            // grpAirDemand1
            // 
            this.grpAirDemand1.Controls.Add(this.flowLayoutPanel4);
            this.grpAirDemand1.Location = new System.Drawing.Point(459, 3);
            this.grpAirDemand1.Name = "grpAirDemand1";
            this.grpAirDemand1.Size = new System.Drawing.Size(200, 100);
            this.grpAirDemand1.TabIndex = 3;
            this.grpAirDemand1.TabStop = false;
            this.grpAirDemand1.Text = "Air Demand Pump 1";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.radAirDemand1Off);
            this.flowLayoutPanel4.Controls.Add(this.radAirDemand1Auto);
            this.flowLayoutPanel4.Controls.Add(this.radAirDemand1On);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // radAirDemand1Off
            // 
            this.radAirDemand1Off.AutoSize = true;
            this.radAirDemand1Off.Location = new System.Drawing.Point(3, 3);
            this.radAirDemand1Off.Name = "radAirDemand1Off";
            this.radAirDemand1Off.Size = new System.Drawing.Size(56, 24);
            this.radAirDemand1Off.TabIndex = 0;
            this.radAirDemand1Off.TabStop = true;
            this.radAirDemand1Off.Text = "Off";
            this.radAirDemand1Off.UseVisualStyleBackColor = true;
            this.radAirDemand1Off.CheckedChanged += new System.EventHandler(this.radAirDemand1_CheckedChanged);
            // 
            // radAirDemand1Auto
            // 
            this.radAirDemand1Auto.AutoSize = true;
            this.radAirDemand1Auto.Location = new System.Drawing.Point(65, 3);
            this.radAirDemand1Auto.Name = "radAirDemand1Auto";
            this.radAirDemand1Auto.Size = new System.Drawing.Size(68, 24);
            this.radAirDemand1Auto.TabIndex = 1;
            this.radAirDemand1Auto.TabStop = true;
            this.radAirDemand1Auto.Text = "Auto";
            this.radAirDemand1Auto.UseVisualStyleBackColor = true;
            this.radAirDemand1Auto.CheckedChanged += new System.EventHandler(this.radAirDemand1_CheckedChanged);
            // 
            // radAirDemand1On
            // 
            this.radAirDemand1On.AutoSize = true;
            this.radAirDemand1On.Location = new System.Drawing.Point(139, 3);
            this.radAirDemand1On.Name = "radAirDemand1On";
            this.radAirDemand1On.Size = new System.Drawing.Size(55, 24);
            this.radAirDemand1On.TabIndex = 2;
            this.radAirDemand1On.TabStop = true;
            this.radAirDemand1On.Text = "On";
            this.radAirDemand1On.UseVisualStyleBackColor = true;
            this.radAirDemand1On.CheckedChanged += new System.EventHandler(this.radAirDemand1_CheckedChanged);
            // 
            // grpAirDemand2
            // 
            this.grpAirDemand2.Controls.Add(this.flowLayoutPanel5);
            this.grpAirDemand2.Location = new System.Drawing.Point(665, 3);
            this.grpAirDemand2.Name = "grpAirDemand2";
            this.grpAirDemand2.Size = new System.Drawing.Size(200, 100);
            this.grpAirDemand2.TabIndex = 4;
            this.grpAirDemand2.TabStop = false;
            this.grpAirDemand2.Text = "Air Demand Pump 2";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.radAirDemand2Off);
            this.flowLayoutPanel5.Controls.Add(this.radAirDemand2Auto);
            this.flowLayoutPanel5.Controls.Add(this.radAirDemand2On);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // radAirDemand2Off
            // 
            this.radAirDemand2Off.AutoSize = true;
            this.radAirDemand2Off.Location = new System.Drawing.Point(3, 3);
            this.radAirDemand2Off.Name = "radAirDemand2Off";
            this.radAirDemand2Off.Size = new System.Drawing.Size(56, 24);
            this.radAirDemand2Off.TabIndex = 0;
            this.radAirDemand2Off.TabStop = true;
            this.radAirDemand2Off.Text = "Off";
            this.radAirDemand2Off.UseVisualStyleBackColor = true;
            this.radAirDemand2Off.CheckedChanged += new System.EventHandler(this.radAirDemand2_CheckedChanged);
            // 
            // radAirDemand2Auto
            // 
            this.radAirDemand2Auto.AutoSize = true;
            this.radAirDemand2Auto.Location = new System.Drawing.Point(65, 3);
            this.radAirDemand2Auto.Name = "radAirDemand2Auto";
            this.radAirDemand2Auto.Size = new System.Drawing.Size(68, 24);
            this.radAirDemand2Auto.TabIndex = 1;
            this.radAirDemand2Auto.TabStop = true;
            this.radAirDemand2Auto.Text = "Auto";
            this.radAirDemand2Auto.UseVisualStyleBackColor = true;
            this.radAirDemand2Auto.CheckedChanged += new System.EventHandler(this.radAirDemand2_CheckedChanged);
            // 
            // radAirDemand2On
            // 
            this.radAirDemand2On.AutoSize = true;
            this.radAirDemand2On.Location = new System.Drawing.Point(139, 3);
            this.radAirDemand2On.Name = "radAirDemand2On";
            this.radAirDemand2On.Size = new System.Drawing.Size(55, 24);
            this.radAirDemand2On.TabIndex = 2;
            this.radAirDemand2On.TabStop = true;
            this.radAirDemand2On.Text = "On";
            this.radAirDemand2On.UseVisualStyleBackColor = true;
            this.radAirDemand2On.CheckedChanged += new System.EventHandler(this.radAirDemand2_CheckedChanged);
            // 
            // grpLeftDemand
            // 
            this.grpLeftDemand.Controls.Add(this.flowLayoutPanel3);
            this.grpLeftDemand.Location = new System.Drawing.Point(1098, 3);
            this.grpLeftDemand.Name = "grpLeftDemand";
            this.grpLeftDemand.Size = new System.Drawing.Size(200, 100);
            this.grpLeftDemand.TabIndex = 4;
            this.grpLeftDemand.TabStop = false;
            this.grpLeftDemand.Text = "Left Electrical Demand Pump";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.radLeftDemandOff);
            this.flowLayoutPanel3.Controls.Add(this.radLeftDemandAuto);
            this.flowLayoutPanel3.Controls.Add(this.radLeftDemandOn);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // radLeftDemandOff
            // 
            this.radLeftDemandOff.AutoSize = true;
            this.radLeftDemandOff.Location = new System.Drawing.Point(3, 3);
            this.radLeftDemandOff.Name = "radLeftDemandOff";
            this.radLeftDemandOff.Size = new System.Drawing.Size(56, 24);
            this.radLeftDemandOff.TabIndex = 0;
            this.radLeftDemandOff.TabStop = true;
            this.radLeftDemandOff.Text = "Off";
            this.radLeftDemandOff.UseVisualStyleBackColor = true;
            // 
            // radLeftDemandAuto
            // 
            this.radLeftDemandAuto.AutoSize = true;
            this.radLeftDemandAuto.Location = new System.Drawing.Point(65, 3);
            this.radLeftDemandAuto.Name = "radLeftDemandAuto";
            this.radLeftDemandAuto.Size = new System.Drawing.Size(68, 24);
            this.radLeftDemandAuto.TabIndex = 1;
            this.radLeftDemandAuto.TabStop = true;
            this.radLeftDemandAuto.Text = "Auto";
            this.radLeftDemandAuto.UseVisualStyleBackColor = true;
            // 
            // radLeftDemandOn
            // 
            this.radLeftDemandOn.AutoSize = true;
            this.radLeftDemandOn.Location = new System.Drawing.Point(139, 3);
            this.radLeftDemandOn.Name = "radLeftDemandOn";
            this.radLeftDemandOn.Size = new System.Drawing.Size(55, 24);
            this.radLeftDemandOn.TabIndex = 2;
            this.radLeftDemandOn.TabStop = true;
            this.radLeftDemandOn.Text = "On";
            this.radLeftDemandOn.UseVisualStyleBackColor = true;
            // 
            // grpRightDemand
            // 
            this.grpRightDemand.Controls.Add(this.flowLayoutPanel6);
            this.grpRightDemand.Location = new System.Drawing.Point(1304, 3);
            this.grpRightDemand.Name = "grpRightDemand";
            this.grpRightDemand.Size = new System.Drawing.Size(200, 100);
            this.grpRightDemand.TabIndex = 5;
            this.grpRightDemand.TabStop = false;
            this.grpRightDemand.Text = "Right Electrical Demand Pump";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.radRightDemandPumpOff);
            this.flowLayoutPanel6.Controls.Add(this.radRightDemandPumpAuto);
            this.flowLayoutPanel6.Controls.Add(this.radRightDemandPumpOn);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // radRightDemandPumpOff
            // 
            this.radRightDemandPumpOff.AutoSize = true;
            this.radRightDemandPumpOff.Location = new System.Drawing.Point(3, 3);
            this.radRightDemandPumpOff.Name = "radRightDemandPumpOff";
            this.radRightDemandPumpOff.Size = new System.Drawing.Size(56, 24);
            this.radRightDemandPumpOff.TabIndex = 0;
            this.radRightDemandPumpOff.TabStop = true;
            this.radRightDemandPumpOff.Text = "Off";
            this.radRightDemandPumpOff.UseVisualStyleBackColor = true;
            // 
            // radRightDemandPumpAuto
            // 
            this.radRightDemandPumpAuto.AutoSize = true;
            this.radRightDemandPumpAuto.Location = new System.Drawing.Point(65, 3);
            this.radRightDemandPumpAuto.Name = "radRightDemandPumpAuto";
            this.radRightDemandPumpAuto.Size = new System.Drawing.Size(68, 24);
            this.radRightDemandPumpAuto.TabIndex = 1;
            this.radRightDemandPumpAuto.TabStop = true;
            this.radRightDemandPumpAuto.Text = "Auto";
            this.radRightDemandPumpAuto.UseVisualStyleBackColor = true;
            // 
            // radRightDemandPumpOn
            // 
            this.radRightDemandPumpOn.AutoSize = true;
            this.radRightDemandPumpOn.Location = new System.Drawing.Point(139, 3);
            this.radRightDemandPumpOn.Name = "radRightDemandPumpOn";
            this.radRightDemandPumpOn.Size = new System.Drawing.Size(55, 24);
            this.radRightDemandPumpOn.TabIndex = 2;
            this.radRightDemandPumpOn.TabStop = true;
            this.radRightDemandPumpOn.Text = "On";
            this.radRightDemandPumpOn.UseVisualStyleBackColor = true;
            // 
            // ctlHydraulics_777
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ctlHydraulics_777";
            this.Size = new System.Drawing.Size(150, 149);
            this.Load += new System.EventHandler(this.ctlHydraulics_777_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grpCenter.ResumeLayout(false);
            this.grpCenter.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.grpAirDemand1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.grpAirDemand2.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.grpLeftDemand.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.grpRightDemand.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrHydraulics;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkEng1;
        private System.Windows.Forms.CheckBox chkEng2;
        private System.Windows.Forms.GroupBox grpCenter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkElec1;
        private System.Windows.Forms.CheckBox chkElec2;
        private System.Windows.Forms.GroupBox grpAirDemand1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton radAirDemand1Off;
        private System.Windows.Forms.RadioButton radAirDemand1Auto;
        private System.Windows.Forms.RadioButton radAirDemand1On;
        private System.Windows.Forms.GroupBox grpAirDemand2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.RadioButton radAirDemand2Off;
        private System.Windows.Forms.RadioButton radAirDemand2Auto;
        private System.Windows.Forms.RadioButton radAirDemand2On;
        private System.Windows.Forms.GroupBox grpLeftDemand;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radLeftDemandOff;
        private System.Windows.Forms.RadioButton radLeftDemandAuto;
        private System.Windows.Forms.RadioButton radLeftDemandOn;
        private System.Windows.Forms.GroupBox grpRightDemand;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.RadioButton radRightDemandPumpOff;
        private System.Windows.Forms.RadioButton radRightDemandPumpAuto;
        private System.Windows.Forms.RadioButton radRightDemandPumpOn;
    }
}
