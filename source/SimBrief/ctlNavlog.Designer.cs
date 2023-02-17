namespace tfm.SimBrief
{
    partial class ctlNavlog
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
            this.navlogListView = new System.Windows.Forms.ListView();
            this.identColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.distanceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.altitudeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // navlogListView
            // 
            this.navlogListView.AccessibleName = "Navlog";
            this.navlogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.identColumnHeader,
            this.typeColumnHeader,
            this.nameColumnHeader,
            this.distanceColumnHeader,
            this.altitudeColumnHeader});
            this.navlogListView.HideSelection = false;
            this.navlogListView.Location = new System.Drawing.Point(0, 0);
            this.navlogListView.Name = "navlogListView";
            this.navlogListView.Size = new System.Drawing.Size(1100, 667);
            this.navlogListView.TabIndex = 0;
            this.navlogListView.UseCompatibleStateImageBehavior = false;
            this.navlogListView.View = System.Windows.Forms.View.Details;
            // 
            // identColumnHeader
            // 
            this.identColumnHeader.Text = "Ident";
            this.identColumnHeader.Width = 100;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.DisplayIndex = 1;
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 100;
            // 
            // distanceColumnHeader
            // 
            this.distanceColumnHeader.DisplayIndex = 2;
            this.distanceColumnHeader.Text = "Distance";
            this.distanceColumnHeader.Width = 100;
            // 
            // altitudeColumnHeader
            // 
            this.altitudeColumnHeader.DisplayIndex = 3;
            this.altitudeColumnHeader.Text = "Altitude";
            this.altitudeColumnHeader.Width = 100;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.DisplayIndex = 0;
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 100;
            // 
            // ctlNavlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.navlogListView);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlNavlog";
            this.Size = new System.Drawing.Size(1103, 670);
            this.Load += new System.EventHandler(this.ctlNavlog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView navlogListView;
        private System.Windows.Forms.ColumnHeader identColumnHeader;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader distanceColumnHeader;
        private System.Windows.Forms.ColumnHeader altitudeColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
    }
}
