using AutoUpdaterDotNET;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace UpdateClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoUpdater.DownloadPath = AppDomain.CurrentDomain.BaseDirectory + @"AutoUpdaterDotNETDownLoad/";//设置更新包下载路径

            var currentDirectory = new DirectoryInfo(AutoUpdater.DownloadPath);
            if (currentDirectory.Parent != null)
            {
                AutoUpdater.InstallationPath = currentDirectory.Parent.FullName;
            }

            AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);//调整更新弹窗的大小

            //采用json文件格式的更新文件
            //AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;
            //AutoUpdater.Start(AppDomain.CurrentDomain.BaseDirectory + "updateJson.json");

            AutoUpdater.Start(AppDomain.CurrentDomain.BaseDirectory + "updateXml.xml");//本地路径

            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;//更新程序完成后事件
        }

        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"关闭更新程序...";
            Thread.Sleep(2000);
            Process.GetCurrentProcess().Kill();
        }

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic json = JsonConvert.DeserializeObject(args.RemoteData);
            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = json.version,
                ChangelogURL = json.changelog,
                DownloadURL = json.url,
                Mandatory = new Mandatory
                {
                    Value = json.mandatory.value,
                    UpdateMode = json.mandatory.mode,
                    MinimumVersion = json.mandatory.minVersion
                },
                CheckSum = new CheckSum
                {
                    Value = json.checksum.value,
                    HashingAlgorithm = json.checksum.hashingAlgorithm
                }
            };
        }
    }
}
