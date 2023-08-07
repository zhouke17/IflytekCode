using Prism.Events;
using System.Windows.Controls;

namespace PrismDemo.Views
{
    /// <summary>
    /// View.xaml 的交互逻辑
    /// </summary>
    public partial class MyView : UserControl
    {
        private readonly IEventAggregator eventAggregator;

        public MyView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            //this.eventAggregator = eventAggregator;

            //eventAggregator.GetEvent<MessageEvent>().Subscribe(arg =>
            //{
            //    MessageBox.Show($"接收来自MainView的消息：{arg}");
            //});
        }
    }
}
