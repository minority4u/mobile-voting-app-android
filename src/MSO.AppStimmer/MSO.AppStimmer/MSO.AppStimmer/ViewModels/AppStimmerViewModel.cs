using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Extensions;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
{
    public class AppStimmerViewModel : BaseViewModel
    {
        private AppStimmer currentAppStimmer;
        private readonly IAppStimmerService appStimmerService;
        private ObservableCollection<AppStimmer> appStimmers;


        [PreferredConstructor]
        public AppStimmerViewModel(IAppStimmerService appStimmerService)
        {
            this.appStimmerService = appStimmerService;
            this.AppStimmers = new ObservableCollection<AppStimmer>(this.appStimmerService.GetAllAppStimmers());
            this.AppStimmers.Shuffle();

            this.CurrentAppStimmer = this.appStimmers.First();
        }

        public AppStimmer CurrentAppStimmer
        {
            get => this.currentAppStimmer;
            set => this.Set(ref this.currentAppStimmer, value);
        }

        public ObservableCollection<AppStimmer> AppStimmers
        {
            get => this.appStimmers;
            set => this.Set(ref this.appStimmers, value);
        }
    }
}
