using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Views;

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
        }

        public ObservableCollection<AppStimmer> AppStimmers
        {
            get => this.appStimmers;
            set => this.Set(ref this.appStimmers, value);
        }

        public void EditAppStimmer(AppStimmer appStimmer)
        {
            var viewModel = new AppStimmerEditorViewModel(this.appStimmerService, appStimmer);
            App.NavigationService.NavigateTo(PagesKeys.AppStimmerEditor, viewModel);
        }
    }
}
