using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DependencyProDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding();
        }

        public void Binding()
        {
            Binding binding = new Binding()
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath("Age")
            };
            txtInput.SetBinding(TextBox.TextProperty, binding);
        }


        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age",
                                        typeof(int),
                                        typeof(MainWindow),
                                        new PropertyMetadata(18, propertyChangedCallback, coerceValueCallback), validateValueCallback);

        /// <summary>
        /// 赋值前验证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool validateValueCallback(object value)
        {
            var age = (int)value;
            if (age > 100)
            {
                MessageBox.Show("超龄");
                return false;
            }
            return age < 100;
        }

        //当进行赋值的时候，成人如果值不在18~100之间，强制将值恢复为18
        private static object coerceValueCallback(DependencyObject d, object baseValue)
        {
            var value = (int)baseValue;
            return value < 18 ? 18 : value;
        }
        /// <summary>
        /// 赋值后的回调
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = (MainWindow)d;
            var textbox = window?.FindName("txtInput") as TextBox;
            if (textbox != null)
            {
                textbox.BorderBrush = Brushes.Blue;
                textbox.BorderThickness = new Thickness(3);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Child.Instance.OverrideMetadata(sender as DependencyObject);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Binding();
        }
    }

    /// <summary>
    /// 重载依赖属性
    /// </summary>
    public class Child : MainWindow
    {
        private static MainWindow mainWindow;
        private static Child _instance;
        public static Child Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Child();
                }
                return _instance;
            }
        }

        public void OverrideMetadata(DependencyObject obj)
        {
            var item = obj as CheckBox;
            if (item == null) return;

            AgeProperty.AddOwner(typeof(Child));
            AgeProperty.OverrideMetadata(typeof(Child), new PropertyMetadata(1, propertyChangedCallback, coerceValueCallback));

            mainWindow = GetWindow(obj) as MainWindow;
            if (mainWindow != null)
            {
                Binding binding = new Binding()
                {
                    Source = this,
                    Path = new PropertyPath("Age")
                };
                var textbox = mainWindow.FindName("txtInput") as TextBox;
                textbox?.SetBinding(TextBox.TextProperty, binding);
            }

        }

        private static object coerceValueCallback(DependencyObject d, object baseValue)
        {
            var value = (int)baseValue;
            return (value < 0 || value > 18) ? 1 : value;

        }


        private static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = mainWindow.FindName("txtInput") as TextBox;
            if (textbox != null)
            {
                textbox.BorderBrush = Brushes.Green;
                textbox.BorderThickness = new Thickness(3);
            }
        }
    }
}
