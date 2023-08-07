using DevExpress.XtraSplashScreen;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DevFormDemo
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



            Custom custom = new Custom();
            custom.ShowSplashScreen();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            SplashScreenManager.CloseForm();

            Application.Run(new MainForm());
        }
    }

    public class Custom
    {
        public void ShowSplashScreen()
        {
            // Show a splashscreen.
            SplashScreenManager.ShowForm(typeof(MySplashScreen));
            // ' Show a splashscreen.
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowSkinSplashScreen(
            //logoImage:= myLogoImage,
            //title:= "When Only The Best Will Do",
            //subtitle:= "DevExpress WinForms Controls",
            //footer:= "Copyright © 2000 - 2020 Developer Express Inc." & Environment.NewLine & "All Rights reserved.",
            //loading:= "Starting...",
            //parentForm:= Me
            //)
        }
    }
}
