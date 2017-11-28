using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
{
    public class AppStimmersViewModel : BaseViewModel
    {
        private readonly IAppStimmerService appStimmerService;
        private ObservableCollection<AppStimmer> appStimmers;

        [PreferredConstructor]
        public AppStimmersViewModel(IAppStimmerService appStimmerService)
        {
            this.appStimmerService = appStimmerService;
            this.appStimmers = new ObservableCollection<AppStimmer>(this.appStimmerService.GetAllAppStimmers());
            //this.appStimmers.Shuffle();
        }

        public ObservableCollection<AppStimmer> AppStimmers
        {
            get => this.appStimmers;
            set => this.Set(ref this.appStimmers, value);
        }
    }
}
