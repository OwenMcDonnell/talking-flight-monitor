namespace tfm.PMDG.PMDG_747.McpComponents
{
    partial class VerticalSpeedBox
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
            this.vsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.vsLabel = new System.Windows.Forms.Label();
            this.vsTextBox = new System.Windows.Forms.TextBox();
            this.vsButton = new System.Windows.Forms.Button();
            this.vsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsFlowLayoutPanel
            // 
            this.vsFlowLayoutPanel.AutoSize = true;
            this.vsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vsFlowLayoutPanel.Controls.Add(this.vsLabel);
            this.vsFlowLayoutPanel.Controls.Add(this.vsTextBox);
            this.vsFlowLayoutPanel.Controls.Add(this.vsButton);
            this.vsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.vsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.vsFlowLayoutPanel.Name = "vsFlowLayoutPanel";
            this.vsFlowLayoutPanel.Size = new System.Drawing.Size(381, 49);
            this.vsFlowLayoutPanel.TabIndex = 0;
            // 
            // vsLabel
            // 
            this.vsLabel.AutoSize = true;
            this.vsLabel.Location = new System.Drawing.Point(10, 0);
            this.vsLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.vsLabel.Name = "vsLabel";
            this.vsLabel.Size = new System.Drawing.Size(138, 33);
            this.vsLabel.TabIndex = 0;
            this.vsLabel.Text = "V&ert. speed";
            // 
            // vsTextBox
            // 
            this.vsTextBox.AccessibleName = "Vertical speed";
            this.vsTextBox.Location = new System.Drawing.Point(154, 3);
            this.vsTextBox.Name = "vsTextBox";
            this.vsTextBox.Size = new System.Drawing.Size(100, 40);
            this.vsTextBox.TabIndex = 1;
            this.vsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vsTextBox_KeyDown);
            // 
            // vsButton
            // 
            this.vsButton.AutoSize = true;
            this.vsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vsButton.Location = new System.Drawing.Point(267, 3);
            this.vsButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.vsButton.Name = "vsButton";
            this.vsButton.Size = new System.Drawing.Size(111, 43);
            this.vsButton.TabIndex = 2;
            this.vsButton.Text = "button1";
            this.vsButton.UseVisualStyleBackColor = true;
            this.vsButton.Click += new System.EventHandler(this.vsButton_Click);
            // 
            // VerticalSpeedBox
            // 
            this.AccessibleName = "Vertical speed box";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 742);
            this.Controls.Add(this.vsFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "VerticalSpeedBox";
            this.Text = "Vertical speed box";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerticalSpeedBox_FormClosing);
            this.Load += new System.EventHandler(this.VerticalSpeedBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VerticalSpeedBox_KeyDown);
            this.vsFlowLayoutPanel.ResumeLayout(false);
            this.vsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel vsFlowLayoutPanel;
        private System.Windows.Forms.Label vsLabel;
        private System.Windows.Forms.TextBox vsTextBox;
        private System.Windows.Forms.Button vsButton;
    }
}