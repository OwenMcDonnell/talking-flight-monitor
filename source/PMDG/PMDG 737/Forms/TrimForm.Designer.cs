namespace tfm.PMDG.PMDG_737.Forms
{
    partial class TrimForm
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
            this.trimFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.trimWheelLabel = new System.Windows.Forms.Label();
            this.trimTextBox = new System.Windows.Forms.TextBox();
            this.trimElectricalButton = new System.Windows.Forms.Button();
            this.trimAutopilotButton = new System.Windows.Forms.Button();
            this.stabTrimButton = new System.Windows.Forms.Button();
            this.trimFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trimFlowLayoutPanel
            // 
            this.trimFlowLayoutPanel.AutoSize = true;
            this.trimFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trimFlowLayoutPanel.Controls.Add(this.trimWheelLabel);
            this.trimFlowLayoutPanel.Controls.Add(this.trimTextBox);
            this.trimFlowLayoutPanel.Controls.Add(this.trimElectricalButton);
            this.trimFlowLayoutPanel.Controls.Add(this.trimAutopilotButton);
            this.trimFlowLayoutPanel.Controls.Add(this.stabTrimButton);
            this.trimFlowLayoutPanel.Location = new System.Drawing.Point(-8, -42);
            this.trimFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.trimFlowLayoutPanel.Name = "trimFlowLayoutPanel";
            this.trimFlowLayoutPanel.Size = new System.Drawing.Size(544, 49);
            this.trimFlowLayoutPanel.TabIndex = 1;
            // 
            // trimWheelLabel
            // 
            this.trimWheelLabel.AutoSize = true;
            this.trimWheelLabel.Location = new System.Drawing.Point(10, 0);
            this.trimWheelLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.trimWheelLabel.Name = "trimWheelLabel";
            this.trimWheelLabel.Size = new System.Drawing.Size(67, 33);
            this.trimWheelLabel.TabIndex = 0;
            this.trimWheelLabel.Text = "&Trim";
            // 
            // trimTextBox
            // 
            this.trimTextBox.AccessibleName = "Elevator trim";
            this.trimTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.trimTextBox.Location = new System.Drawing.Point(83, 3);
            this.trimTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.trimTextBox.Name = "trimTextBox";
            this.trimTextBox.ReadOnly = true;
            this.trimTextBox.Size = new System.Drawing.Size(100, 40);
            this.trimTextBox.TabIndex = 1;
            this.trimTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.trimTextBox.Enter += new System.EventHandler(this.trimTextBox_Enter);
            this.trimTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trimTextBox_KeyDown);
            // 
            // trimElectricalButton
            // 
            this.trimElectricalButton.AutoSize = true;
            this.trimElectricalButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trimElectricalButton.Location = new System.Drawing.Point(196, 3);
            this.trimElectricalButton.Name = "trimElectricalButton";
            this.trimElectricalButton.Size = new System.Drawing.Size(111, 43);
            this.trimElectricalButton.TabIndex = 2;
            this.trimElectricalButton.Text = "button1";
            this.trimElectricalButton.UseVisualStyleBackColor = true;
            this.trimElectricalButton.Click += new System.EventHandler(this.trimElectricalButton_Click);
            // 
            // trimAutopilotButton
            // 
            this.trimAutopilotButton.AutoSize = true;
            this.trimAutopilotButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trimAutopilotButton.Location = new System.Drawing.Point(313, 3);
            this.trimAutopilotButton.Name = "trimAutopilotButton";
            this.trimAutopilotButton.Size = new System.Drawing.Size(111, 43);
            this.trimAutopilotButton.TabIndex = 3;
            this.trimAutopilotButton.Text = "button1";
            this.trimAutopilotButton.UseVisualStyleBackColor = true;
            this.trimAutopilotButton.Click += new System.EventHandler(this.trimAutopilotButton_Click);
            // 
            // stabTrimButton
            // 
            this.stabTrimButton.AutoSize = true;
            this.stabTrimButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stabTrimButton.Location = new System.Drawing.Point(430, 3);
            this.stabTrimButton.Name = "stabTrimButton";
            this.stabTrimButton.Size = new System.Drawing.Size(111, 43);
            this.stabTrimButton.TabIndex = 4;
            this.stabTrimButton.Text = "button1";
            this.stabTrimButton.UseVisualStyleBackColor = true;
            this.stabTrimButton.Click += new System.EventHandler(this.stabTrimButton_Click);
            // 
            // TrimForm
            // 
            this.AccessibleName = "Trim";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(528, 0);
            this.Controls.Add(this.trimFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "TrimForm";
            this.Text = "Trim";
            this.Load += new System.EventHandler(this.TrimForm_Load);
            this.trimFlowLayoutPanel.ResumeLayout(false);
            this.trimFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel trimFlowLayoutPanel;
        private System.Windows.Forms.Label trimWheelLabel;
        private System.Windows.Forms.TextBox trimTextBox;
        private System.Windows.Forms.Button trimElectricalButton;
        private System.Windows.Forms.Button trimAutopilotButton;
        private System.Windows.Forms.Button stabTrimButton;
    }
}