using ModuleB.ViewModels;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleB
{
    public class MyModuleB : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewB));
        }
        /// <summary>
        /// 注册导航区域
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
        }
    }
}
