using System.Drawing;
using System.Windows.Forms;
using 捷宇科技签字版;

namespace 婕宇签名终端
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.OpenDevice(null,
              () =>
              {
                  MessageBox.Show("初始化设备成功！");
              },
              (msg, ex) =>
              {
                  MessageBox.Show($"{msg}");
              });
        }

        public void GetImage(Image image)
        {
            this.pictureBox1.Image = image;
        }

        private void btn_Sign_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.SignType = SignType.Signature;

            SignBoard_JieYu.Instance.StartSign();

            SignBoard_JieYu.Instance.SetSignCallBack(GetImage);

            SignBoard_JieYu.Instance.ErrorEventCallback = (msg, ex) =>
            {
                MessageBox.Show($"{msg}");
            };
        }

        private void btn_SignFinger_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.SignType = SignType.SignFinger;

            SignBoard_JieYu.Instance.StartSignAndFinger();

            SignBoard_JieYu.Instance.SetSignCallBack(GetImage);

            SignBoard_JieYu.Instance.ErrorEventCallback = (msg, ex) =>
            {
                MessageBox.Show($"{msg}");
            };
        }

        private void btn_FaceComparison_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.SignType = SignType.Face;

            SignBoard_JieYu.Instance.StartFace();

            SignBoard_JieYu.Instance.SetSignCallBack(GetImage);

            SignBoard_JieYu.Instance.ErrorEventCallback = (msg, ex) =>
            {
                MessageBox.Show($"{msg}");
            };

        }

        private void GetUserInfo(UserInfo obj)
        {
            MessageBox.Show($"验证通过：{obj.PassFlag}\t\n姓名：{obj.Name}\t\n身份证号：{obj.Id}");
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.SetMode(0);
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.SetMode(1);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.SetIp(ip_txt.Text.Trim());//10.4.125.13
        }

        private void btn_ReadIDCard_Click(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.GetMode((ip) =>
            {
                MessageBox.Show($"当前模式：{ip}");
            });
        }

        private void btn_ESign_Click(object sender, System.EventArgs e)
        {
            SignBoard_JieYu.Instance.StartElectronicSignature();
        }
    }
}
