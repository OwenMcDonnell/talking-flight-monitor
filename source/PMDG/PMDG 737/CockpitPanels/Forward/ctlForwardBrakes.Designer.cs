namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    partial class ctlForwardBrakes
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
            this.brakesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.autoBrakeLabel = new System.Windows.Forms.Label();
            this.autoBrakeTextBox = new System.Windows.Forms.TextBox();
            this.brakeNeedleLabel = new System.Windows.Forms.Label();
            this.brakeNeedleTextBox = new System.Windows.Forms.TextBox();
            this.indicatorsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.speedBrakeArmedLabel = new System.Windows.Forms.Label();
            this.speedBrakeArmedTextBox = new System.Windows.Forms.TextBox();
            this.speedBrakeDoNotArmLabel = new System.Windows.Forms.Label();
            this.speedBrakeDoNotArmTextBox = new System.Windows.Forms.TextBox();
            this.speedBrakeExtendedLabel = new System.Windows.Forms.Label();
            this.speedBrakeExtendedTextBox = new System.Windows.Forms.TextBox();
            this.autoBrakeDisarmLabel = new System.Windows.Forms.Label();
            this.autoBrakeDisarmTextBox = new System.Windows.Forms.TextBox();
            this.brakesFlowLayoutPanel.SuspendLayout();
            this.indicatorsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // brakesFlowLayoutPanel
            // 
            this.brakesFlowLayoutPanel.AutoSize = true;
            this.brakesFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.brakesFlowLayoutPanel.Controls.Add(this.autoBrakeLabel);
            this.brakesFlowLayoutPanel.Controls.Add(this.autoBrakeTextBox);
            this.brakesFlowLayoutPanel.Controls.Add(this.brakeNeedleLabel);
            this.brakesFlowLayoutPanel.Controls.Add(this.brakeNeedleTextBox);
            this.brakesFlowLayoutPanel.Location = new System.Drawing.Point(404, 10);
            this.brakesFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.brakesFlowLayoutPanel.Name = "brakesFlowLayoutPanel";
            this.brakesFlowLayoutPanel.Size = new System.Drawing.Size(455, 46);
            this.brakesFlowLayoutPanel.TabIndex = 0;
            // 
            // autoBrakeLabel
            // 
            this.autoBrakeLabel.AutoSize = true;
            this.autoBrakeLabel.Location = new System.Drawing.Point(10, 0);
            this.autoBrakeLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.autoBrakeLabel.Name = "autoBrakeLabel";
            this.autoBrakeLabel.Size = new System.Drawing.Size(138, 33);
            this.autoBrakeLabel.TabIndex = 13;
            this.autoBrakeLabel.Text = "Au&to brake";
            // 
            // autoBrakeTextBox
            // 
            this.autoBrakeTextBox.AccessibleName = "Auto brake";
            this.autoBrakeTextBox.Location = new System.Drawing.Point(161, 3);
            this.autoBrakeTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.autoBrakeTextBox.Name = "autoBrakeTextBox";
            this.autoBrakeTextBox.ReadOnly = true;
            this.autoBrakeTextBox.Size = new System.Drawing.Size(60, 40);
            this.autoBrakeTextBox.TabIndex = 14;
            this.autoBrakeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoBrakeTextBox.Enter += new System.EventHandler(this.autoBrakeTextBox_Enter);
            this.autoBrakeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.autoBrakeTextBox_KeyDown);
            // 
            // brakeNeedleLabel
            // 
            this.brakeNeedleLabel.AutoSize = true;
            this.brakeNeedleLabel.Location = new System.Drawing.Point(234, 0);
            this.brakeNeedleLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.brakeNeedleLabel.Name = "brakeNeedleLabel";
            this.brakeNeedleLabel.Size = new System.Drawing.Size(152, 33);
            this.brakeNeedleLabel.TabIndex = 15;
            this.brakeNeedleLabel.Text = "&Brake press.";
            // 
            // brakeNeedleTextBox
            // 
            this.brakeNeedleTextBox.AccessibleName = "Brake pressure";
            this.brakeNeedleTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.brakeNeedleTextBox.Location = new System.Drawing.Point(392, 3);
            this.brakeNeedleTextBox.Name = "brakeNeedleTextBox";
            this.brakeNeedleTextBox.ReadOnly = true;
            this.brakeNeedleTextBox.Size = new System.Drawing.Size(60, 40);
            this.brakeNeedleTextBox.TabIndex = 16;
            // 
            // indicatorsFlowLayoutPanel
            // 
            this.indicatorsFlowLayoutPanel.AutoSize = true;
            this.indicatorsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.indicatorsFlowLayoutPanel.Controls.Add(this.speedBrakeArmedLabel);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.speedBrakeArmedTextBox);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.speedBrakeDoNotArmLabel);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.speedBrakeDoNotArmTextBox);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.speedBrakeExtendedLabel);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.speedBrakeExtendedTextBox);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.autoBrakeDisarmLabel);
            this.indicatorsFlowLayoutPanel.Controls.Add(this.autoBrakeDisarmTextBox);
            this.indicatorsFlowLayoutPanel.Location = new System.Drawing.Point(3, 62);
            this.indicatorsFlowLayoutPanel.Name = "indicatorsFlowLayoutPanel";
            this.indicatorsFlowLayoutPanel.Size = new System.Drawing.Size(1257, 46);
            this.indicatorsFlowLayoutPanel.TabIndex = 1;
            // 
            // speedBrakeArmedLabel
            // 
            this.speedBrakeArmedLabel.AutoSize = true;
            this.speedBrakeArmedLabel.Location = new System.Drawing.Point(10, 0);
            this.speedBrakeArmedLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.speedBrakeArmedLabel.Name = "speedBrakeArmedLabel";
            this.speedBrakeArmedLabel.Size = new System.Drawing.Size(213, 33);
            this.speedBrakeArmedLabel.TabIndex = 0;
            this.speedBrakeArmedLabel.Text = "&1. SPD brk armed";
            // 
            // speedBrakeArmedTextBox
            // 
            this.speedBrakeArmedTextBox.AccessibleName = "Speed brake armed";
            this.speedBrakeArmedTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.speedBrakeArmedTextBox.Location = new System.Drawing.Point(229, 3);
            this.speedBrakeArmedTextBox.Name = "speedBrakeArmedTextBox";
            this.speedBrakeArmedTextBox.ReadOnly = true;
            this.speedBrakeArmedTextBox.Size = new System.Drawing.Size(60, 40);
            this.speedBrakeArmedTextBox.TabIndex = 1;
            // 
            // speedBrakeDoNotArmLabel
            // 
            this.speedBrakeDoNotArmLabel.AutoSize = true;
            this.speedBrakeDoNotArmLabel.Location = new System.Drawing.Point(302, 0);
            this.speedBrakeDoNotArmLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.speedBrakeDoNotArmLabel.Name = "speedBrakeDoNotArmLabel";
            this.speedBrakeDoNotArmLabel.Size = new System.Drawing.Size(242, 33);
            this.speedBrakeDoNotArmLabel.TabIndex = 2;
            this.speedBrakeDoNotArmLabel.Text = "&2. SPD brk D/N arm";
            // 
            // speedBrakeDoNotArmTextBox
            // 
            this.speedBrakeDoNotArmTextBox.AccessibleName = "Speed brake do not arm";
            this.speedBrakeDoNotArmTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.speedBrakeDoNotArmTextBox.Location = new System.Drawing.Point(550, 3);
            this.speedBrakeDoNotArmTextBox.Name = "speedBrakeDoNotArmTextBox";
            this.speedBrakeDoNotArmTextBox.ReadOnly = true;
            this.speedBrakeDoNotArmTextBox.Size = new System.Drawing.Size(60, 40);
            this.speedBrakeDoNotArmTextBox.TabIndex = 3;
            // 
            // speedBrakeExtendedLabel
            // 
            this.speedBrakeExtendedLabel.AutoSize = true;
            this.speedBrakeExtendedLabel.Location = new System.Drawing.Point(623, 0);
            this.speedBrakeExtendedLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.speedBrakeExtendedLabel.Name = "speedBrakeExtendedLabel";
            this.speedBrakeExtendedLabel.Size = new System.Drawing.Size(212, 33);
            this.speedBrakeExtendedLabel.TabIndex = 4;
            this.speedBrakeExtendedLabel.Text = "&3. SPD BRK Ext.";
            // 
            // speedBrakeExtendedTextBox
            // 
            this.speedBrakeExtendedTextBox.AccessibleName = "Speed brake extended";
            this.speedBrakeExtendedTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.speedBrakeExtendedTextBox.Location = new System.Drawing.Point(841, 3);
            this.speedBrakeExtendedTextBox.Name = "speedBrakeExtendedTextBox";
            this.speedBrakeExtendedTextBox.ReadOnly = true;
            this.speedBrakeExtendedTextBox.Size = new System.Drawing.Size(60, 40);
            this.speedBrakeExtendedTextBox.TabIndex = 5;
            // 
            // autoBrakeDisarmLabel
            // 
            this.autoBrakeDisarmLabel.AutoSize = true;
            this.autoBrakeDisarmLabel.Location = new System.Drawing.Point(914, 0);
            this.autoBrakeDisarmLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.autoBrakeDisarmLabel.Name = "autoBrakeDisarmLabel";
            this.autoBrakeDisarmLabel.Size = new System.Drawing.Size(274, 33);
            this.autoBrakeDisarmLabel.TabIndex = 6;
            this.autoBrakeDisarmLabel.Text = "&4. Auto BRK DISARM";
            // 
            // autoBrakeDisarmTextBox
            // 
            this.autoBrakeDisarmTextBox.AccessibleName = "Auto brake disarm";
            this.autoBrakeDisarmTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.autoBrakeDisarmTextBox.Location = new System.Drawing.Point(1194, 3);
            this.autoBrakeDisarmTextBox.Name = "autoBrakeDisarmTextBox";
            this.autoBrakeDisarmTextBox.ReadOnly = true;
            this.autoBrakeDisarmTextBox.Size = new System.Drawing.Size(60, 40);
            this.autoBrakeDisarmTextBox.TabIndex = 7;
            // 
            // ctlForwardBrakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.indicatorsFlowLayoutPanel);
            this.Controls.Add(this.brakesFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlForwardBrakes";
            this.Size = new System.Drawing.Size(1263, 111);
            this.Load += new System.EventHandler(this.ctlForwardBrakes_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlForwardBrakes_VisibleChanged);
            this.brakesFlowLayoutPanel.ResumeLayout(false);
            this.brakesFlowLayoutPanel.PerformLayout();
            this.indicatorsFlowLayoutPanel.ResumeLayout(false);
            this.indicatorsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel brakesFlowLayoutPanel;
        private System.Windows.Forms.Label autoBrakeLabel;
        private System.Windows.Forms.TextBox autoBrakeTextBox;
        private System.Windows.Forms.Label brakeNeedleLabel;
        private System.Windows.Forms.TextBox brakeNeedleTextBox;
        private System.Windows.Forms.FlowLayoutPanel indicatorsFlowLayoutPanel;
        private System.Windows.Forms.Label speedBrakeArmedLabel;
        private System.Windows.Forms.TextBox speedBrakeArmedTextBox;
        private System.Windows.Forms.Label speedBrakeDoNotArmLabel;
        private System.Windows.Forms.TextBox speedBrakeDoNotArmTextBox;
        private System.Windows.Forms.Label speedBrakeExtendedLabel;
        private System.Windows.Forms.TextBox speedBrakeExtendedTextBox;
        private System.Windows.Forms.Label autoBrakeDisarmLabel;
        private System.Windows.Forms.TextBox autoBrakeDisarmTextBox;
    }
}
