namespace tfm.Settings_panels.PMDG737
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
            this.servosCheckBox = new System.Windows.Forms.CheckBox();
            this.pitchCheckBox = new System.Windows.Forms.CheckBox();
            this.rollCheckBox = new System.Windows.Forms.CheckBox();
            this.afsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // afsFlowLayoutPanel
            // 
            this.afsFlowLayoutPanel.AutoSize = true;
            this.afsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.afsFlowLayoutPanel.Controls.Add(this.servosCheckBox);
            this.afsFlowLayoutPanel.Controls.Add(this.pitchCheckBox);
            this.afsFlowLayoutPanel.Controls.Add(this.rollCheckBox);
            this.afsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.afsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.afsFlowLayoutPanel.Name = "afsFlowLayoutPanel";
            this.afsFlowLayoutPanel.Size = new System.Drawing.Size(459, 43);
            this.afsFlowLayoutPanel.TabIndex = 0;
            // 
            // servosCheckBox
            // 
            this.servosCheckBox.AccessibleName = "Auto throttle servos";
            this.servosCheckBox.AutoSize = true;
            this.servosCheckBox.Location = new System.Drawing.Point(3, 3);
            this.servosCheckBox.Name = "servosCheckBox";
            this.servosCheckBox.Size = new System.Drawing.Size(148, 37);
            this.servosCheckBox.TabIndex = 0;
            this.servosCheckBox.Text = "&AT servos";
            this.servosCheckBox.UseVisualStyleBackColor = true;
            // 
            // pitchCheckBox
            // 
            this.pitchCheckBox.AccessibleName = "Auto pitch";
            this.pitchCheckBox.AutoSize = true;
            this.pitchCheckBox.Location = new System.Drawing.Point(157, 3);
            this.pitchCheckBox.Name = "pitchCheckBox";
            this.pitchCheckBox.Size = new System.Drawing.Size(155, 37);
            this.pitchCheckBox.TabIndex = 1;
            this.pitchCheckBox.Text = "AFS &pitch";
            this.pitchCheckBox.UseVisualStyleBackColor = true;
            // 
            // rollCheckBox
            // 
            this.rollCheckBox.AccessibleName = "Auto roll";
            this.rollCheckBox.AutoSize = true;
            this.rollCheckBox.Location = new System.Drawing.Point(318, 3);
            this.rollCheckBox.Name = "rollCheckBox";
            this.rollCheckBox.Size = new System.Drawing.Size(138, 37);
            this.rollCheckBox.TabIndex = 2;
            this.rollCheckBox.Text = "AFS &roll";
            this.rollCheckBox.UseVisualStyleBackColor = true;
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
            this.Size = new System.Drawing.Size(462, 46);
            this.Load += new System.EventHandler(this.ctlAFS_Load);
            this.afsFlowLayoutPanel.ResumeLayout(false);
            this.afsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel afsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox servosCheckBox;
        private System.Windows.Forms.CheckBox pitchCheckBox;
        private System.Windows.Forms.CheckBox rollCheckBox;
    }
}
