using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace CustomControlLibrary
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlLibrary"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class TipBar : Control
    {
        private const string ElementGridMain = "PART_GridMain";
        static TipBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TipBar), new FrameworkPropertyMetadata(typeof(TipBar)));
        }



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TipBar), new PropertyMetadata(""));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TipBar));


        protected static Dictionary<string, PanelItem> TipsPanel { set; get; } = new Dictionary<string, PanelItem>();

        public static readonly DependencyProperty TipsToolNameProperty = DependencyProperty.RegisterAttached(
            "TipsToolName", typeof(string), typeof(TipBar), new PropertyMetadata("", (o, args) =>
            {
                if (!string.IsNullOrEmpty((string)args.NewValue) && o is Panel panel)
                {
                    SetTipsPanel(panel, (string)args.NewValue);
                    panel.Loaded += Panel_Loaded;
                }
            }));

        public static void SetTipsToolName(DependencyObject element, string value) => element.SetValue(TipsToolNameProperty, value);

        public static string GetTipsToolName(DependencyObject element) => (string)element.GetValue(TipsToolNameProperty);

        public static readonly DependencyProperty DirectionProperty = DependencyProperty.RegisterAttached(
            "Direction", typeof(Direction), typeof(TipBar), new PropertyMetadata(Direction.Top, (o, args) =>
            {
            }));
        public static readonly DependencyProperty HAlignProperty = DependencyProperty.RegisterAttached(
            "HAligin", typeof(HorizontalAlignment), typeof(TipBar), new PropertyMetadata(HorizontalAlignment.Left, (o, args) =>
            {
            }));

        private static void Panel_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Panel panel)
            {
                UpdatePanelRotate(panel);
            }
        }

        private static void UpdatePanelRotate(Panel panel)
        {
            if ((Direction)panel.GetValue(TipBar.DirectionProperty) == Direction.Bottom)
            {
                Rotate180(panel);
            }
            else
            {
                Rotate180(panel, 0);
            }
        }

        /// <summary>
        ///     旋转控件
        /// </summary>
        /// <param name="sender">控件实例</param>
        /// <param name="angle">角度</param>
        private static void Rotate180(FrameworkElement sender, int angle = 180)
        {
            RotateTransform rotate = new RotateTransform(angle, sender.ActualWidth / 2, sender.ActualHeight / 2);
            sender.SetValue(Panel.RenderTransformProperty, rotate);
        }
        public static void SetDirection(DependencyObject element, Direction value) => element.SetValue(DirectionProperty, value);

        public static Direction GetDirection(DependencyObject element) => (Direction)element.GetValue(DirectionProperty);
        public static void SetHAligin(DependencyObject element, HorizontalAlignment value) => element.SetValue(DirectionProperty, value);

        public static HorizontalAlignment GetHAligin(DependencyObject element) => (HorizontalAlignment)element.GetValue(DirectionProperty);

        public static readonly DependencyProperty WaitTimeProperty = DependencyProperty.RegisterAttached(
            "WaitTime", typeof(int), typeof(TipBar), new PropertyMetadata(3));
        public static void SetWaitTime(DependencyObject element, int value) => element.SetValue(WaitTimeProperty, value);

        public static int GetWaitTime(DependencyObject element) => (int)element.GetValue(WaitTimeProperty);


        public static readonly DependencyProperty EnterPostionProperty = DependencyProperty.RegisterAttached(
            "EnterPostion", typeof(int), typeof(TipBar), new PropertyMetadata(0));
        public static void SetEnterPostion(DependencyObject element, int value) => element.SetValue(EnterPostionProperty, value);

        public static int GetEnterPostion(DependencyObject element) => (int)element.GetValue(EnterPostionProperty);

        //Vertical垂直，Horizon水平
        public static readonly DependencyProperty EnterStyleProperty = DependencyProperty.RegisterAttached(
            "EnterStyle", typeof(string), typeof(TipBar), new PropertyMetadata("Horizon"));
        public static void SetEnterStyle(DependencyObject element, string value) => element.SetValue(EnterPostionProperty, value);

        public static string GetEnterStyle(DependencyObject element) => (string)element.GetValue(EnterPostionProperty);


        public static readonly DependencyProperty MaxTipCountProperty = DependencyProperty.RegisterAttached(
            "MaxTipCount", typeof(int), typeof(TipBar), new PropertyMetadata(3));
        public static void SetMaxTipCount(DependencyObject element, int value) => element.SetValue(MaxTipCountProperty, value);

        public static int GetMaxTipCount(DependencyObject element) => (int)element.GetValue(MaxTipCountProperty);

        public static readonly DependencyProperty UseMainWindowThemeProperty = DependencyProperty.RegisterAttached(
            "UseMainWindowTheme", typeof(bool), typeof(TipBar), new PropertyMetadata(default(bool)));

        public static void SetUseMainWindowTheme(DependencyObject element, bool value)
        {
            element.SetValue(UseMainWindowThemeProperty, value);
        }

        public static bool GetUseMainWindowTheme(DependencyObject element)
        {
            return (bool)element.GetValue(UseMainWindowThemeProperty);
        }

        private int _waitTime = 3;
        private DispatcherTimer _timerClose;


        protected static void SetTipsPanel(Panel panel, string name)
        {
            if (!TipsPanel.ContainsKey(name))
            {
                TipsPanel.Add(name, new PanelItem(panel));
                panel.SizeChanged += Panel_SizeChanged;
            }
        }

        private static void Panel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePanelRotate((Panel)sender);
        }

        /// <summary>
        ///     成功提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="name">指定控件名</param>
        public static void Success(string msg, string name = "")
        {
            Action<TipBar, Panel> Func_SetTipBar = new Action<TipBar, Panel>((tip, panel) =>
            {
                tip.Text = msg;
                tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Success_Border") as SolidColorBrush;
                tip.Foreground = panel?.TryFindResource("Common.TipBar.Success_Foreground") as SolidColorBrush;
                tip.Background = panel?.TryFindResource("Common.TipBar.Success_Background") as SolidColorBrush;
            });
            Show(Func_SetTipBar, name);
        }
        public static void Success(string msg, Panel panel)
        {
            if (panel == null) return;
            TipBar tip = new TipBar();
            tip.Text = msg;
            tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Success_Border") as SolidColorBrush;
            tip.Foreground = panel?.TryFindResource("Common.TipBar.Success_Foreground") as SolidColorBrush;
            tip.Background = panel?.TryFindResource("Common.TipBar.Success_Background") as SolidColorBrush;
            Show(tip, panel);
        }
        /// <summary>
        ///     一般提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="name">指定控件名</param>
        public static void Info(string msg, string name = "")
        {
            Action<TipBar, Panel> Func_SetTipBar = new Action<TipBar, Panel>((tip, panel) =>
            {
                tip.Text = msg;
                tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Info_Border") as SolidColorBrush;
                tip.Foreground = panel?.TryFindResource("Common.TipBar.Info_Foreground") as SolidColorBrush;
                tip.Background = panel?.TryFindResource("Common.TipBar.Info_Background") as SolidColorBrush;
            });
            Show(Func_SetTipBar, name);
        }
        public static void Info(string msg, Panel panel)
        {
            if (panel == null) return;
            TipBar tip = new TipBar();
            tip.Text = msg;
            tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Info_Border") as SolidColorBrush;
            tip.Foreground = panel?.TryFindResource("Common.TipBar.Info_Foreground") as SolidColorBrush;
            tip.Background = panel?.TryFindResource("Common.TipBar.Info_Background") as SolidColorBrush;
            Show(tip, panel);
        }
        /// <summary>
        ///     错误提示
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="name">指定控件名</param>
        public static void Error(string msg, string name = "")
        {
            Action<TipBar, Panel> Func_SetTipBar = new Action<TipBar, Panel>((tip, panel) =>
            {
                tip.Text = msg;
                tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Error_Border") as SolidColorBrush;
                tip.Foreground = panel?.TryFindResource("Common.TipBar.Error_Foreground") as SolidColorBrush;
                tip.Background = panel?.TryFindResource("Common.TipBar.Error_Background") as SolidColorBrush;
            });
            Show(Func_SetTipBar, name);
        }
        public static void Error(string msg, Panel panel)
        {
            if (panel == null) return;
            TipBar tip = new TipBar();
            tip.Text = msg;
            tip.BorderBrush = panel?.TryFindResource("Common.TipBar.Error_Border") as SolidColorBrush;
            tip.Foreground = panel?.TryFindResource("Common.TipBar.Error_Foreground") as SolidColorBrush;
            tip.Background = panel?.TryFindResource("Common.TipBar.Error_Background") as SolidColorBrush;
            Show(tip, panel);
        }

        /// <summary>
        ///     清空提示
        /// </summary>
        /// <param name="name">指定控件名</param>
        public static void Clear(string name)
        {
            Panel panel;
            if (String.IsNullOrEmpty(name))
            {
                panel = TipsPanel.FirstOrDefault().Value?.Panel;
            }
            else
            {
                panel = TipsPanel.FirstOrDefault(t => t.Key == name).Value?.Panel;
            }
            if (panel != null)
            {
                panel.Children.Clear();
            }
        }

        private static void Tip_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is TipBar obj)
            {
                Rotate180(obj, obj.RotateAngle);
            }
        }

        private Grid _gridMain;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _gridMain = GetTemplateChild(ElementGridMain) as Grid;
            var transform = new TranslateTransform();
            if (this.EnterPosition == 0 && this.EnterStyle == "Horizon")
            {
                this.EnterPosition = (int)MaxWidth;
            }
            if (this.EnterStyle == "Horizon")
            {
                transform.X = this.EnterPosition;
            }
            else if (this.EnterStyle == "Vertical")
            {
                transform.Y = this.EnterPosition;
            }
            else
            {
                return;
            }
            _gridMain.RenderTransform = transform;
            transform.BeginAnimation(this.EnterStyle == "Horizon" ? TranslateTransform.XProperty : TranslateTransform.YProperty, CreateAnimation(0));
            StartTimer();
        }

        public bool IsAutoClose { set; get; } = true;
        private void StartTimer()
        {
            if (IsAutoClose)
            {
                int _tickCount = 0;
                _timerClose = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                _timerClose.Tick += delegate
                {
                    if (IsMouseOver)
                    {
                        _tickCount = 0;
                        return;
                    }

                    _tickCount++;
                    if (_tickCount >= _waitTime) Close();
                };
                _timerClose.Start();
            }
        }
        public int RotateAngle { set; get; } = 0;
        public int EnterPosition { set; get; }
        public string EnterStyle { set; get; }
        /// <summary>
        ///     显示消息-指定容器名
        /// </summary>
        /// <param name="tip">内容</param>
        /// <param name="name">指定控件名</param>
        public static TipBar Show(Action<TipBar, Panel> Func_SetTipBar, string name = "")
        {
            Panel panel = null;

            if (String.IsNullOrEmpty(name))
            {
                panel = TipsPanel.FirstOrDefault().Value?.Panel;
            }
            else
            {
                panel = TipsPanel.FirstOrDefault(t => t.Key == name).Value?.Panel;
            }
            if (panel != null)
            {
                TipBar tip = new TipBar();
                if ("MainWindowTipBarStyle".Equals(panel.Tag?.ToString()))
                {
                    tip.Tag = "MainWindowTipBarStyle";
                }
                Func_SetTipBar(tip, panel);
                tip._waitTime = (int)panel.GetValue(TipBar.WaitTimeProperty);
                int maxCount = (int)panel.GetValue(TipBar.MaxTipCountProperty);
                HorizontalAlignment hAlign = (HorizontalAlignment)panel.GetValue(TipBar.HAlignProperty);

                Application.Current.Dispatcher?.Invoke(() =>
                {
                    tip.EnterPosition = (int)panel.GetValue(TipBar.EnterPostionProperty);
                    tip.EnterStyle = (string)panel.GetValue(TipBar.EnterStyleProperty);
                    if ((Direction)panel.GetValue(TipBar.DirectionProperty) == Direction.Bottom)
                    {
                        tip.RotateAngle = 180;
                        tip.Loaded += Tip_Loaded;
                    }
                    tip.HorizontalAlignment = hAlign;
                    panel.Children.Insert(0, tip);
                    if (maxCount < panel.Children.Count)
                    {
                        panel.Children.RemoveAt(panel.Children.Count - 1);
                    }
                });
                return tip;
            }
            return null;
        }

        private static List<Panel> HasInitPanel = new List<Panel>();
        /// <summary>
        /// 显示提示-指定Panel实例
        /// </summary>
        /// <param name="tip"></param>
        /// <param name="panel"></param>
        public static void Show(TipBar tip, Panel panel)
        {
            if (!HasInitPanel.Contains(panel))
            {
                HasInitPanel.Add(panel);
                //初始化容器事件
                panel.IsVisibleChanged += (sender, e) =>
                {
                    Panel curPanel = sender as Panel;
                    if ((bool)e.NewValue)
                    {
                        HasInitPanel.Remove(curPanel);
                        curPanel.SizeChanged -= Panel_SizeChanged;
                        curPanel.Loaded -= Panel_Loaded;
                    }
                };
                panel.SizeChanged += Panel_SizeChanged;
                panel.Loaded += Panel_Loaded;
            }
            if (panel != null)
            {
                if ("MainWindowTipBarStyle".Equals(panel.Tag?.ToString()))
                {
                    tip.Tag = "MainWindowTipBarStyle";
                }
                tip._waitTime = (int)panel.GetValue(TipBar.WaitTimeProperty);
                int maxCount = (int)panel.GetValue(TipBar.MaxTipCountProperty);
                HorizontalAlignment hAlign = (HorizontalAlignment)panel.GetValue(TipBar.HAlignProperty);

                Application.Current.Dispatcher?.Invoke(() =>
                {
                    tip.EnterPosition = (int)panel.GetValue(TipBar.EnterPostionProperty);
                    tip.EnterStyle = (string)panel.GetValue(TipBar.EnterStyleProperty);
                    if ((Direction)panel.GetValue(TipBar.DirectionProperty) == Direction.Bottom)
                    {
                        tip.RotateAngle = 180;
                        tip.Loaded += Tip_Loaded;
                    }
                    tip.HorizontalAlignment = hAlign;
                    panel.Children.Insert(0, tip);
                    if (maxCount < panel.Children.Count)
                    {
                        panel.Children.RemoveAt(panel.Children.Count - 1);
                    }
                });
            }
        }
        /// <summary>
        ///     移除提示
        /// </summary>
        public void Close()
        {
            _timerClose?.Stop();
            var transform = new TranslateTransform();
            _gridMain.RenderTransform = transform;

            var animation = CreateAnimation(this.EnterPosition);
            animation.Completed += (s, e) =>
            {
                if (Parent is Panel panel)
                {
                    panel.Children.Remove(this);
                }
            };
            transform.BeginAnimation(this.EnterStyle == "Horizon" ? TranslateTransform.XProperty : TranslateTransform.YProperty, animation);
        }
        public static DoubleAnimation CreateAnimation(double toValue, double milliseconds = 200)
        {
            return new DoubleAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(milliseconds)))
            {
                EasingFunction = new PowerEase { EasingMode = EasingMode.EaseInOut }
            };
        }

    }
    public class PanelItem
    {
        public PanelItem(Panel panel)
        {
            this.Panel = panel;
            this.Direction = (Direction)panel.GetValue(TipBar.DirectionProperty);
        }
        public Direction Direction { set; get; } = Direction.Top;
        public Panel Panel { set; get; }
    }
    public enum Direction
    {
        Top,
        Bottom
    }
}
