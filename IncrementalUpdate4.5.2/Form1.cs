using Squirrel;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace IncrementalUpdate4._5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Assembly asm = Assembly.GetEntryAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            Version currentVersion = new Version(fvi.FileVersion);
            this.textBox1.Text = currentVersion.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var mgr = new UpdateManager(@"http://localhost:8090/"))
            {
                var newVersion = await mgr.UpdateApp();

                // optionally restart the app automatically, or ask the user if/when they want to restart
                if (newVersion != null)
                {
                    UpdateManager.RestartApp();
                }
            }
        }
    }
}
