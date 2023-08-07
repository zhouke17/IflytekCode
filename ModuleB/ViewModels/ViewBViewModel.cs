using Prism.Mvvm;
using Prism.Regions;
using System;

namespace ModuleB.ViewModels
{
    public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
    {
        public ViewBViewModel()
        {

        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 是否每次导航时重用实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 控制导航(确认导航请求返回True时触发)
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        /// <summary>
        /// 接收参数(进入页面时触发)
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Text = navigationContext.Parameters.GetValue<string>("ModuleB");
        }
        /// <summary>
        /// 确认导航请求(离开页面时触发)
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            //if (MessageBox.Show("确认导航？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
            //{
            //    result = false;
            //}
            continuationCallback(result);
        }
    }
}
