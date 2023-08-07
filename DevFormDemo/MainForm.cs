using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DevFormDemo
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            //this.tip_layer.Visible = true;
            //label.Parent = pictureBox1;
            //label.Text = "图片显示文字";
            //label.BackColor = Color.Black;
            //label.ForeColor = Color.White;
        }


        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //args.AutoCloseOptions.Delay = 5000;
            args.Caption = "Auto-close message";
            args.Text = "This message closes automatically after 5 seconds.";
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            // change the default button
            args.DefaultButtonIndex = 1;
            // set to false to hide the countdown
            //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            if (XtraMessageBox.Show(args) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        int clickTimes = 0;
        private void simpleButton_Click(object sender, System.EventArgs e)
        {
            ++clickTimes;
            //if (clickTimes == 1 || clickTimes == 2)
            //{
            //    this.toolTip1.SetToolTip(this.simpleButton1, $"点击{clickTimes}次");
            //}
            //else if (clickTimes == 3 || clickTimes == 4)
            //{
            //    this.toolTip1.SetToolTip(this.simpleButton1, $"点击{clickTimes}次");
            //}
            //else
            //{
            //    this.toolTip1.RemoveAll();
            //    clickTimes = 0;
            //}
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            this.pictureBox1.Visible = false;
            //this.tip_layer.Visible = true;
        }

        private void tip_layer_Click(object sender, System.EventArgs e)
        {
            this.pictureBox1.Visible = true;
            //this.tip_layer.Visible = false;
        }

        public void Remove(LayoutControlGroup group)
        {
            // Normal Dispose forgets to remove Controls, so have to do this ourselves.
            List<Control> controls = new List<Control>();
            AddControls(group, controls);
            var owner = group.Owner;
            //owner.BeginUpdate();
            foreach (var c in controls)
            {
                c.Dispose();
            }
            //owner.EndUpdate();
            //group.Dispose();
            //group = null;
        }
        private static void AddControls(BaseLayoutItem layoutItem, List<Control> controls)
        {
            if (layoutItem is LayoutControlGroup)
            {
                foreach (BaseLayoutItem item in ((LayoutControlGroup)layoutItem).Items)
                {
                    AddControls(item, controls);
                }
            }
            else if (layoutItem is LayoutControlItem)
            {
                var ic = (LayoutControlItem)layoutItem;
                if (ic.Control != null)
                    controls.Add(ic.Control);
            }
            else if (layoutItem is TabbedControlGroup)
            {
                foreach (BaseLayoutItem page in ((TabbedControlGroup)layoutItem).TabPages)
                {
                    AddControls(page, controls);
                }
            }
        }

        /// <summary>
        /// 删除控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            //Remove(bottom_layoutControlGroup);
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            LayoutControlItem item = null;
            if (layoutControlGroup1.Items.Count <= 0)
            {
                item = layoutControlGroup1.AddItem();
            }
            else
            {
                item = layoutControlGroup1.AddItem(layoutControlGroup1.Items[layoutControlGroup1.Items.Count - 1], DevExpress.XtraLayout.Utils.InsertType.Top);
            }
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = DevFormDemo.Properties.Resources.Logo;
            item.Control = pictureBox;
            item.MinSize = new Size(400, 200);
            item.MaxSize = new Size(400, 200);
            item.Size = new Size(400, 200);
            item.TextVisible = false;
        }

        private void simpleButton3_Click(object sender, System.EventArgs e)
        {
            TabbedControlGroup tcg = layoutControl3.Root.AddTabbedGroup();

            LayoutControlGroup lcg1 = tcg.AddTabPage("one");
            LayoutControlItem lci11 = lcg1.AddItem();
            lci11.Control = new TextEdit();
            lci11.Text = "First:";
            lci11.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            LayoutControlItem lci12 = lcg1.AddItem();
            lci12.Control = new TextEdit();
            lci12.Text = "Second:";
            LayoutControlItem lci13 = lcg1.AddItem();
            lci13.Control = new TextEdit();
            lci13.Text = "Three:";
            lci13.Move(lci12, InsertType.Right);
        }
    }
}
