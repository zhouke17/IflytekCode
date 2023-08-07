namespace WinFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.发送邮件 = new System.Windows.Forms.Button();
            this.截取屏幕 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.课程选修的人数 = new System.Windows.Forms.Button();
            this.选课数量 = new System.Windows.Forms.Button();
            this.所有及格的课程对应的人 = new System.Windows.Forms.Button();
            this.大于18岁的人 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 74);
            this.panel2.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "执行异步委托";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(32, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(177, 44);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(389, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 78);
            this.panel3.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(282, 25);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 44);
            this.button5.TabIndex = 2;
            this.button5.Text = "委托ShowDialog";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(151, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 44);
            this.button4.TabIndex = 1;
            this.button4.Text = "ShowDialog()";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 44);
            this.button3.TabIndex = 0;
            this.button3.Text = "Show()";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(123, 39);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(143, 37);
            this.button12.TabIndex = 6;
            this.button12.Text = "AutoUpdaterDotNET更新";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 39);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(95, 37);
            this.button13.TabIndex = 9;
            this.button13.Text = "原有更新";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(287, 39);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(124, 37);
            this.button14.TabIndex = 10;
            this.button14.Text = "NAppUpdate更新";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Controls.Add(this.发送邮件);
            this.groupBox2.Controls.Add(this.截取屏幕);
            this.groupBox2.Location = new System.Drawing.Point(2, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "lock死锁";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(243, 10);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(218, 90);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // 发送邮件
            // 
            this.发送邮件.Location = new System.Drawing.Point(134, 29);
            this.发送邮件.Name = "发送邮件";
            this.发送邮件.Size = new System.Drawing.Size(75, 23);
            this.发送邮件.TabIndex = 1;
            this.发送邮件.Text = "异步线程";
            this.发送邮件.UseVisualStyleBackColor = true;
            this.发送邮件.Click += new System.EventHandler(this.异步线程_Click);
            // 
            // 截取屏幕
            // 
            this.截取屏幕.Location = new System.Drawing.Point(12, 29);
            this.截取屏幕.Name = "截取屏幕";
            this.截取屏幕.Size = new System.Drawing.Size(91, 23);
            this.截取屏幕.TabIndex = 0;
            this.截取屏幕.Text = "主线程";
            this.截取屏幕.UseVisualStyleBackColor = true;
            this.截取屏幕.Click += new System.EventHandler(this.主线程_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.课程选修的人数);
            this.groupBox3.Controls.Add(this.选课数量);
            this.groupBox3.Controls.Add(this.所有及格的课程对应的人);
            this.groupBox3.Controls.Add(this.大于18岁的人);
            this.groupBox3.Location = new System.Drawing.Point(2, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 153);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Linq";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(125, 23);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 4;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // 课程选修的人数
            // 
            this.课程选修的人数.Location = new System.Drawing.Point(12, 130);
            this.课程选修的人数.Name = "课程选修的人数";
            this.课程选修的人数.Size = new System.Drawing.Size(75, 23);
            this.课程选修的人数.TabIndex = 3;
            this.课程选修的人数.Text = "课程选修的人数";
            this.课程选修的人数.UseVisualStyleBackColor = true;
            this.课程选修的人数.Click += new System.EventHandler(this.课程选修的人数_Click);
            // 
            // 选课数量
            // 
            this.选课数量.Location = new System.Drawing.Point(12, 93);
            this.选课数量.Name = "选课数量";
            this.选课数量.Size = new System.Drawing.Size(75, 23);
            this.选课数量.TabIndex = 2;
            this.选课数量.Text = "选课数量";
            this.选课数量.UseVisualStyleBackColor = true;
            this.选课数量.Click += new System.EventHandler(this.选课数量_Click);
            // 
            // 所有及格的课程对应的人
            // 
            this.所有及格的课程对应的人.Location = new System.Drawing.Point(12, 56);
            this.所有及格的课程对应的人.Name = "所有及格的课程对应的人";
            this.所有及格的课程对应的人.Size = new System.Drawing.Size(91, 23);
            this.所有及格的课程对应的人.TabIndex = 1;
            this.所有及格的课程对应的人.Text = "所有及格的课程对应的人";
            this.所有及格的课程对应的人.UseVisualStyleBackColor = true;
            this.所有及格的课程对应的人.Click += new System.EventHandler(this.所有及格的课程对应的人_Click);
            // 
            // 大于18岁的人
            // 
            this.大于18岁的人.Location = new System.Drawing.Point(12, 23);
            this.大于18岁的人.Name = "大于18岁的人";
            this.大于18岁的人.Size = new System.Drawing.Size(91, 23);
            this.大于18岁的人.TabIndex = 0;
            this.大于18岁的人.Text = "大于18岁的人";
            this.大于18岁的人.UseVisualStyleBackColor = true;
            this.大于18岁的人.Click += new System.EventHandler(this.大于18岁的人_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(805, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 786);
            this.vScrollBar1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Location = new System.Drawing.Point(2, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更新框架";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 786);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private OpenFileDialog openFileDialog1;
        private ImageList imageList1;
        private Panel panel2;
        private Button button2;
        private RichTextBox richTextBox1;
        private Panel panel3;
        private Button button4;
        private Button button3;
        private Button button5;
        private Button button12;
        private Button button13;
        private Button button14;
        private GroupBox groupBox2;
        private Button 截取屏幕;
        private Button 发送邮件;
        private RichTextBox richTextBox2;
        private GroupBox groupBox3;
        private Button 大于18岁的人;
        private Button button10;
        private Button 课程选修的人数;
        private Button 选课数量;
        private Button 所有及格的课程对应的人;
        private VScrollBar vScrollBar1;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
    }
}