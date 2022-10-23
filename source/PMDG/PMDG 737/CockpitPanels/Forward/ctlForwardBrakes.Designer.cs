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
            this.brakesFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // brakesFlowLayoutPanel
            // 
            this.brakesFlowLayoutPanel.AutoSize = true;
            this.brakesFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.brakesFlowLayoutPanel.Controls.Add(this.autoBrakeLabel);
            this.brakesFlowLayoutPanel.Controls.Add(this.autoBrakeTextBox);
            this.brakesFlowLayoutPanel.Location = new System.Drawing.Point(0, -123);
            this.brakesFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.brakesFlowLayoutPanel.Name = "brakesFlowLayoutPanel";
            this.brakesFlowLayoutPanel.Size = new System.Drawing.Size(0, 0);
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
            this.autoBrakeTextBox.Location = new System.Drawing.Point(10, 36);
            this.autoBrakeTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.autoBrakeTextBox.Name = "autoBrakeTextBox";
            this.autoBrakeTextBox.ReadOnly = true;
            this.autoBrakeTextBox.Size = new System.Drawing.Size(60, 40);
            this.autoBrakeTextBox.TabIndex = 14;
            this.autoBrakeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoBrakeTextBox.Enter += new System.EventHandler(this.autoBrakeTextBox_Enter);
            this.autoBrakeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.autoBrakeTextBox_KeyDown);
            // 
            // ctlForwardBrakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.brakesFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlForwardBrakes";
            this.Size = new System.Drawing.Size(227, 0);
            this.brakesFlowLayoutPanel.ResumeLayout(false);
            this.brakesFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel brakesFlowLayoutPanel;
        private System.Windows.Forms.Label autoBrakeLabel;
        private System.Windows.Forms.TextBox autoBrakeTextBox;
    }
}
