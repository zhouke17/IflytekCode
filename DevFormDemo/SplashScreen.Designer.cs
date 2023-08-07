
namespace DevFormDemo
{
    partial class MySplashScreen
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
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(125, 267);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(424, 15);
            this.marqueeProgressBarControl1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DevFormDemo.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(215, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 223);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MySplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 369);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Name = "MySplashScreen";
            this.Text = "SplashScreen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
    }
}