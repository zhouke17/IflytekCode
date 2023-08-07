using CustomControls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfTestDemo.MyRouteEvent;

namespace WpfTestDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region 属性
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string passWord2;

        public string PassWord2
        {
            get { return passWord2; }
            set
            {
                passWord2 = value;
                OnPropertyChanged();
            }
        }




        public string PassWord
        {
            get { return (string)GetValue(PassWordProperty); }
            set { SetValue(PassWordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassWord.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassWordProperty =
            DependencyProperty.Register("PassWord", typeof(string), typeof(MainWindow), new PropertyMetadata(""));


        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.RootGrid.AddHandler(CornerButton.ClickEvent, new RoutedEventHandler(CornerButton_Click));//添加内置路由事件的路由处理程序

            this.RootGrid.AddHandler(TimeButton.ReportTimeEvent,new RoutedEventHandler(RootEvent_Listener));//添加自定义路由事件的路由处理程序
        }

        private void RootEvent_Listener(object sender, RoutedEventArgs e)
        {
            var args = e as ReportTimeEventArgs;
            var originalSource = $"VisualTree start point：{(args.OriginalSource as FrameworkElement).Name}， Type is ：{args.OriginalSource.GetType().Name}";

            var source = $"LogicalTree start point：{(args.Source as FrameworkElement).Name}， Type is ：{args.Source.GetType().Name}";


            MessageBox.Show($"{args.ClickTime.ToLocalTime()}\r\n{originalSource}\r\n{source}");

        }

        private void CornerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as FrameworkElement).Name);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInfo(new TipsMassageBody { IsAutoClose = true, Message = "窗体加载完成", MessageType = TipsMassageType.Info }, this.TopTips);
        }

        private void ShowInfo(TipsMassageBody msg, Panel panel)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var tip = new TipBar
                {
                    Text = msg.Message,
                    IsAutoClose = msg.IsAutoClose
                };

                switch (msg.MessageType)
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
            }));
        }

        private void pwdBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //PassWord = pwdBox.Password;
        }

        private void stackPanel_ReportTime(object sender, ReportTimeEventArgs e)
        {
            var originalSource = $"VisualTree start point：{(e.OriginalSource as FrameworkElement).Name}， Type is ：{e.OriginalSource.GetType().Name}";

            var source = $"LogicalTree start point：{(e.Source as FrameworkElement).Name}， Type is ：{e.Source.GetType().Name}";


            MessageBox.Show($"{e.ClickTime.ToLocalTime()}\r\n{originalSource}\r\n{source}");
        }
    }

    public class TipsMassageBody
    {
        public TipsMassageType MessageType { get; set; }
        public string Message { get; set; }
        public bool IsAutoClose { get; set; }

        public bool VisibleOnIndexScreen { get; set; } = true;
    }

    public enum TipsMassageType
    {
        Info,
        Success,
        Error
    }
}
