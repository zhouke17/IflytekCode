
namespace WordDemo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_stopTransform = new System.Windows.Forms.Button();
            this.btn_checkcomment = new System.Windows.Forms.Button();
            this.btn_removeComment = new System.Windows.Forms.Button();
            this.btn_addComment = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_startTransform = new System.Windows.Forms.Button();
            this.btn_resize = new System.Windows.Forms.Button();
            this.btn_initWord = new System.Windows.Forms.Button();
            this.btn_killWord = new System.Windows.Forms.Button();
            this.btn_Embed = new System.Windows.Forms.Button();
            this.btn_checkSpeaker = new System.Windows.Forms.Button();
            this.btn_startHook = new System.Windows.Forms.Button();
            this.btn_getRange = new System.Windows.Forms.Button();
            this.btn_createRange = new System.Windows.Forms.Button();
            this.btn_listenText = new System.Windows.Forms.Button();
            this.btn_testBookMark = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 339);
            this.panel1.TabIndex = 0;
            // 
            // btn_stopTransform
            // 
            this.btn_stopTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stopTransform.Location = new System.Drawing.Point(98, 371);
            this.btn_stopTransform.Name = "btn_stopTransform";
            this.btn_stopTransform.Size = new System.Drawing.Size(68, 23);
            this.btn_stopTransform.TabIndex = 23;
            this.btn_stopTransform.Text = "停止转写";
            this.btn_stopTransform.UseVisualStyleBackColor = true;
            this.btn_stopTransform.Click += new System.EventHandler(this.btn_stopTransform_Click);
            // 
            // btn_checkcomment
            // 
            this.btn_checkcomment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_checkcomment.Location = new System.Drawing.Point(530, 371);
            this.btn_checkcomment.Name = "btn_checkcomment";
            this.btn_checkcomment.Size = new System.Drawing.Size(75, 23);
            this.btn_checkcomment.TabIndex = 22;
            this.btn_checkcomment.Text = "检查批注";
            this.btn_checkcomment.UseVisualStyleBackColor = true;
            this.btn_checkcomment.Click += new System.EventHandler(this.btn_checkcomment_Click);
            // 
            // btn_removeComment
            // 
            this.btn_removeComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removeComment.Location = new System.Drawing.Point(449, 371);
            this.btn_removeComment.Name = "btn_removeComment";
            this.btn_removeComment.Size = new System.Drawing.Size(75, 23);
            this.btn_removeComment.TabIndex = 21;
            this.btn_removeComment.Text = "删除批注";
            this.btn_removeComment.UseVisualStyleBackColor = true;
            this.btn_removeComment.Click += new System.EventHandler(this.btn_removeComment_Click);
            // 
            // btn_addComment
            // 
            this.btn_addComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addComment.Location = new System.Drawing.Point(368, 371);
            this.btn_addComment.Name = "btn_addComment";
            this.btn_addComment.Size = new System.Drawing.Size(75, 23);
            this.btn_addComment.TabIndex = 20;
            this.btn_addComment.Text = "添加批注";
            this.btn_addComment.UseVisualStyleBackColor = true;
            this.btn_addComment.Click += new System.EventHandler(this.btn_addComment_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stop.Location = new System.Drawing.Point(287, 371);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 19;
            this.btn_stop.Text = "停止插入";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(33, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 339);
            this.panel2.TabIndex = 12;
            // 
            // btn_insert
            // 
            this.btn_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_insert.Location = new System.Drawing.Point(206, 371);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 18;
            this.btn_insert.Text = "开始插入";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_startTransform
            // 
            this.btn_startTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_startTransform.Location = new System.Drawing.Point(24, 371);
            this.btn_startTransform.Name = "btn_startTransform";
            this.btn_startTransform.Size = new System.Drawing.Size(68, 23);
            this.btn_startTransform.TabIndex = 17;
            this.btn_startTransform.Text = "开始转写";
            this.btn_startTransform.UseVisualStyleBackColor = true;
            this.btn_startTransform.Click += new System.EventHandler(this.btn_selection_Click);
            // 
            // btn_resize
            // 
            this.btn_resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_resize.Location = new System.Drawing.Point(870, 371);
            this.btn_resize.Name = "btn_resize";
            this.btn_resize.Size = new System.Drawing.Size(75, 23);
            this.btn_resize.TabIndex = 16;
            this.btn_resize.Text = "重新布局";
            this.btn_resize.UseVisualStyleBackColor = true;
            this.btn_resize.Click += new System.EventHandler(this.btn_resize_Click);
            // 
            // btn_initWord
            // 
            this.btn_initWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_initWord.Location = new System.Drawing.Point(676, 371);
            this.btn_initWord.Name = "btn_initWord";
            this.btn_initWord.Size = new System.Drawing.Size(75, 23);
            this.btn_initWord.TabIndex = 15;
            this.btn_initWord.Text = "初始化word";
            this.btn_initWord.UseVisualStyleBackColor = true;
            this.btn_initWord.Click += new System.EventHandler(this.btn_initWord_Click);
            // 
            // btn_killWord
            // 
            this.btn_killWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_killWord.Location = new System.Drawing.Point(965, 371);
            this.btn_killWord.Name = "btn_killWord";
            this.btn_killWord.Size = new System.Drawing.Size(75, 23);
            this.btn_killWord.TabIndex = 14;
            this.btn_killWord.Text = "关闭word";
            this.btn_killWord.UseVisualStyleBackColor = true;
            this.btn_killWord.Click += new System.EventHandler(this.btn_killWord_Click);
            // 
            // btn_Embed
            // 
            this.btn_Embed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Embed.Location = new System.Drawing.Point(771, 371);
            this.btn_Embed.Name = "btn_Embed";
            this.btn_Embed.Size = new System.Drawing.Size(75, 23);
            this.btn_Embed.TabIndex = 13;
            this.btn_Embed.Text = "嵌入";
            this.btn_Embed.UseVisualStyleBackColor = true;
            this.btn_Embed.Click += new System.EventHandler(this.btn_Embed_Click);
            // 
            // btn_checkSpeaker
            // 
            this.btn_checkSpeaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_checkSpeaker.Location = new System.Drawing.Point(1055, 371);
            this.btn_checkSpeaker.Name = "btn_checkSpeaker";
            this.btn_checkSpeaker.Size = new System.Drawing.Size(75, 23);
            this.btn_checkSpeaker.TabIndex = 24;
            this.btn_checkSpeaker.Text = "检查讲话人";
            this.btn_checkSpeaker.UseVisualStyleBackColor = true;
            this.btn_checkSpeaker.Click += new System.EventHandler(this.btn_checkSpeaker_Click);
            // 
            // btn_startHook
            // 
            this.btn_startHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_startHook.Location = new System.Drawing.Point(24, 421);
            this.btn_startHook.Name = "btn_startHook";
            this.btn_startHook.Size = new System.Drawing.Size(68, 23);
            this.btn_startHook.TabIndex = 25;
            this.btn_startHook.Text = "安装钩子";
            this.btn_startHook.UseVisualStyleBackColor = true;
            this.btn_startHook.Click += new System.EventHandler(this.btn_startHook_Click);
            // 
            // btn_getRange
            // 
            this.btn_getRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getRange.Location = new System.Drawing.Point(287, 421);
            this.btn_getRange.Name = "btn_getRange";
            this.btn_getRange.Size = new System.Drawing.Size(75, 23);
            this.btn_getRange.TabIndex = 26;
            this.btn_getRange.Text = "获取Range";
            this.btn_getRange.UseVisualStyleBackColor = true;
            this.btn_getRange.Click += new System.EventHandler(this.btn_getRange_Click);
            // 
            // btn_createRange
            // 
            this.btn_createRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_createRange.Location = new System.Drawing.Point(206, 421);
            this.btn_createRange.Name = "btn_createRange";
            this.btn_createRange.Size = new System.Drawing.Size(75, 23);
            this.btn_createRange.TabIndex = 27;
            this.btn_createRange.Text = "创建Range";
            this.btn_createRange.UseVisualStyleBackColor = true;
            this.btn_createRange.Click += new System.EventHandler(this.btn_createRange_Click);
            // 
            // btn_listenText
            // 
            this.btn_listenText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_listenText.Location = new System.Drawing.Point(368, 421);
            this.btn_listenText.Name = "btn_listenText";
            this.btn_listenText.Size = new System.Drawing.Size(75, 23);
            this.btn_listenText.TabIndex = 28;
            this.btn_listenText.Text = "监听变化";
            this.btn_listenText.UseVisualStyleBackColor = true;
            this.btn_listenText.Click += new System.EventHandler(this.btn_listenText_Click);
            // 
            // btn_testBookMark
            // 
            this.btn_testBookMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_testBookMark.Location = new System.Drawing.Point(449, 421);
            this.btn_testBookMark.Name = "btn_testBookMark";
            this.btn_testBookMark.Size = new System.Drawing.Size(75, 23);
            this.btn_testBookMark.TabIndex = 29;
            this.btn_testBookMark.Text = "书签测试";
            this.btn_testBookMark.UseVisualStyleBackColor = true;
            this.btn_testBookMark.Click += new System.EventHandler(this.btn_testBookMark_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(771, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "删除所有页脚";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(676, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "添加图片 ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(870, 421);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 32;
            this.button3.Text = "删除图片 ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(965, 421);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 33;
            this.button4.Text = "外部打开";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 501);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_testBookMark);
            this.Controls.Add(this.btn_listenText);
            this.Controls.Add(this.btn_createRange);
            this.Controls.Add(this.btn_getRange);
            this.Controls.Add(this.btn_startHook);
            this.Controls.Add(this.btn_checkSpeaker);
            this.Controls.Add(this.btn_stopTransform);
            this.Controls.Add(this.btn_checkcomment);
            this.Controls.Add(this.btn_removeComment);
            this.Controls.Add(this.btn_addComment);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.btn_startTransform);
            this.Controls.Add(this.btn_resize);
            this.Controls.Add(this.btn_initWord);
            this.Controls.Add(this.btn_killWord);
            this.Controls.Add(this.btn_Embed);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_stopTransform;
        private System.Windows.Forms.Button btn_checkcomment;
        private System.Windows.Forms.Button btn_removeComment;
        private System.Windows.Forms.Button btn_addComment;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_startTransform;
        private System.Windows.Forms.Button btn_resize;
        private System.Windows.Forms.Button btn_initWord;
        private System.Windows.Forms.Button btn_killWord;
        private System.Windows.Forms.Button btn_Embed;
        private System.Windows.Forms.Button btn_checkSpeaker;
        private System.Windows.Forms.Button btn_startHook;
        private System.Windows.Forms.Button btn_getRange;
        private System.Windows.Forms.Button btn_createRange;
        private System.Windows.Forms.Button btn_listenText;
        private System.Windows.Forms.Button btn_testBookMark;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

