namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
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
            this.n1SelectorButton = new System.Windows.Forms.Button();
            this.speedRefButton = new System.Windows.Forms.Button();
            this.speedFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // speedFlowLayoutPanel
            // 
            this.speedFlowLayoutPanel.Controls.Add(this.n1SelectorButton);
            this.speedFlowLayoutPanel.Controls.Add(this.speedRefButton);
            this.speedFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.speedFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.speedFlowLayoutPanel.Name = "speedFlowLayoutPanel";
            this.speedFlowLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.speedFlowLayoutPanel.TabIndex = 0;
            // 
            // n1SelectorButton
            // 
            this.n1SelectorButton.AutoSize = true;
            this.n1SelectorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.n1SelectorButton.Location = new System.Drawing.Point(3, 3);
            this.n1SelectorButton.Name = "n1SelectorButton";
            this.n1SelectorButton.Size = new System.Drawing.Size(111, 43);
            this.n1SelectorButton.TabIndex = 0;
            this.n1SelectorButton.Text = "button1";
            this.n1SelectorButton.UseVisualStyleBackColor = true;
            this.n1SelectorButton.Click += new System.EventHandler(this.n1SelectorButton_Click);
            // 
            // speedRefButton
            // 
            this.speedRefButton.AutoSize = true;
            this.speedRefButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.speedRefButton.Location = new System.Drawing.Point(3, 52);
            this.speedRefButton.Name = "speedRefButton";
            this.speedRefButton.Size = new System.Drawing.Size(111, 43);
            this.speedRefButton.TabIndex = 1;
            this.speedRefButton.Text = "button2";
            this.speedRefButton.UseVisualStyleBackColor = true;
            this.speedRefButton.Click += new System.EventHandler(this.speedRefButton_Click);
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
            this.Size = new System.Drawing.Size(203, 103);
            this.Load += new System.EventHandler(this.ctlForwardSpeed_Load);
            this.speedFlowLayoutPanel.ResumeLayout(false);
            this.speedFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel speedFlowLayoutPanel;
        private System.Windows.Forms.Button n1SelectorButton;
        private System.Windows.Forms.Button speedRefButton;
    }
}
