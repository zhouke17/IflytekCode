using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HWUG
{
    /// <summary>
    /// 径宇科技签名版
    /// </summary>
    public partial class JYKJForm : Form
    {
        private HWUGSocketService _hwugSocketService;
        public JYKJForm()
        {
            InitializeComponent();
        }

        private bool IsSign = false;
        private void JYKJForm_Load(object sender, EventArgs e)
        {
            _hwugSocketService = HWUGSocketService.Instance;
            btn_signature.Enabled = false;
            btn_finger.Enabled = false;
        }
        private Image signatureImg;
        private Image fingerImg;

        private void _hwugSocketService_OnReceiveMessage(object arg, JObject obj)
        {
            if (obj["type"].ToString() == Convert.ToString((int)OperationType.Finger))//指纹
            {
                if (obj["ret"].ToString() == "0")
                {
                    //MessageBox.Show(obj["Fingerprint_Base64"].ToString());
                    byte[] bytes = Convert.FromBase64String(obj["Fingerprint_Base64"]?.ToString());
                    using (MemoryStream memStream = new MemoryStream(bytes))
                    {
                        fingerImg = Image.FromStream(memStream);
                        pictureBox.Image = fingerImg;
                    };
                    if (IsSign)
                    {
                        pictureBox.Image = CombinImage(signatureImg,fingerImg);
                    }
                }
                else
                {
                    ShowErrorMessage(obj["ret"].ToString());
                }
            }
            else if (obj["type"].ToString() == Convert.ToString((int)OperationType.Signature))//签名
            {
                if (obj["ret"].ToString() == "0")
                {
                    //MessageBox.Show(obj["SignNameBase64"].ToString());
                    byte[] bytes = Convert.FromBase64String(obj["SignNameBase64"]?.ToString());
                    using (MemoryStream memStream = new MemoryStream(bytes))
                    {
                        pictureBox.Image = signatureImg = Image.FromStream(memStream);
                    };
                    if (IsSign)
                    {
                        this.Invoke(new Action(()=> 
                        {
                            btn_finger_Click(null, null);
                        })); 
                    }
                }
                else
                {
                    ShowErrorMessage(obj["ret"].ToString());
                }
            }
            else if (obj["type"].ToString() == Convert.ToString((int)OperationType.Init))//授权
            {
                if (obj["ret"].ToString() == "0")
                {
                    MessageBox.Show("授权成功");
                }
                else
                {
                    ShowErrorMessage(obj["ret"].ToString());
                }
            }
            else if (obj["type"].ToString() == Convert.ToString((int)OperationType.Close))//授权
            {
                if (obj["ret"].ToString() == "0")
                {
                    MessageBox.Show("页面关闭");
                }
                else
                {
                    ShowErrorMessage(obj["ret"].ToString());
                }
            }
            else if (obj["type"].ToString() == Convert.ToString((int)OperationType.ScreenPage))//更换屏保页
            {
                if (obj["ret"].ToString() == "0")
                {
                    MessageBox.Show("更换成功");
                }
                else
                {
                    ShowErrorMessage(obj["ret"].ToString());
                }
            }
            else
            {
                ShowErrorMessage(obj["ret"].ToString());
            }
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
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
        /// <summary>
        /// 签名版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_signature_Click(object sender, EventArgs e)
        {
            if (!_hwugSocketService.Vertify())
            {
                MessageBox.Show("链接websocket失败");
                return;
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            _hwugSocketService.OnReceiveMessage += _hwugSocketService_OnReceiveMessage;
            var str = new { type = (int)OperationType.Signature, SignWidth = 300, LineWidth = 10 };

            _hwugSocketService.SendAsync(JsonConvert.SerializeObject(str));

            btn_signature.Enabled = false;
            btn_finger.Enabled = true;
        }

        /// <summary>
        /// 指纹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_finger_Click(object sender, EventArgs e)
        {
            if (_hwugSocketService.Vertify())
            {
                var str = new { type = (int)OperationType.Finger, TimeOut = 300};
                _hwugSocketService.SendAsync(JsonConvert.SerializeObject(str));
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            _hwugSocketService.OnReceiveMessage += _hwugSocketService_OnReceiveMessage;
            btn_finger.Enabled = false;
            btn_signature.Enabled = true;
            this.pictureBox.Image = null;
        }
        /// <summary>
        /// 授权初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Init_Click(object sender, EventArgs e)
        {
            if (!_hwugSocketService.Vertify())
            {
                MessageBox.Show("链接websocket失败");
                return;
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            _hwugSocketService.OnReceiveMessage += _hwugSocketService_OnReceiveMessage;
            var str = new { type = (int)OperationType.Init, projectCode = "U21FY+/orVlzg5lU+8MnDMGeFnoOA3tu2zcpo6SAg2QNncXmPazQ1XpS4s8wF8ZK40+fhppzPT49NOK5FBxL4lZbgjv1225Vm9QXYQRF+Tj1PP+niybIqTSBgDRv+1uVf3LnsuE5dNFNReBMY2m5mRzcUMET/kTtIG5t+w8KcIE=" };

            _hwugSocketService.SendAsync(JsonConvert.SerializeObject(str));

            btn_signature.Enabled = true;
            btn_finger.Enabled = true;
        }
        /// <summary>
        /// 签名+指纹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sign_Click(object sender, EventArgs e)
        {
            IsSign = true;
            this.Invoke(new Action(()=>
            {
                btn_signature_Click(null, null);
            })); 
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            if (!_hwugSocketService.Vertify())
            {
                MessageBox.Show("链接websocket失败");
                return;
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            _hwugSocketService.OnReceiveMessage += _hwugSocketService_OnReceiveMessage;
            var str = new { type = (int)OperationType.Close };

            _hwugSocketService.SendAsync(JsonConvert.SerializeObject(str));

            btn_signature.Enabled = true;
            btn_finger.Enabled = true;
        }
        public void ShowErrorMessage(string errorCode)
        {
            switch (errorCode)
            {
                case "-1":
                    MessageBox.Show("传入参数错误");
                    break;
                case "-2":
                    MessageBox.Show("超时");
                    break;
                case "-3":
                    MessageBox.Show("打开设备失败");
                    break;
                case "-4":
                    MessageBox.Show("写数据错误");
                    break;
                case "-5":
                    MessageBox.Show("读数据错误");
                    break;
                case "-6":
                    MessageBox.Show("文件不存在或者为空");
                    break;
                case "-7":
                    MessageBox.Show("设备返回错误信息");
                    break;
                case "-8":
                    MessageBox.Show("读取文件错误");
                    break;
                case "-9":
                    MessageBox.Show("取消操作");
                    break;
                case "-10":
                    MessageBox.Show("传入空间太小，内存错误");
                    break;
                default:
                    MessageBox.Show($"操作失败，返回错误码{errorCode}");
                    break;
            }
        }
        /// <summary>  
        /// 合并图片，默认是垂直合并，图1在下，图2在上。
        /// </summary>  
        /// <param name="imgBack"></param>  
        /// <param name="img"></param>  
        /// <returns></returns>  
        public static Bitmap CombinImage(Image imgBack, Image img, int xDeviation = 0, int yDeviation = 0)
        {

            Bitmap bmp = new Bitmap(imgBack.Width, imgBack.Height + img.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height); 

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2 + xDeviation, imgBack.Height / 2 - img.Height / 2 + 50, img.Width, img.Height);
            GC.Collect();
            return bmp;
        }

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            if (!_hwugSocketService.Vertify())
            {
                MessageBox.Show("链接websocket失败");
                return;
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            _hwugSocketService.OnReceiveMessage += _hwugSocketService_OnReceiveMessage;
            var str = new { type = (int)OperationType.ScreenPage, FileName = "C:\\Users\\Public\\GWQOcx\\ad1.jpg" };

            _hwugSocketService.SendAsync(JsonConvert.SerializeObject(str));

        }
    }

    public enum OperationType
    {
        /// <summary>
        /// 授权初始化
        /// </summary>
        Init = 181,
        /// <summary>
        /// 启动签名板
        /// </summary>
        Signature = 81,
        /// <summary>
        /// 启动指纹
        /// </summary>
        Finger = 51,
        /// <summary>
        /// 关闭
        /// </summary>
        Close = 2,
        ScreenPage = 6
    }
}
