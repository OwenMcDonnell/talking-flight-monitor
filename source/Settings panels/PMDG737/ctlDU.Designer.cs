namespace tfm.Settings_panels.PMDG737
{
    partial class ctlDU
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
            this.duFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.captDUCheckBox = new System.Windows.Forms.CheckBox();
            this.foDUCheckBox = new System.Windows.Forms.CheckBox();
            this.captLowerDUCheckBox = new System.Windows.Forms.CheckBox();
            this.foLowerDUCheckBox = new System.Windows.Forms.CheckBox();
            this.duFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // duFlowLayoutPanel
            // 
            this.duFlowLayoutPanel.AutoSize = true;
            this.duFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.duFlowLayoutPanel.Controls.Add(this.captDUCheckBox);
            this.duFlowLayoutPanel.Controls.Add(this.foDUCheckBox);
            this.duFlowLayoutPanel.Controls.Add(this.captLowerDUCheckBox);
            this.duFlowLayoutPanel.Controls.Add(this.foLowerDUCheckBox);
            this.duFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.duFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.duFlowLayoutPanel.Name = "duFlowLayoutPanel";
            this.duFlowLayoutPanel.Size = new System.Drawing.Size(718, 43);
            this.duFlowLayoutPanel.TabIndex = 0;
            // 
            // captDUCheckBox
            // 
            this.captDUCheckBox.AccessibleName = "Captain\'s DU selector";
            this.captDUCheckBox.AutoSize = true;
            this.captDUCheckBox.Location = new System.Drawing.Point(3, 3);
            this.captDUCheckBox.Name = "captDUCheckBox";
            this.captDUCheckBox.Size = new System.Drawing.Size(147, 37);
            this.captDUCheckBox.TabIndex = 0;
            this.captDUCheckBox.Text = "Capt. DU";
            this.captDUCheckBox.UseVisualStyleBackColor = true;
            // 
            // foDUCheckBox
            // 
            this.foDUCheckBox.AccessibleName = "First officer\'s DU selector";
            this.foDUCheckBox.AutoSize = true;
            this.foDUCheckBox.Location = new System.Drawing.Point(156, 3);
            this.foDUCheckBox.Name = "foDUCheckBox";
            this.foDUCheckBox.Size = new System.Drawing.Size(131, 37);
            this.foDUCheckBox.TabIndex = 1;
            this.foDUCheckBox.Text = "F/O DU";
            this.foDUCheckBox.UseVisualStyleBackColor = true;
            // 
            // captLowerDUCheckBox
            // 
            this.captLowerDUCheckBox.AccessibleName = "Captain\'s lower DU selector";
            this.captLowerDUCheckBox.AutoSize = true;
            this.captLowerDUCheckBox.Location = new System.Drawing.Point(293, 3);
            this.captLowerDUCheckBox.Name = "captLowerDUCheckBox";
            this.captLowerDUCheckBox.Size = new System.Drawing.Size(216, 37);
            this.captLowerDUCheckBox.TabIndex = 2;
            this.captLowerDUCheckBox.Text = "Capt. lower DU";
            this.captLowerDUCheckBox.UseVisualStyleBackColor = true;
            // 
            // foLowerDUCheckBox
            // 
            this.foLowerDUCheckBox.AccessibleName = "First officer\'s lower DU selector";
            this.foLowerDUCheckBox.AutoSize = true;
            this.foLowerDUCheckBox.Location = new System.Drawing.Point(515, 3);
            this.foLowerDUCheckBox.Name = "foLowerDUCheckBox";
            this.foLowerDUCheckBox.Size = new System.Drawing.Size(200, 37);
            this.foLowerDUCheckBox.TabIndex = 3;
            this.foLowerDUCheckBox.Text = "F/O lower DU";
            this.foLowerDUCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlDU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.duFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlDU";
            this.Size = new System.Drawing.Size(721, 46);
            this.Load += new System.EventHandler(this.ctlDU_Load);
            this.duFlowLayoutPanel.ResumeLayout(false);
            this.duFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel duFlowLayoutPanel;
        private System.Windows.Forms.CheckBox captDUCheckBox;
        private System.Windows.Forms.CheckBox foDUCheckBox;
        private System.Windows.Forms.CheckBox captLowerDUCheckBox;
        private System.Windows.Forms.CheckBox foLowerDUCheckBox;
    }
}
