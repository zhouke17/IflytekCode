using ModuleC.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleC
{
    public class MyModuleC : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewC));
        }
        /// <summary>
        /// 注册导航区域
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>();
        }
    }
}
