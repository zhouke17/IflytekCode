using System;
using System.Windows.Forms;

namespace NLogWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggerManager.Log1.Debug("输入log1文本到log2日志文件中");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoggerManager.Log2.Debug("输入log2文本到log2日志文件中");
        }
    }
}
