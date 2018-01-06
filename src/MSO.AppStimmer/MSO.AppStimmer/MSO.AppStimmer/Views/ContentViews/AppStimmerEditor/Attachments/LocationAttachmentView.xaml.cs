using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Maps;
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

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var viewModel = new MapAttachmentViewModel(this.Attachment);
            App.NavigationService.NavigateTo(PagesKeys.MapsContent, viewModel);
        }
    }
}


