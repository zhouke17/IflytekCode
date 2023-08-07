using Squirrel;
using System;
using System.Windows.Forms;

namespace IncrementalUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            //run Squirrel first, as the app may exit after these run
            SquirrelAwareApp.HandleEvents(
                onInitialInstall: OnAppInstall,
                onAppUninstall: OnAppUninstall,
                onEveryRun: OnAppRun);

            //本地文件夹或服务器地址
            //using (var mgr = new UpdateManager(@"http://localhost:8080/updates/"))
            //{
            //    var newVersion = mgr.UpdateApp();

            //    while (!newVersion.IsCompleted)
            //    {

            //    }

            //    // optionally restart the app automatically, or ask the user if/when they want to restart
            //    if (newVersion != null)
            //    {
            //        UpdateManager.RestartApp();
            //    }
            //}
            //... other app init code after...
        }

        private static void OnAppInstall(SemanticVersion version, IAppTools tools)
        {
            tools.CreateShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
        }

        private static void OnAppUninstall(SemanticVersion version, IAppTools tools)
        {
            tools.RemoveShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
        }

        private static void OnAppRun(SemanticVersion version, IAppTools tools, bool firstRun)
        {
            tools.SetProcessAppUserModelId();
            // show a welcome message when the app is first installed
            if (firstRun) MessageBox.Show("Thanks for installing my application!");

            // 启动你的应用
            Application.Run(new Form1());
        }
    }
}
