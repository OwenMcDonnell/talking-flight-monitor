namespace tfm.Settings_panels.PMDG737
{
    partial class ctlNav_Dis
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
            this.vhfCheckBox = new System.Windows.Forms.CheckBox();
            this.irsCheckBox = new System.Windows.Forms.CheckBox();
            this.fmcCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceCheckBox = new System.Windows.Forms.CheckBox();
            this.controlPaneCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.vhfCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.irsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.fmcCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.sourceCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.controlPaneCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1080, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // vhfCheckBox
            // 
            this.vhfCheckBox.AccessibleName = "VHF selector switch";
            this.vhfCheckBox.AutoSize = true;
            this.vhfCheckBox.Location = new System.Drawing.Point(3, 3);
            this.vhfCheckBox.Name = "vhfCheckBox";
            this.vhfCheckBox.Size = new System.Drawing.Size(189, 37);
            this.vhfCheckBox.TabIndex = 0;
            this.vhfCheckBox.Text = "&VHF selector";
            this.vhfCheckBox.UseVisualStyleBackColor = true;
            this.vhfCheckBox.CheckedChanged += new System.EventHandler(this.vhfCheckBox_CheckedChanged);
            // 
            // irsCheckBox
            // 
            this.irsCheckBox.AccessibleName = "IRS selector switch";
            this.irsCheckBox.AutoSize = true;
            this.irsCheckBox.Location = new System.Drawing.Point(198, 3);
            this.irsCheckBox.Name = "irsCheckBox";
            this.irsCheckBox.Size = new System.Drawing.Size(177, 37);
            this.irsCheckBox.TabIndex = 1;
            this.irsCheckBox.Text = "&IRS selector";
            this.irsCheckBox.UseVisualStyleBackColor = true;
            this.irsCheckBox.CheckedChanged += new System.EventHandler(this.irsCheckBox_CheckedChanged);
            // 
            // fmcCheckBox
            // 
            this.fmcCheckBox.AccessibleName = "FMC selector switch";
            this.fmcCheckBox.AutoSize = true;
            this.fmcCheckBox.Location = new System.Drawing.Point(381, 3);
            this.fmcCheckBox.Name = "fmcCheckBox";
            this.fmcCheckBox.Size = new System.Drawing.Size(194, 37);
            this.fmcCheckBox.TabIndex = 2;
            this.fmcCheckBox.Text = "&FMC selector";
            this.fmcCheckBox.UseVisualStyleBackColor = true;
            this.fmcCheckBox.CheckedChanged += new System.EventHandler(this.fmcCheckBox_CheckedChanged);
            // 
            // sourceCheckBox
            // 
            this.sourceCheckBox.AccessibleName = "Source selector switch";
            this.sourceCheckBox.AutoSize = true;
            this.sourceCheckBox.Location = new System.Drawing.Point(581, 3);
            this.sourceCheckBox.Name = "sourceCheckBox";
            this.sourceCheckBox.Size = new System.Drawing.Size(211, 37);
            this.sourceCheckBox.TabIndex = 3;
            this.sourceCheckBox.Text = "&Source selector";
            this.sourceCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.sourceCheckBox.UseVisualStyleBackColor = true;
            this.sourceCheckBox.CheckedChanged += new System.EventHandler(this.sourceCheckBox_CheckedChanged);
            // 
            // controlPaneCheckBox
            // 
            this.controlPaneCheckBox.AccessibleName = "Control pane selector switch";
            this.controlPaneCheckBox.AutoSize = true;
            this.controlPaneCheckBox.Location = new System.Drawing.Point(798, 3);
            this.controlPaneCheckBox.Name = "controlPaneCheckBox";
            this.controlPaneCheckBox.Size = new System.Drawing.Size(279, 37);
            this.controlPaneCheckBox.TabIndex = 4;
            this.controlPaneCheckBox.Text = "&Control pane selector";
            this.controlPaneCheckBox.UseVisualStyleBackColor = true;
            this.controlPaneCheckBox.CheckedChanged += new System.EventHandler(this.controlPaneCheckBox_CheckedChanged);
            // 
            // ctlNav_Dis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlNav_Dis";
            this.Size = new System.Drawing.Size(1083, 46);
            this.Load += new System.EventHandler(this.ctlNav_Dis_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox vhfCheckBox;
        private System.Windows.Forms.CheckBox irsCheckBox;
        private System.Windows.Forms.CheckBox fmcCheckBox;
        private System.Windows.Forms.CheckBox sourceCheckBox;
        private System.Windows.Forms.CheckBox controlPaneCheckBox;
    }
}
