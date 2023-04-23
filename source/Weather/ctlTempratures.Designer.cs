namespace tfm.Weather
{
    partial class ctlTempratures
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
            this.tempratureZonesListBox = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tempratureZonesListBox
            // 
            this.tempratureZonesListBox.AccessibleName = "Temprature zones";
            this.tempratureZonesListBox.FormattingEnabled = true;
            this.tempratureZonesListBox.ItemHeight = 33;
            this.tempratureZonesListBox.Location = new System.Drawing.Point(0, 0);
            this.tempratureZonesListBox.Name = "tempratureZonesListBox";
            this.tempratureZonesListBox.Size = new System.Drawing.Size(600, 598);
            this.tempratureZonesListBox.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.AccessibleName = "Refresh temprature zones.";
            this.refreshButton.AutoSize = true;
            this.refreshButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshButton.Location = new System.Drawing.Point(246, 606);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(111, 43);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ctlTempratures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.tempratureZonesListBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlTempratures";
            this.Size = new System.Drawing.Size(603, 652);
            this.Load += new System.EventHandler(this.ctlTempratures_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox tempratureZonesListBox;
        private System.Windows.Forms.Button refreshButton;
    }
}
