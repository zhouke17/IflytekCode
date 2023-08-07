using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismDemo.Events;

namespace PrismDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal navigationJournal;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand<string> ModuleCommand { get; set; }
        public DelegateCommand NavigationCommand { get; set; }

        public DelegateCommand PubEventCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager, IRegionNavigationJournal regionNavigationJournal, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.navigationJournal = regionNavigationJournal;
            ModuleCommand = new DelegateCommand<string>(OpenNavi);
            NavigationCommand = new DelegateCommand(GoBack);
            PubEventCommand = new DelegateCommand(PubEvent);
            this.eventAggregator = eventAggregator;
        }

        private void PubEvent()
        {
            eventAggregator.GetEvent<MessageEvent>().Publish("Hello,This is MainView!");
        }

        private void GoBack()
        {
            if (navigationJournal.CanGoBack)
            {
                navigationJournal.GoBack();
            }
        }

        private void OpenNavi(string navigationName)
        {
            NavigationParameters keyValuePairs = new NavigationParameters();
            keyValuePairs.Add("ModuleA", "我是ViewA,来自ModuleA");
            keyValuePairs.Add("ModuleB", "我是ViewB,来自ModuleB");
            keyValuePairs.Add("ModuleC", "我是ViewC,来自ModuleC");
            keyValuePairs.Add("Module", "我是MyView,来自MainWindow");
            this.regionManager.Regions["ContentRegion"].RequestNavigate(navigationName, (navigateResult) =>
             {
                 if (navigateResult.Result ?? false)
                 {
                     navigationJournal = navigateResult.Context.NavigationService.Journal;
                 }
             }, keyValuePairs);
        }
    }
}
