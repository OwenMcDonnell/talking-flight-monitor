namespace tfm.Settings_panels.PMDG737
{
    partial class ctlServiceInterPhone
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
            this.servicePhoneCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.servicePhoneCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(254, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // servicePhoneCheckBox
            // 
            this.servicePhoneCheckBox.AccessibleName = "Service interphone";
            this.servicePhoneCheckBox.AutoSize = true;
            this.servicePhoneCheckBox.Location = new System.Drawing.Point(3, 3);
            this.servicePhoneCheckBox.Name = "servicePhoneCheckBox";
            this.servicePhoneCheckBox.Size = new System.Drawing.Size(248, 37);
            this.servicePhoneCheckBox.TabIndex = 0;
            this.servicePhoneCheckBox.Text = "&Service interphone";
            this.servicePhoneCheckBox.UseVisualStyleBackColor = true;
            this.servicePhoneCheckBox.CheckedChanged += new System.EventHandler(this.servicePhoneCheckBox_CheckedChanged);
            // 
            // ctlServiceInterPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ctlServiceInterPhone";
            this.Size = new System.Drawing.Size(257, 46);
            this.Load += new System.EventHandler(this.ctlServiceInterPhone_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox servicePhoneCheckBox;
    }
}
