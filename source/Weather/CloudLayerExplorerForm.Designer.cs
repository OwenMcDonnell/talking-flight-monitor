namespace tfm.Weather
{
    partial class CloudLayerExplorerForm
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
            this.cloudLayersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cloudLayersListBox
            // 
            this.cloudLayersListBox.AccessibleName = "Cloud layers";
            this.cloudLayersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cloudLayersListBox.FormattingEnabled = true;
            this.cloudLayersListBox.ItemHeight = 33;
            this.cloudLayersListBox.Location = new System.Drawing.Point(0, 0);
            this.cloudLayersListBox.Name = "cloudLayersListBox";
            this.cloudLayersListBox.Size = new System.Drawing.Size(478, 444);
            this.cloudLayersListBox.TabIndex = 0;
            // 
            // CloudLayerExplorerForm
            // 
            this.AccessibleName = "Cloud layer explorer";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.cloudLayersListBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.Name = "CloudLayerExplorerForm";
            this.Text = "Cloud layer explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CloudLayerExplorerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox cloudLayersListBox;
    }
}