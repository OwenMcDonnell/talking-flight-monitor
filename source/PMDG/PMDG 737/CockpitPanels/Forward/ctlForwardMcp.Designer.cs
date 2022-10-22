namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    partial class ctlForwardMcp
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
            this.mcpFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.throttleGroup = new System.Windows.Forms.GroupBox();
            this.autoThrottleFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftATLabel = new System.Windows.Forms.Label();
            this.leftATTextBox = new System.Windows.Forms.TextBox();
            this.rightATLabel = new System.Windows.Forms.Label();
            this.rightATTextBox = new System.Windows.Forms.TextBox();
            this.leftAmberATLabel = new System.Windows.Forms.Label();
            this.leftAmberATTextBox = new System.Windows.Forms.TextBox();
            this.rightAmberATLabel = new System.Windows.Forms.Label();
            this.rightAmberATTextBox = new System.Windows.Forms.TextBox();
            this.autoPilotGroup = new System.Windows.Forms.GroupBox();
            this.autoPilotFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftAPLabel = new System.Windows.Forms.Label();
            this.leftAPTextBox = new System.Windows.Forms.TextBox();
            this.rightAPLabel = new System.Windows.Forms.Label();
            this.rightAPTextBox = new System.Windows.Forms.TextBox();
            this.leftAmberAPLabel = new System.Windows.Forms.Label();
            this.leftAmberAPTextBox = new System.Windows.Forms.TextBox();
            this.rightAmberAPLabel = new System.Windows.Forms.Label();
            this.rightAmberAPTextBox = new System.Windows.Forms.TextBox();
            this.mcpFlowLayoutPanel.SuspendLayout();
            this.throttleGroup.SuspendLayout();
            this.autoThrottleFlowLayoutPanel.SuspendLayout();
            this.autoPilotGroup.SuspendLayout();
            this.autoPilotFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcpFlowLayoutPanel
            // 
            this.mcpFlowLayoutPanel.AutoSize = true;
            this.mcpFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mcpFlowLayoutPanel.Controls.Add(this.throttleGroup);
            this.mcpFlowLayoutPanel.Controls.Add(this.autoPilotGroup);
            this.mcpFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mcpFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.mcpFlowLayoutPanel.Name = "mcpFlowLayoutPanel";
            this.mcpFlowLayoutPanel.Size = new System.Drawing.Size(430, 181);
            this.mcpFlowLayoutPanel.TabIndex = 0;
            // 
            // throttleGroup
            // 
            this.throttleGroup.AccessibleName = "Auto throttles";
            this.throttleGroup.AutoSize = true;
            this.throttleGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.throttleGroup.Controls.Add(this.autoThrottleFlowLayoutPanel);
            this.throttleGroup.Location = new System.Drawing.Point(3, 3);
            this.throttleGroup.Name = "throttleGroup";
            this.throttleGroup.Size = new System.Drawing.Size(209, 175);
            this.throttleGroup.TabIndex = 0;
            this.throttleGroup.TabStop = false;
            this.throttleGroup.Text = "Auto throttles";
            // 
            // autoThrottleFlowLayoutPanel
            // 
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.leftATLabel);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.leftATTextBox);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.rightATLabel);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.rightATTextBox);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.leftAmberATLabel);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.leftAmberATTextBox);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.rightAmberATLabel);
            this.autoThrottleFlowLayoutPanel.Controls.Add(this.rightAmberATTextBox);
            this.autoThrottleFlowLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.autoThrottleFlowLayoutPanel.Name = "autoThrottleFlowLayoutPanel";
            this.autoThrottleFlowLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.autoThrottleFlowLayoutPanel.TabIndex = 0;
            // 
            // leftATLabel
            // 
            this.leftATLabel.AutoSize = true;
            this.leftATLabel.Location = new System.Drawing.Point(10, 0);
            this.leftATLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.leftATLabel.Name = "leftATLabel";
            this.leftATLabel.Size = new System.Drawing.Size(97, 33);
            this.leftATLabel.TabIndex = 0;
            this.leftATLabel.Text = "&1. AT/L";
            // 
            // leftATTextBox
            // 
            this.leftATTextBox.AccessibleName = "Left auto throttle red disengage";
            this.leftATTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.leftATTextBox.Location = new System.Drawing.Point(113, 3);
            this.leftATTextBox.Name = "leftATTextBox";
            this.leftATTextBox.ReadOnly = true;
            this.leftATTextBox.Size = new System.Drawing.Size(60, 40);
            this.leftATTextBox.TabIndex = 1;
            this.leftATTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightATLabel
            // 
            this.rightATLabel.AutoSize = true;
            this.rightATLabel.Location = new System.Drawing.Point(10, 46);
            this.rightATLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.rightATLabel.Name = "rightATLabel";
            this.rightATLabel.Size = new System.Drawing.Size(100, 33);
            this.rightATLabel.TabIndex = 2;
            this.rightATLabel.Text = "&2. AT/R";
            // 
            // rightATTextBox
            // 
            this.rightATTextBox.AccessibleName = "Right auto throttle red disengage";
            this.rightATTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rightATTextBox.Location = new System.Drawing.Point(116, 49);
            this.rightATTextBox.Name = "rightATTextBox";
            this.rightATTextBox.ReadOnly = true;
            this.rightATTextBox.Size = new System.Drawing.Size(60, 40);
            this.rightATTextBox.TabIndex = 3;
            this.rightATTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leftAmberATLabel
            // 
            this.leftAmberATLabel.AutoSize = true;
            this.leftAmberATLabel.Location = new System.Drawing.Point(10, 92);
            this.leftAmberATLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.leftAmberATLabel.Name = "leftAmberATLabel";
            this.leftAmberATLabel.Size = new System.Drawing.Size(176, 33);
            this.leftAmberATLabel.TabIndex = 4;
            this.leftAmberATLabel.Text = "&3. Amber AT/L";
            // 
            // leftAmberATTextBox
            // 
            this.leftAmberATTextBox.AccessibleName = "Left auto throttle amber disengage";
            this.leftAmberATTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.leftAmberATTextBox.Location = new System.Drawing.Point(3, 128);
            this.leftAmberATTextBox.Name = "leftAmberATTextBox";
            this.leftAmberATTextBox.ReadOnly = true;
            this.leftAmberATTextBox.Size = new System.Drawing.Size(60, 40);
            this.leftAmberATTextBox.TabIndex = 5;
            this.leftAmberATTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightAmberATLabel
            // 
            this.rightAmberATLabel.AutoSize = true;
            this.rightAmberATLabel.Location = new System.Drawing.Point(10, 171);
            this.rightAmberATLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.rightAmberATLabel.Name = "rightAmberATLabel";
            this.rightAmberATLabel.Size = new System.Drawing.Size(179, 33);
            this.rightAmberATLabel.TabIndex = 6;
            this.rightAmberATLabel.Text = "&4. Amber AT/R";
            // 
            // rightAmberATTextBox
            // 
            this.rightAmberATTextBox.AccessibleName = "Right auto throttle amber disengage";
            this.rightAmberATTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rightAmberATTextBox.Location = new System.Drawing.Point(3, 207);
            this.rightAmberATTextBox.Name = "rightAmberATTextBox";
            this.rightAmberATTextBox.ReadOnly = true;
            this.rightAmberATTextBox.Size = new System.Drawing.Size(60, 40);
            this.rightAmberATTextBox.TabIndex = 7;
            this.rightAmberATTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // autoPilotGroup
            // 
            this.autoPilotGroup.AccessibleName = "Auto pilot";
            this.autoPilotGroup.AutoSize = true;
            this.autoPilotGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.autoPilotGroup.Controls.Add(this.autoPilotFlowLayoutPanel);
            this.autoPilotGroup.Location = new System.Drawing.Point(218, 3);
            this.autoPilotGroup.Name = "autoPilotGroup";
            this.autoPilotGroup.Size = new System.Drawing.Size(209, 175);
            this.autoPilotGroup.TabIndex = 1;
            this.autoPilotGroup.TabStop = false;
            this.autoPilotGroup.Text = "Auto pilot";
            // 
            // autoPilotFlowLayoutPanel
            // 
            this.autoPilotFlowLayoutPanel.Controls.Add(this.leftAPLabel);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.leftAPTextBox);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.rightAPLabel);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.rightAPTextBox);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.leftAmberAPLabel);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.leftAmberAPTextBox);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.rightAmberAPLabel);
            this.autoPilotFlowLayoutPanel.Controls.Add(this.rightAmberAPTextBox);
            this.autoPilotFlowLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.autoPilotFlowLayoutPanel.Name = "autoPilotFlowLayoutPanel";
            this.autoPilotFlowLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.autoPilotFlowLayoutPanel.TabIndex = 0;
            // 
            // leftAPLabel
            // 
            this.leftAPLabel.AutoSize = true;
            this.leftAPLabel.Location = new System.Drawing.Point(10, 0);
            this.leftAPLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.leftAPLabel.Name = "leftAPLabel";
            this.leftAPLabel.Size = new System.Drawing.Size(103, 33);
            this.leftAPLabel.TabIndex = 0;
            this.leftAPLabel.Text = "&5. AP/A";
            // 
            // leftAPTextBox
            // 
            this.leftAPTextBox.AccessibleName = "Command A red disengage";
            this.leftAPTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.leftAPTextBox.Location = new System.Drawing.Point(119, 3);
            this.leftAPTextBox.Name = "leftAPTextBox";
            this.leftAPTextBox.ReadOnly = true;
            this.leftAPTextBox.Size = new System.Drawing.Size(60, 40);
            this.leftAPTextBox.TabIndex = 1;
            this.leftAPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightAPLabel
            // 
            this.rightAPLabel.AutoSize = true;
            this.rightAPLabel.Location = new System.Drawing.Point(10, 46);
            this.rightAPLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.rightAPLabel.Name = "rightAPLabel";
            this.rightAPLabel.Size = new System.Drawing.Size(103, 33);
            this.rightAPLabel.TabIndex = 2;
            this.rightAPLabel.Text = "&6. AP/B";
            // 
            // rightAPTextBox
            // 
            this.rightAPTextBox.AccessibleName = "Command B red disengage";
            this.rightAPTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rightAPTextBox.Location = new System.Drawing.Point(119, 49);
            this.rightAPTextBox.Name = "rightAPTextBox";
            this.rightAPTextBox.ReadOnly = true;
            this.rightAPTextBox.Size = new System.Drawing.Size(60, 40);
            this.rightAPTextBox.TabIndex = 3;
            this.rightAPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leftAmberAPLabel
            // 
            this.leftAmberAPLabel.AutoSize = true;
            this.leftAmberAPLabel.Location = new System.Drawing.Point(10, 92);
            this.leftAmberAPLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.leftAmberAPLabel.Name = "leftAmberAPLabel";
            this.leftAmberAPLabel.Size = new System.Drawing.Size(182, 33);
            this.leftAmberAPLabel.TabIndex = 4;
            this.leftAmberAPLabel.Text = "&7. Amber AP/A";
            // 
            // leftAmberAPTextBox
            // 
            this.leftAmberAPTextBox.AccessibleName = "Command A amber disengage";
            this.leftAmberAPTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.leftAmberAPTextBox.Location = new System.Drawing.Point(3, 128);
            this.leftAmberAPTextBox.Name = "leftAmberAPTextBox";
            this.leftAmberAPTextBox.ReadOnly = true;
            this.leftAmberAPTextBox.Size = new System.Drawing.Size(60, 40);
            this.leftAmberAPTextBox.TabIndex = 5;
            this.leftAmberAPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightAmberAPLabel
            // 
            this.rightAmberAPLabel.AutoSize = true;
            this.rightAmberAPLabel.Location = new System.Drawing.Point(10, 171);
            this.rightAmberAPLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.rightAmberAPLabel.Name = "rightAmberAPLabel";
            this.rightAmberAPLabel.Size = new System.Drawing.Size(182, 33);
            this.rightAmberAPLabel.TabIndex = 6;
            this.rightAmberAPLabel.Text = "&8. Amber AP/B";
            // 
            // rightAmberAPTextBox
            // 
            this.rightAmberAPTextBox.AccessibleName = "Command B amber disengage";
            this.rightAmberAPTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rightAmberAPTextBox.Location = new System.Drawing.Point(3, 207);
            this.rightAmberAPTextBox.Name = "rightAmberAPTextBox";
            this.rightAmberAPTextBox.ReadOnly = true;
            this.rightAmberAPTextBox.Size = new System.Drawing.Size(60, 40);
            this.rightAmberAPTextBox.TabIndex = 7;
            this.rightAmberAPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlForwardMcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.mcpFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlForwardMcp";
            this.Size = new System.Drawing.Size(433, 184);
            this.Load += new System.EventHandler(this.ctlForwardMcp_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlForwardMcp_VisibleChanged);
            this.mcpFlowLayoutPanel.ResumeLayout(false);
            this.mcpFlowLayoutPanel.PerformLayout();
            this.throttleGroup.ResumeLayout(false);
            this.autoThrottleFlowLayoutPanel.ResumeLayout(false);
            this.autoThrottleFlowLayoutPanel.PerformLayout();
            this.autoPilotGroup.ResumeLayout(false);
            this.autoPilotFlowLayoutPanel.ResumeLayout(false);
            this.autoPilotFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mcpFlowLayoutPanel;
        private System.Windows.Forms.GroupBox throttleGroup;
        private System.Windows.Forms.FlowLayoutPanel autoThrottleFlowLayoutPanel;
        private System.Windows.Forms.Label leftATLabel;
        private System.Windows.Forms.TextBox leftATTextBox;
        private System.Windows.Forms.Label rightATLabel;
        private System.Windows.Forms.TextBox rightATTextBox;
        private System.Windows.Forms.Label leftAmberATLabel;
        private System.Windows.Forms.TextBox leftAmberATTextBox;
        private System.Windows.Forms.Label rightAmberATLabel;
        private System.Windows.Forms.TextBox rightAmberATTextBox;
        private System.Windows.Forms.GroupBox autoPilotGroup;
        private System.Windows.Forms.FlowLayoutPanel autoPilotFlowLayoutPanel;
        private System.Windows.Forms.Label leftAPLabel;
        private System.Windows.Forms.TextBox leftAPTextBox;
        private System.Windows.Forms.Label rightAPLabel;
        private System.Windows.Forms.TextBox rightAPTextBox;
        private System.Windows.Forms.Label leftAmberAPLabel;
        private System.Windows.Forms.TextBox leftAmberAPTextBox;
        private System.Windows.Forms.Label rightAmberAPLabel;
        private System.Windows.Forms.TextBox rightAmberAPTextBox;
    }
}
