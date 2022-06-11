namespace tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead
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
            this.oxygenFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.oxygenNeedleFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.oxygenNeedleTextBox = new System.Windows.Forms.TextBox();
            this.oxygenButton = new System.Windows.Forms.Button();
            this.passengerOxyFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.passengerOxygenTextBox = new System.Windows.Forms.TextBox();
            this.oxygenFlowLayoutPanel.SuspendLayout();
            this.oxygenNeedleFlowLayout.SuspendLayout();
            this.passengerOxyFlowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // oxygenFlowLayoutPanel
            // 
            this.oxygenFlowLayoutPanel.AutoSize = true;
            this.oxygenFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.oxygenFlowLayoutPanel.Controls.Add(this.oxygenNeedleFlowLayout);
            this.oxygenFlowLayoutPanel.Controls.Add(this.oxygenButton);
            this.oxygenFlowLayoutPanel.Controls.Add(this.passengerOxyFlowLayout);
            this.oxygenFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.oxygenFlowLayoutPanel.Name = "oxygenFlowLayoutPanel";
            this.oxygenFlowLayoutPanel.Size = new System.Drawing.Size(595, 85);
            this.oxygenFlowLayoutPanel.TabIndex = 0;
            // 
            // oxygenNeedleFlowLayout
            // 
            this.oxygenNeedleFlowLayout.AutoSize = true;
            this.oxygenNeedleFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.oxygenNeedleFlowLayout.Controls.Add(this.label1);
            this.oxygenNeedleFlowLayout.Controls.Add(this.oxygenNeedleTextBox);
            this.oxygenNeedleFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.oxygenNeedleFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.oxygenNeedleFlowLayout.Name = "oxygenNeedleFlowLayout";
            this.oxygenNeedleFlowLayout.Size = new System.Drawing.Size(256, 79);
            this.oxygenNeedleFlowLayout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "O&xygen level [0-240]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oxygenNeedleTextBox
            // 
            this.oxygenNeedleTextBox.AccessibleName = "Oxygen needle";
            this.oxygenNeedleTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.oxygenNeedleTextBox.Location = new System.Drawing.Point(3, 36);
            this.oxygenNeedleTextBox.Name = "oxygenNeedleTextBox";
            this.oxygenNeedleTextBox.Size = new System.Drawing.Size(233, 40);
            this.oxygenNeedleTextBox.TabIndex = 1;
            this.oxygenNeedleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // oxygenButton
            // 
            this.oxygenButton.AccessibleName = "Oxygen";
            this.oxygenButton.Location = new System.Drawing.Point(265, 31);
            this.oxygenButton.Margin = new System.Windows.Forms.Padding(3, 31, 3, 31);
            this.oxygenButton.Name = "oxygenButton";
            this.oxygenButton.Size = new System.Drawing.Size(75, 23);
            this.oxygenButton.TabIndex = 1;
            this.oxygenButton.Text = "Oxygen";
            this.oxygenButton.UseVisualStyleBackColor = true;
            this.oxygenButton.Click += new System.EventHandler(this.oxygenButton_Click);
            // 
            // passengerOxyFlowLayout
            // 
            this.passengerOxyFlowLayout.AutoSize = true;
            this.passengerOxyFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.passengerOxyFlowLayout.Controls.Add(this.label2);
            this.passengerOxyFlowLayout.Controls.Add(this.passengerOxygenTextBox);
            this.passengerOxyFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.passengerOxyFlowLayout.Location = new System.Drawing.Point(346, 3);
            this.passengerOxyFlowLayout.Name = "passengerOxyFlowLayout";
            this.passengerOxyFlowLayout.Size = new System.Drawing.Size(246, 79);
            this.passengerOxyFlowLayout.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "&1. Passenger oxygen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passengerOxygenTextBox
            // 
            this.passengerOxygenTextBox.AccessibleName = "Passenger oxygen";
            this.passengerOxygenTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.passengerOxygenTextBox.Location = new System.Drawing.Point(3, 36);
            this.passengerOxygenTextBox.Name = "passengerOxygenTextBox";
            this.passengerOxygenTextBox.ReadOnly = true;
            this.passengerOxygenTextBox.Size = new System.Drawing.Size(240, 40);
            this.passengerOxygenTextBox.TabIndex = 1;
            // 
            // ctlOxygen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.oxygenFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlOxygen";
            this.Size = new System.Drawing.Size(598, 88);
            this.Load += new System.EventHandler(this.ctlOxygen_Load);
            this.oxygenFlowLayoutPanel.ResumeLayout(false);
            this.oxygenFlowLayoutPanel.PerformLayout();
            this.oxygenNeedleFlowLayout.ResumeLayout(false);
            this.oxygenNeedleFlowLayout.PerformLayout();
            this.passengerOxyFlowLayout.ResumeLayout(false);
            this.passengerOxyFlowLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel oxygenFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel oxygenNeedleFlowLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oxygenNeedleTextBox;
        private System.Windows.Forms.Button oxygenButton;
        private System.Windows.Forms.FlowLayoutPanel passengerOxyFlowLayout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passengerOxygenTextBox;
    }
}
