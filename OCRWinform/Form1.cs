using PaddleOCRSharp;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OCRWinform
{
    public partial class Form1 : Form
    {

        static OCRModelConfig config = null;
        static OCRParameter oCRParameter = new OCRParameter();
        OCRResult ocrResult = new OCRResult();
        //建议程序全局初始化一次即可，不必每次识别都初始化，容易报错。
        PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var imagebyte = File.ReadAllBytes(ofd.FileName);
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));
            ocrResult = engine.DetectText(bitmap);

            if (ocrResult != null)
            {
                this.richTextBox1.Text = ocrResult.Text;
            }
        }
    }
}
