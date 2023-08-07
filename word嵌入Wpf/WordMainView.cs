using System;
using System.Windows.Forms;
using WpfApp.WordContorl;

namespace WPFApp
{
    public partial class WordMainView : UserControl
    {
        public WordMainView()
        {
            InitializeComponent();
            elementHost1.Child = new WPFApp.MyUserControl();
            this.Controls.Add(elementHost1);
        }

        public void OpenWord(IWord word, string fileName)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}打开文件");
            word.SetParent(this.panel.Handle, panel.Width, panel.Height);
            word.OpenFile(fileName);
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}打开文件End");
        }

    }
}
