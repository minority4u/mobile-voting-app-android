using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMainPicturePopupPage : PopupPage
    {
        public AddMainPicturePopupPage()
        {
            this.InitializeComponent();
        }

        public AddMainPicturePopupPage(AppStimmerEditorViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }

        AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        private async void AddCameraButton_OnTapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var options = new StoreCameraMediaOptions
            {
                CompressionQuality = 50
            };

            var file = await CrossMedia.Current.TakePhotoAsync(options);
            if (file == null)
                return;

            var path = file.Path;
            this.ViewModel.AppStimmer.Picture = path;

            await PopupNavigation.PopAsync();
        }

        private async void AddGalleryButton_OnTapped(object sender, EventArgs e)
        {
            var options = new PickMediaOptions
            {
                CompressionQuality = 50
            };

            var file = await CrossMedia.Current.PickPhotoAsync(options);
            if (file == null)
                return;

            var path = file.Path;
            this.ViewModel.AppStimmer.Picture = path;

            await PopupNavigation.PopAsync();
        }
    }
}