using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Extensions;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;
using Xamarin.Forms;

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
            this.appStimmers = new ObservableCollection<AppStimmer>(this.appStimmerService.GetAllAppStimmers());
            //this.appStimmers.Shuffle();

            this.currentAppStimmer = this.appStimmers.First();
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
