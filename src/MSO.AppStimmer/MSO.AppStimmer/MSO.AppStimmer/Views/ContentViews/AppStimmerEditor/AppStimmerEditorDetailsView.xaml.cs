using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using MSO.StimmApp.Views.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerEditorDetailsView : ContentView
    {
        public AppStimmerEditorDetailsView()
        {
            this.InitializeComponent();
        }

        public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        private async void AddAttachmentImageButton_OnTapped(object sender, EventArgs e)
        {
            //this.ViewModel.IsAddingAttachment = true;

            var page = new AddAttachmentPopupPage(this.ViewModel);
            await PopupNavigation.PushAsync(page);
        }
    }
}