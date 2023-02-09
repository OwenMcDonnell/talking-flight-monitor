namespace tfm.Weather
{
    partial class ctlWindLayers
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
            this.windLayersListBox = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // windLayersListBox
            // 
            this.windLayersListBox.AccessibleName = "Wind layers";
            this.windLayersListBox.FormattingEnabled = true;
            this.windLayersListBox.ItemHeight = 33;
            this.windLayersListBox.Location = new System.Drawing.Point(0, 0);
            this.windLayersListBox.Name = "windLayersListBox";
            this.windLayersListBox.Size = new System.Drawing.Size(600, 598);
            this.windLayersListBox.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.AccessibleName = "Refresh wind layers.";
            this.refreshButton.AutoSize = true;
            this.refreshButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshButton.Location = new System.Drawing.Point(246, 613);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(111, 43);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ctlWindLayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.windLayersListBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlWindLayers";
            this.Size = new System.Drawing.Size(603, 659);
            this.Load += new System.EventHandler(this.ctlWindLayers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox windLayersListBox;
        private System.Windows.Forms.Button refreshButton;
    }
}
