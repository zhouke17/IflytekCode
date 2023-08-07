using iflytek.Court.Client.Views.Sign_JieYuHelper;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using 婕宇签名终端;

namespace 捷宇科技签字版
{
    /// <summary>
    /// 捷宇科技签字版
    /// </summary>
    public class SignBoard_JieYu : ISign
    {
        ILog log = log4net.LogManager.GetLogger("SignBoard_JieYu");
        private JieYuSocketService jieyuSocketService { get; set; }
        public SignType SignType { get; set; }

        public Action<string, Exception> ErrorEventCallback { set; get; }
        public Action SuccessFunc { get; set; }
        public Action<Image> SignImageCallBack { get; set; }
        public Action<UserInfo> Action { get; set; }

        private static readonly Object locker = new object();
        private static SignBoard_JieYu _instance = null;

        public Action<string> ModeAction { get; set; }

        private Image signImg;
        private Image fingerImg;
        public static SignBoard_JieYu Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new SignBoard_JieYu();
                        }
                    }
                }
                return _instance;
            }
        }

        private SignBoard_JieYu()
        {
            jieyuSocketService = JieYuSocketService.Instance;
        }
        public void Clear()
        {

        }

        public void CloseDevice()
        {
            var str = new { type = (int)OrderType.Close };

            jieyuSocketService.Send(JsonConvert.SerializeObject(str));
            jieyuSocketService.OnReceiveMessage -= jieyuSocketService_OnReceiveMessage;
        }

        public void OpenDevice(Control control, Action successFunc, Action<string, Exception> errorFunc)
        {
            ErrorEventCallback = errorFunc;
            SuccessFunc = successFunc;
            jieyuSocketService.Connection();
            if (jieyuSocketService != null && !jieyuSocketService.Vertify())
            {
                //连接签名版服务异常时，重启签名版服务。
                try
                {
                    var processes = Process.GetProcessesByName("ZNXXJHZDService");
                    foreach (var p in processes)
                    {
                        p.CloseMainWindow();
                        p.Kill();
                    }
                    if (File.Exists("ZNXXJHZDServicePath.txt"))
                    {
                        string jieyuServerPath = File.ReadAllText("ZNXXJHZDServicePath.txt");
                        Process myprocess = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo(jieyuServerPath);
                        myprocess.StartInfo = startInfo;
                        startInfo.CreateNoWindow = true;
                        myprocess.StartInfo.UseShellExecute = false;
                        myprocess.Start();
                    }
                    else
                    {
                        ErrorEventCallback.Invoke("请检查签名板驱动是否已安装", null);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                finally
                {
                    jieyuSocketService.Connection();
                }
                //ErrorEventCallback.Invoke("签名版服务连接失败,重启中...", null);
            }
            jieyuSocketService.OnReceiveMessage -= jieyuSocketService_OnReceiveMessage;
            jieyuSocketService.OnReceiveMessage += jieyuSocketService_OnReceiveMessage;

            var order = new { type = (int)OrderType.Init, projectCode = "sFDIxyb+W6VK5lWJbGqPaEaiLLGKOhCTEbezv4Y2UJreH5G+o2fXlp4n/9WD2tJQLf416VY7wWufYge3npVamUcwDwuSK5dg/U3YAUHpxamnlE1Qm5PPM4Ybd1dzR464PueyVUGGqCvyJfI1goxNITNYsYel4UMMr4PsvBOOVyo=" };

            jieyuSocketService.Send(JsonConvert.SerializeObject(order));
        }

        private void jieyuSocketService_OnReceiveMessage(object arg, JObject obj)
        {
            try
            {
                if (obj["type"].ToString() == Convert.ToString((int)OrderType.Signature))//签名
                {
                    if (obj["ret"].ToString() == "0")
                    {
                        byte[] bytes = Convert.FromBase64String(obj["SignNameBase64"]?.ToString());
                        using (MemoryStream memStream = new MemoryStream(bytes))
                        {
                            signImg = Image.FromStream(memStream);
                        };
                        if (SignType == SignType.Signature)
                        {
                            SignImageCallBack?.Invoke(signImg);
                        }
                        else if (SignType == SignType.SignFinger)
                        {
                            //发送采集指纹命令
                            var order = new { type = (int)OrderType.Finger, TimeOut = 300 };
                            jieyuSocketService.Send(JsonConvert.SerializeObject(order));
                        }
                    }
                    else
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Finger))//指纹
                {
                    if (obj["ret"].ToString() == "0")
                    {
                        byte[] bytes = Convert.FromBase64String(obj["Fingerprint_Base64"]?.ToString());
                        using (MemoryStream memStream = new MemoryStream(bytes))
                        {
                            fingerImg = Image.FromStream(memStream);
                            fingerImg = ResizeImage(fingerImg, new Size(200, 100));
                        };
                        SignImageCallBack?.Invoke(ResizeImage(CombinImage(signImg, fingerImg), new Size(300, 250)));
                    }
                    else
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Init))//授权
                {
                    if (obj["ret"].ToString() == "0")
                    {
                        SuccessFunc?.Invoke();
                        //if (SignType == SignType.Face)
                        //{
                        //    //发送人脸核对命令
                        //    var order = new { type = (int)OrderType.Face };
                        //    jieyuSocketService.Send(JsonConvert.SerializeObject(order));
                        //}
                        //else
                        //{
                        //    //发送签名命令
                        //    var order = new { type = (int)OrderType.Signature, SignWidth = 300, LineWidth = 10 };
                        //    jieyuSocketService.Send(JsonConvert.SerializeObject(order));
                        //}
                    }
                    else
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Face))//人脸核对
                {
                    if (obj["ret"].ToString() == "0")
                    {
                        SuccessFunc?.Invoke();
                        Action?.Invoke(new UserInfo { Name = obj["name"].ToString(), Id = obj["id_num"].ToString(), PassFlag = (bool)obj["passFlag"] });
                    }
                    else
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Close))//关闭页面
                {
                    if (obj["ret"].ToString() != "0")
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Mode))//设置模式
                {
                    if (obj["ret"].ToString() != "0")
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Ip))//设置IP
                {
                    if (obj["ret"].ToString() != "0")
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.GetMode))//获取模式
                {
                    if (obj["ret"].ToString() != "0")
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                    else
                    {
                        ModeAction?.Invoke(obj["ret"].ToString());
                    }
                }
                else if (obj["type"].ToString() == Convert.ToString((int)OrderType.Confirm))//文档确认
                {
                    if (obj["ret"].ToString() != "0")
                    {
                        ShowErrorMessage(obj["ret"].ToString());
                    }
                    else
                    {
                        ModeAction?.Invoke(obj["ret"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorEventCallback.Invoke(ex.Message, null);
            }
        }

        public void ShowErrorMessage(string errorCode)
        {
            switch (errorCode)
            {
                case "-1":
                    ErrorEventCallback("传入参数错误", null);
                    break;
                case "-2":
                    ErrorEventCallback("超时操作", null);
                    break;
                case "-3":
                    ErrorEventCallback("打开设备失败", null);
                    break;
                case "-4":
                    ErrorEventCallback("写数据错误", null);
                    break;
                case "-5":
                    ErrorEventCallback("读数据错误", null);
                    break;
                case "-6":
                    ErrorEventCallback("文件不存在或者为空", null);
                    break;
                case "-7":
                    ErrorEventCallback("设备返回错误信息", null);
                    break;
                case "-8":
                    ErrorEventCallback("读取文件错误", null);
                    break;
                case "-9":
                    ErrorEventCallback("取消操作", null);
                    break;
                case "-10":
                    ErrorEventCallback("传入空间太小，内存错误", null);
                    break;
                default:
                    ErrorEventCallback($"操作失败，错误码：{errorCode}", null);
                    break;
            }
        }

        public void SetSignCallBack(Action<Image> callBack)
        {
            SignImageCallBack = callBack;
        }

        public void GetIdCardInfo(Action<UserInfo> action)
        {
            Action = action;
        }

        public void StartSign()
        {
            //发送签名命令
            var order = new { type = (int)OrderType.Signature, SignWidth = 300, LineWidth = 10 };
            jieyuSocketService.Send(JsonConvert.SerializeObject(order));
        }
        public void StartSignAndFinger()
        {
            //发送签名捺印命令
            var order = new { type = (int)OrderType.Signature, SignWidth = 300, LineWidth = 10 };
            jieyuSocketService.Send(JsonConvert.SerializeObject(order));
        }
        public void StartFace()
        {
            //发送人脸核对命令
            var order = new { type = (int)OrderType.Face };
            jieyuSocketService.Send(JsonConvert.SerializeObject(order));
        }
        public void SetMode(long mode)
        {
            jieyuSocketService.Send(JsonConvert.SerializeObject(new { type = (int)OrderType.Mode, mode = mode }));
        }

        public void SetIp(string IpAddress)
        {
            jieyuSocketService.Send(JsonConvert.SerializeObject(new { type = (int)OrderType.Ip, IP = IpAddress }));
        }

        public void GetMode(Action<string> action)
        {
            this.ModeAction = action;
            jieyuSocketService.Send(JsonConvert.SerializeObject(new { type = (int)OrderType.GetMode }));
        }

        public void GetIp(string IpAddress)
        {
            jieyuSocketService.Send(JsonConvert.SerializeObject(new { type = (int)OrderType.Ip, IP = IpAddress }));
        }

        public void StartElectronicSignature()
        {
            jieyuSocketService.Send(JsonConvert.SerializeObject(new
            {
                type = (int)OrderType.Confirm,
                PDFPath = @"D:\Court\icourt5.2\code\bin\TempFile\Preview\(2023)京01民初051101号-1.pdf",
                Timeout = "60"
            }));
        }
        /// <summary>  
        /// 合并图片，默认是垂直合并，图1在下，图2在上。
        /// </summary>  
        /// <param name="imgBack"></param>  
        /// <param name="img"></param>  
        /// <returns></returns>  
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
                log.Error(ex);
            }
            return null;
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
    }
    /// <summary>
    /// 签署类型
    /// </summary>
    public enum SignType
    {
        /// <summary>
        /// 签名
        /// </summary>
        Signature,
        /// <summary>
        /// 指纹
        /// </summary>
        Finger,
        /// <summary>
        /// 签名+指纹
        /// </summary>
        SignFinger,
        /// <summary>
        /// 人脸
        /// </summary>
        Face
    }
    /// <summary>
    /// 命令类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 关闭
        /// </summary>
        Close = 2,
        /// <summary>
        /// 启动指纹
        /// </summary>
        Finger = 51,
        /// <summary>
        /// 启动签名板
        /// </summary>
        Signature = 81,
        /// <summary>
        /// 授权初始化
        /// </summary>
        Init = 181,
        /// <summary>
        /// 人脸核对
        /// </summary>
        Face = 122,
        /// <summary>
        /// 设置IP
        /// </summary>
        Ip = 72,
        /// <summary>
        /// 设置通信模式
        /// </summary>
        Mode = 59,
        /// <summary>
        /// 获取模式
        /// </summary>
        GetMode = 143,
        /// <summary>
        /// 文档确认
        /// </summary>
        Confirm = 13

    }
    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        public bool PassFlag { get; set; }
    }
}
