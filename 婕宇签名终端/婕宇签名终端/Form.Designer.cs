namespace 婕宇签名终端
{
    partial class Form
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
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_Sign = new System.Windows.Forms.Button();
            this.btn_SignFinger = new System.Windows.Forms.Button();
            this.btn_ReadIDCard = new System.Windows.Forms.Button();
            this.btn_FaceComparison = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.ip_txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ESign = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(47, 89);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "打开设备";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_Sign
            // 
            this.btn_Sign.Location = new System.Drawing.Point(172, 89);
            this.btn_Sign.Name = "btn_Sign";
            this.btn_Sign.Size = new System.Drawing.Size(75, 23);
            this.btn_Sign.TabIndex = 1;
            this.btn_Sign.Text = "签字";
            this.btn_Sign.UseVisualStyleBackColor = true;
            this.btn_Sign.Click += new System.EventHandler(this.btn_Sign_Click);
            // 
            // btn_SignFinger
            // 
            this.btn_SignFinger.Location = new System.Drawing.Point(321, 89);
            this.btn_SignFinger.Name = "btn_SignFinger";
            this.btn_SignFinger.Size = new System.Drawing.Size(75, 23);
            this.btn_SignFinger.TabIndex = 3;
            this.btn_SignFinger.Text = "签名按捺";
            this.btn_SignFinger.UseVisualStyleBackColor = true;
            this.btn_SignFinger.Click += new System.EventHandler(this.btn_SignFinger_Click);
            // 
            // btn_ReadIDCard
            // 
            this.btn_ReadIDCard.Location = new System.Drawing.Point(459, 89);
            this.btn_ReadIDCard.Name = "btn_ReadIDCard";
            this.btn_ReadIDCard.Size = new System.Drawing.Size(75, 23);
            this.btn_ReadIDCard.TabIndex = 4;
            this.btn_ReadIDCard.Text = "读取身份证";
            this.btn_ReadIDCard.UseVisualStyleBackColor = true;
            this.btn_ReadIDCard.Click += new System.EventHandler(this.btn_ReadIDCard_Click);
            // 
            // btn_FaceComparison
            // 
            this.btn_FaceComparison.Location = new System.Drawing.Point(584, 89);
            this.btn_FaceComparison.Name = "btn_FaceComparison";
            this.btn_FaceComparison.Size = new System.Drawing.Size(75, 23);
            this.btn_FaceComparison.TabIndex = 5;
            this.btn_FaceComparison.Text = "人脸比对";
            this.btn_FaceComparison.UseVisualStyleBackColor = true;
            this.btn_FaceComparison.Click += new System.EventHandler(this.btn_FaceComparison_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(104, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 181);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "设置IP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(172, 199);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 16);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "USB";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(237, 199);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "网线";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // ip_txt
            // 
            this.ip_txt.Location = new System.Drawing.Point(352, 194);
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(100, 21);
            this.ip_txt.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "当前模式";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ESign
            // 
            this.btn_ESign.Location = new System.Drawing.Point(172, 136);
            this.btn_ESign.Name = "btn_ESign";
            this.btn_ESign.Size = new System.Drawing.Size(87, 23);
            this.btn_ESign.TabIndex = 12;
            this.btn_ESign.Text = "电子签名";
            this.btn_ESign.UseVisualStyleBackColor = true;
            this.btn_ESign.Click += new System.EventHandler(this.btn_ESign_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ESign);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ip_txt);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_FaceComparison);
            this.Controls.Add(this.btn_ReadIDCard);
            this.Controls.Add(this.btn_SignFinger);
            this.Controls.Add(this.btn_Sign);
            this.Controls.Add(this.btn_open);
            this.Name = "Form";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_Sign;
        private System.Windows.Forms.Button btn_SignFinger;
        private System.Windows.Forms.Button btn_ReadIDCard;
        private System.Windows.Forms.Button btn_FaceComparison;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox ip_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ESign;
    }
}

