namespace tfm.Settings_panels.PMDG737
{
    partial class ctlAPU
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
            this.apuFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.egtNeedleCheckBox = new System.Windows.Forms.CheckBox();
            this.maintCheckBox = new System.Windows.Forms.CheckBox();
            this.lowOilCheckBox = new System.Windows.Forms.CheckBox();
            this.faultCheckBox = new System.Windows.Forms.CheckBox();
            this.overSpeedCheckBox = new System.Windows.Forms.CheckBox();
            this.apuFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // apuFlowLayoutPanel
            // 
            this.apuFlowLayoutPanel.AutoSize = true;
            this.apuFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.apuFlowLayoutPanel.Controls.Add(this.egtNeedleCheckBox);
            this.apuFlowLayoutPanel.Controls.Add(this.maintCheckBox);
            this.apuFlowLayoutPanel.Controls.Add(this.lowOilCheckBox);
            this.apuFlowLayoutPanel.Controls.Add(this.faultCheckBox);
            this.apuFlowLayoutPanel.Controls.Add(this.overSpeedCheckBox);
            this.apuFlowLayoutPanel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apuFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.apuFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.apuFlowLayoutPanel.MaximumSize = new System.Drawing.Size(3200, 1782);
            this.apuFlowLayoutPanel.Name = "apuFlowLayoutPanel";
            this.apuFlowLayoutPanel.Size = new System.Drawing.Size(791, 43);
            this.apuFlowLayoutPanel.TabIndex = 0;
            // 
            // egtNeedleCheckBox
            // 
            this.egtNeedleCheckBox.AccessibleName = "EGT needle";
            this.egtNeedleCheckBox.AutoSize = true;
            this.egtNeedleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.egtNeedleCheckBox.Name = "egtNeedleCheckBox";
            this.egtNeedleCheckBox.Size = new System.Drawing.Size(171, 37);
            this.egtNeedleCheckBox.TabIndex = 0;
            this.egtNeedleCheckBox.Text = "EG&T needle";
            this.egtNeedleCheckBox.UseVisualStyleBackColor = true;
            this.egtNeedleCheckBox.CheckedChanged += new System.EventHandler(this.egtNeedleCheckBox_CheckedChanged);
            // 
            // maintCheckBox
            // 
            this.maintCheckBox.AccessibleName = "Maint indicator";
            this.maintCheckBox.AutoSize = true;
            this.maintCheckBox.Location = new System.Drawing.Point(180, 3);
            this.maintCheckBox.Name = "maintCheckBox";
            this.maintCheckBox.Size = new System.Drawing.Size(108, 37);
            this.maintCheckBox.TabIndex = 1;
            this.maintCheckBox.Text = "&Maint";
            this.maintCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.maintCheckBox.UseVisualStyleBackColor = true;
            this.maintCheckBox.CheckedChanged += new System.EventHandler(this.maintCheckBox_CheckedChanged);
            // 
            // lowOilCheckBox
            // 
            this.lowOilCheckBox.AccessibleName = "Low oil pressure indicator";
            this.lowOilCheckBox.AutoSize = true;
            this.lowOilCheckBox.Location = new System.Drawing.Point(294, 3);
            this.lowOilCheckBox.Name = "lowOilCheckBox";
            this.lowOilCheckBox.Size = new System.Drawing.Size(226, 37);
            this.lowOilCheckBox.TabIndex = 2;
            this.lowOilCheckBox.Text = "Low &oil pressure";
            this.lowOilCheckBox.UseVisualStyleBackColor = true;
            this.lowOilCheckBox.CheckedChanged += new System.EventHandler(this.lowOilCheckBox_CheckedChanged);
            // 
            // faultCheckBox
            // 
            this.faultCheckBox.AccessibleName = "Fault indicator";
            this.faultCheckBox.AutoSize = true;
            this.faultCheckBox.Location = new System.Drawing.Point(526, 3);
            this.faultCheckBox.Name = "faultCheckBox";
            this.faultCheckBox.Size = new System.Drawing.Size(99, 37);
            this.faultCheckBox.TabIndex = 3;
            this.faultCheckBox.Text = "&Fault";
            this.faultCheckBox.UseVisualStyleBackColor = true;
            this.faultCheckBox.CheckedChanged += new System.EventHandler(this.faultCheckBox_CheckedChanged);
            // 
            // overSpeedCheckBox
            // 
            this.overSpeedCheckBox.AccessibleName = "Overspeed indicator";
            this.overSpeedCheckBox.AutoSize = true;
            this.overSpeedCheckBox.Location = new System.Drawing.Point(631, 3);
            this.overSpeedCheckBox.Name = "overSpeedCheckBox";
            this.overSpeedCheckBox.Size = new System.Drawing.Size(157, 37);
            this.overSpeedCheckBox.TabIndex = 4;
            this.overSpeedCheckBox.Text = "Over&speed";
            this.overSpeedCheckBox.UseVisualStyleBackColor = true;
            this.overSpeedCheckBox.CheckedChanged += new System.EventHandler(this.overSpeedCheckBox_CheckedChanged);
            // 
            // ctlAPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.apuFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(3200, 1782);
            this.Name = "ctlAPU";
            this.Size = new System.Drawing.Size(796, 48);
            this.Load += new System.EventHandler(this.ctlAPU_Load);
            this.apuFlowLayoutPanel.ResumeLayout(false);
            this.apuFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel apuFlowLayoutPanel;
        private System.Windows.Forms.CheckBox egtNeedleCheckBox;
        private System.Windows.Forms.CheckBox maintCheckBox;
        private System.Windows.Forms.CheckBox lowOilCheckBox;
        private System.Windows.Forms.CheckBox faultCheckBox;
        private System.Windows.Forms.CheckBox overSpeedCheckBox;
    }
}
