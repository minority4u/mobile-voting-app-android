using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using MSO.StimmApp.Views.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationAttachmentView : ContentView
    {
        public LocationAttachmentView(AppStimmerAttachment attachment)
        {
            this.InitializeComponent();
            this.BindingContext = attachment;
        }

        public AppStimmerAttachment Attachment => this.BindingContext as AppStimmerAttachment;

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var viewModel = new MapAttachmentViewModel(this.Attachment);
            var page = new MapsContentPage(viewModel);

            await PopupNavigation.PushAsync(page);
        }
    }
}