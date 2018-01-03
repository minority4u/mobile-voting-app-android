using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
    public class AppStimmersViewModel : BaseViewModel
    {
        private readonly IAppStimmerService appStimmerService;
        private ObservableCollection<AppStimmer> appStimmers;

        [PreferredConstructor]
        public AppStimmersViewModel(IAppStimmerService appStimmerService)
        {
            this.appStimmerService = appStimmerService;
            this.LoadAllAppStimmers();

            Messenger.Default.Register<AppStimmerAddedMessage>(this, this.OnAppStimmerAdded);
            Messenger.Default.Register<AppStimmerUpdatedMessage>(this, this.OnAppStimmerUpdated);
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

        private void RemoveJobIfApPStimmerExists(Guid id)
        {
            var existingAppStimmer = this.AppStimmers.SingleOrDefault(a => a.Id == id);
            if (existingAppStimmer != null)
            {
                this.AppStimmers.Remove(existingAppStimmer);
            }
        }

        private void OnAppStimmerAdded(AppStimmerAddedMessage message)
        {
            Device.BeginInvokeOnMainThread(() => this.AppStimmers.Add(message.AppStimmer));
        }


        public async Task LoadAllAppStimmers()
        {
            var allAppStimmers = await this.appStimmerService.GetAllAppStimmers();
            this.AppStimmers = new ObservableCollection<AppStimmer>(allAppStimmers);
        }

        public ObservableCollection<AppStimmer> AppStimmers
        {
            get => this.appStimmers;
            set => this.Set(ref this.appStimmers, value);
        }

        public void EditAppStimmer(AppStimmer appStimmer)
        {
            var viewModel = new AppStimmerEditorViewModel(this.appStimmerService, appStimmer, AppStimmerEditorDisplayType.Details, isEditable: false);
            App.NavigationService.NavigateTo(PagesKeys.AppStimmerEditor, viewModel);
        }
    }
}
