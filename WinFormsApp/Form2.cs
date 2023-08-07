using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region 屏蔽窗体双击方法缩小功能
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112)
            {
                if ((int)m.WParam != 0xf020 && (int)m.WParam != 0xf030 && (int)m.WParam != 0xf060 && (int)m.WParam != 0xf120)
                {
                    m.WParam = IntPtr.Zero;
                }
            }
            base.WndProc(ref m);
        }
        #endregion


        #region 屏蔽WPS快捷键
        /// <summary>
        /// 查找所有窗口(只要是在进程里面的)
        /// 如果不限制类名或者标题使用null代替
        /// </summary>
        /// <param name="lpClassName">窗口类名,不限制使用null</param>
        /// <param name="lpWindowName">窗口标题,不限制使用null</param>
        /// <returns>找到的窗口句柄</returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 获取目标句柄的类名
        /// </summary>
        /// <param name="hWnd">目标窗口句柄</param>
        /// <param name="lpClassName">返回的Class名称</param>
        /// <param name="nMaxCount">允许返回的Class名称的字符数量上限</param>
        /// <returns>获取到的实际Class字符长度</returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// 判断目标窗口是否可见
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns>可见true,不可见false</returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// 给目标句柄发送消息
        /// </summary>
        /// <param name="hwnd">目标句柄</param>
        /// <param name="wMsg">消息内容</param>
        /// <param name="wParam">附加自定义参数1</param>
        /// <param name="lParam">附加自定义参数2</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 通过窗口句柄获取线程ID(TID)和进程ID(PID)
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="PID">返回进程ID</param>
        /// <returns>返回线程ID</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int PID);

        [DllImport("kernel32")]
        public static extern long TerminateProcess(int handle, int exitCode);


        private void button1_Click(object sender, EventArgs e)
        {
            Do("欢迎使用WPS文字帮助", "HH Parent");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Do(null, "QWidget");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Do("另存为", "#32770");
        }

        private void Do(string lpWindowName = null, string lpClassName = null)
        {
            //条件值(API函数接口)
            const int WM_CLOSE = 0x10;
            int findClassMaxLen = 2048;//返回类名字符上限
            StringBuilder sbr = new StringBuilder(500);//返回类名字符串数据流
            string scr = string.Empty;//返回的类名字符串
            int ClassLen = 0;//实际返回类名字符长度
            int hwTID = 0;//线程ID
            int hwPID = 0;//进程ID
            int hwMSR = 0;//关闭窗口返回值
            string ProcTitleResult = string.Empty;//标题名
            Process ProcInfo = null;//实例化进程数据类
            string ProcNameResult = string.Empty;//进程名

            IntPtr hWnd = IntPtr.Zero;//窗口句柄
            hWnd = FindWindow(lpClassName, lpWindowName);//通过标题找句柄
            //判断窗口句柄是否存在，存在残存问题
            if (hWnd != IntPtr.Zero)
            {
                ClassLen = GetClassName(hWnd, sbr, findClassMaxLen);//获取类名
                if (ClassLen > 0)
                {
                    scr = sbr.ToString();//将返回的类名字符串数据流转换为字符串
                    //if (scr == findClass1 | scr == findClass2)
                    {
                        if (IsWindowVisible(hWnd))//排除句柄残存情况
                        {
                            hwTID = GetWindowThreadProcessId(hWnd, out hwPID);//获取线程ID和进程ID
                            ProcInfo = Process.GetProcessById(hwPID);//通过进程ID获取进程所有信息
                            ProcNameResult = ProcInfo.ProcessName;//获取进程名
                            ProcTitleResult = ProcInfo.MainWindowTitle;//主进程标题
                            hwMSR = SendMessage(hWnd, WM_CLOSE, 0, 0);
                            if (hwMSR == 0)
                                MessageBox.Show("窗体关闭成功！");
                        }
                    }
                }
            }
        }

        #endregion

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show($"窗体关闭后DialogResult值为：{DialogResult.ToString()}");
        }
    }
}
