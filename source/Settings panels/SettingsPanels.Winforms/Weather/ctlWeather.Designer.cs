namespace tfm.Settings_panels.Weather
{
    partial class ctlWeather
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
            this.weatherFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshRateLabel = new System.Windows.Forms.Label();
            this.refreshRateNumericSpinner = new System.Windows.Forms.NumericUpDown();
            this.weatherFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateNumericSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // weatherFlowLayoutPanel
            // 
            this.weatherFlowLayoutPanel.AutoSize = true;
            this.weatherFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.weatherFlowLayoutPanel.Controls.Add(this.refreshRateLabel);
            this.weatherFlowLayoutPanel.Controls.Add(this.refreshRateNumericSpinner);
            this.weatherFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.weatherFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.weatherFlowLayoutPanel.Name = "weatherFlowLayoutPanel";
            this.weatherFlowLayoutPanel.Size = new System.Drawing.Size(249, 46);
            this.weatherFlowLayoutPanel.TabIndex = 0;
            // 
            // refreshRateLabel
            // 
            this.refreshRateLabel.AutoSize = true;
            this.refreshRateLabel.Location = new System.Drawing.Point(10, 0);
            this.refreshRateLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.refreshRateLabel.Name = "refreshRateLabel";
            this.refreshRateLabel.Size = new System.Drawing.Size(149, 33);
            this.refreshRateLabel.TabIndex = 0;
            this.refreshRateLabel.Text = "&Refresh rate";
            // 
            // refreshRateNumericSpinner
            // 
            this.refreshRateNumericSpinner.AccessibleName = "Refresh rate in minutes.";
            this.refreshRateNumericSpinner.AutoSize = true;
            this.refreshRateNumericSpinner.Location = new System.Drawing.Point(165, 3);
            this.refreshRateNumericSpinner.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.refreshRateNumericSpinner.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.refreshRateNumericSpinner.Name = "refreshRateNumericSpinner";
            this.refreshRateNumericSpinner.Size = new System.Drawing.Size(81, 40);
            this.refreshRateNumericSpinner.TabIndex = 1;
            this.refreshRateNumericSpinner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ctlWeather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.weatherFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlWeather";
            this.Size = new System.Drawing.Size(252, 49);
            this.Load += new System.EventHandler(this.ctlWeather_Load);
            this.weatherFlowLayoutPanel.ResumeLayout(false);
            this.weatherFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateNumericSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel weatherFlowLayoutPanel;
        private System.Windows.Forms.Label refreshRateLabel;
        private System.Windows.Forms.NumericUpDown refreshRateNumericSpinner;
    }
}
