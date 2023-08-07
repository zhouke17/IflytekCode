using System.Windows;

namespace CustomControls
{
    /// <summary>
    /// 自定义依赖属性
    /// </summary>
    public class CornerButton : System.Windows.Controls.Button
    {
        public CornerRadius MyCornerRadius
        {
            get { return (CornerRadius)GetValue(MyCornerRadiusProperty); }
            set { SetValue(MyCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCornerRadiusProperty =
            DependencyProperty.Register("MyCornerRadius", typeof(CornerRadius), typeof(CornerButton));


    }
    /// <summary>
    /// 自定义附加属性
    /// </summary>
    public class CornerButton2
    {
        public static CornerRadius GetCornerRadius2(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadius2Property);
        }

        public static void SetCornerRadius2(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadius2Property, value);
        }

        // Using a DependencyProperty as the backing store for CornerRadius2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadius2Property =
            DependencyProperty.RegisterAttached("CornerRadius2", typeof(CornerRadius), typeof(CornerButton2));
    }
}
