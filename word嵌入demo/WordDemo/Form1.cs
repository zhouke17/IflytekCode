using iflytek.Court.Office.Core;
using iflytek.Court.Office.Core.Interface;
using iflytek.Court.Office.Core.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WordDemo.Model;
using static WordDemo.Model.WinApi;

namespace WordDemo
{
    public partial class Form1 : Form
    {
        IWord word = null;
        IWordTest wordTest = null;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (word != null)
                word.Dispose();
        }

        private void btn_Embed_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}打开文件");
            word.SetParent(panel1.Handle, panel1.Width, panel1.Height);

            EasyOp.TryDo(3, () =>
            {
                word.OpenFile(@"D:\Test.doc");
            });

            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}打开文件End");
        }


        private void btn_killWord_Click(object sender, EventArgs e)
        {
            word.Exit();
        }

        private void btn_initWord_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}初始化");
            Word temp = new Word();
            word = temp;
            wordTest = temp;
            word.Init();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}初始化End");
            //btn_Embed_Click(null, null);
        }

        private void btn_resize_Click(object sender, EventArgs e)
        {
            word.Layout(panel1.Width, panel1.Height);
        }

        private void btn_selection_Click(object sender, EventArgs e)
        {
            word.StartTransform();
        }

        System.Windows.Forms.Timer timer = null;
        int transCount = 0;
        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 300;
                timer.Tick += Timer_Tick;
                timer.Enabled = true;
            }
            timer.Start();

        }

        string bookMark { set; get; }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (transCount > 3)
            {
                transCount = 0;
            }
            if (transCount == 0) bookMark = DateTime.Now.ToString("Bk_yyyy_MM_dd_HH_mm_ss_ffff");
            word.InsertTransformText($"{new Random().Next(10000, 99999)}", transCount == 0, transCount == 3)?.AddBookMark(bookMark);
            transCount++;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void btn_addComment_Click(object sender, EventArgs e)
        {
            word.AddComment(0, -1, "这是一段批注", "jmxie3");
        }

        private void btn_removeComment_Click(object sender, EventArgs e)
        {
            word.RemoveComment("这是一段批注");
        }


        private void btn_checkcomment_Click(object sender, EventArgs e)
        {
            var result = word.CheckCommentChange();
            if (result.IsChange)
            {
                MessageBox.Show(result.Msg);
            }
        }

        private void btn_stopTransform_Click(object sender, EventArgs e)
        {
            word.StopTransform();
        }

        private void btn_checkSpeaker_Click(object sender, EventArgs e)
        {
            word.CheckAndAppendSpeaker("原告：");
        }
        KeyBoardHook hook;
        private void btn_startHook_Click(object sender, EventArgs e)
        {
            if (hook == null)
            {
                //Process cProcess = Process.GetCurrentProcess();

                //ProcessModule cModule = cProcess.MainModule;
                //IntPtr mh = GetModuleHandle(cModule.ModuleName);
                IntPtr hInstance = LoadLibrary("User32");
                hook = new KeyBoardHook(KeyboardHookProc, MouseHookProc, hInstance/* QueryAllWordProcess().FirstOrDefault().MainWindowHandle*/);
                try
                {
                    hook.Open();
                    btn_startHook.Text = "卸载钩子";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    hook = null;
                    btn_startHook.Text = "安装钩子";
                }
            }
            else
            {
                hook.Stop();
                hook = null;
                btn_startHook.Text = "安装钩子";
            }
        }

        private IList<Process> QueryAllWordProcess()
        {
            var words = Process.GetProcessesByName("winword").ToList();
            var wps = Process.GetProcessesByName("wps");
            words.AddRange(wps);
            return words;

        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

            wordTest.CheckWord(false);
            return CallNextHookEx(hook.hKeyboardHook, nCode, wParam, lParam);
        }

        /// <summary>
        /// 鼠标钩子回调函数
        /// </summary>
        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 假设正常执行而且用户要监听鼠标的消息
            if ((nCode >= 0))
            {
                switch (wParam)
                {
                    case WinApi.WM_LBUTTONUP:
                        wordTest.CheckWord(true);
                        break;
                }
            }
            // 启动下一次钩子
            return CallNextHookEx(hook.hMouseHook, nCode, wParam, lParam);
        }




        object TRange = null;
        private void btn_getRange_Click(object sender, EventArgs e)
        {
            if (TRange != null)
            {
                Tuple<int, int> result = wordTest.GetRangeValue(TRange);
                MessageBox.Show($"start:{result.Item1}  end:{result.Item2}");
            }
        }

        private void btn_createRange_Click(object sender, EventArgs e)
        {
            TRange = wordTest.GetRange(3, 5);
        }

        private void btn_listenText_Click(object sender, EventArgs e)
        {
            wordTest.ListenInput();
        }

        private void btn_testBookMark_Click(object sender, EventArgs e)
        {
            wordTest.ReplaceText("清楚", "这是替换测试");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            word.RemoveFooter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "6.jpeg";
            word.InsertSignPages(path, new List<int> { 1, 3 });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            word.RemovePictures();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // WPS Office的安装路径，根据实际情况修改
            string wpsPath = @"D:\软件\wps\WPS Office\10.8.2.7119\office6\wps.exe";

            // 要打开的Word文档路径，根据实际情况修改
            string documentPath = @"D:\Test.doc";

            Process myprocess = new Process();
            string args = $"/wps /w /fromksolaunch \"{documentPath}\"";
            ProcessStartInfo startInfo = new ProcessStartInfo(wpsPath, args);
            myprocess.StartInfo = startInfo;
            myprocess.Start();
            //Thread thread = new Thread(() => RunWps(wpsPath, documentPath));
            //thread.Start();
        }
        static void RunWps(string wpsPath, string documentPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = wpsPath;
            process.StartInfo.Arguments = $"/e \"{documentPath}\""; // 使用/e参数打开文档，将文件路径作为参数传递给WPS Office
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = false;

            process.Start();

            // 从WPS Office进程的标准输出中读取结果
            string result = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            Console.WriteLine(result); // 在控制台输出结果，可以根据需要进行处理或显示
        }
    }
}
