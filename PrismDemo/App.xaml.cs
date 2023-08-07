using Prism.Ioc;
using Prism.Modularity;
using PrismDemo.ViewModels;
using PrismDemo.Views;
using System.Windows;

namespace PrismDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        /// <summary>
        /// 注册导航区域
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MyView, MyViewViewModel>();
        }

        /// <summary>
        /// 注册模块
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<ModuleA.MyModuleA>();//Code方式进行Module加载。
            //moduleCatalog.AddModule<ModuleB.MyModuleB>();//替换为下方AppConfig的方式进行Module加载。

            moduleCatalog.AddModule<ModuleC.MyModuleC>();
            //var moduleAType = typeof(MyModuleC);
            //moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleAType.Name,
            //    ModuleType = moduleAType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog(); // AppConfig方式
        }
    }
}
