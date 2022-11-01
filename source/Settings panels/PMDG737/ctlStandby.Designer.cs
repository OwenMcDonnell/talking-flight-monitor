namespace tfm.Settings_panels.PMDG737
{
    partial class ctlStandby
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
            this.standbyFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rmi1CheckBox = new System.Windows.Forms.CheckBox();
            this.rmi2CheckBox = new System.Windows.Forms.CheckBox();
            this.standbyFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // standbyFlowLayoutPanel
            // 
            this.standbyFlowLayoutPanel.AutoSize = true;
            this.standbyFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.standbyFlowLayoutPanel.Controls.Add(this.rmi1CheckBox);
            this.standbyFlowLayoutPanel.Controls.Add(this.rmi2CheckBox);
            this.standbyFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.standbyFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.standbyFlowLayoutPanel.Name = "standbyFlowLayoutPanel";
            this.standbyFlowLayoutPanel.Size = new System.Drawing.Size(268, 43);
            this.standbyFlowLayoutPanel.TabIndex = 0;
            // 
            // rmi1CheckBox
            // 
            this.rmi1CheckBox.AccessibleName = "RMI #1 switch";
            this.rmi1CheckBox.AutoSize = true;
            this.rmi1CheckBox.Location = new System.Drawing.Point(3, 3);
            this.rmi1CheckBox.Name = "rmi1CheckBox";
            this.rmi1CheckBox.Size = new System.Drawing.Size(128, 37);
            this.rmi1CheckBox.TabIndex = 0;
            this.rmi1CheckBox.Text = "RMI #1";
            this.rmi1CheckBox.UseVisualStyleBackColor = true;
            // 
            // rmi2CheckBox
            // 
            this.rmi2CheckBox.AccessibleName = "RMI #2 switch";
            this.rmi2CheckBox.AutoSize = true;
            this.rmi2CheckBox.Location = new System.Drawing.Point(137, 3);
            this.rmi2CheckBox.Name = "rmi2CheckBox";
            this.rmi2CheckBox.Size = new System.Drawing.Size(128, 37);
            this.rmi2CheckBox.TabIndex = 1;
            this.rmi2CheckBox.Text = "RMI #2";
            this.rmi2CheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlStandby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.standbyFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlStandby";
            this.Size = new System.Drawing.Size(271, 46);
            this.Load += new System.EventHandler(this.ctlStandby_Load);
            this.standbyFlowLayoutPanel.ResumeLayout(false);
            this.standbyFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel standbyFlowLayoutPanel;
        private System.Windows.Forms.CheckBox rmi1CheckBox;
        private System.Windows.Forms.CheckBox rmi2CheckBox;
    }
}
