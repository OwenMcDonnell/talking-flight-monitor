namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    partial class ctlForwardGear
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
            this.gearFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gearLeverButton = new System.Windows.Forms.Button();
            this.gearTransitGroupBox = new System.Windows.Forms.GroupBox();
            this.transitFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.noseTransitLabel = new System.Windows.Forms.Label();
            this.noseTransitTextBox = new System.Windows.Forms.TextBox();
            this.leftTransitLabel = new System.Windows.Forms.Label();
            this.leftTransitTextBox = new System.Windows.Forms.TextBox();
            this.rightTransitLabel = new System.Windows.Forms.Label();
            this.rightTransitTextBox = new System.Windows.Forms.TextBox();
            this.lockedGroupBox = new System.Windows.Forms.GroupBox();
            this.lockedFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.noseLockedLabel = new System.Windows.Forms.Label();
            this.noseLockedTextBox = new System.Windows.Forms.TextBox();
            this.leftLockedLabel = new System.Windows.Forms.Label();
            this.leftLockedTextBox = new System.Windows.Forms.TextBox();
            this.rightLockedLabel = new System.Windows.Forms.Label();
            this.rightLockedTextBox = new System.Windows.Forms.TextBox();
            this.gearFlowLayoutPanel.SuspendLayout();
            this.gearTransitGroupBox.SuspendLayout();
            this.transitFlowLayoutPanel.SuspendLayout();
            this.lockedGroupBox.SuspendLayout();
            this.lockedFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gearFlowLayoutPanel
            // 
            this.gearFlowLayoutPanel.AutoSize = true;
            this.gearFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gearFlowLayoutPanel.Controls.Add(this.gearLeverButton);
            this.gearFlowLayoutPanel.Controls.Add(this.gearTransitGroupBox);
            this.gearFlowLayoutPanel.Controls.Add(this.lockedGroupBox);
            this.gearFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.gearFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.gearFlowLayoutPanel.Name = "gearFlowLayoutPanel";
            this.gearFlowLayoutPanel.Size = new System.Drawing.Size(1207, 127);
            this.gearFlowLayoutPanel.TabIndex = 0;
            // 
            // gearLeverButton
            // 
            this.gearLeverButton.AutoSize = true;
            this.gearLeverButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gearLeverButton.Location = new System.Drawing.Point(3, 3);
            this.gearLeverButton.Name = "gearLeverButton";
            this.gearLeverButton.Size = new System.Drawing.Size(111, 43);
            this.gearLeverButton.TabIndex = 0;
            this.gearLeverButton.Text = "button1";
            this.gearLeverButton.UseVisualStyleBackColor = true;
            this.gearLeverButton.Click += new System.EventHandler(this.gearLeverButton_Click);
            // 
            // gearTransitGroupBox
            // 
            this.gearTransitGroupBox.AccessibleName = "In transit indicators";
            this.gearTransitGroupBox.AutoSize = true;
            this.gearTransitGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gearTransitGroupBox.Controls.Add(this.transitFlowLayoutPanel);
            this.gearTransitGroupBox.Location = new System.Drawing.Point(120, 3);
            this.gearTransitGroupBox.Name = "gearTransitGroupBox";
            this.gearTransitGroupBox.Size = new System.Drawing.Size(539, 121);
            this.gearTransitGroupBox.TabIndex = 1;
            this.gearTransitGroupBox.TabStop = false;
            this.gearTransitGroupBox.Text = "In transit";
            // 
            // transitFlowLayoutPanel
            // 
            this.transitFlowLayoutPanel.AutoSize = true;
            this.transitFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transitFlowLayoutPanel.Controls.Add(this.noseTransitLabel);
            this.transitFlowLayoutPanel.Controls.Add(this.noseTransitTextBox);
            this.transitFlowLayoutPanel.Controls.Add(this.leftTransitLabel);
            this.transitFlowLayoutPanel.Controls.Add(this.leftTransitTextBox);
            this.transitFlowLayoutPanel.Controls.Add(this.rightTransitLabel);
            this.transitFlowLayoutPanel.Controls.Add(this.rightTransitTextBox);
            this.transitFlowLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.transitFlowLayoutPanel.Name = "transitFlowLayoutPanel";
            this.transitFlowLayoutPanel.Size = new System.Drawing.Size(530, 46);
            this.transitFlowLayoutPanel.TabIndex = 0;
            // 
            // noseTransitLabel
            // 
            this.noseTransitLabel.AutoSize = true;
            this.noseTransitLabel.Location = new System.Drawing.Point(10, 0);
            this.noseTransitLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.noseTransitLabel.Name = "noseTransitLabel";
            this.noseTransitLabel.Size = new System.Drawing.Size(100, 33);
            this.noseTransitLabel.TabIndex = 0;
            this.noseTransitLabel.Text = "&1. Nose";
            // 
            // noseTransitTextBox
            // 
            this.noseTransitTextBox.AccessibleName = "Nose gear in transit";
            this.noseTransitTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.noseTransitTextBox.Location = new System.Drawing.Point(116, 3);
            this.noseTransitTextBox.Name = "noseTransitTextBox";
            this.noseTransitTextBox.ReadOnly = true;
            this.noseTransitTextBox.Size = new System.Drawing.Size(60, 40);
            this.noseTransitTextBox.TabIndex = 1;
            // 
            // leftTransitLabel
            // 
            this.leftTransitLabel.AutoSize = true;
            this.leftTransitLabel.Location = new System.Drawing.Point(189, 0);
            this.leftTransitLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.leftTransitLabel.Name = "leftTransitLabel";
            this.leftTransitLabel.Size = new System.Drawing.Size(88, 33);
            this.leftTransitLabel.TabIndex = 2;
            this.leftTransitLabel.Text = "&2. Left";
            // 
            // leftTransitTextBox
            // 
            this.leftTransitTextBox.AccessibleName = "Left gear in transit";
            this.leftTransitTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.leftTransitTextBox.Location = new System.Drawing.Point(283, 3);
            this.leftTransitTextBox.Name = "leftTransitTextBox";
            this.leftTransitTextBox.ReadOnly = true;
            this.leftTransitTextBox.Size = new System.Drawing.Size(60, 40);
            this.leftTransitTextBox.TabIndex = 3;
            // 
            // rightTransitLabel
            // 
            this.rightTransitLabel.AutoSize = true;
            this.rightTransitLabel.Location = new System.Drawing.Point(356, 0);
            this.rightTransitLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.rightTransitLabel.Name = "rightTransitLabel";
            this.rightTransitLabel.Size = new System.Drawing.Size(105, 33);
            this.rightTransitLabel.TabIndex = 4;
            this.rightTransitLabel.Text = "&3. Right";
            // 
            // rightTransitTextBox
            // 
            this.rightTransitTextBox.AccessibleName = "Right gear in transit";
            this.rightTransitTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rightTransitTextBox.Location = new System.Drawing.Point(467, 3);
            this.rightTransitTextBox.Name = "rightTransitTextBox";
            this.rightTransitTextBox.ReadOnly = true;
            this.rightTransitTextBox.Size = new System.Drawing.Size(60, 40);
            this.rightTransitTextBox.TabIndex = 5;
            // 
            // lockedGroupBox
            // 
            this.lockedGroupBox.AccessibleName = "Gear locked indicators";
            this.lockedGroupBox.AutoSize = true;
            this.lockedGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lockedGroupBox.Controls.Add(this.lockedFlowLayoutPanel);
            this.lockedGroupBox.Location = new System.Drawing.Point(665, 3);
            this.lockedGroupBox.Name = "lockedGroupBox";
            this.lockedGroupBox.Size = new System.Drawing.Size(539, 121);
            this.lockedGroupBox.TabIndex = 2;
            this.lockedGroupBox.TabStop = false;
            this.lockedGroupBox.Text = "Locked";
            // 
            // lockedFlowLayoutPanel
            // 
            this.lockedFlowLayoutPanel.AutoSize = true;
            this.lockedFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lockedFlowLayoutPanel.Controls.Add(this.noseLockedLabel);
            this.lockedFlowLayoutPanel.Controls.Add(this.noseLockedTextBox);
            this.lockedFlowLayoutPanel.Controls.Add(this.leftLockedLabel);
            this.lockedFlowLayoutPanel.Controls.Add(this.leftLockedTextBox);
            this.lockedFlowLayoutPanel.Controls.Add(this.rightLockedLabel);
            this.lockedFlowLayoutPanel.Controls.Add(this.rightLockedTextBox);
            this.lockedFlowLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.lockedFlowLayoutPanel.Name = "lockedFlowLayoutPanel";
            this.lockedFlowLayoutPanel.Size = new System.Drawing.Size(530, 46);
            this.lockedFlowLayoutPanel.TabIndex = 0;
            // 
            // noseLockedLabel
            // 
            this.noseLockedLabel.AutoSize = true;
            this.noseLockedLabel.Location = new System.Drawing.Point(10, 0);
            this.noseLockedLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.noseLockedLabel.Name = "noseLockedLabel";
            this.noseLockedLabel.Size = new System.Drawing.Size(100, 33);
            this.noseLockedLabel.TabIndex = 0;
            this.noseLockedLabel.Text = "&4. Nose";
            // 
            // noseLockedTextBox
            // 
            this.noseLockedTextBox.AccessibleName = "Nose gear locked";
            this.noseLockedTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.noseLockedTextBox.Location = new System.Drawing.Point(116, 3);
            this.noseLockedTextBox.Name = "noseLockedTextBox";
            this.noseLockedTextBox.ReadOnly = true;
            this.noseLockedTextBox.Size = new System.Drawing.Size(60, 40);
            this.noseLockedTextBox.TabIndex = 1;
            // 
            // leftLockedLabel
            // 
            this.leftLockedLabel.AutoSize = true;
            this.leftLockedLabel.Location = new System.Drawing.Point(189, 0);
            this.leftLockedLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.leftLockedLabel.Name = "leftLockedLabel";
            this.leftLockedLabel.Size = new System.Drawing.Size(88, 33);
            this.leftLockedLabel.TabIndex = 2;
            this.leftLockedLabel.Text = "&5. Left";
            // 
            // leftLockedTextBox
            // 
            this.leftLockedTextBox.AccessibleName = "Left gear locked";
            this.leftLockedTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.leftLockedTextBox.Location = new System.Drawing.Point(283, 3);
            this.leftLockedTextBox.Name = "leftLockedTextBox";
            this.leftLockedTextBox.ReadOnly = true;
            this.leftLockedTextBox.Size = new System.Drawing.Size(60, 40);
            this.leftLockedTextBox.TabIndex = 3;
            // 
            // rightLockedLabel
            // 
            this.rightLockedLabel.AutoSize = true;
            this.rightLockedLabel.Location = new System.Drawing.Point(356, 0);
            this.rightLockedLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.rightLockedLabel.Name = "rightLockedLabel";
            this.rightLockedLabel.Size = new System.Drawing.Size(105, 33);
            this.rightLockedLabel.TabIndex = 4;
            this.rightLockedLabel.Text = "&6. Right";
            // 
            // rightLockedTextBox
            // 
            this.rightLockedTextBox.AccessibleName = "Right gear locked";
            this.rightLockedTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rightLockedTextBox.Location = new System.Drawing.Point(467, 3);
            this.rightLockedTextBox.Name = "rightLockedTextBox";
            this.rightLockedTextBox.ReadOnly = true;
            this.rightLockedTextBox.Size = new System.Drawing.Size(60, 40);
            this.rightLockedTextBox.TabIndex = 5;
            // 
            // ctlForwardGear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.gearFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlForwardGear";
            this.Size = new System.Drawing.Size(1210, 130);
            this.Load += new System.EventHandler(this.ctlForwardGear_Load);
            this.gearFlowLayoutPanel.ResumeLayout(false);
            this.gearFlowLayoutPanel.PerformLayout();
            this.gearTransitGroupBox.ResumeLayout(false);
            this.gearTransitGroupBox.PerformLayout();
            this.transitFlowLayoutPanel.ResumeLayout(false);
            this.transitFlowLayoutPanel.PerformLayout();
            this.lockedGroupBox.ResumeLayout(false);
            this.lockedGroupBox.PerformLayout();
            this.lockedFlowLayoutPanel.ResumeLayout(false);
            this.lockedFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel gearFlowLayoutPanel;
        private System.Windows.Forms.Button gearLeverButton;
        private System.Windows.Forms.GroupBox gearTransitGroupBox;
        private System.Windows.Forms.FlowLayoutPanel transitFlowLayoutPanel;
        private System.Windows.Forms.Label noseTransitLabel;
        private System.Windows.Forms.TextBox noseTransitTextBox;
        private System.Windows.Forms.Label leftTransitLabel;
        private System.Windows.Forms.TextBox leftTransitTextBox;
        private System.Windows.Forms.Label rightTransitLabel;
        private System.Windows.Forms.TextBox rightTransitTextBox;
        private System.Windows.Forms.GroupBox lockedGroupBox;
        private System.Windows.Forms.FlowLayoutPanel lockedFlowLayoutPanel;
        private System.Windows.Forms.Label noseLockedLabel;
        private System.Windows.Forms.TextBox noseLockedTextBox;
        private System.Windows.Forms.Label leftLockedLabel;
        private System.Windows.Forms.TextBox leftLockedTextBox;
        private System.Windows.Forms.Label rightLockedLabel;
        private System.Windows.Forms.TextBox rightLockedTextBox;
    }
}
