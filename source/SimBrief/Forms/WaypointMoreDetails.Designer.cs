namespace tfm.SimBrief.Forms
{
    partial class WaypointMoreDetails
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
            this.waypointDetailsTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // waypointDetailsTextBox
            // 
            this.waypointDetailsTextBox.Location = new System.Drawing.Point(-11, 0);
            this.waypointDetailsTextBox.MaximumSize = new System.Drawing.Size(800, 700);
            this.waypointDetailsTextBox.Multiline = true;
            this.waypointDetailsTextBox.Name = "waypointDetailsTextBox";
            this.waypointDetailsTextBox.ReadOnly = true;
            this.waypointDetailsTextBox.Size = new System.Drawing.Size(800, 700);
            this.waypointDetailsTextBox.TabIndex = 0;
            this.waypointDetailsTextBox.Enter += new System.EventHandler(this.waypointDetailsTextBox_Enter);
            // 
            // closeButton
            // 
            this.closeButton.AccessibleName = "Close";
            this.closeButton.AutoSize = true;
            this.closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.closeButton.Location = new System.Drawing.Point(345, 706);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(89, 43);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // WaypointMoreDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.waypointDetailsTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimizeBox = false;
            this.Name = "WaypointMoreDetails";
            this.Text = "WaypointMoreDetails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WaypointMoreDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox waypointDetailsTextBox;
        private System.Windows.Forms.Button closeButton;
    }
}