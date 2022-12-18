namespace tfm.PMDG.PMDG_737.CockpitPanels.ControlStand
{
    partial class ctlXponder
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
            this.transponderFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.transponderCodeLabel = new System.Windows.Forms.Label();
            this.transponderCodeTextBox = new System.Windows.Forms.TextBox();
            this.sourceButton = new System.Windows.Forms.Button();
            this.altSourceButton = new System.Windows.Forms.Button();
            this.modeButton = new System.Windows.Forms.Button();
            this.identButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.transponderFailLabel = new System.Windows.Forms.Label();
            this.transponderFailTextBox = new System.Windows.Forms.TextBox();
            this.transponderFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // transponderFlowLayoutPanel
            // 
            this.transponderFlowLayoutPanel.AutoSize = true;
            this.transponderFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transponderFlowLayoutPanel.Controls.Add(this.transponderCodeLabel);
            this.transponderFlowLayoutPanel.Controls.Add(this.transponderCodeTextBox);
            this.transponderFlowLayoutPanel.Controls.Add(this.sourceButton);
            this.transponderFlowLayoutPanel.Controls.Add(this.altSourceButton);
            this.transponderFlowLayoutPanel.Controls.Add(this.modeButton);
            this.transponderFlowLayoutPanel.Controls.Add(this.identButton);
            this.transponderFlowLayoutPanel.Controls.Add(this.testButton);
            this.transponderFlowLayoutPanel.Controls.Add(this.transponderFailLabel);
            this.transponderFlowLayoutPanel.Controls.Add(this.transponderFailTextBox);
            this.transponderFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.transponderFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.transponderFlowLayoutPanel.Name = "transponderFlowLayoutPanel";
            this.transponderFlowLayoutPanel.Size = new System.Drawing.Size(1140, 49);
            this.transponderFlowLayoutPanel.TabIndex = 0;
            // 
            // transponderCodeLabel
            // 
            this.transponderCodeLabel.AutoSize = true;
            this.transponderCodeLabel.Location = new System.Drawing.Point(10, 0);
            this.transponderCodeLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.transponderCodeLabel.Name = "transponderCodeLabel";
            this.transponderCodeLabel.Size = new System.Drawing.Size(157, 33);
            this.transponderCodeLabel.TabIndex = 0;
            this.transponderCodeLabel.Text = "Xpnder cod&e";
            // 
            // transponderCodeTextBox
            // 
            this.transponderCodeTextBox.AccessibleName = "Transponder code";
            this.transponderCodeTextBox.Location = new System.Drawing.Point(173, 3);
            this.transponderCodeTextBox.Name = "transponderCodeTextBox";
            this.transponderCodeTextBox.Size = new System.Drawing.Size(150, 40);
            this.transponderCodeTextBox.TabIndex = 1;
            this.transponderCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.transponderCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.transponderCodeTextBox_KeyDown);
            // 
            // sourceButton
            // 
            this.sourceButton.AutoSize = true;
            this.sourceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sourceButton.Location = new System.Drawing.Point(346, 3);
            this.sourceButton.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(111, 43);
            this.sourceButton.TabIndex = 2;
            this.sourceButton.Text = "button1";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // altSourceButton
            // 
            this.altSourceButton.AutoSize = true;
            this.altSourceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.altSourceButton.Location = new System.Drawing.Point(463, 3);
            this.altSourceButton.Name = "altSourceButton";
            this.altSourceButton.Size = new System.Drawing.Size(111, 43);
            this.altSourceButton.TabIndex = 3;
            this.altSourceButton.Text = "button2";
            this.altSourceButton.UseVisualStyleBackColor = true;
            this.altSourceButton.Click += new System.EventHandler(this.altSourceButton_Click);
            // 
            // modeButton
            // 
            this.modeButton.AutoSize = true;
            this.modeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.modeButton.Location = new System.Drawing.Point(580, 3);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(111, 43);
            this.modeButton.TabIndex = 4;
            this.modeButton.Text = "button3";
            this.modeButton.UseVisualStyleBackColor = true;
            this.modeButton.Click += new System.EventHandler(this.modeButton_Click);
            // 
            // identButton
            // 
            this.identButton.AccessibleName = "Ident";
            this.identButton.AutoSize = true;
            this.identButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.identButton.Location = new System.Drawing.Point(697, 3);
            this.identButton.Name = "identButton";
            this.identButton.Size = new System.Drawing.Size(81, 43);
            this.identButton.TabIndex = 5;
            this.identButton.Text = "&Ident";
            this.identButton.UseVisualStyleBackColor = true;
            this.identButton.Click += new System.EventHandler(this.identButton_Click);
            // 
            // testButton
            // 
            this.testButton.AccessibleName = "Test";
            this.testButton.AutoSize = true;
            this.testButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.testButton.Location = new System.Drawing.Point(784, 3);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(70, 43);
            this.testButton.TabIndex = 6;
            this.testButton.Text = "&Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // transponderFailLabel
            // 
            this.transponderFailLabel.AutoSize = true;
            this.transponderFailLabel.Location = new System.Drawing.Point(877, 0);
            this.transponderFailLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.transponderFailLabel.Name = "transponderFailLabel";
            this.transponderFailLabel.Size = new System.Drawing.Size(164, 33);
            this.transponderFailLabel.TabIndex = 7;
            this.transponderFailLabel.Text = "&1. xpnder fail";
            // 
            // transponderFailTextBox
            // 
            this.transponderFailTextBox.AccessibleName = "Transponder failure";
            this.transponderFailTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.transponderFailTextBox.Location = new System.Drawing.Point(1047, 3);
            this.transponderFailTextBox.Name = "transponderFailTextBox";
            this.transponderFailTextBox.ReadOnly = true;
            this.transponderFailTextBox.Size = new System.Drawing.Size(90, 40);
            this.transponderFailTextBox.TabIndex = 8;
            this.transponderFailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlXponder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.transponderFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlXponder";
            this.Size = new System.Drawing.Size(1146, 55);
            this.Load += new System.EventHandler(this.ctlXponder_Load);
            this.transponderFlowLayoutPanel.ResumeLayout(false);
            this.transponderFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel transponderFlowLayoutPanel;
        private System.Windows.Forms.Label transponderCodeLabel;
        private System.Windows.Forms.TextBox transponderCodeTextBox;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.Button altSourceButton;
        private System.Windows.Forms.Button modeButton;
        private System.Windows.Forms.Button identButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label transponderFailLabel;
        private System.Windows.Forms.TextBox transponderFailTextBox;
    }
}
