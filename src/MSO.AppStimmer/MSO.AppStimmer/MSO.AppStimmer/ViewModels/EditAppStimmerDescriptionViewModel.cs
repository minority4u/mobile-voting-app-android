using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Enums;
using Rg.Plugins.Popup.Services;

namespace MSO.StimmApp.ViewModels
{
    public class EditAppStimmerDescriptionViewModel : BaseViewModel
    {
        private string text;
        private AppStimmer appStimmer;
        private RelayCommand saveDescriptionCommand;

        public EditAppStimmerDescriptionViewModel(AppStimmer appStimmer)
        {
            this.AppStimmer = appStimmer;
            this.Text = appStimmer.Description;
        }

        public RelayCommand SaveDescriptionCommand => this.saveDescriptionCommand ?? (this.saveDescriptionCommand =
            new RelayCommand(this.SaveText));

        private async void SaveText()
        {
            this.AppStimmer.Description = this.Text;
            await PopupNavigation.PopAsync(true);
        }

        public string Text
        {
            get => this.text;
            set => this.Set(ref this.text, value);
        }

        public AppStimmer AppStimmer
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value);
        }
    }
}
