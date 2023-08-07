using System.Windows;
using System.Windows.Media;

namespace DependencyProDemo
{
    /// <summary>
    /// 附加属性：旋转角度
    /// </summary>
    public class AttachProperty : DependencyObject
    {
        public static double GetAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject obj, double value)
        {
            obj.SetValue(AngleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(AttachProperty), new PropertyMetadata(0.0, propertyChangedCallback));

        /// <summary>
        /// 赋值后回调
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = (UIElement)d;
            if (uiElement != null)
            {
                uiElement.RenderTransformOrigin = new Point(0.5, 0.5);
                uiElement.RenderTransform = new RotateTransform((double)e.NewValue);
            }
        }
    }
}
