namespace tfm.Settings_panels.Weather
{
    partial class ctlAutomaticAnnouncements
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
            this.automaticAnnouncementsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sapiCloudsCheckBox = new System.Windows.Forms.CheckBox();
            this.automaticAnnouncementsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // automaticAnnouncementsFlowLayoutPanel
            // 
            this.automaticAnnouncementsFlowLayoutPanel.AutoSize = true;
            this.automaticAnnouncementsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.automaticAnnouncementsFlowLayoutPanel.Controls.Add(this.sapiCloudsCheckBox);
            this.automaticAnnouncementsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.automaticAnnouncementsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.automaticAnnouncementsFlowLayoutPanel.Name = "automaticAnnouncementsFlowLayoutPanel";
            this.automaticAnnouncementsFlowLayoutPanel.Size = new System.Drawing.Size(274, 43);
            this.automaticAnnouncementsFlowLayoutPanel.TabIndex = 0;
            // 
            // sapiCloudsCheckBox
            // 
            this.sapiCloudsCheckBox.AccessibleName = "When available, use SAPI for automatic cloud announcements.";
            this.sapiCloudsCheckBox.AutoSize = true;
            this.sapiCloudsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.sapiCloudsCheckBox.Name = "sapiCloudsCheckBox";
            this.sapiCloudsCheckBox.Size = new System.Drawing.Size(268, 37);
            this.sapiCloudsCheckBox.TabIndex = 0;
            this.sapiCloudsCheckBox.Text = "Use SAPI for clouds";
            this.sapiCloudsCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlAutomaticAnnouncements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.automaticAnnouncementsFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlAutomaticAnnouncements";
            this.Size = new System.Drawing.Size(277, 46);
            this.Load += new System.EventHandler(this.ctlAutomaticAnnouncements_Load);
            this.automaticAnnouncementsFlowLayoutPanel.ResumeLayout(false);
            this.automaticAnnouncementsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel automaticAnnouncementsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox sapiCloudsCheckBox;
    }
}
