namespace tfm.Settings_panels.PMDG737
{
    partial class ctlForwardSpeed
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
            this.speedFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.n1SelectorCheckBox = new System.Windows.Forms.CheckBox();
            this.speedRefCheckBox = new System.Windows.Forms.CheckBox();
            this.speedFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // speedFlowLayoutPanel
            // 
            this.speedFlowLayoutPanel.AutoSize = true;
            this.speedFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.speedFlowLayoutPanel.Controls.Add(this.n1SelectorCheckBox);
            this.speedFlowLayoutPanel.Controls.Add(this.speedRefCheckBox);
            this.speedFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.speedFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.speedFlowLayoutPanel.Name = "speedFlowLayoutPanel";
            this.speedFlowLayoutPanel.Size = new System.Drawing.Size(326, 43);
            this.speedFlowLayoutPanel.TabIndex = 0;
            // 
            // n1SelectorCheckBox
            // 
            this.n1SelectorCheckBox.AccessibleName = "N1 selector switch";
            this.n1SelectorCheckBox.AutoSize = true;
            this.n1SelectorCheckBox.Location = new System.Drawing.Point(3, 3);
            this.n1SelectorCheckBox.Name = "n1SelectorCheckBox";
            this.n1SelectorCheckBox.Size = new System.Drawing.Size(168, 37);
            this.n1SelectorCheckBox.TabIndex = 0;
            this.n1SelectorCheckBox.Text = "N1 selector";
            this.n1SelectorCheckBox.UseVisualStyleBackColor = true;
            // 
            // speedRefCheckBox
            // 
            this.speedRefCheckBox.AccessibleName = "Speed ref selector switch";
            this.speedRefCheckBox.AutoSize = true;
            this.speedRefCheckBox.Location = new System.Drawing.Point(177, 3);
            this.speedRefCheckBox.Name = "speedRefCheckBox";
            this.speedRefCheckBox.Size = new System.Drawing.Size(146, 37);
            this.speedRefCheckBox.TabIndex = 1;
            this.speedRefCheckBox.Text = "Speed ref";
            this.speedRefCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlForwardSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.speedFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlForwardSpeed";
            this.Size = new System.Drawing.Size(329, 46);
            this.Load += new System.EventHandler(this.ctlForwardSpeed_Load);
            this.speedFlowLayoutPanel.ResumeLayout(false);
            this.speedFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel speedFlowLayoutPanel;
        private System.Windows.Forms.CheckBox n1SelectorCheckBox;
        private System.Windows.Forms.CheckBox speedRefCheckBox;
    }
}
