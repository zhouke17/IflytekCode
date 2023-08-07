using System.Windows;
using System.Windows.Controls;

namespace WpfTestDemo.MyDependencyProperty
{
    public class PasswordBoxWaterMark
    {
        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }

        // Using a DependencyProperty as the backing store for PasswordLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordLengthProperty =
            DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxWaterMark), new PropertyMetadata(0));



        public static bool GetIsUpdating(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatingProperty);
        }

        public static void SetIsUpdating(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatingProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsUpdating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordBoxWaterMark), new PropertyMetadata(false, OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            if (passwordBox == null) return;
            if ((bool)e.NewValue)
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            else
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox == null) return;
            SetPasswordLength(passwordBox, passwordBox.Password.Length);
        }
    }
}
