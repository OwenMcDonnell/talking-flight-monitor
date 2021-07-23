
namespace tfm.PMDG.PMDG737.McpComponents
{
    partial class SpeedBox
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.speedButton = new System.Windows.Forms.Button();
            this.autoThrottleGroup = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoThrottleLButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.autoThrottleGroup.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.speedTextBox);
            this.flowLayoutPanel1.Controls.Add(this.speedButton);
            this.flowLayoutPanel1.Controls.Add(this.autoThrottleGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(615, 95);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // speedTextBox
            // 
            this.speedTextBox.AccessibleName = "Speed";
            this.speedTextBox.Location = new System.Drawing.Point(3, 3);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(100, 40);
            this.speedTextBox.TabIndex = 0;
            this.speedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.speedTextBox_KeyDown);
            // 
            // speedButton
            // 
            this.speedButton.AccessibleName = "Speed";
            this.speedButton.AutoSize = true;
            this.speedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.speedButton.Location = new System.Drawing.Point(109, 3);
            this.speedButton.Name = "speedButton";
            this.speedButton.Size = new System.Drawing.Size(88, 43);
            this.speedButton.TabIndex = 2;
            this.speedButton.Text = "&speed";
            this.speedButton.UseVisualStyleBackColor = true;
            this.speedButton.Click += new System.EventHandler(this.speedButton_Click);
            // 
            // autoThrottleGroup
            // 
            this.autoThrottleGroup.AccessibleName = "Autothrottle";
            this.autoThrottleGroup.AutoSize = true;
            this.autoThrottleGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.autoThrottleGroup.Controls.Add(this.flowLayoutPanel2);
            this.autoThrottleGroup.Location = new System.Drawing.Point(203, 3);
            this.autoThrottleGroup.Name = "autoThrottleGroup";
            this.autoThrottleGroup.Size = new System.Drawing.Size(51, 88);
            this.autoThrottleGroup.TabIndex = 3;
            this.autoThrottleGroup.TabStop = false;
            this.autoThrottleGroup.Text = "Autothrottle";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.autoThrottleLButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(45, 49);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // autoThrottleLButton
            // 
            this.autoThrottleLButton.AccessibleName = "Left";
            this.autoThrottleLButton.AutoSize = true;
            this.autoThrottleLButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.autoThrottleLButton.Location = new System.Drawing.Point(3, 3);
            this.autoThrottleLButton.Name = "autoThrottleLButton";
            this.autoThrottleLButton.Size = new System.Drawing.Size(39, 43);
            this.autoThrottleLButton.TabIndex = 0;
            this.autoThrottleLButton.Text = "q";
            this.autoThrottleLButton.UseVisualStyleBackColor = true;
            this.autoThrottleLButton.Click += new System.EventHandler(this.autoThrottleLButton_Click);
            // 
            // SpeedBox
            // 
            this.AccessibleName = "Speed box";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(615, 95);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SpeedBox";
            this.Text = "Speed box";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpeedBox_FormClosing);
            this.Load += new System.EventHandler(this.SpeedBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpeedBox_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.autoThrottleGroup.ResumeLayout(false);
            this.autoThrottleGroup.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Button speedButton;
        private System.Windows.Forms.GroupBox autoThrottleGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button autoThrottleLButton;
    }
}