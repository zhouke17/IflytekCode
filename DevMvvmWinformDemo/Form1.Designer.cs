
namespace DevMvvmWinformDemo
{
    partial class MvvmFormView
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
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_submit = new DevExpress.XtraBars.BarButtonItem();
            this.btn_empty = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.richtxt_show = new System.Windows.Forms.RichTextBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(DevMvvmWinformDemo.MvvmFormViewModel);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btn_submit,
            this.btn_empty});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(485, 182);
            // 
            // btn_submit
            // 
            this.btn_submit.Caption = "提交";
            this.btn_submit.Id = 1;
            this.btn_submit.ImageOptions.Image = global::DevMvvmWinformDemo.Properties.Resources.apply_32x32;
            this.btn_submit.ImageOptions.LargeImage = global::DevMvvmWinformDemo.Properties.Resources.apply_32x32;
            this.btn_submit.Name = "btn_submit";
            // 
            // btn_empty
            // 
            this.btn_empty.Caption = "清空";
            this.btn_empty.Id = 2;
            this.btn_empty.ImageOptions.Image = global::DevMvvmWinformDemo.Properties.Resources.trash_16x16;
            this.btn_empty.ImageOptions.LargeImage = global::DevMvvmWinformDemo.Properties.Resources.trash_32x32;
            this.btn_empty.Name = "btn_empty";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_submit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_empty);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_input);
            this.layoutControl1.Controls.Add(this.richtxt_show);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 182);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(485, 346);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(485, 346);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txt_input
            // 
            this.txt_input.Location = new System.Drawing.Point(81, 16);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(388, 25);
            this.txt_input.TabIndex = 7;
            // 
            // richtxt_show
            // 
            this.richtxt_show.Location = new System.Drawing.Point(81, 47);
            this.richtxt_show.Name = "richtxt_show";
            this.richtxt_show.Size = new System.Drawing.Size(388, 283);
            this.richtxt_show.TabIndex = 6;
            this.richtxt_show.Text = "";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_input;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(459, 31);
            this.layoutControlItem2.Text = "请输入：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.richtxt_show;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(459, 289);
            this.layoutControlItem3.Text = "内容：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 18);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 528);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btn_submit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btn_empty;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.RichTextBox richtxt_show;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

