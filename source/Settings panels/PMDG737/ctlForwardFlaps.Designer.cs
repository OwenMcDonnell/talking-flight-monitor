namespace tfm.Settings_panels.PMDG737
{
    partial class ctlForwardFlaps
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
            this.flapsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftFlapsNeedleCheckBox = new System.Windows.Forms.CheckBox();
            this.rightFlapsNeedleCheckBox = new System.Windows.Forms.CheckBox();
            this.flapsInTransitCheckBox = new System.Windows.Forms.CheckBox();
            this.flapsExtendedCheckBox = new System.Windows.Forms.CheckBox();
            this.flapsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flapsFlowLayoutPanel
            // 
            this.flapsFlowLayoutPanel.AutoSize = true;
            this.flapsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flapsFlowLayoutPanel.Controls.Add(this.leftFlapsNeedleCheckBox);
            this.flapsFlowLayoutPanel.Controls.Add(this.rightFlapsNeedleCheckBox);
            this.flapsFlowLayoutPanel.Controls.Add(this.flapsInTransitCheckBox);
            this.flapsFlowLayoutPanel.Controls.Add(this.flapsExtendedCheckBox);
            this.flapsFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flapsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flapsFlowLayoutPanel.Name = "flapsFlowLayoutPanel";
            this.flapsFlowLayoutPanel.Size = new System.Drawing.Size(853, 43);
            this.flapsFlowLayoutPanel.TabIndex = 0;
            // 
            // leftFlapsNeedleCheckBox
            // 
            this.leftFlapsNeedleCheckBox.AccessibleName = "Left flaps needle indicator";
            this.leftFlapsNeedleCheckBox.AutoSize = true;
            this.leftFlapsNeedleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.leftFlapsNeedleCheckBox.Name = "leftFlapsNeedleCheckBox";
            this.leftFlapsNeedleCheckBox.Size = new System.Drawing.Size(204, 37);
            this.leftFlapsNeedleCheckBox.TabIndex = 0;
            this.leftFlapsNeedleCheckBox.Text = "Flaps/L needle";
            this.leftFlapsNeedleCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightFlapsNeedleCheckBox
            // 
            this.rightFlapsNeedleCheckBox.AccessibleName = "Right flaps needle indicator";
            this.rightFlapsNeedleCheckBox.AutoSize = true;
            this.rightFlapsNeedleCheckBox.Location = new System.Drawing.Point(213, 3);
            this.rightFlapsNeedleCheckBox.Name = "rightFlapsNeedleCheckBox";
            this.rightFlapsNeedleCheckBox.Size = new System.Drawing.Size(208, 37);
            this.rightFlapsNeedleCheckBox.TabIndex = 1;
            this.rightFlapsNeedleCheckBox.Text = "Flaps/R needle";
            this.rightFlapsNeedleCheckBox.UseVisualStyleBackColor = true;
            // 
            // flapsInTransitCheckBox
            // 
            this.flapsInTransitCheckBox.AccessibleName = "Flaps in transit indicator";
            this.flapsInTransitCheckBox.AutoSize = true;
            this.flapsInTransitCheckBox.Location = new System.Drawing.Point(427, 3);
            this.flapsInTransitCheckBox.Name = "flapsInTransitCheckBox";
            this.flapsInTransitCheckBox.Size = new System.Drawing.Size(208, 37);
            this.flapsInTransitCheckBox.TabIndex = 2;
            this.flapsInTransitCheckBox.Text = "Flaps in transit";
            this.flapsInTransitCheckBox.UseVisualStyleBackColor = true;
            // 
            // flapsExtendedCheckBox
            // 
            this.flapsExtendedCheckBox.AccessibleName = "Flaps extended indicator";
            this.flapsExtendedCheckBox.AutoSize = true;
            this.flapsExtendedCheckBox.Location = new System.Drawing.Point(641, 3);
            this.flapsExtendedCheckBox.Name = "flapsExtendedCheckBox";
            this.flapsExtendedCheckBox.Size = new System.Drawing.Size(209, 37);
            this.flapsExtendedCheckBox.TabIndex = 3;
            this.flapsExtendedCheckBox.Text = "Flaps extended";
            this.flapsExtendedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlForwardFlaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flapsFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlForwardFlaps";
            this.Size = new System.Drawing.Size(859, 49);
            this.Load += new System.EventHandler(this.ctlForwardFlaps_Load);
            this.flapsFlowLayoutPanel.ResumeLayout(false);
            this.flapsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flapsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox leftFlapsNeedleCheckBox;
        private System.Windows.Forms.CheckBox rightFlapsNeedleCheckBox;
        private System.Windows.Forms.CheckBox flapsInTransitCheckBox;
        private System.Windows.Forms.CheckBox flapsExtendedCheckBox;
    }
}
