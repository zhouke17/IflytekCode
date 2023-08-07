using AutoUpdaterDotNET;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net;
using System.Runtime.InteropServices;
using static WinFormsApp.Extension;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Initialize();
            InitializeComponent();
        }

        #region 屏蔽消息
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112)
            {
                switch ((int)m.WParam)
                {
                    //禁止双击标题栏关闭窗体
                    case 0xF063:
                    case 0xF093:
                    case 0xA3:
                        m.WParam = IntPtr.Zero;
                        break;
                    //禁止双击标题栏
                    case 0xf122:
                    case 0xf012:
                        m.WParam = IntPtr.Zero;
                        break;
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        #region 窗体阴影
        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            dwmInitialize();
            base.OnLoad(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _IsMouseDown = true;
            _location = this.Location;
            _startPoint = Control.MousePosition;
            base.OnMouseDown(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                Point p = Control.MousePosition;
                this.Location = new Point(_location.X + p.X - _startPoint.X, _location.Y + p.Y - _startPoint.Y);
            }
            base.OnMouseMove(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _IsMouseDown = false;
            base.OnMouseUp(e);
        }
        /// <summary>
        /// 界面绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (dwmEnabled)
            {
                e.Graphics.Clear(Color.FromArgb(0, 0, 0, 0));
                DrawShadow(this.Size, dwmleft, e.Graphics);
            }
            RectangleF rect = new RectangleF(dwmleft - 0.5f, dwmtop - 0.5f, this.Width - dwmleft - dwmright + 0.5f, this.Height - dwmtop - dwmbottom + 0.5f);
            SolidBrush brush = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(brush, rect);
            brush.Dispose(); brush = null;
        }
        /// <summary>
        /// 
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;
                return cp;
            }
        }
        /// <summary>
        /// 绘制阴影效果
        /// </summary>
        /// <param name="size">控件尺寸</param>
        /// <param name="radius">阴影半径</param>
        /// <param name="g">绘图区</param>
        private void DrawShadow(Size size, int radius, Graphics g)
        {
            if (radius <= 0) return;
            int d = 2 * radius;
            #region[LinearGradientBrush]   
            ColorBlend blend = new ColorBlend();
            blend.Colors = new Color[] { Color.FromArgb(100, Color.Black), Color.FromArgb(40, Color.Black), Color.FromArgb(0, Color.Black) };
            blend.Positions = new float[] { 0, 0.4f, 1 };
            LinearGradientBrush brushleft = new LinearGradientBrush(new Point(radius, 0), new Point(0, 0), Color.FromArgb(60, Color.Black), Color.FromArgb(0, Color.Black));
            brushleft.InterpolationColors = blend;
            LinearGradientBrush brushright = new LinearGradientBrush(new Point(size.Width - radius - 1, 0), new Point(size.Width, 0), Color.FromArgb(80, Color.Black), Color.FromArgb(0, Color.Black));
            brushright.InterpolationColors = blend;
            LinearGradientBrush brushtop = new LinearGradientBrush(new Point(0, radius), new Point(0, 0), Color.FromArgb(60, Color.Black), Color.FromArgb(0, Color.Black));
            brushtop.InterpolationColors = blend;
            LinearGradientBrush brushbottom = new LinearGradientBrush(new Point(0, size.Height - radius - 1), new Point(0, size.Height), Color.FromArgb(80, Color.Black), Color.FromArgb(0, Color.Black));
            brushbottom.InterpolationColors = blend;
            #endregion
            #region[path]
            GraphicsPath pathlefttop = new GraphicsPath();
            pathlefttop.AddPie(new Rectangle(0, 0, d, d), 180, 90);
            GraphicsPath pathrighttop = new GraphicsPath();
            pathrighttop.AddPie(new Rectangle(this.Width - d, 0, d, d), 270, 90);
            GraphicsPath pathleftbottom = new GraphicsPath();
            pathleftbottom.AddPie(new Rectangle(0, this.Height - d, d, d), 90, 90);
            GraphicsPath pathrightbottom = new GraphicsPath();
            pathrightbottom.AddPie(new Rectangle(this.Width - d, this.Height - d, d, d), 0, 90);
            #endregion
            #region[PathGradientBrush]
            PathGradientBrush brushlefttop = new PathGradientBrush(pathlefttop);
            brushlefttop.CenterPoint = new Point(radius, radius);
            brushlefttop.CenterColor = Color.FromArgb(80, Color.Black);
            brushlefttop.SurroundColors = new Color[] { Color.FromArgb(0, Color.Black) };
            //brushlefttop.InterpolationColors = blend;
            PathGradientBrush brushrighttop = new PathGradientBrush(pathrighttop);
            brushrighttop.CenterPoint = new Point(this.Width - radius, radius);
            brushrighttop.CenterColor = Color.FromArgb(80, Color.Black);
            brushrighttop.SurroundColors = new Color[] { Color.FromArgb(0, Color.Black) };
            //brushrighttop.InterpolationColors = blend;
            PathGradientBrush brushleftbottom = new PathGradientBrush(pathleftbottom);
            brushleftbottom.CenterPoint = new Point(radius, this.Height - radius);
            brushleftbottom.CenterColor = Color.FromArgb(80, Color.Black);
            brushleftbottom.SurroundColors = new Color[] { Color.FromArgb(0, Color.Black) };
            //brushleftbottom.InterpolationColors = blend;
            PathGradientBrush brushrightbottom = new PathGradientBrush(pathrightbottom);
            brushrightbottom.CenterPoint = new Point(this.Width - radius, this.Height - radius);
            brushrightbottom.CenterColor = Color.FromArgb(80, Color.Black);
            brushrightbottom.SurroundColors = new Color[] { Color.FromArgb(0, Color.Black) };
            //brushrightbottom.InterpolationColors = blend;
            #endregion
            #region[draw]
            g.FillRectangle(brushleft, new RectangleF(1, radius - 0.5f, radius, this.Height - d + 0.5f));
            g.FillRectangle(brushright, new RectangleF(this.Width - radius - 1, radius - 0.5f, radius, this.Height - d + 0.5f));
            g.FillRectangle(brushtop, new RectangleF(radius - 0.5f, 0, this.Width - d + 0.5f, radius));
            g.FillRectangle(brushbottom, new RectangleF(radius - 0.5f, this.Height - radius - 1, this.Width - d + 0.5f, radius));
            g.FillPath(brushlefttop, pathlefttop);
            g.FillPath(brushrighttop, pathrighttop);
            g.FillPath(brushleftbottom, pathleftbottom);
            g.FillPath(brushrightbottom, pathrightbottom);
            #endregion
            #region[dispose]
            brushleft.Dispose(); brushleft = null;
            brushright.Dispose(); brushright = null;
            brushtop.Dispose(); brushtop = null;
            brushbottom.Dispose(); brushbottom = null;
            pathlefttop.Dispose(); pathlefttop = null;
            pathrighttop.Dispose(); pathrighttop = null;
            pathleftbottom.Dispose(); pathleftbottom = null;
            pathrightbottom.Dispose(); pathrightbottom = null;
            brushlefttop.Dispose(); brushlefttop = null;
            brushrighttop.Dispose(); brushrighttop = null;
            brushleftbottom.Dispose(); brushleftbottom = null;
            brushrightbottom.Dispose(); brushrightbottom = null;
            #endregion
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            dwmleft = 5;
            dwmtop = 5;
            dwmright = 5;
            dwmbottom = 5;
        }
        /// <summary>
        /// dwm初始化
        /// </summary>
        private void dwmInitialize()
        {
            #region[dwmInitialize]
            this.dwmEnabled = true;
            int flag = 0;
            MARGINS mg = new MARGINS();
            mg.m_Left = dwmleft;
            mg.m_Top = dwmtop;
            mg.m_Right = dwmright;
            mg.m_Bottom = dwmbottom;
            //判断Vista系统
            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                DwmIsCompositionEnabled(ref flag);    //检测Aero是否为打开
                if (flag > 0)
                {
                    DwmExtendFrameIntoClientArea(this.Handle, ref mg);
                }
                else
                {
                    dwmEnabled = false;
                    dwmleft = 0;
                    dwmtop = 0;
                    dwmright = 0;
                    dwmbottom = 0;
                    //MessageBox.Show("Desktop Composition is Disabled!");
                }
            }
            else
            {
                dwmEnabled = false;
                dwmleft = 0;
                dwmtop = 0;
                dwmright = 0;
                dwmbottom = 0;
                //MessageBox.Show("Please run this on Windows Vista.");
            }
            GC.Collect();
            #endregion
        }
        protected bool dwmEnabled;
        protected int dwmleft;
        protected int dwmtop;
        protected int dwmright;
        protected int dwmbottom;
        private bool _IsMouseDown;
        private Point _location;
        private Point _startPoint;
        private const int WS_MINIMIZEBOX = 0x00020000;

        /// <summary>
        /// 
        /// </summary>
        public struct MARGINS
        {
            public int m_Left;
            public int m_Right;
            public int m_Top;
            public int m_Bottom;
        };
        [DllImport("dwmapi.dll")]
        private static extern void DwmIsCompositionEnabled(ref int enabledptr);
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
        [DllImport("dwmapi.dll")]
        private static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margin);
        #endregion

        #region 打开Notepad.exe 并且输入文本
        private void button1_Click(object sender, EventArgs e)
        {
            OpenNotepad(this.textBox1.Text.Trim());
        }
        /// <summary>
        /// 打开Notepad.exe 并且输入文本
        /// </summary>
        /// <param name="message"></param>
        private void OpenNotepad(string message)
        {
            Process process = new Process();

            try
            {
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = "Notepad.exe",
                    UseShellExecute = false, // 要重定向 IO流，Process对象必须将 UseShellExecute属性设置为false；
                    CreateNoWindow = true, // 是否以没有窗体的模式创建应用程序，默认为false，即有窗体，如为true，即隐藏窗体。在这里不设置该值也可以；
                    RedirectStandardInput = true, // 标准输入流的重定向，重定向至Process，我们可以通过Process.StandardInput.WriteLine将数据写入标准流；
                    RedirectStandardOutput = true // 与RedirectStandardInput相反，这是标准输出流的重定向，我们可以通过
                };
                process.Start();
            }
            catch (Exception ex)
            {
                process = null;
            }

            if (process != null)
            {
                while (process.MainWindowHandle == IntPtr.Zero)
                {
                    process.Refresh();
                }
                IntPtr vHandle = FindWindowEx(process.MainWindowHandle, IntPtr.Zero, "Edit", null);
                SendMessage(vHandle, 0x000C, 0, message);
            }
        }


        [DllImport("User32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        public const uint WM_SETTEXT = 0x000C;

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);
        #endregion


        #region 异步委托
        private void button2_Click(object sender, EventArgs e)
        {
            Action action = () => { Thread.Sleep(5000); };
        }
        #endregion

        #region 弹窗
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Thread.Sleep(2000);
            form2.Close();
            MessageBox.Show($"Show弹窗的关闭返回值为：{form2.DialogResult.ToString()}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            MessageBox.Show($"ShowDialog弹窗的关闭返回值为：{form2.DialogResult.ToString()}");
        }

        //委托中异步使用弹窗
        private void button5_Click(object sender, EventArgs e)
        {
            Action action = async () =>
            {
                await Task.Delay(2000);
                Form2 form2 = new Form2();
                DialogResult dialog = form2.ShowDialog();
                MessageBox.Show($"异步委托中弹窗被关闭时的返回值为：{form2.DialogResult.ToString()}");
            };

            //Task.Run(() =>
            //this.BeginInvoke(new Action(() => { action.Invoke(); }))
            //);
            action.Invoke();
        }

        #endregion

        #region 关闭进程
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] iflyCourtList = Process.GetProcessesByName("iflyCourt");//iflyCourt.exe
                foreach (Process process in iflyCourtList)
                {
                    process.Kill();
                }
                Process[] ScreenshotsList = Process.GetProcessesByName("iflyCourt_Screenshots");//iflyCourt_Screenshots.exe
                foreach (Process process in ScreenshotsList)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 超时
        private async void button7_Click(object sender, EventArgs e)
        {
            var task = await TestTask().Timeout(3000);

            if (task == 0)
            {
                MessageBox.Show("Task超时");
                return;
            }
            MessageBox.Show($"Task结果为：{task}");
        }

        public async Task<int> TestTask()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(4000);
                return 3;
            });
        }
        #endregion


        #region 更新

        #region NAppUpdate更新
        private void button14_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region AutoUpdaterDotNET更新
        private void button12_Click(object sender, EventArgs e)
        {
            //AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;

            //AutoUpdater.ClearAppDirectory = true;//清楚之前的更新包

            AutoUpdater.DownloadPath = AppDomain.CurrentDomain.BaseDirectory + @"AutoUpdaterDotNETDownLoad/";//设置更新包下载路径

            var currentDirectory = new DirectoryInfo(AutoUpdater.DownloadPath);
            if (currentDirectory.Parent != null)
            {
                AutoUpdater.InstallationPath = currentDirectory.Parent.FullName;
            }

            AutoUpdater.UpdateFormSize = new System.Drawing.Size(800, 600);//调整更新弹窗的大小

            //不让用户选择延迟更新的具体时间点,默认一个时间段，分，小时，天
            //AutoUpdater.LetUserSelectRemindLater = false;
            //AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Minutes;
            //AutoUpdater.RemindLaterAt = 10;

            //采用json文件格式的更新文件
            AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;
            AutoUpdater.Start(AppDomain.CurrentDomain.BaseDirectory + "updateJson.json");

            //AutoUpdater.Start("http://localhost:8080/updateXml.xml");//网路路径

            //AutoUpdater.Start(AppDomain.CurrentDomain.BaseDirectory + "updateXml.xml");//本地路径

            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;//更新程序完成后事件
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. This is required update. Press Ok to begin updating the application.", @"Update Available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. Do you want to update the application now?", @"Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                    }

                    // Uncomment the following line if you want to show standard update dialog instead.
                    // AutoUpdater.ShowUpdateForm(args);

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"There is no update available please try again later.", @"No update available",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is WebException)
                {
                    MessageBox.Show(
                        @"There is a problem reaching update server. Please check your internet connection and try again later.",
                        @"Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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


        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"关闭更新程序...";
            Process.GetCurrentProcess().Kill();
        }
        #endregion

        #region 原有更新
        private void button13_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            string args = string.Format("{0} {1}", @"http://172.31.97.233:88/group1/M00/07/6F/rB9h6WNqAxCAOEBqAAKXfcPpKW4816.zip", "948d958fea5ba27356dca6ee5752114e");
            ProcessStartInfo stateInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "updater_launch.exe", args);
            p.StartInfo = stateInfo;
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }



        #endregion

        #endregion


        #region Base64图片合成

        private void button15_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        private Image fingerImg;
        private Image signatureImg;

        #region base64
        private string signature = "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";

        private string finger = "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";
        #endregion

        private void base64Btn_Click(object sender, EventArgs e)
        {
            byte[] bytes = Convert.FromBase64String(finger);
            using (MemoryStream memStream = new MemoryStream(bytes))
            {
                fingerImg = Image.FromStream(memStream);
                fingerImg = ResizeImage(fingerImg, new Size(200, 100));
            };

            byte[] bytes2 = Convert.FromBase64String(signature);
            using (MemoryStream memStream = new MemoryStream(bytes2))
            {
                signatureImg = Image.FromStream(memStream);
            };

            var retImage = ResizeImage(CombinImage(signatureImg, fingerImg), new Size(300, 250));
            var percent = 176.0 / retImage.Height;//适配界面展示大小
            pictureBox1.Image = PercentImage(retImage, percent);
        }
        private System.Drawing.Image ResizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //获取图片宽度
            int sourceWidth = imgToResize.Width;
            //获取图片高度
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private Bitmap CombinImage(Image imgBack, Image img, int xDeviation = 0, int yDeviation = 0)
        {
            try
            {
                Bitmap bmp = new Bitmap(imgBack.Width, imgBack.Height);

                Graphics g = Graphics.FromImage(bmp);
                g.Clear(System.Drawing.Color.White);
                g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);//绘制下层图片

                g.DrawImage(img, imgBack.Width / 2 - img.Width / 2 + xDeviation, imgBack.Height / 2 - img.Height / 2 + yDeviation, img.Width, img.Height);//绘制上层图片
                GC.Collect();
                return bmp;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public Bitmap PercentImage(Image srcImage, double percent)
        {
            // 缩小后的高度 
            int newH = int.Parse(Math.Round(srcImage.Height * percent).ToString());
            // 缩小后的宽度 
            int newW = int.Parse(Math.Round(srcImage.Width * percent).ToString());
            try
            {
                // 要保存到的图片 
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(srcImage, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region lock死锁

        private void 主线程_Click(object sender, EventArgs e)
        {
            byte[] bytes = Convert.FromBase64String(finger);
            using (MemoryStream memStream = new MemoryStream(bytes))
            {
                fingerImg = Image.FromStream(memStream);
                fingerImg = ResizeImage(fingerImg, new Size(200, 100));
            };
            SetPic(fingerImg, "sync");
        }

        private void 异步线程_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                byte[] bytes = Convert.FromBase64String(finger);
                using (MemoryStream memStream = new MemoryStream(bytes))
                {
                    fingerImg = Image.FromStream(memStream);
                    fingerImg = ResizeImage(fingerImg, new Size(200, 100));
                };
                SetPic(fingerImg, "async");
            });
        }

        private static object lockObj = new object();
        void SetPic(Image image, string form)
        {
            lock (lockObj)
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    ++i;
                }
                richTextBox2.Text += form;
                pictureBox1.Image = image;
            }
        }
        #endregion


        #region Linq
        List<Person> list = new List<Person>();
        List<Course> list2 = new List<Course>();

        private void Init()
        {
            list.Add(new Person() { name = "小明", age = 19 });
            list.Add(new Person() { name = "小红", age = 17 });
            list.Add(new Person() { name = "小强", age = 20 });

            list2.Add(new Course() { personName = "小明", name = "数学", score = 90 });
            list2.Add(new Course() { personName = "小明", name = "英语", score = 56 });
            list2.Add(new Course() { personName = "小红", name = "数学", score = 60 });
            list2.Add(new Course() { personName = "小红", name = "英语", score = 100 });
        }

        #endregion

        private void 大于18岁的人_Click(object sender, EventArgs e)
        {
            Init();
            var res = list.Where(x => x.age > 18).ToList();
        }

        private void 所有及格的课程对应的人_Click(object sender, EventArgs e)
        {
            var res = from p in list
                      from c in list2
                      where p.name == c.personName && c.score >= 60
                      select new { c, p };

            var res1 = from p in list
                       join c in list2 on p.name equals c.personName
                       where c.score >= 60
                       select new { c, p };


            var res2 = list.SelectMany(c => list2, (person, course) => new { person, course }).Where(x => x.course.personName == x.person.name & x.course.score >= 60);

            var res3 = list.Join(list2, p => p.name, c => c.personName, (p, c) => new { c, p }).Where(x => x.c.score >= 60);
        }

        private void 选课数量_Click(object sender, EventArgs e)
        {
            var res1 = list.GroupJoin(list2, p => p.name, c => c.personName, (p, ct) => new { p.name, count = ct.Count() });
        }

        private void 课程选修的人数_Click(object sender, EventArgs e)
        {
            var res1 = list2.GroupBy(c => c.personName).Select((sub) => new { proName = sub.Key, count = sub.Count() });
        }


        private void MeasureText1(PaintEventArgs e)
        {
            String text1 = "Measure this text";
            Font arialBold = new Font("Arial", 12.0F);
            Size textSize = TextRenderer.MeasureText(text1, arialBold);
            TextRenderer.DrawText(e.Graphics, text1, arialBold,
                new Rectangle(new Point(10, 10), textSize), Color.Red);
        }
    }

    class Person
    {
        public string name;
        public int age;
        public override string ToString()
        {
            return "name: " + name + ", age: " + age;
        }
    }

    class Course
    {
        public string personName;
        public string name;
        public int score;

        public override string ToString()
        {
            return "name: " + name + ", score: " + score + ", personName: " + personName;
        }
    }
}
