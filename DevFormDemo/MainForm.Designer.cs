
namespace DevFormDemo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.offlinelayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.trial_offlineGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.offlineGroupControl = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offlinelayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trial_offlineGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offlineGroupControl)).BeginInit();
            this.offlineGroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DevFormDemo.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(31, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 228);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.simpleButton2);
            this.layoutControl2.Controls.Add(this.simpleButton1);
            this.layoutControl2.Controls.Add(this.buttonEdit1);
            this.layoutControl2.Controls.Add(this.textEdit1);
            this.layoutControl2.Controls.Add(this.simpleButton3);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(575, 233, 650, 400);
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(933, 182);
            this.layoutControl2.TabIndex = 8;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(12, 148);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(100, 22);
            this.simpleButton2.StyleController = this.layoutControl2;
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "RemoveButton";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(236, 148);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 22);
            this.simpleButton1.StyleController = this.layoutControl2;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "AddButton";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(933, 182);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem2";
            this.layoutControlItem1.Size = new System.Drawing.Size(913, 88);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(204, 136);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(104, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(54, 26);
            this.layoutControlItem2.Name = "item0";
            this.layoutControlItem2.Size = new System.Drawing.Size(709, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(20, 0, 0, 0);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton2;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 136);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(104, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // offlinelayoutControl
            // 
            this.offlinelayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offlinelayoutControl.Location = new System.Drawing.Point(2, 21);
            this.offlinelayoutControl.Margin = new System.Windows.Forms.Padding(0);
            this.offlinelayoutControl.Name = "offlinelayoutControl";
            this.offlinelayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.offlinelayoutControl.Root = null;
            this.offlinelayoutControl.Size = new System.Drawing.Size(209, 220);
            this.offlinelayoutControl.TabIndex = 0;
            // 
            // trial_offlineGroup
            // 
            this.trial_offlineGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.trial_offlineGroup.GroupBordersVisible = false;
            this.trial_offlineGroup.Location = new System.Drawing.Point(0, 0);
            this.trial_offlineGroup.Name = "trial_offlineGroup";
            this.trial_offlineGroup.Size = new System.Drawing.Size(209, 220);
            this.trial_offlineGroup.TextVisible = false;
            // 
            // offlineGroupControl
            // 
            this.offlineGroupControl.Controls.Add(this.layoutControl3);
            this.offlineGroupControl.Location = new System.Drawing.Point(23, 23);
            this.offlineGroupControl.Margin = new System.Windows.Forms.Padding(0);
            this.offlineGroupControl.Name = "offlineGroupControl";
            this.offlineGroupControl.Size = new System.Drawing.Size(356, 243);
            this.offlineGroupControl.TabIndex = 9;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.offlineGroupControl);
            this.layoutControl1.Location = new System.Drawing.Point(0, 236);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(598, 234, 650, 400);
            this.layoutControl1.Root = null;
            this.layoutControl1.Size = new System.Drawing.Size(340, 289);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControl3
            // 
            this.layoutControl3.Location = new System.Drawing.Point(26, 34);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(575, 233, 650, 400);
            this.layoutControl3.Root = this.layoutControlGroup1;
            this.layoutControl3.Size = new System.Drawing.Size(290, 187);
            this.layoutControl3.TabIndex = 9;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 30;
            this.layoutControlGroup1.Size = new System.Drawing.Size(290, 187);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem2";
            this.layoutControlItem3.Size = new System.Drawing.Size(270, 167);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(63, 124);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(245, 20);
            this.buttonEdit1.StyleController = this.layoutControl2;
            this.buttonEdit1.TabIndex = 6;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.buttonEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 112);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(300, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(162, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(913, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "编辑按钮";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(63, 100);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(245, 20);
            this.textEdit1.StyleController = this.layoutControl2;
            this.textEdit1.TabIndex = 7;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.textEdit1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 88);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(300, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(189, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(913, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "文本填写";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(116, 148);
            this.simpleButton3.MaximumSize = new System.Drawing.Size(100, 0);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(96, 22);
            this.simpleButton3.StyleController = this.layoutControl2;
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "AddTabPage";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton3;
            this.layoutControlItem7.Location = new System.Drawing.Point(104, 136);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 551);
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offlinelayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trial_offlineGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offlineGroupControl)).EndInit();
            this.offlineGroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl offlinelayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup trial_offlineGroup;
        private DevExpress.XtraEditors.GroupControl offlineGroupControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}

