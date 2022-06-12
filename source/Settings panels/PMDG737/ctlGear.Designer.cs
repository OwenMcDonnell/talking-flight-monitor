namespace tfm.Settings_panels.PMDG737
{
    partial class ctlGear
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
            this.noseGearCheckBox = new System.Windows.Forms.CheckBox();
            this.leftGearCheckBox = new System.Windows.Forms.CheckBox();
            this.rightGearCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.noseGearCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.leftGearCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.rightGearCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(548, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // noseGearCheckBox
            // 
            this.noseGearCheckBox.AccessibleName = "Nose gear indicator";
            this.noseGearCheckBox.AutoSize = true;
            this.noseGearCheckBox.Location = new System.Drawing.Point(3, 3);
            this.noseGearCheckBox.Name = "noseGearCheckBox";
            this.noseGearCheckBox.Size = new System.Drawing.Size(179, 37);
            this.noseGearCheckBox.TabIndex = 0;
            this.noseGearCheckBox.Text = "&1. Nose gear";
            this.noseGearCheckBox.UseVisualStyleBackColor = true;
            this.noseGearCheckBox.CheckedChanged += new System.EventHandler(this.noseGearCheckBox_CheckedChanged);
            // 
            // leftGearCheckBox
            // 
            this.leftGearCheckBox.AccessibleName = "Left gear indicator";
            this.leftGearCheckBox.AutoSize = true;
            this.leftGearCheckBox.Location = new System.Drawing.Point(188, 3);
            this.leftGearCheckBox.Name = "leftGearCheckBox";
            this.leftGearCheckBox.Size = new System.Drawing.Size(167, 37);
            this.leftGearCheckBox.TabIndex = 1;
            this.leftGearCheckBox.Text = "&2. Left gear";
            this.leftGearCheckBox.UseVisualStyleBackColor = true;
            this.leftGearCheckBox.CheckedChanged += new System.EventHandler(this.leftGearCheckBox_CheckedChanged);
            // 
            // rightGearCheckBox
            // 
            this.rightGearCheckBox.AccessibleName = "Right gear indicator";
            this.rightGearCheckBox.AutoSize = true;
            this.rightGearCheckBox.Location = new System.Drawing.Point(361, 3);
            this.rightGearCheckBox.Name = "rightGearCheckBox";
            this.rightGearCheckBox.Size = new System.Drawing.Size(184, 37);
            this.rightGearCheckBox.TabIndex = 2;
            this.rightGearCheckBox.Text = "&3. Right gear";
            this.rightGearCheckBox.UseVisualStyleBackColor = true;
            this.rightGearCheckBox.CheckedChanged += new System.EventHandler(this.rightGearCheckBox_CheckedChanged);
            // 
            // ctlGear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ctlGear";
            this.Size = new System.Drawing.Size(551, 46);
            this.Load += new System.EventHandler(this.ctlGear_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox noseGearCheckBox;
        private System.Windows.Forms.CheckBox leftGearCheckBox;
        private System.Windows.Forms.CheckBox rightGearCheckBox;
    }
}
