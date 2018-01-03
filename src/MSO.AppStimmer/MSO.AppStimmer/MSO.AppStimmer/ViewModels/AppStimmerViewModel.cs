using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Views;
using MSO.StimmApp.Views.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class AppStimmerViewModel : BaseViewModel
    {
        private AppStimmer currentAppStimmer;
        private readonly IAppStimmerService appStimmerService;
        private ObservableCollection<AppStimmer> appStimmers;
        private RelayCommand showDetailsCommand;
        private RelayCommand swipedLeftCommand;
        private RelayCommand swipedRightCommand;

        [PreferredConstructor]
        public AppStimmerViewModel(IAppStimmerService appStimmerService)
        {
            this.appStimmerService = appStimmerService;
            this.LoadAppStimmers();

            Messenger.Default.Register<AppStimmerAddedMessage>(this, this.OnAppStimmerAdded);
            Messenger.Default.Register<AppStimmerUpdatedMessage>(this, this.OnAppStimmerUpdated);
        }

        private void OnAppStimmerAdded(AppStimmerAddedMessage message)
        {
            Device.BeginInvokeOnMainThread(() =>this.AppStimmers.Add(message.AppStimmer));
        }

        private void OnAppStimmerUpdated(AppStimmerUpdatedMessage message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var existingAppStimmer = this.AppStimmers.FirstOrDefault(a => a.Id == message.AppStimmer.Id);

                if (existingAppStimmer != null)
                {
                    var index = this.appStimmers.IndexOf(existingAppStimmer);
                    this.AppStimmers[index] = message.AppStimmer;
                }
            });
        }

        public async Task LoadAppStimmers()
        {
            var allAppStimmers = await this.appStimmerService.GetAllAppStimmers();
            this.AppStimmers = new ObservableCollection<AppStimmer>(allAppStimmers);
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

        public RelayCommand ShowDetailsCommand => this.showDetailsCommand ?? (this.showDetailsCommand =
            new RelayCommand(this.ShowDetailsForCurrentAppStimmer));

        public RelayCommand SwipedLeftCommand => this.swipedLeftCommand ?? (this.swipedLeftCommand =
            new RelayCommand(this.SwipeLeft));

        public RelayCommand SwipedRightCommand => this.swipedRightCommand ?? (this.swipedRightCommand =
            new RelayCommand(this.SwipeRight));

        private void SwipeLeft()
        {
            this.CurrentAppStimmer.VotedFor = false;
            this.appStimmerService.SaveAppStimmer(this.CurrentAppStimmer);
        }

        private void SwipeRight()
        {
            this.CurrentAppStimmer.VotedFor = true;
            this.appStimmerService.SaveAppStimmer(this.CurrentAppStimmer);
        }

        public void ShowDetailsForCurrentAppStimmer()
        {
            var viewModel = new AppStimmerEditorViewModel(this.appStimmerService, this.CurrentAppStimmer, 
                AppStimmerEditorDisplayType.Overview, isEditable: false);

            App.NavigationService.NavigateTo(PagesKeys.AppStimmerEditor, viewModel);
        }
    }
}
