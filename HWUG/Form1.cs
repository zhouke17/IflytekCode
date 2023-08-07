using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HWUG
{
    public partial class Form1 : Form
    {
        private string signUrl;
        private HWUGSocketService _hwugSocketService;
        private bool isOpenUrl;

        public Form1()
        {
            InitializeComponent();
            InIt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _hwugSocketService = HWUGSocketService.Instance;
        }
        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!_hwugSocketService.Vertify())
            {
                MessageBox.Show("链接websocket失败");
                return;
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            _hwugSocketService.OnReceiveMessage += _hwugSocketService_OnReceiveMessage;
            var str = "{\"typename\":\"extendurl\",\"message\":{\"url\":\"" + signUrl + "\"}}";

            _hwugSocketService.SendAsync(str);
            str = "{\"typename\":\"startsign\",\"message\":{\"left\":\"" + 240 + "\",\"top\":\"" + 200 + "\",\"width\":\"" + 600 + "\",\"height\":\"" + 300 + "\",\"penwidth\":\"" + 5 + "\"}}";

            _hwugSocketService.SendAsync(str);

            str = "{\"typename\": \"mouseenable\",\"message\": {\"mod\": \"0\"}}";

            _hwugSocketService.SendAsync(str);

            isOpenUrl = true;
            btn_Start.Enabled = false;
            btn_End.Enabled = true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (_hwugSocketService.Vertify() && isOpenUrl)
            {

                var str1 = "{\"typename\": \"mouseenable\",\"message\": {\"mod\": \"0\"}}";
                _hwugSocketService.SendAsync(str1);

                str1 = "{\"typename\":\"closeurl\",\"message\":{\"url\":\"" + signUrl + "\"}}";
                _hwugSocketService.SendAsync(str1);

                str1 = "{\"typename\":\"closewindow\"}";
                _hwugSocketService.SendAsync(str1);
            }
            _hwugSocketService.OnReceiveMessage -= _hwugSocketService_OnReceiveMessage;
            btn_End.Enabled = false;
            btn_Start.Enabled = true;
            isOpenUrl = false;
            this.pictureBox.Image = null;
        }

        private Image image1;
        private Image image2;
        private void _hwugSocketService_OnReceiveMessage(object arg1, Newtonsoft.Json.Linq.JObject msg)
        {
            switch (msg["typename"]?.ToString())
            {
                //签名
                case "signbase64":
                    string msgBase64 = msg["message"]?.ToString().Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                    if (msgBase64.Length % 4 > 0)
                    {
                        msgBase64 = msgBase64.PadRight(msgBase64.Length + 4 - msgBase64.Length % 4, '=');
                    }
                    byte[] bytes = Convert.FromBase64String(msgBase64);
                    using (MemoryStream memStream = new MemoryStream(bytes))
                    {
                        image1 = Image.FromStream(memStream); 
                    };
                    // 发送采集指纹命令
                    var str = "{\"typename\":\"startfinger\",\"message\":{\"left\":\"" + 340 + "\",\"top\":\"" + 250 + "\",\"width\":\"" + 600 + "\",\"height\":\"" + 300
                    + "\",\"quality\":\"" + 100 + "\",\"flag\":\"" + 1 + "\"}}";
                    _hwugSocketService.SendAsync(str);
                    break;
                //指纹
                case "fingerbase64":
                    //签名+指纹
                    //case "signfbase64":
                    string msgBase642 = msg["message"]?.ToString().Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                    if (msgBase642.Length % 4 > 0)
                    {
                        msgBase642 = msgBase642.PadRight(msgBase642.Length + 4 - msgBase642.Length % 4, '=');
                    }
                    byte[] bytes2 = Convert.FromBase64String(msgBase642);
                    using (MemoryStream memStream = new MemoryStream(bytes2))
                    {
                        image2 = Image.FromStream(memStream);
                        pictureBox.Image = CombinImage(image1,image2);
                    };
                    //str = "{\"typename\":\"closeurl\",\"message\":{\"url\":\"" + signUrl + "\"}}";
                    //_hwugSocketService.SendAsync(str);
                    //str = "{\"typename\":\"closewindow\"}";
                    //_hwugSocketService.SendAsync(str);
                    break;
                case "cancel":
                    break;
                case "unsign":
                    MessageBox.Show(msg["message"].ToString());
                    break;
                case "error":
                    MessageBox.Show("未成功连接设备");
                    break;
                default:
                    break;
            }
        }

        #region 方法
        /// <summary>
        /// 查找签字页面
        /// </summary>
        public void InIt()
        {
            btn_Start.Enabled = true;
            btn_End.Enabled = false;
            string webPath =  Path.Combine( AppDomain.CurrentDomain.BaseDirectory ,"web");
            // 查找签字页面URl
            if (!Directory.Exists(webPath))
            {
                MessageBox.Show("汉王友基签字版所需文件缺失，请添加后再次启动", "提示", MessageBoxButtons.OK);
            }
            else
            {
                signUrl = Path.Combine(webPath, "law.html").Replace("\\",@"\\");
                //var signUrl1 = @"C:\\Users\\kezhou3\\source\\repos\\HWUG\\bin\\Debug\\web\\law.html";
            }
            #endregion


        }

        /// <summary>  
        /// 合并图片，默认是垂直合并，图1在上，图2在下。
        /// </summary>  
        /// <param name="imgBack"></param>  
        /// <param name="img"></param>  
        /// <returns></returns>  
        public static Bitmap CombinImage(Image imgBack, Image img, int xDeviation = 0, int yDeviation = 0)
        {

            Bitmap bmp = new Bitmap(imgBack.Width, imgBack.Height + img.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height); //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2 + xDeviation, imgBack.Height/2 - img.Height / 2 + yDeviation, img.Width, img.Height);
            GC.Collect();
            return bmp;
        }

        /// <summary>
        /// 两张图片纵向合并
        /// </summary>
        /// <param name="firstImage">图片一</param>
        /// <param name="secondImage">图片2</param>
        /// <returns>合并后的图片</returns>
        public Bitmap MergeTwoImagesLongitudinal(Image firstImage, Image secondImage)
        {
            try
            {
                if (firstImage == null)
                {
                    throw new ArgumentNullException("firstImage");
                }
                if (secondImage == null)
                {
                    throw new ArgumentNullException("secondImage");
                }
                int outputImageWidth = firstImage.Width > secondImage.Width ? firstImage.Width : secondImage.Width;
                int outputImageHeight = firstImage.Height + secondImage.Height + 1;
                Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics graphics = Graphics.FromImage(outputImage))
                {
                    graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                        new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                    graphics.DrawImage(secondImage, new Rectangle(new Point(0, firstImage.Height + 1), secondImage.Size),
                        new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
                }
                return outputImage;
            }
            catch (Exception ex)
            {
               

                throw;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string str = "{\"typename\":\"closewindow\"}";
            _hwugSocketService.SendAsync(str);
        }
    }
}
