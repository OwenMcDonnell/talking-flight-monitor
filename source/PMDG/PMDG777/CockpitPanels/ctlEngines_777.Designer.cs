namespace tfm
{
    partial class ctlEngines_777
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEng1Start = new System.Windows.Forms.Button();
            this.btnEng1Fuel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEng2Start = new System.Windows.Forms.Button();
            this.btnEng2Fuel = new System.Windows.Forms.Button();
            this.tmrEngines = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnEng1Start);
            this.flowLayoutPanel2.Controls.Add(this.btnEng1Fuel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnEng1Start
            // 
            this.btnEng1Start.Location = new System.Drawing.Point(3, 3);
            this.btnEng1Start.Name = "btnEng1Start";
            this.btnEng1Start.Size = new System.Drawing.Size(75, 23);
            this.btnEng1Start.TabIndex = 0;
            this.btnEng1Start.Text = "Engine 1 Ignition";
            this.btnEng1Start.UseVisualStyleBackColor = true;
            this.btnEng1Start.Click += new System.EventHandler(this.btnEng1Start_Click);
            // 
            // btnEng1Fuel
            // 
            this.btnEng1Fuel.Location = new System.Drawing.Point(84, 3);
            this.btnEng1Fuel.Name = "btnEng1Fuel";
            this.btnEng1Fuel.Size = new System.Drawing.Size(75, 23);
            this.btnEng1Fuel.TabIndex = 2;
            this.btnEng1Fuel.Text = "Engine 1 fuel";
            this.btnEng1Fuel.UseVisualStyleBackColor = true;
            this.btnEng1Fuel.Click += new System.EventHandler(this.btnEng1Fuel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnEng2Start);
            this.flowLayoutPanel3.Controls.Add(this.btnEng2Fuel);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnEng2Start
            // 
            this.btnEng2Start.Location = new System.Drawing.Point(3, 3);
            this.btnEng2Start.Name = "btnEng2Start";
            this.btnEng2Start.Size = new System.Drawing.Size(75, 23);
            this.btnEng2Start.TabIndex = 4;
            this.btnEng2Start.Text = "Engine 2 Start";
            this.btnEng2Start.UseVisualStyleBackColor = true;
            this.btnEng2Start.Click += new System.EventHandler(this.btnEng2Start_Click);
            // 
            // btnEng2Fuel
            // 
            this.btnEng2Fuel.Location = new System.Drawing.Point(84, 3);
            this.btnEng2Fuel.Name = "btnEng2Fuel";
            this.btnEng2Fuel.Size = new System.Drawing.Size(75, 23);
            this.btnEng2Fuel.TabIndex = 5;
            this.btnEng2Fuel.Text = "Engine 2 Fuel";
            this.btnEng2Fuel.UseVisualStyleBackColor = true;
            this.btnEng2Fuel.Click += new System.EventHandler(this.btnEng2Fuel_Click);
            // 
            // tmrEngines
            // 
            this.tmrEngines.Interval = 1000;
            this.tmrEngines.Tick += new System.EventHandler(this.tmrEngines_Tick);
            // 
            // ctlEngines_777
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ctlEngines_777";
            this.Load += new System.EventHandler(this.ctlEngines_777_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnEng1Start;
        private System.Windows.Forms.Button btnEng1Fuel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnEng2Start;
        private System.Windows.Forms.Button btnEng2Fuel;
        private System.Windows.Forms.Timer tmrEngines;
    }
}
