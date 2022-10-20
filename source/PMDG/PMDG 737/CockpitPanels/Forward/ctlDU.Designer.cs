namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
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
            this.du1Button = new System.Windows.Forms.Button();
            this.du2Button = new System.Windows.Forms.Button();
            this.lowerDu1Button = new System.Windows.Forms.Button();
            this.lowerDu2Button = new System.Windows.Forms.Button();
            this.duFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // duFlowLayoutPanel
            // 
            this.duFlowLayoutPanel.AutoSize = true;
            this.duFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.duFlowLayoutPanel.Controls.Add(this.du1Button);
            this.duFlowLayoutPanel.Controls.Add(this.du2Button);
            this.duFlowLayoutPanel.Controls.Add(this.lowerDu1Button);
            this.duFlowLayoutPanel.Controls.Add(this.lowerDu2Button);
            this.duFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.duFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.duFlowLayoutPanel.Name = "duFlowLayoutPanel";
            this.duFlowLayoutPanel.Size = new System.Drawing.Size(468, 49);
            this.duFlowLayoutPanel.TabIndex = 0;
            // 
            // du1Button
            // 
            this.du1Button.AutoSize = true;
            this.du1Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.du1Button.Location = new System.Drawing.Point(3, 3);
            this.du1Button.Name = "du1Button";
            this.du1Button.Size = new System.Drawing.Size(111, 43);
            this.du1Button.TabIndex = 0;
            this.du1Button.Text = "button1";
            this.du1Button.UseVisualStyleBackColor = true;
            this.du1Button.Click += new System.EventHandler(this.du1Button_Click);
            // 
            // du2Button
            // 
            this.du2Button.AutoSize = true;
            this.du2Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.du2Button.Location = new System.Drawing.Point(120, 3);
            this.du2Button.Name = "du2Button";
            this.du2Button.Size = new System.Drawing.Size(111, 43);
            this.du2Button.TabIndex = 1;
            this.du2Button.Text = "button2";
            this.du2Button.UseVisualStyleBackColor = true;
            this.du2Button.Click += new System.EventHandler(this.du2Button_Click);
            // 
            // lowerDu1Button
            // 
            this.lowerDu1Button.AutoSize = true;
            this.lowerDu1Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lowerDu1Button.Location = new System.Drawing.Point(237, 3);
            this.lowerDu1Button.Name = "lowerDu1Button";
            this.lowerDu1Button.Size = new System.Drawing.Size(111, 43);
            this.lowerDu1Button.TabIndex = 2;
            this.lowerDu1Button.Text = "button3";
            this.lowerDu1Button.UseVisualStyleBackColor = true;
            this.lowerDu1Button.Click += new System.EventHandler(this.lowerDu1Button_Click);
            // 
            // lowerDu2Button
            // 
            this.lowerDu2Button.AutoSize = true;
            this.lowerDu2Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lowerDu2Button.Location = new System.Drawing.Point(354, 3);
            this.lowerDu2Button.Name = "lowerDu2Button";
            this.lowerDu2Button.Size = new System.Drawing.Size(111, 43);
            this.lowerDu2Button.TabIndex = 3;
            this.lowerDu2Button.Text = "button4";
            this.lowerDu2Button.UseVisualStyleBackColor = true;
            this.lowerDu2Button.Click += new System.EventHandler(this.lowerDu2Button_Click);
            // 
            // ctlDU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.duFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlDU";
            this.Size = new System.Drawing.Size(471, 52);
            this.Load += new System.EventHandler(this.ctlDU_Load);
            this.duFlowLayoutPanel.ResumeLayout(false);
            this.duFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel duFlowLayoutPanel;
        private System.Windows.Forms.Button du1Button;
        private System.Windows.Forms.Button du2Button;
        private System.Windows.Forms.Button lowerDu1Button;
        private System.Windows.Forms.Button lowerDu2Button;
    }
}
