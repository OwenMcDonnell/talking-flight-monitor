namespace tfm.Settings_panels.PMDG737
{
    partial class ctlAirSystems
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
            tfm.Properties.Settings settings1 = new tfm.Properties.Settings();
            this.airSystemsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.fltAltitudeCheckBox = new System.Windows.Forms.CheckBox();
            this.lndAltCheckBox = new System.Windows.Forms.CheckBox();
            this.airSourceCheckBox = new System.Windows.Forms.CheckBox();
            this.pressModeCheckBox = new System.Windows.Forms.CheckBox();
            this.leftPackCheckBox = new System.Windows.Forms.CheckBox();
            this.rightPackCheckBox = new System.Windows.Forms.CheckBox();
            this.leftBleedCheckBox = new System.Windows.Forms.CheckBox();
            this.rightBleedCheckBox = new System.Windows.Forms.CheckBox();
            this.apuBleedCheckBox = new System.Windows.Forms.CheckBox();
            this.leftRecircFanCheckBox = new System.Windows.Forms.CheckBox();
            this.rightRecircFanCheckBox = new System.Windows.Forms.CheckBox();
            this.airTrimCheckBox = new System.Windows.Forms.CheckBox();
            this.outflowValveCheckBox = new System.Windows.Forms.CheckBox();
            this.isolValveCheckBox = new System.Windows.Forms.CheckBox();
            this.fltDeckCheckBox = new System.Windows.Forms.CheckBox();
            this.fwdCabinCheckBox = new System.Windows.Forms.CheckBox();
            this.aftCabinCheckBox = new System.Windows.Forms.CheckBox();
            this.dualBleedCheckBox = new System.Windows.Forms.CheckBox();
            this.leftBleedTripCheckBox = new System.Windows.Forms.CheckBox();
            this.rightBleedTripCheckBox = new System.Windows.Forms.CheckBox();
            this.leftRamDoorCheckBox = new System.Windows.Forms.CheckBox();
            this.rightRamDoorCheckBox = new System.Windows.Forms.CheckBox();
            this.leftPackTripCheckBox = new System.Windows.Forms.CheckBox();
            this.rightPackTripCheckBox = new System.Windows.Forms.CheckBox();
            this.leftWingOverheatCheckBox = new System.Windows.Forms.CheckBox();
            this.rightWingOverheatCheckBox = new System.Windows.Forms.CheckBox();
            this.airSystemsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // airSystemsFlowLayoutPanel
            // 
            this.airSystemsFlowLayoutPanel.AutoSize = true;
            this.airSystemsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.airSystemsFlowLayoutPanel.Controls.Add(this.fltAltitudeCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.lndAltCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.airSourceCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.pressModeCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftPackCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightPackCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftBleedCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightBleedCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.apuBleedCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftRecircFanCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightRecircFanCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.airTrimCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.outflowValveCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.isolValveCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.fltDeckCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.fwdCabinCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.aftCabinCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.dualBleedCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftBleedTripCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightBleedTripCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftRamDoorCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightRamDoorCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftPackTripCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightPackTripCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.leftWingOverheatCheckBox);
            this.airSystemsFlowLayoutPanel.Controls.Add(this.rightWingOverheatCheckBox);
            this.airSystemsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.airSystemsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.airSystemsFlowLayoutPanel.Name = "airSystemsFlowLayoutPanel";
            this.airSystemsFlowLayoutPanel.Size = new System.Drawing.Size(1905, 129);
            this.airSystemsFlowLayoutPanel.TabIndex = 0;
            // 
            // fltAltitudeCheckBox
            // 
            this.fltAltitudeCheckBox.AccessibleName = "Flight altitude display";
            this.fltAltitudeCheckBox.AutoSize = true;
            settings1.AltitudeAnnouncements = true;
            settings1.AnnouncePerfInitComplete = true;
            settings1.AnnounceTakeoffConfigComplete = true;
            settings1.AttitudeAnnouncementMode = 1;
            settings1.AzureAPIKey = "";
            settings1.AzureServiceRegion = "";
            settings1.AzureVoice = "";
            settings1.bingMapsAPIKey = "";
            settings1.FallbackSpeechSystem = "ScreenReader";
            settings1.FlightFollowing = false;
            settings1.FlightFollowingOffline = false;
            settings1.FlightFollowingTimeInterval = "10";
            settings1.GeonamesUsername = "";
            settings1.ILSAnnouncementTimeInterval = "5";
            settings1.NewAvionicsTab = "";
            settings1.OutputBraille = true;
            settings1.OutputHistoryLength = new decimal(new int[] {
            50,
            0,
            0,
            0});
            settings1.P3DAirportsDatabasePath = "";
            settings1.PlayShutdownSound = true;
            settings1.PlayStartupSound = true;
            settings1.PMDGCDUKeyLayout = "1";
            settings1.ReadAutopilot = false;
            settings1.ReadFlaps = true;
            settings1.ReadGPWS = true;
            settings1.ReadGroundSpeed = true;
            settings1.ReadGSAltitude = false;
            settings1.ReadILS = true;
            settings1.AutomaticAnnouncements = true;
            settings1.ReadLocaliserHeadingOffsets = false;
            settings1.ReadNavRadios = false;
            settings1.ReadSimconnectMessages = true;
            settings1.SAPISpeechRate = 0;
            settings1.SettingsKey = "";
            settings1.SettingsRequiresUpgrade = true;
            settings1.SpeechHistoryTimestamps = false;
            settings1.SpeechSystem = "ScreenReader";
            settings1.takeOffAssistMode = "off";
            settings1.UseDatabase = false;
            settings1.UseMetric = false;
            this.fltAltitudeCheckBox.Checked = settings1.ReadLocaliserHeadingOffsets;
            this.fltAltitudeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.fltAltitudeCheckBox.Name = "fltAltitudeCheckBox";
            this.fltAltitudeCheckBox.Size = new System.Drawing.Size(108, 37);
            this.fltAltitudeCheckBox.TabIndex = 0;
            this.fltAltitudeCheckBox.Text = "Flt alt";
            this.fltAltitudeCheckBox.UseVisualStyleBackColor = true;
            // 
            // lndAltCheckBox
            // 
            this.lndAltCheckBox.AccessibleName = "Landing altitude display";
            this.lndAltCheckBox.AutoSize = true;
            this.lndAltCheckBox.Location = new System.Drawing.Point(117, 3);
            this.lndAltCheckBox.Name = "lndAltCheckBox";
            this.lndAltCheckBox.Size = new System.Drawing.Size(120, 37);
            this.lndAltCheckBox.TabIndex = 1;
            this.lndAltCheckBox.Text = "Lnd alt";
            this.lndAltCheckBox.UseVisualStyleBackColor = true;
            // 
            // airSourceCheckBox
            // 
            this.airSourceCheckBox.AccessibleName = "Air source slector switch";
            this.airSourceCheckBox.AutoSize = true;
            this.airSourceCheckBox.Location = new System.Drawing.Point(243, 3);
            this.airSourceCheckBox.Name = "airSourceCheckBox";
            this.airSourceCheckBox.Size = new System.Drawing.Size(156, 37);
            this.airSourceCheckBox.TabIndex = 2;
            this.airSourceCheckBox.Text = "Air source";
            this.airSourceCheckBox.UseVisualStyleBackColor = true;
            // 
            // pressModeCheckBox
            // 
            this.pressModeCheckBox.AccessibleName = "Pressurization mode selector switch";
            this.pressModeCheckBox.AutoSize = true;
            this.pressModeCheckBox.Location = new System.Drawing.Point(405, 3);
            this.pressModeCheckBox.Name = "pressModeCheckBox";
            this.pressModeCheckBox.Size = new System.Drawing.Size(174, 37);
            this.pressModeCheckBox.TabIndex = 3;
            this.pressModeCheckBox.Text = "Press. mode";
            this.pressModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftPackCheckBox
            // 
            this.leftPackCheckBox.AccessibleName = "Left pack selector switch";
            this.leftPackCheckBox.AutoSize = true;
            this.leftPackCheckBox.Location = new System.Drawing.Point(585, 3);
            this.leftPackCheckBox.Name = "leftPackCheckBox";
            this.leftPackCheckBox.Size = new System.Drawing.Size(123, 37);
            this.leftPackCheckBox.TabIndex = 4;
            this.leftPackCheckBox.Text = "L. pack";
            this.leftPackCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightPackCheckBox
            // 
            this.rightPackCheckBox.AccessibleName = "Right pack selector switch";
            this.rightPackCheckBox.AutoSize = true;
            this.rightPackCheckBox.Location = new System.Drawing.Point(714, 3);
            this.rightPackCheckBox.Name = "rightPackCheckBox";
            this.rightPackCheckBox.Size = new System.Drawing.Size(126, 37);
            this.rightPackCheckBox.TabIndex = 5;
            this.rightPackCheckBox.Text = "R. pack";
            this.rightPackCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftBleedCheckBox
            // 
            this.leftBleedCheckBox.AccessibleName = "Left bleed switch";
            this.leftBleedCheckBox.AutoSize = true;
            this.leftBleedCheckBox.Location = new System.Drawing.Point(846, 3);
            this.leftBleedCheckBox.Name = "leftBleedCheckBox";
            this.leftBleedCheckBox.Size = new System.Drawing.Size(131, 37);
            this.leftBleedCheckBox.TabIndex = 6;
            this.leftBleedCheckBox.Text = "L. bleed";
            this.leftBleedCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightBleedCheckBox
            // 
            this.rightBleedCheckBox.AccessibleName = "Right bleed switch";
            this.rightBleedCheckBox.AutoSize = true;
            this.rightBleedCheckBox.Location = new System.Drawing.Point(983, 3);
            this.rightBleedCheckBox.Name = "rightBleedCheckBox";
            this.rightBleedCheckBox.Size = new System.Drawing.Size(134, 37);
            this.rightBleedCheckBox.TabIndex = 7;
            this.rightBleedCheckBox.Text = "R. bleed";
            this.rightBleedCheckBox.UseVisualStyleBackColor = true;
            // 
            // apuBleedCheckBox
            // 
            this.apuBleedCheckBox.AccessibleName = "APU bleed switch";
            this.apuBleedCheckBox.AutoSize = true;
            this.apuBleedCheckBox.Location = new System.Drawing.Point(1123, 3);
            this.apuBleedCheckBox.Name = "apuBleedCheckBox";
            this.apuBleedCheckBox.Size = new System.Drawing.Size(162, 37);
            this.apuBleedCheckBox.TabIndex = 8;
            this.apuBleedCheckBox.Text = "APU bleed";
            this.apuBleedCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftRecircFanCheckBox
            // 
            this.leftRecircFanCheckBox.AccessibleName = "Left recirc fan switch";
            this.leftRecircFanCheckBox.AutoSize = true;
            this.leftRecircFanCheckBox.Location = new System.Drawing.Point(1291, 3);
            this.leftRecircFanCheckBox.Name = "leftRecircFanCheckBox";
            this.leftRecircFanCheckBox.Size = new System.Drawing.Size(133, 37);
            this.leftRecircFanCheckBox.TabIndex = 9;
            this.leftRecircFanCheckBox.Text = "L. recirc";
            this.leftRecircFanCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightRecircFanCheckBox
            // 
            this.rightRecircFanCheckBox.AccessibleName = "Right recirc fan switch";
            this.rightRecircFanCheckBox.AutoSize = true;
            this.rightRecircFanCheckBox.Location = new System.Drawing.Point(1430, 3);
            this.rightRecircFanCheckBox.Name = "rightRecircFanCheckBox";
            this.rightRecircFanCheckBox.Size = new System.Drawing.Size(136, 37);
            this.rightRecircFanCheckBox.TabIndex = 10;
            this.rightRecircFanCheckBox.Text = "R. recirc";
            this.rightRecircFanCheckBox.UseVisualStyleBackColor = true;
            // 
            // airTrimCheckBox
            // 
            this.airTrimCheckBox.AccessibleName = "Air trim switch";
            this.airTrimCheckBox.AutoSize = true;
            this.airTrimCheckBox.Location = new System.Drawing.Point(1572, 3);
            this.airTrimCheckBox.Name = "airTrimCheckBox";
            this.airTrimCheckBox.Size = new System.Drawing.Size(129, 37);
            this.airTrimCheckBox.TabIndex = 11;
            this.airTrimCheckBox.Text = "Air trim";
            this.airTrimCheckBox.UseVisualStyleBackColor = true;
            // 
            // outflowValveCheckBox
            // 
            this.outflowValveCheckBox.AccessibleName = "Outflow valve switch";
            this.outflowValveCheckBox.AutoSize = true;
            this.outflowValveCheckBox.Location = new System.Drawing.Point(1707, 3);
            this.outflowValveCheckBox.Name = "outflowValveCheckBox";
            this.outflowValveCheckBox.Size = new System.Drawing.Size(195, 37);
            this.outflowValveCheckBox.TabIndex = 12;
            this.outflowValveCheckBox.Text = "OTFLW valve";
            this.outflowValveCheckBox.UseVisualStyleBackColor = true;
            // 
            // isolValveCheckBox
            // 
            this.isolValveCheckBox.AccessibleName = "Isolation valve switch";
            this.isolValveCheckBox.AutoSize = true;
            this.isolValveCheckBox.Location = new System.Drawing.Point(3, 46);
            this.isolValveCheckBox.Name = "isolValveCheckBox";
            this.isolValveCheckBox.Size = new System.Drawing.Size(152, 37);
            this.isolValveCheckBox.TabIndex = 13;
            this.isolValveCheckBox.Text = "Isol. valve";
            this.isolValveCheckBox.UseVisualStyleBackColor = true;
            // 
            // fltDeckCheckBox
            // 
            this.fltDeckCheckBox.AccessibleName = "Flight deck zone temp indicator";
            this.fltDeckCheckBox.AutoSize = true;
            this.fltDeckCheckBox.Location = new System.Drawing.Point(161, 46);
            this.fltDeckCheckBox.Name = "fltDeckCheckBox";
            this.fltDeckCheckBox.Size = new System.Drawing.Size(240, 37);
            this.fltDeckCheckBox.TabIndex = 14;
            this.fltDeckCheckBox.Text = "Flt dck zone temp";
            this.fltDeckCheckBox.UseVisualStyleBackColor = true;
            // 
            // fwdCabinCheckBox
            // 
            this.fwdCabinCheckBox.AccessibleName = "Forward cabin zone temp indicator";
            this.fwdCabinCheckBox.AutoSize = true;
            this.fwdCabinCheckBox.Location = new System.Drawing.Point(407, 46);
            this.fwdCabinCheckBox.Name = "fwdCabinCheckBox";
            this.fwdCabinCheckBox.Size = new System.Drawing.Size(275, 37);
            this.fwdCabinCheckBox.TabIndex = 15;
            this.fwdCabinCheckBox.Text = "FWD cab. zone temp";
            this.fwdCabinCheckBox.UseVisualStyleBackColor = true;
            // 
            // aftCabinCheckBox
            // 
            this.aftCabinCheckBox.AccessibleName = "Aft cabin zone temp indicator";
            this.aftCabinCheckBox.AutoSize = true;
            this.aftCabinCheckBox.Location = new System.Drawing.Point(688, 46);
            this.aftCabinCheckBox.Name = "aftCabinCheckBox";
            this.aftCabinCheckBox.Size = new System.Drawing.Size(263, 37);
            this.aftCabinCheckBox.TabIndex = 16;
            this.aftCabinCheckBox.Text = "AFT cab. zone temp";
            this.aftCabinCheckBox.UseVisualStyleBackColor = true;
            // 
            // dualBleedCheckBox
            // 
            this.dualBleedCheckBox.AccessibleName = "Dual bleed indicator";
            this.dualBleedCheckBox.AutoSize = true;
            this.dualBleedCheckBox.Location = new System.Drawing.Point(957, 46);
            this.dualBleedCheckBox.Name = "dualBleedCheckBox";
            this.dualBleedCheckBox.Size = new System.Drawing.Size(162, 37);
            this.dualBleedCheckBox.TabIndex = 17;
            this.dualBleedCheckBox.Text = "Dual bleed";
            this.dualBleedCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftBleedTripCheckBox
            // 
            this.leftBleedTripCheckBox.AccessibleName = "Left bleed trip indicator";
            this.leftBleedTripCheckBox.AutoSize = true;
            this.leftBleedTripCheckBox.Location = new System.Drawing.Point(1125, 46);
            this.leftBleedTripCheckBox.Name = "leftBleedTripCheckBox";
            this.leftBleedTripCheckBox.Size = new System.Drawing.Size(199, 37);
            this.leftBleedTripCheckBox.TabIndex = 18;
            this.leftBleedTripCheckBox.Text = "Left bleed trip";
            this.leftBleedTripCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightBleedTripCheckBox
            // 
            this.rightBleedTripCheckBox.AccessibleName = "Right bleed trip indicator";
            this.rightBleedTripCheckBox.AutoSize = true;
            this.rightBleedTripCheckBox.Location = new System.Drawing.Point(1330, 46);
            this.rightBleedTripCheckBox.Name = "rightBleedTripCheckBox";
            this.rightBleedTripCheckBox.Size = new System.Drawing.Size(216, 37);
            this.rightBleedTripCheckBox.TabIndex = 19;
            this.rightBleedTripCheckBox.Text = "Right bleed trip";
            this.rightBleedTripCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftRamDoorCheckBox
            // 
            this.leftRamDoorCheckBox.AccessibleName = "Left ram door indicator";
            this.leftRamDoorCheckBox.AutoSize = true;
            this.leftRamDoorCheckBox.Location = new System.Drawing.Point(1552, 46);
            this.leftRamDoorCheckBox.Name = "leftRamDoorCheckBox";
            this.leftRamDoorCheckBox.Size = new System.Drawing.Size(192, 37);
            this.leftRamDoorCheckBox.TabIndex = 20;
            this.leftRamDoorCheckBox.Text = "Left ram door";
            this.leftRamDoorCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightRamDoorCheckBox
            // 
            this.rightRamDoorCheckBox.AccessibleName = "Right ram door indicator";
            this.rightRamDoorCheckBox.AutoSize = true;
            this.rightRamDoorCheckBox.Location = new System.Drawing.Point(3, 89);
            this.rightRamDoorCheckBox.Name = "rightRamDoorCheckBox";
            this.rightRamDoorCheckBox.Size = new System.Drawing.Size(209, 37);
            this.rightRamDoorCheckBox.TabIndex = 21;
            this.rightRamDoorCheckBox.Text = "Right ram door";
            this.rightRamDoorCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftPackTripCheckBox
            // 
            this.leftPackTripCheckBox.AccessibleName = "Left pack trip indicator";
            this.leftPackTripCheckBox.AutoSize = true;
            this.leftPackTripCheckBox.Location = new System.Drawing.Point(218, 89);
            this.leftPackTripCheckBox.Name = "leftPackTripCheckBox";
            this.leftPackTripCheckBox.Size = new System.Drawing.Size(191, 37);
            this.leftPackTripCheckBox.TabIndex = 22;
            this.leftPackTripCheckBox.Text = "Left pack trip";
            this.leftPackTripCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightPackTripCheckBox
            // 
            this.rightPackTripCheckBox.AccessibleName = "Right pack trip indicator";
            this.rightPackTripCheckBox.AutoSize = true;
            this.rightPackTripCheckBox.Location = new System.Drawing.Point(415, 89);
            this.rightPackTripCheckBox.Name = "rightPackTripCheckBox";
            this.rightPackTripCheckBox.Size = new System.Drawing.Size(208, 37);
            this.rightPackTripCheckBox.TabIndex = 23;
            this.rightPackTripCheckBox.Text = "Right pack trip";
            this.rightPackTripCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftWingOverheatCheckBox
            // 
            this.leftWingOverheatCheckBox.AccessibleName = "Left wing overheat indicator";
            this.leftWingOverheatCheckBox.AutoSize = true;
            this.leftWingOverheatCheckBox.Location = new System.Drawing.Point(629, 89);
            this.leftWingOverheatCheckBox.Name = "leftWingOverheatCheckBox";
            this.leftWingOverheatCheckBox.Size = new System.Drawing.Size(229, 37);
            this.leftWingOverheatCheckBox.TabIndex = 24;
            this.leftWingOverheatCheckBox.Text = "Left wing OVHT";
            this.leftWingOverheatCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightWingOverheatCheckBox
            // 
            this.rightWingOverheatCheckBox.AccessibleName = "Right wing overheat indicator";
            this.rightWingOverheatCheckBox.AutoSize = true;
            this.rightWingOverheatCheckBox.Location = new System.Drawing.Point(864, 89);
            this.rightWingOverheatCheckBox.Name = "rightWingOverheatCheckBox";
            this.rightWingOverheatCheckBox.Size = new System.Drawing.Size(229, 37);
            this.rightWingOverheatCheckBox.TabIndex = 25;
            this.rightWingOverheatCheckBox.Text = "Left wing OVHT";
            this.rightWingOverheatCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlAirSystems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.airSystemsFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlAirSystems";
            this.Size = new System.Drawing.Size(1908, 132);
            this.Load += new System.EventHandler(this.ctlAirSystems_Load);
            this.airSystemsFlowLayoutPanel.ResumeLayout(false);
            this.airSystemsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel airSystemsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox fltAltitudeCheckBox;
        private System.Windows.Forms.CheckBox lndAltCheckBox;
        private System.Windows.Forms.CheckBox airSourceCheckBox;
        private System.Windows.Forms.CheckBox pressModeCheckBox;
        private System.Windows.Forms.CheckBox leftPackCheckBox;
        private System.Windows.Forms.CheckBox rightPackCheckBox;
        private System.Windows.Forms.CheckBox leftBleedCheckBox;
        private System.Windows.Forms.CheckBox rightBleedCheckBox;
        private System.Windows.Forms.CheckBox apuBleedCheckBox;
        private System.Windows.Forms.CheckBox leftRecircFanCheckBox;
        private System.Windows.Forms.CheckBox rightRecircFanCheckBox;
        private System.Windows.Forms.CheckBox airTrimCheckBox;
        private System.Windows.Forms.CheckBox outflowValveCheckBox;
        private System.Windows.Forms.CheckBox isolValveCheckBox;
        private System.Windows.Forms.CheckBox fltDeckCheckBox;
        private System.Windows.Forms.CheckBox fwdCabinCheckBox;
        private System.Windows.Forms.CheckBox aftCabinCheckBox;
        private System.Windows.Forms.CheckBox dualBleedCheckBox;
        private System.Windows.Forms.CheckBox leftBleedTripCheckBox;
        private System.Windows.Forms.CheckBox rightBleedTripCheckBox;
        private System.Windows.Forms.CheckBox leftRamDoorCheckBox;
        private System.Windows.Forms.CheckBox rightRamDoorCheckBox;
        private System.Windows.Forms.CheckBox leftPackTripCheckBox;
        private System.Windows.Forms.CheckBox rightPackTripCheckBox;
        private System.Windows.Forms.CheckBox leftWingOverheatCheckBox;
        private System.Windows.Forms.CheckBox rightWingOverheatCheckBox;
    }
}
