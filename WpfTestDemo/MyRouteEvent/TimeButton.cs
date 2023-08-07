using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfTestDemo.MyRouteEvent
{
    public class TimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime",RoutingStrategy.Bubble,typeof(EventHandler<ReportTimeEventArgs>),typeof(TimeButton));

        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent,value); }
            remove { this.RemoveHandler(ReportTimeEvent,value); }
        }


        protected override void OnClick()
        {
            base.OnClick();

            ReportTimeEventArgs reportTimeEventArgs = new ReportTimeEventArgs(ReportTimeEvent,this) 
            { 
                ClickTime = DateTime.Now
            };
            this.RaiseEvent(reportTimeEventArgs);
        }
    }
    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) :base(routedEvent, source){}

        public DateTime ClickTime { get; set; }
    }
}
