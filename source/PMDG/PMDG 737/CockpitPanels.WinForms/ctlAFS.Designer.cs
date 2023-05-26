namespace tfm.PMDG.PMDG_737.CockpitPanels
{
    partial class ctlAFS
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
            this.afsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.afsServosLabel = new System.Windows.Forms.Label();
            this.servosTextBox = new System.Windows.Forms.TextBox();
            this.afsPitchLabel = new System.Windows.Forms.Label();
            this.pitchTextBox = new System.Windows.Forms.TextBox();
            this.afsRollLabel = new System.Windows.Forms.Label();
            this.rollTextBox = new System.Windows.Forms.TextBox();
            this.afsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // afsFlowLayoutPanel
            // 
            this.afsFlowLayoutPanel.AutoSize = true;
            this.afsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.afsFlowLayoutPanel.Controls.Add(this.afsServosLabel);
            this.afsFlowLayoutPanel.Controls.Add(this.servosTextBox);
            this.afsFlowLayoutPanel.Controls.Add(this.afsPitchLabel);
            this.afsFlowLayoutPanel.Controls.Add(this.pitchTextBox);
            this.afsFlowLayoutPanel.Controls.Add(this.afsRollLabel);
            this.afsFlowLayoutPanel.Controls.Add(this.rollTextBox);
            this.afsFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.afsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.afsFlowLayoutPanel.Name = "afsFlowLayoutPanel";
            this.afsFlowLayoutPanel.Size = new System.Drawing.Size(690, 46);
            this.afsFlowLayoutPanel.TabIndex = 0;
            // 
            // afsServosLabel
            // 
            this.afsServosLabel.AutoSize = true;
            this.afsServosLabel.Location = new System.Drawing.Point(10, 0);
            this.afsServosLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.afsServosLabel.Name = "afsServosLabel";
            this.afsServosLabel.Size = new System.Drawing.Size(122, 33);
            this.afsServosLabel.TabIndex = 0;
            this.afsServosLabel.Text = "&AT servos";
            // 
            // servosTextBox
            // 
            this.servosTextBox.AccessibleName = "Auto throttle servos";
            this.servosTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.servosTextBox.Location = new System.Drawing.Point(138, 3);
            this.servosTextBox.Name = "servosTextBox";
            this.servosTextBox.ReadOnly = true;
            this.servosTextBox.Size = new System.Drawing.Size(90, 40);
            this.servosTextBox.TabIndex = 1;
            this.servosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // afsPitchLabel
            // 
            this.afsPitchLabel.AutoSize = true;
            this.afsPitchLabel.Location = new System.Drawing.Point(241, 0);
            this.afsPitchLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.afsPitchLabel.Name = "afsPitchLabel";
            this.afsPitchLabel.Size = new System.Drawing.Size(129, 33);
            this.afsPitchLabel.TabIndex = 2;
            this.afsPitchLabel.Text = "AFS &pitch";
            // 
            // pitchTextBox
            // 
            this.pitchTextBox.AccessibleName = "auto pitch";
            this.pitchTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.pitchTextBox.Location = new System.Drawing.Point(376, 3);
            this.pitchTextBox.Name = "pitchTextBox";
            this.pitchTextBox.ReadOnly = true;
            this.pitchTextBox.Size = new System.Drawing.Size(90, 40);
            this.pitchTextBox.TabIndex = 3;
            this.pitchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // afsRollLabel
            // 
            this.afsRollLabel.AutoSize = true;
            this.afsRollLabel.Location = new System.Drawing.Point(479, 0);
            this.afsRollLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.afsRollLabel.Name = "afsRollLabel";
            this.afsRollLabel.Size = new System.Drawing.Size(112, 33);
            this.afsRollLabel.TabIndex = 4;
            this.afsRollLabel.Text = "AFS &roll";
            // 
            // rollTextBox
            // 
            this.rollTextBox.AccessibleName = "auto roll";
            this.rollTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.rollTextBox.Location = new System.Drawing.Point(597, 3);
            this.rollTextBox.Name = "rollTextBox";
            this.rollTextBox.ReadOnly = true;
            this.rollTextBox.Size = new System.Drawing.Size(90, 40);
            this.rollTextBox.TabIndex = 5;
            this.rollTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlAFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.afsFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlAFS";
            this.Size = new System.Drawing.Size(696, 52);
            this.Load += new System.EventHandler(this.ctlAFS_Load);
            this.afsFlowLayoutPanel.ResumeLayout(false);
            this.afsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel afsFlowLayoutPanel;
        private System.Windows.Forms.Label afsServosLabel;
        private System.Windows.Forms.TextBox servosTextBox;
        private System.Windows.Forms.Label afsPitchLabel;
        private System.Windows.Forms.TextBox pitchTextBox;
        private System.Windows.Forms.Label afsRollLabel;
        private System.Windows.Forms.TextBox rollTextBox;
    }
}
