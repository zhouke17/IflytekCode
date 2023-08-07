using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class MyModuleA : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
        /// <summary>
        /// 模块中注册导航区域
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
