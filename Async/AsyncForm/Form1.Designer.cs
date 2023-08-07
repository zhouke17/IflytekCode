
namespace AsyncForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.Monitor2 = new System.Windows.Forms.Button();
            this.Monitor = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.MonitorWait = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cpu爆炸 = new System.Windows.Forms.Button();
            this.内存溢出 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aysnc/Await";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 76);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "TaskCompletionSource";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 450);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "异步同步执行";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.Monitor2);
            this.groupBox2.Controls.Add(this.Monitor);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(151, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 450);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(24, 189);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(148, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "AutoResetEvent2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Monitor2
            // 
            this.Monitor2.Location = new System.Drawing.Point(24, 416);
            this.Monitor2.Name = "Monitor2";
            this.Monitor2.Size = new System.Drawing.Size(148, 23);
            this.Monitor2.TabIndex = 8;
            this.Monitor2.Text = "MonitorPulseAll";
            this.Monitor2.UseVisualStyleBackColor = true;
            this.Monitor2.Click += new System.EventHandler(this.MonitorPulseAll_Click);
            // 
            // Monitor
            // 
            this.Monitor.Location = new System.Drawing.Point(24, 365);
            this.Monitor.Name = "Monitor";
            this.Monitor.Size = new System.Drawing.Size(148, 23);
            this.Monitor.TabIndex = 7;
            this.Monitor.Text = "Monitor";
            this.Monitor.UseVisualStyleBackColor = true;
            this.Monitor.Click += new System.EventHandler(this.Monitor_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 305);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "SemaphoreSlim";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 252);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "ConcurrentDictionary";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "AutoResetEvent";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MonitorWait
            // 
            this.MonitorWait.Location = new System.Drawing.Point(27, 36);
            this.MonitorWait.Name = "MonitorWait";
            this.MonitorWait.Size = new System.Drawing.Size(101, 23);
            this.MonitorWait.TabIndex = 6;
            this.MonitorWait.Text = "MonitorWait";
            this.MonitorWait.UseVisualStyleBackColor = true;
            this.MonitorWait.Click += new System.EventHandler(this.MonitorWait_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cpu爆炸);
            this.groupBox3.Controls.Add(this.内存溢出);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.MonitorWait);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(340, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 450);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // cpu爆炸
            // 
            this.cpu爆炸.Location = new System.Drawing.Point(24, 239);
            this.cpu爆炸.Name = "cpu爆炸";
            this.cpu爆炸.Size = new System.Drawing.Size(75, 23);
            this.cpu爆炸.TabIndex = 10;
            this.cpu爆炸.Text = "Cpu爆炸";
            this.cpu爆炸.UseVisualStyleBackColor = true;
            this.cpu爆炸.Click += new System.EventHandler(this.cpu爆炸_Click);
            // 
            // 内存溢出
            // 
            this.内存溢出.Location = new System.Drawing.Point(24, 193);
            this.内存溢出.Name = "内存溢出";
            this.内存溢出.Size = new System.Drawing.Size(75, 23);
            this.内存溢出.TabIndex = 9;
            this.内存溢出.Text = "内存溢出";
            this.内存溢出.UseVisualStyleBackColor = true;
            this.内存溢出.Click += new System.EventHandler(this.内存溢出_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(27, 136);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 8;
            this.button11.Text = "线程间同步";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(27, 84);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 7;
            this.button10.Text = "Parallel";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button Monitor;
        private System.Windows.Forms.Button Monitor2;
        private System.Windows.Forms.Button MonitorWait;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button 内存溢出;
        private System.Windows.Forms.Button cpu爆炸;
    }
}

