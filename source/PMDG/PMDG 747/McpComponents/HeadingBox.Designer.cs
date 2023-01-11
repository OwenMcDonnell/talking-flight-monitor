namespace tfm.PMDG.PMDG_747.McpComponents
{
    partial class HeadingBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headingFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headingLabel = new System.Windows.Forms.Label();
            this.headingTextBox = new System.Windows.Forms.TextBox();
            this.interveneButton = new System.Windows.Forms.Button();
            this.lNavButton = new System.Windows.Forms.Button();
            this.holdButton = new System.Windows.Forms.Button();
            this.headingFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headingFlowLayoutPanel
            // 
            this.headingFlowLayoutPanel.AutoSize = true;
            this.headingFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headingFlowLayoutPanel.Controls.Add(this.headingLabel);
            this.headingFlowLayoutPanel.Controls.Add(this.headingTextBox);
            this.headingFlowLayoutPanel.Controls.Add(this.interveneButton);
            this.headingFlowLayoutPanel.Controls.Add(this.lNavButton);
            this.headingFlowLayoutPanel.Controls.Add(this.holdButton);
            this.headingFlowLayoutPanel.Location = new System.Drawing.Point(-1, -35);
            this.headingFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.headingFlowLayoutPanel.Name = "headingFlowLayoutPanel";
            this.headingFlowLayoutPanel.Size = new System.Drawing.Size(599, 49);
            this.headingFlowLayoutPanel.TabIndex = 2;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Location = new System.Drawing.Point(10, 0);
            this.headingLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(107, 33);
            this.headingLabel.TabIndex = 1;
            this.headingLabel.Text = "H&eading";
            // 
            // headingTextBox
            // 
            this.headingTextBox.AccessibleName = "Heading";
            this.headingTextBox.Location = new System.Drawing.Point(123, 3);
            this.headingTextBox.Name = "headingTextBox";
            this.headingTextBox.Size = new System.Drawing.Size(100, 40);
            this.headingTextBox.TabIndex = 2;
            this.headingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.headingTextBox_KeyDown);
            // 
            // interveneButton
            // 
            this.interveneButton.AccessibleName = "Intervene";
            this.interveneButton.AutoSize = true;
            this.interveneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.interveneButton.Location = new System.Drawing.Point(236, 3);
            this.interveneButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.interveneButton.Name = "interveneButton";
            this.interveneButton.Size = new System.Drawing.Size(126, 43);
            this.interveneButton.TabIndex = 3;
            this.interveneButton.Text = "&Intervene";
            this.interveneButton.UseVisualStyleBackColor = true;
            this.interveneButton.Click += new System.EventHandler(this.interveneButton_Click);
            // 
            // lNavButton
            // 
            this.lNavButton.AutoSize = true;
            this.lNavButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lNavButton.Location = new System.Drawing.Point(368, 3);
            this.lNavButton.Name = "lNavButton";
            this.lNavButton.Size = new System.Drawing.Size(111, 43);
            this.lNavButton.TabIndex = 4;
            this.lNavButton.Text = "button1";
            this.lNavButton.UseVisualStyleBackColor = true;
            this.lNavButton.Click += new System.EventHandler(this.lNavButton_Click);
            // 
            // holdButton
            // 
            this.holdButton.AutoSize = true;
            this.holdButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.holdButton.Location = new System.Drawing.Point(485, 3);
            this.holdButton.Name = "holdButton";
            this.holdButton.Size = new System.Drawing.Size(111, 43);
            this.holdButton.TabIndex = 5;
            this.holdButton.Text = "button1";
            this.holdButton.UseVisualStyleBackColor = true;
            this.holdButton.Click += new System.EventHandler(this.holdButton_Click);
            // 
            // HeadingBox
            // 
            this.AccessibleName = "Heading box";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(597, 13);
            this.Controls.Add(this.headingFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HeadingBox";
            this.Text = "Heading box";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HeadingBox_FormClosing);
            this.Load += new System.EventHandler(this.HeadingBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeadingBox_KeyDown);
            this.headingFlowLayoutPanel.ResumeLayout(false);
            this.headingFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel headingFlowLayoutPanel;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.TextBox headingTextBox;
        private System.Windows.Forms.Button interveneButton;
        private System.Windows.Forms.Button lNavButton;
        private System.Windows.Forms.Button holdButton;
    }
}