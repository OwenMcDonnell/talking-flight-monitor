namespace tfm.Settings_panels.PMDG737
{
    partial class ctlWipers
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
            this.wipersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftWiperCheckBox = new System.Windows.Forms.CheckBox();
            this.rightWiperCheckBox = new System.Windows.Forms.CheckBox();
            this.wipersFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wipersFlowLayoutPanel
            // 
            this.wipersFlowLayoutPanel.AutoSize = true;
            this.wipersFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wipersFlowLayoutPanel.Controls.Add(this.leftWiperCheckBox);
            this.wipersFlowLayoutPanel.Controls.Add(this.rightWiperCheckBox);
            this.wipersFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.wipersFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.wipersFlowLayoutPanel.MaximumSize = new System.Drawing.Size(3200, 1782);
            this.wipersFlowLayoutPanel.Name = "wipersFlowLayoutPanel";
            this.wipersFlowLayoutPanel.Size = new System.Drawing.Size(525, 43);
            this.wipersFlowLayoutPanel.TabIndex = 0;
            // 
            // leftWiperCheckBox
            // 
            this.leftWiperCheckBox.AccessibleName = "Left wiper selector switch";
            this.leftWiperCheckBox.AutoSize = true;
            this.leftWiperCheckBox.Location = new System.Drawing.Point(3, 3);
            this.leftWiperCheckBox.Name = "leftWiperCheckBox";
            this.leftWiperCheckBox.Size = new System.Drawing.Size(248, 37);
            this.leftWiperCheckBox.TabIndex = 0;
            this.leftWiperCheckBox.Text = "&Left wiper selector";
            this.leftWiperCheckBox.UseVisualStyleBackColor = true;
            this.leftWiperCheckBox.CheckedChanged += new System.EventHandler(this.leftWiperCheckBox_CheckedChanged);
            // 
            // rightWiperCheckBox
            // 
            this.rightWiperCheckBox.AccessibleName = "Left wiper selector switch";
            this.rightWiperCheckBox.AutoSize = true;
            this.rightWiperCheckBox.Location = new System.Drawing.Point(257, 3);
            this.rightWiperCheckBox.Name = "rightWiperCheckBox";
            this.rightWiperCheckBox.Size = new System.Drawing.Size(265, 37);
            this.rightWiperCheckBox.TabIndex = 1;
            this.rightWiperCheckBox.Text = "&Right wiper selector";
            this.rightWiperCheckBox.UseVisualStyleBackColor = true;
            this.rightWiperCheckBox.CheckedChanged += new System.EventHandler(this.rightWiperCheckBox_CheckedChanged);
            // 
            // ctlWipers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.wipersFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(3200, 1782);
            this.Name = "ctlWipers";
            this.Size = new System.Drawing.Size(530, 48);
            this.Load += new System.EventHandler(this.ctlWipers_Load);
            this.wipersFlowLayoutPanel.ResumeLayout(false);
            this.wipersFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel wipersFlowLayoutPanel;
        private System.Windows.Forms.CheckBox leftWiperCheckBox;
        private System.Windows.Forms.CheckBox rightWiperCheckBox;
    }
}
