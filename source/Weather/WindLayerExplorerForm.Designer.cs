namespace tfm.Weather
{
    partial class WindLayerExplorerForm
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
            this.windLayersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // windLayersListBox
            // 
            this.windLayersListBox.AccessibleName = "Wind layers";
            this.windLayersListBox.ColumnWidth = 500;
            this.windLayersListBox.FormattingEnabled = true;
            this.windLayersListBox.ItemHeight = 33;
            this.windLayersListBox.Location = new System.Drawing.Point(-11, -45);
            this.windLayersListBox.Name = "windLayersListBox";
            this.windLayersListBox.Size = new System.Drawing.Size(500, 499);
            this.windLayersListBox.TabIndex = 0;
            // 
            // WindLayerExplorerForm
            // 
            this.AccessibleName = "Wind layer explorer";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.windLayersListBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "WindLayerExplorerForm";
            this.Text = "Wind layer explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WindLayerExplorerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox windLayersListBox;
    }
}