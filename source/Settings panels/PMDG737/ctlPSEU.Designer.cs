namespace tfm.Settings_panels.PMDG737
{
    partial class ctlPSEU
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pseuWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.pseuWarningCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pseuWarningCheckBox
            // 
            this.pseuWarningCheckBox.AccessibleName = "PSEU warning light";
            this.pseuWarningCheckBox.AutoSize = true;
            this.pseuWarningCheckBox.Location = new System.Drawing.Point(3, 3);
            this.pseuWarningCheckBox.Name = "pseuWarningCheckBox";
            this.pseuWarningCheckBox.Size = new System.Drawing.Size(263, 37);
            this.pseuWarningCheckBox.TabIndex = 0;
            this.pseuWarningCheckBox.Text = "&PSEU warning light";
            this.pseuWarningCheckBox.UseVisualStyleBackColor = true;
            this.pseuWarningCheckBox.CheckedChanged += new System.EventHandler(this.pseuWarningCheckBox_CheckedChanged);
            // 
            // ctlPSEU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlPSEU";
            this.Size = new System.Drawing.Size(272, 46);
            this.Load += new System.EventHandler(this.ctlPSEU_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox pseuWarningCheckBox;
    }
}
