using Prism.Commands;
using System;
using System.ComponentModel;
using System.IO;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Xps.Packaging;
using WpfApp.WordContorl;

namespace WPFApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool isChecked;

        public bool IsChecked
        {
            get
            {
                if (isChecked)
                {
                    this.PwTxTBox.Visibility = Visibility.Visible;
                    this.PwBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.PwTxTBox.Visibility = Visibility.Collapsed;
                    this.PwBox.Visibility = Visibility.Visible;
                }
                return isChecked;
            }
            set { isChecked = value; OnPropertyChanged(); }
        }

        public string Pwd
        {
            get { return (string)GetValue(PwdProperty); }
            set { SetValue(PwdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.Register("Pwd", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));


        private IWord word;
        private WordMainView WordMain;
        private string fileName;

        public ICommand EnterCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            WordMain = new WordMainView();
            WordHost.Child = WordMain;
            //ConvertWordToXPS(@"D:\wordTest.doc");//利用DocumentViewer加载word：无法编辑
            Text = "请输入文本";

            EnterCommand = new DelegateCommand<string>(OnEnterCommand);
        }

        private void OnEnterCommand(string obj)
        {
            System.Windows.MessageBox.Show("Enter");
        }

        private XpsDocument ConvertWordToXps2(string wordDocName, string xpsFilename)
        {
            Spire.Doc.Document document = new Spire.Doc.Document(wordDocName);
            document.SaveToFile(xpsFilename, Spire.Doc.FileFormat.XPS);
            document.Close();

            return new XpsDocument(xpsFilename, FileAccess.Read);
        }
        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}初始化");
            word = new Word();
            word.Init();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffff}初始化End");

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word文档(*.doc;*.docx)|*.doc;*.docx";
            ofd.Title = "导入文档";
            ofd.ValidateNames = true; // 验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true; //验证路径的有效性
            ofd.CheckPathExists = true;//验证路径的有效性
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) //用户点击确认按钮，发送确认消息
            {
                fileName = ofd.FileName;
                WordMain.OpenWord(word, ofd.FileName);
            }
        }
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            word?.CloseFile(fileName);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("定时器");
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.MessageBox.Show("Window_PreviewKeyDown");
        }

        private void StackPanel_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.MessageBox.Show("StackPanel_PreviewKeyDown");
        }
        private void Grid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.MessageBox.Show("Grid_PreviewKeyDown");
            //e.Handled = true;//阻止了文本框接受隧道事件，相应的冒泡事件将不会产生。
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.MessageBox.Show("Grid_KeyDown");
            e.Handled = true;//阻止冒泡事件的产生
        }
        private void StackPanel_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.MessageBox.Show("StackPanel_KeyDown");
        }
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            System.Windows.MessageBox.Show("Window_KeyDown");
        }

        /// <summary>
        /// 输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            editableBox.Visibility = Visibility.Visible;
            readOnlyBlock.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 完成输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            editableBox.Visibility = Visibility.Collapsed;
            readOnlyBlock.Visibility = Visibility.Visible;

            System.Windows.Forms.MessageBox.Show(this.Text);
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            button.Visibility = Visibility.Collapsed;
        }

        private void button_Click_4(object sender, RoutedEventArgs e)
        {
            button2.Visibility = Visibility.Collapsed;
        }

        private void OnPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //var textBox = (TextBox)sender;
                //var binding = textBox.GetBindingExpression(TextBox.TextProperty);
                //if (binding != null)
                //{
                //    // 执行命令并传递参数
                //    binding.UpdateSource();
                //}
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            new ImageList().Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PointingDevice");
                foreach (ManagementObject device in searcher.Get())
                {
                    if (device["PNPDeviceID"].ToString().Contains("Touch"))
                    {
                        System.Windows.MessageBox.Show("This computer has a touch screen.");
                        return;
                    }
                }
                System.Windows.MessageBox.Show("This computer does not have a touch screen.");
                TipBar.Success("", this.TopTips);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ShowTips(TipsMassageType type, string msg, System.Windows.Controls.Panel panel)
        {
            var tip = new TipBar
            {
                Text = msg,
                IsAutoClose = true
            };

            switch (type)
            {
                case TipsMassageType.Info:
                    tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Info_Border") as SolidColorBrush;
                    tip.Foreground = panel?.TryFindResource("Common.TipBar.Info_Foreground") as SolidColorBrush;
                    tip.Background = panel?.TryFindResource("Common.TipBar.Info_Background") as SolidColorBrush;
                    break;
                case TipsMassageType.Success:
                    tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Success_Border") as SolidColorBrush;
                    tip.Foreground = panel?.TryFindResource("Common.TipBar.Success_Foreground") as SolidColorBrush;
                    tip.Background = panel?.TryFindResource("Common.TipBar.Success_Background") as SolidColorBrush;
                    break;
                case TipsMassageType.Error:
                    tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Error_Border") as SolidColorBrush;
                    tip.Foreground = panel?.TryFindResource("Common.TipBar.Error_Foreground") as SolidColorBrush;
                    tip.Background = panel?.TryFindResource("Common.TipBar.Error_Background") as SolidColorBrush;
                    break;
            }

            TipBar.Show(tip, panel);
        }
    }
    public enum TipsMassageType
    {
        Info,
        Success,
        Error
    }
}
