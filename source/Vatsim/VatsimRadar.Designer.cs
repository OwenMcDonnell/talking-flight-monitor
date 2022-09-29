namespace tfm.Vatsim
{
    partial class VatsimRadar
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
            this.vatsimRadarTabControl = new System.Windows.Forms.TabControl();
            this.trafficTabPage = new System.Windows.Forms.TabPage();
            this.distanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.usersListView = new System.Windows.Forms.ListView();
            this.callSignColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.distanceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.altitudeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headingColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bearingToColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groundSpeedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ratingColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controllersTabPage = new System.Windows.Forms.TabPage();
            this.controllersListView = new System.Windows.Forms.ListView();
            this.controllerCallSignColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controllerFacilityShortNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controllerFrequencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controllerVisualRangeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controllerRatingColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vatsimRadarTabControl.SuspendLayout();
            this.trafficTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).BeginInit();
            this.controllersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // vatsimRadarTabControl
            // 
            this.vatsimRadarTabControl.AccessibleName = "Vatsim radar controls";
            this.vatsimRadarTabControl.Controls.Add(this.trafficTabPage);
            this.vatsimRadarTabControl.Controls.Add(this.controllersTabPage);
            this.vatsimRadarTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vatsimRadarTabControl.Location = new System.Drawing.Point(0, 0);
            this.vatsimRadarTabControl.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.vatsimRadarTabControl.Name = "vatsimRadarTabControl";
            this.vatsimRadarTabControl.SelectedIndex = 0;
            this.vatsimRadarTabControl.Size = new System.Drawing.Size(1478, 944);
            this.vatsimRadarTabControl.TabIndex = 0;
            // 
            // trafficTabPage
            // 
            this.trafficTabPage.AccessibleName = "aircraft traffic";
            this.trafficTabPage.Controls.Add(this.distanceNumericUpDown);
            this.trafficTabPage.Controls.Add(this.rangeLabel);
            this.trafficTabPage.Controls.Add(this.usersListView);
            this.trafficTabPage.Location = new System.Drawing.Point(4, 42);
            this.trafficTabPage.Name = "trafficTabPage";
            this.trafficTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.trafficTabPage.Size = new System.Drawing.Size(1470, 898);
            this.trafficTabPage.TabIndex = 0;
            this.trafficTabPage.Text = "Traffic";
            this.trafficTabPage.UseVisualStyleBackColor = true;
            // 
            // distanceNumericUpDown
            // 
            this.distanceNumericUpDown.AccessibleName = "Radar distance (NM)";
            this.distanceNumericUpDown.AutoSize = true;
            this.distanceNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.distanceNumericUpDown.Location = new System.Drawing.Point(161, 848);
            this.distanceNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.distanceNumericUpDown.Name = "distanceNumericUpDown";
            this.distanceNumericUpDown.Size = new System.Drawing.Size(120, 40);
            this.distanceNumericUpDown.TabIndex = 2;
            this.distanceNumericUpDown.ValueChanged += new System.EventHandler(this.distanceNumericUpDown_ValueChanged);
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(10, 850);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(182, 33);
            this.rangeLabel.TabIndex = 1;
            this.rangeLabel.Text = "&Distance (NM)";
            // 
            // usersListView
            // 
            this.usersListView.AccessibleName = "Vatsim users";
            this.usersListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.usersListView.AllowColumnReorder = true;
            this.usersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.callSignColumnHeader,
            this.distanceColumnHeader,
            this.altitudeColumnHeader,
            this.headingColumnHeader,
            this.bearingToColumnHeader,
            this.groundSpeedColumnHeader,
            this.ratingColumnHeader});
            this.usersListView.HideSelection = false;
            this.usersListView.HoverSelection = true;
            this.usersListView.Location = new System.Drawing.Point(0, 0);
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(1470, 842);
            this.usersListView.TabIndex = 0;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.Details;
            // 
            // callSignColumnHeader
            // 
            this.callSignColumnHeader.Text = "Call sign";
            this.callSignColumnHeader.Width = 200;
            // 
            // distanceColumnHeader
            // 
            this.distanceColumnHeader.Text = "Distance";
            this.distanceColumnHeader.Width = 200;
            // 
            // altitudeColumnHeader
            // 
            this.altitudeColumnHeader.Text = "Altitude";
            this.altitudeColumnHeader.Width = 200;
            // 
            // headingColumnHeader
            // 
            this.headingColumnHeader.Text = "Heading";
            this.headingColumnHeader.Width = 200;
            // 
            // bearingToColumnHeader
            // 
            this.bearingToColumnHeader.Text = "Bearing to";
            this.bearingToColumnHeader.Width = 200;
            // 
            // groundSpeedColumnHeader
            // 
            this.groundSpeedColumnHeader.Text = "Ground speed";
            this.groundSpeedColumnHeader.Width = 200;
            // 
            // ratingColumnHeader
            // 
            this.ratingColumnHeader.Text = "Rating";
            this.ratingColumnHeader.Width = 200;
            // 
            // controllersTabPage
            // 
            this.controllersTabPage.AccessibleName = "Controllers in range";
            this.controllersTabPage.Controls.Add(this.controllersListView);
            this.controllersTabPage.Location = new System.Drawing.Point(4, 42);
            this.controllersTabPage.Name = "controllersTabPage";
            this.controllersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.controllersTabPage.Size = new System.Drawing.Size(1470, 898);
            this.controllersTabPage.TabIndex = 1;
            this.controllersTabPage.Text = "Controllers";
            this.controllersTabPage.UseVisualStyleBackColor = true;
            // 
            // controllersListView
            // 
            this.controllersListView.AccessibleName = "Controllers";
            this.controllersListView.AllowColumnReorder = true;
            this.controllersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.controllerCallSignColumnHeader,
            this.controllerFacilityShortNameColumnHeader,
            this.controllerFrequencyColumnHeader,
            this.controllerVisualRangeColumnHeader,
            this.controllerRatingColumnHeader});
            this.controllersListView.HideSelection = false;
            this.controllersListView.Location = new System.Drawing.Point(0, 0);
            this.controllersListView.Name = "controllersListView";
            this.controllersListView.Size = new System.Drawing.Size(1470, 842);
            this.controllersListView.TabIndex = 0;
            this.controllersListView.UseCompatibleStateImageBehavior = false;
            this.controllersListView.View = System.Windows.Forms.View.Details;
            // 
            // controllerCallSignColumnHeader
            // 
            this.controllerCallSignColumnHeader.Text = "Callsign";
            this.controllerCallSignColumnHeader.Width = 293;
            // 
            // controllerFacilityShortNameColumnHeader
            // 
            this.controllerFacilityShortNameColumnHeader.Text = "Facility";
            this.controllerFacilityShortNameColumnHeader.Width = 293;
            // 
            // controllerFrequencyColumnHeader
            // 
            this.controllerFrequencyColumnHeader.Text = "Frequency";
            this.controllerFrequencyColumnHeader.Width = 293;
            // 
            // controllerVisualRangeColumnHeader
            // 
            this.controllerVisualRangeColumnHeader.Text = "Visual range";
            this.controllerVisualRangeColumnHeader.Width = 293;
            // 
            // controllerRatingColumnHeader
            // 
            this.controllerRatingColumnHeader.Text = "Rating";
            this.controllerRatingColumnHeader.Width = 293;
            // 
            // VatsimRadar
            // 
            this.AccessibleName = "Vatsim radar";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.vatsimRadarTabControl);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "VatsimRadar";
            this.ShowInTaskbar = false;
            this.Text = "Vatsim radar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VatsimRadar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VatsimRadar_KeyDown);
            this.vatsimRadarTabControl.ResumeLayout(false);
            this.trafficTabPage.ResumeLayout(false);
            this.trafficTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).EndInit();
            this.controllersTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl vatsimRadarTabControl;
        private System.Windows.Forms.TabPage trafficTabPage;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.TabPage controllersTabPage;
        private System.Windows.Forms.ColumnHeader callSignColumnHeader;
        private System.Windows.Forms.ColumnHeader distanceColumnHeader;
        private System.Windows.Forms.ColumnHeader altitudeColumnHeader;
        private System.Windows.Forms.ColumnHeader headingColumnHeader;
        private System.Windows.Forms.ColumnHeader groundSpeedColumnHeader;
        private System.Windows.Forms.ColumnHeader ratingColumnHeader;
        private System.Windows.Forms.ColumnHeader bearingToColumnHeader;
        private System.Windows.Forms.NumericUpDown distanceNumericUpDown;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.ListView controllersListView;
        private System.Windows.Forms.ColumnHeader controllerCallSignColumnHeader;
        private System.Windows.Forms.ColumnHeader controllerFacilityShortNameColumnHeader;
        private System.Windows.Forms.ColumnHeader controllerFrequencyColumnHeader;
        private System.Windows.Forms.ColumnHeader controllerVisualRangeColumnHeader;
        private System.Windows.Forms.ColumnHeader controllerRatingColumnHeader;
    }
}