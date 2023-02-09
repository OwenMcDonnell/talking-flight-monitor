namespace tfm
{
    partial class ctlGeneral
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGeonames = new System.Windows.Forms.Label();
            this.txtGeonames = new System.Windows.Forms.TextBox();
            this.chkMetric = new System.Windows.Forms.CheckBox();
            this.bingMapsLabel = new System.Windows.Forms.Label();
            this.bingMapsKeyTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblGeonames, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGeonames, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkMetric, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bingMapsLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bingMapsKeyTextBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 134);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblGeonames
            // 
            this.lblGeonames.AutoSize = true;
            this.lblGeonames.Location = new System.Drawing.Point(4, 0);
            this.lblGeonames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeonames.Name = "lblGeonames";
            this.lblGeonames.Size = new System.Drawing.Size(171, 20);
            this.lblGeonames.TabIndex = 1;
            this.lblGeonames.Text = "Geonames username: ";
            // 
            // txtGeonames
            // 
            this.txtGeonames.AccessibleName = "Geonames username";
            this.txtGeonames.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::tfm.Properties.Settings.Default, "GeonamesUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGeonames.Location = new System.Drawing.Point(233, 5);
            this.txtGeonames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGeonames.Name = "txtGeonames";
            this.txtGeonames.Size = new System.Drawing.Size(139, 26);
            this.txtGeonames.TabIndex = 2;
            this.txtGeonames.Text = global::tfm.Properties.Settings.Default.GeonamesUsername;
            // 
            // chkMetric
            // 
            this.chkMetric.AutoSize = true;
            settings1.AltitudeAnnouncements = true;
            settings1.AnnouncePerfInitComplete = true;
            settings1.AnnounceTakeoffConfigComplete = true;
            settings1.AttitudeAnnouncementMode = 1;
            settings1.avionics_tab = "simplified";
            settings1.AvionicsTabChangeFlag = false;
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
            settings1.MSFSAirportsDatabasePath = "";
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
            settings1.SapiILSAnnouncements = true;
            settings1.SAPISpeechRate = 0;
            settings1.SettingsKey = "";
            settings1.SettingsRequiresUpgrade = true;
            settings1.ShowFirstRunDialog = true;
            settings1.SpeechHistoryTimestamps = false;
            settings1.SpeechSystem = "ScreenReader";
            settings1.takeOffAssistMode = "off";
            settings1.UseDatabase = false;
            settings1.UseMetric = false;
            settings1.VatsimMode = false;
            this.chkMetric.Checked = settings1.UseMetric;
            this.chkMetric.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "UseMetric", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkMetric.Location = new System.Drawing.Point(4, 77);
            this.chkMetric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMetric.Name = "chkMetric";
            this.chkMetric.Size = new System.Drawing.Size(221, 21);
            this.chkMetric.TabIndex = 5;
            this.chkMetric.Text = "Use metric measurements";
            this.chkMetric.UseVisualStyleBackColor = true;
            this.chkMetric.Visible = false;
            // 
            // bingMapsLabel
            // 
            this.bingMapsLabel.AutoSize = true;
            this.bingMapsLabel.Location = new System.Drawing.Point(4, 36);
            this.bingMapsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bingMapsLabel.Name = "bingMapsLabel";
            this.bingMapsLabel.Size = new System.Drawing.Size(116, 20);
            this.bingMapsLabel.TabIndex = 3;
            this.bingMapsLabel.Text = "Bing maps key:";
            // 
            // bingMapsKeyTextBox
            // 
            this.bingMapsKeyTextBox.AccessibleName = "Bing maps API key";
            this.bingMapsKeyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::tfm.Properties.Settings.Default, "bingMapsAPIKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bingMapsKeyTextBox.Location = new System.Drawing.Point(233, 41);
            this.bingMapsKeyTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bingMapsKeyTextBox.Name = "bingMapsKeyTextBox";
            this.bingMapsKeyTextBox.Size = new System.Drawing.Size(148, 26);
            this.bingMapsKeyTextBox.TabIndex = 4;
            this.bingMapsKeyTextBox.Text = global::tfm.Properties.Settings.Default.bingMapsAPIKey;
            // 
            // ctlGeneral
            // 
            this.AccessibleName = "General settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctlGeneral";
            this.Size = new System.Drawing.Size(462, 139);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblGeonames;
        private System.Windows.Forms.TextBox txtGeonames;
        private System.Windows.Forms.CheckBox chkMetric;
        private System.Windows.Forms.Label bingMapsLabel;
        private System.Windows.Forms.TextBox bingMapsKeyTextBox;
    }
}
