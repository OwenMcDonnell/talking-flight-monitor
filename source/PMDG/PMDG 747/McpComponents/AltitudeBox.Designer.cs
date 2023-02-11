namespace tfm.PMDG.PMDG_747.McpComponents
{
    partial class AltitudeBox
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
            this.altitudeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.altitudeTextBox = new System.Windows.Forms.TextBox();
            this.interveneButton = new System.Windows.Forms.Button();
            this.vNavButton = new System.Windows.Forms.Button();
            this.lvlChangeButton = new System.Windows.Forms.Button();
            this.holdButton = new System.Windows.Forms.Button();
            this.altitudeFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // altitudeFlowLayoutPanel
            // 
            this.altitudeFlowLayoutPanel.AutoSize = true;
            this.altitudeFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.altitudeFlowLayoutPanel.Controls.Add(this.altitudeLabel);
            this.altitudeFlowLayoutPanel.Controls.Add(this.altitudeTextBox);
            this.altitudeFlowLayoutPanel.Controls.Add(this.interveneButton);
            this.altitudeFlowLayoutPanel.Controls.Add(this.vNavButton);
            this.altitudeFlowLayoutPanel.Controls.Add(this.lvlChangeButton);
            this.altitudeFlowLayoutPanel.Controls.Add(this.holdButton);
            this.altitudeFlowLayoutPanel.Location = new System.Drawing.Point(-1, -35);
            this.altitudeFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.altitudeFlowLayoutPanel.Name = "altitudeFlowLayoutPanel";
            this.altitudeFlowLayoutPanel.Size = new System.Drawing.Size(715, 49);
            this.altitudeFlowLayoutPanel.TabIndex = 0;
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.Location = new System.Drawing.Point(10, 0);
            this.altitudeLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(106, 33);
            this.altitudeLabel.TabIndex = 0;
            this.altitudeLabel.Text = "Altitud&e";
            // 
            // altitudeTextBox
            // 
            this.altitudeTextBox.AccessibleName = "Altitude";
            this.altitudeTextBox.Location = new System.Drawing.Point(122, 3);
            this.altitudeTextBox.Name = "altitudeTextBox";
            this.altitudeTextBox.Size = new System.Drawing.Size(100, 40);
            this.altitudeTextBox.TabIndex = 1;
            this.altitudeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.altitudeTextBox_KeyDown);
            // 
            // interveneButton
            // 
            this.interveneButton.AccessibleName = "Intervene";
            this.interveneButton.AutoSize = true;
            this.interveneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.interveneButton.Location = new System.Drawing.Point(235, 3);
            this.interveneButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.interveneButton.Name = "interveneButton";
            this.interveneButton.Size = new System.Drawing.Size(126, 43);
            this.interveneButton.TabIndex = 2;
            this.interveneButton.Text = "&Intervene";
            this.interveneButton.UseVisualStyleBackColor = true;
            this.interveneButton.Click += new System.EventHandler(this.interveneButton_Click);
            // 
            // vNavButton
            // 
            this.vNavButton.AutoSize = true;
            this.vNavButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vNavButton.Location = new System.Drawing.Point(367, 3);
            this.vNavButton.Name = "vNavButton";
            this.vNavButton.Size = new System.Drawing.Size(111, 43);
            this.vNavButton.TabIndex = 3;
            this.vNavButton.Text = "button1";
            this.vNavButton.UseVisualStyleBackColor = true;
            this.vNavButton.Click += new System.EventHandler(this.vNavButton_Click);
            // 
            // lvlChangeButton
            // 
            this.lvlChangeButton.AutoSize = true;
            this.lvlChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lvlChangeButton.Location = new System.Drawing.Point(484, 3);
            this.lvlChangeButton.Name = "lvlChangeButton";
            this.lvlChangeButton.Size = new System.Drawing.Size(111, 43);
            this.lvlChangeButton.TabIndex = 4;
            this.lvlChangeButton.Text = "button1";
            this.lvlChangeButton.UseVisualStyleBackColor = true;
            this.lvlChangeButton.Click += new System.EventHandler(this.lvlChangeButton_Click);
            // 
            // holdButton
            // 
            this.holdButton.AutoSize = true;
            this.holdButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.holdButton.Location = new System.Drawing.Point(601, 3);
            this.holdButton.Name = "holdButton";
            this.holdButton.Size = new System.Drawing.Size(111, 43);
            this.holdButton.TabIndex = 5;
            this.holdButton.Text = "button1";
            this.holdButton.UseVisualStyleBackColor = true;
            this.holdButton.Click += new System.EventHandler(this.holdButton_Click);
            // 
            // AltitudeBox
            // 
            this.AccessibleName = "Altitude box";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(713, 13);
            this.Controls.Add(this.altitudeFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "AltitudeBox";
            this.Text = "Altitude box";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltitudeBox_FormClosing);
            this.Load += new System.EventHandler(this.AltitudeBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AltitudeBox_KeyDown);
            this.altitudeFlowLayoutPanel.ResumeLayout(false);
            this.altitudeFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel altitudeFlowLayoutPanel;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.TextBox altitudeTextBox;
        private System.Windows.Forms.Button interveneButton;
        private System.Windows.Forms.Button vNavButton;
        private System.Windows.Forms.Button lvlChangeButton;
        private System.Windows.Forms.Button holdButton;
    }
}