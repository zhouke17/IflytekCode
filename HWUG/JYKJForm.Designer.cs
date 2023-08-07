
namespace HWUG
{
    partial class JYKJForm
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
            this.btn_signature = new System.Windows.Forms.Button();
            this.btn_finger = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btn_Init = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_sign = new System.Windows.Forms.Button();
            this.btn_Capture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_signature
            // 
            this.btn_signature.Location = new System.Drawing.Point(150, 323);
            this.btn_signature.Name = "btn_signature";
            this.btn_signature.Size = new System.Drawing.Size(100, 40);
            this.btn_signature.TabIndex = 0;
            this.btn_signature.Text = "开启签名版";
            this.btn_signature.UseVisualStyleBackColor = true;
            this.btn_signature.Click += new System.EventHandler(this.btn_signature_Click);
            // 
            // btn_finger
            // 
            this.btn_finger.Location = new System.Drawing.Point(552, 323);
            this.btn_finger.Name = "btn_finger";
            this.btn_finger.Size = new System.Drawing.Size(100, 40);
            this.btn_finger.TabIndex = 1;
            this.btn_finger.Text = "开启指纹仪";
            this.btn_finger.UseVisualStyleBackColor = true;
            this.btn_finger.Click += new System.EventHandler(this.btn_finger_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(155, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 250);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // btn_Init
            // 
            this.btn_Init.Location = new System.Drawing.Point(339, 323);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(100, 40);
            this.btn_Init.TabIndex = 3;
            this.btn_Init.Text = "授权初始化";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(339, 398);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 40);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_sign
            // 
            this.btn_sign.Location = new System.Drawing.Point(150, 398);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(100, 40);
            this.btn_sign.TabIndex = 5;
            this.btn_sign.Text = "签字画押";
            this.btn_sign.UseVisualStyleBackColor = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(552, 398);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(100, 40);
            this.btn_Capture.TabIndex = 6;
            this.btn_Capture.Text = "更换屏保页";
            this.btn_Capture.UseVisualStyleBackColor = true;
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // JYKJForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Capture);
            this.Controls.Add(this.btn_sign);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btn_finger);
            this.Controls.Add(this.btn_signature);
            this.Name = "JYKJForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JYKJForm";
            this.Load += new System.EventHandler(this.JYKJForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_signature;
        private System.Windows.Forms.Button btn_finger;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_sign;
        private System.Windows.Forms.Button btn_Capture;
    }
}