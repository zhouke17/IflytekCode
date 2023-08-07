
namespace HWUG
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_End = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 450);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(119, 336);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(95, 37);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "开始签字";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(580, 341);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(93, 32);
            this.btn_End.TabIndex = 2;
            this.btn_End.Text = "结束签字";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_End;
    }
}

