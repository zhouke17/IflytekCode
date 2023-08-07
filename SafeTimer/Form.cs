using System;
using System.Threading;

namespace SafeTimer
{
    public partial class Form : System.Windows.Forms.Form
    {
        private static SafeTimer safeTimer = null;
        public Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            safeTimer = new SafeTimer(WriteLine, string.Empty, 2000, Timeout.Infinite);
        }

        private void WriteLine(object state)
        {
            Thread.Sleep(3000);
            this.richTextBox.BeginInvoke(() =>
            {
                this.richTextBox.Text += "Hello " + DateTime.Now.ToString("yyyy - MM - dd hh: mm: ss fff")
            });
            Console.WriteLine();
            safeTimer.Change(2000, Timeout.Infinite);
        }
    }
}
