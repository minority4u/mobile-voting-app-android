using System;
using System.Diagnostics;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using MSO.StimmApp.Views.Pages;
using Plugin.MediaManager;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoAttachmentView : ContentView
    {
        public VideoAttachmentView()
        {
            this.InitializeComponent();
        }

        public AppStimmerAttachment AppStimmer => this.BindingContext as AppStimmerAttachment;

        private async void VideoPreviewFrame_OnTapped(object sender, EventArgs e)
        {
            var viewModel = new ShowVideoAttachmentViewModel(this.AppStimmer);

            var page = new ShowVideoAttachmentPage(viewModel);
            await PopupNavigation.PushAsync(page);
        }
    }
}