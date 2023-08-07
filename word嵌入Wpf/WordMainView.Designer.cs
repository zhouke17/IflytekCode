namespace WPFApp
{
    partial class WordMainView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(524, 271);
            this.panel.TabIndex = 0;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 271);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(524, 165);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // WordMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.panel);
            this.Name = "WordMainView";
            this.Size = new System.Drawing.Size(524, 436);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}
