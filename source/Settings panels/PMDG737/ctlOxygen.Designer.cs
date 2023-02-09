namespace tfm.Settings_panels.PMDG737
{
    partial class ctlOxygen
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
            this.oxyNeedleCheckBox = new System.Windows.Forms.CheckBox();
            this.oxySwitchCheckBox = new System.Windows.Forms.CheckBox();
            this.passengerOxyCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.oxyNeedleCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.oxySwitchCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.passengerOxyCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(754, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // oxyNeedleCheckBox
            // 
            this.oxyNeedleCheckBox.AccessibleName = "Oxygen needle";
            this.oxyNeedleCheckBox.AutoSize = true;
            this.oxyNeedleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.oxyNeedleCheckBox.Name = "oxyNeedleCheckBox";
            this.oxyNeedleCheckBox.Size = new System.Drawing.Size(206, 37);
            this.oxyNeedleCheckBox.TabIndex = 0;
            this.oxyNeedleCheckBox.Text = "O&xygen needle";
            this.oxyNeedleCheckBox.UseVisualStyleBackColor = true;
            this.oxyNeedleCheckBox.CheckedChanged += new System.EventHandler(this.oxyNeedleCheckBox_CheckedChanged);
            // 
            // oxySwitchCheckBox
            // 
            this.oxySwitchCheckBox.AccessibleName = "Oxygen switch";
            this.oxySwitchCheckBox.AutoSize = true;
            this.oxySwitchCheckBox.Location = new System.Drawing.Point(215, 3);
            this.oxySwitchCheckBox.Name = "oxySwitchCheckBox";
            this.oxySwitchCheckBox.Size = new System.Drawing.Size(206, 37);
            this.oxySwitchCheckBox.TabIndex = 1;
            this.oxySwitchCheckBox.Text = "&Oxygen switch";
            this.oxySwitchCheckBox.UseVisualStyleBackColor = true;
            this.oxySwitchCheckBox.CheckedChanged += new System.EventHandler(this.oxySwitchCheckBox_CheckedChanged);
            // 
            // passengerOxyCheckBox
            // 
            this.passengerOxyCheckBox.AccessibleName = "Passenger oxygen indicator";
            this.passengerOxyCheckBox.AutoSize = true;
            this.passengerOxyCheckBox.Location = new System.Drawing.Point(427, 3);
            this.passengerOxyCheckBox.Name = "passengerOxyCheckBox";
            this.passengerOxyCheckBox.Size = new System.Drawing.Size(324, 37);
            this.passengerOxyCheckBox.TabIndex = 2;
            this.passengerOxyCheckBox.Text = "&1. Passenger oxygen light";
            this.passengerOxyCheckBox.UseVisualStyleBackColor = true;
            this.passengerOxyCheckBox.CheckedChanged += new System.EventHandler(this.passengerOxyCheckBox_CheckedChanged);
            // 
            // ctlOxygen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ctlOxygen";
            this.Size = new System.Drawing.Size(759, 48);
            this.Load += new System.EventHandler(this.ctlOxygen_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox oxyNeedleCheckBox;
        private System.Windows.Forms.CheckBox oxySwitchCheckBox;
        private System.Windows.Forms.CheckBox passengerOxyCheckBox;
    }
}
