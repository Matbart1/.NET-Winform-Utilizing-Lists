namespace No_Direction_Project
{
    partial class Form1
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
            this.lblBounce = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tkbWidth = new System.Windows.Forms.TrackBar();
            this.tkbHeight = new System.Windows.Forms.TrackBar();
            this.lblwidth = new System.Windows.Forms.Label();
            this.lblheight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tkbWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBounce
            // 
            this.lblBounce.AutoSize = true;
            this.lblBounce.Location = new System.Drawing.Point(33, 28);
            this.lblBounce.Name = "lblBounce";
            this.lblBounce.Size = new System.Drawing.Size(138, 13);
            this.lblBounce.TabIndex = 1;
            this.lblBounce.Text = "Number of total bounces : 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zero Guidance Program";
            // 
            // tkbWidth
            // 
            this.tkbWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tkbWidth.LargeChange = 1;
            this.tkbWidth.Location = new System.Drawing.Point(7, 74);
            this.tkbWidth.Maximum = 5;
            this.tkbWidth.Minimum = 1;
            this.tkbWidth.Name = "tkbWidth";
            this.tkbWidth.Size = new System.Drawing.Size(191, 45);
            this.tkbWidth.TabIndex = 3;
            this.tkbWidth.Value = 1;
            // 
            // tkbHeight
            // 
            this.tkbHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tkbHeight.LargeChange = 1;
            this.tkbHeight.Location = new System.Drawing.Point(7, 163);
            this.tkbHeight.Maximum = 5;
            this.tkbHeight.Minimum = 1;
            this.tkbHeight.Name = "tkbHeight";
            this.tkbHeight.Size = new System.Drawing.Size(191, 45);
            this.tkbHeight.TabIndex = 4;
            this.tkbHeight.Value = 1;
            // 
            // lblwidth
            // 
            this.lblwidth.AutoSize = true;
            this.lblwidth.Location = new System.Drawing.Point(13, 55);
            this.lblwidth.Name = "lblwidth";
            this.lblwidth.Size = new System.Drawing.Size(99, 13);
            this.lblwidth.TabIndex = 5;
            this.lblwidth.Text = "Rectangle Width: 1";
            // 
            // lblheight
            // 
            this.lblheight.AutoSize = true;
            this.lblheight.Location = new System.Drawing.Point(10, 147);
            this.lblheight.Name = "lblheight";
            this.lblheight.Size = new System.Drawing.Size(102, 13);
            this.lblheight.TabIndex = 6;
            this.lblheight.Text = "Rectangle Height: 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(204, 228);
            this.Controls.Add(this.lblheight);
            this.Controls.Add(this.lblwidth);
            this.Controls.Add(this.tkbHeight);
            this.Controls.Add(this.tkbWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBounce);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tkbWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBounce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tkbWidth;
        private System.Windows.Forms.TrackBar tkbHeight;
        private System.Windows.Forms.Label lblwidth;
        private System.Windows.Forms.Label lblheight;
    }
}

