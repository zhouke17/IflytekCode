using System.Windows;
using System.Windows.Controls;

namespace WpfTestDemo.MyDependencyProperty
{
    public class PassWordAttached
    {
        public static string GetPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdProperty);
        }

        public static void SetPwd(DependencyObject obj, string value)
        {
            obj.SetValue(PwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.RegisterAttached("Pwd", typeof(string), typeof(PassWordAttached), new PropertyMetadata(null, new PropertyChangedCallback((s, e) =>//使用依赖属性的值变化的回调
            {
                var passwordbox = s as PasswordBox;
                if (passwordbox != null)
                {
                    passwordbox.PasswordChanged -= Passwordbox_PasswordChanged;
                    passwordbox.PasswordChanged += Passwordbox_PasswordChanged;
                }
            })));

        private static void Passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            SetPwd(passwordBox, passwordBox.Password);//将密码内容传递出去给到后端的PassWord属性，从而实现数据绑定。
        }
    }
}
