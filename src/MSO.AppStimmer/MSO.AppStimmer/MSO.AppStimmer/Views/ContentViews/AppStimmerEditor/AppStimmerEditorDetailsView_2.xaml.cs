using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class AppStimmerEditorDetailsView_2 : ContentView
    {
        private double _imageHeight = 0;

        public AppStimmerEditorDetailsView_2()
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

        private void Parallax()
        {
            var scrollView = this.MainScrollView;
            var photoImage = this.MainPicture;

            if (_imageHeight <= 0)
                _imageHeight = photoImage.Height;

            var y = scrollView.ScrollY * .4;
            if (y >= 0)
            {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
                photoImage.Scale = 1;
                photoImage.TranslationY = y;
            }
            else
            {
                //Calculate a scale that equalizes the height vs scroll
                double newHeight = _imageHeight + (scrollView.ScrollY * -1);
                photoImage.Scale = newHeight / _imageHeight;
                photoImage.TranslationY = scrollView.ScrollY / 2;
            }
        }

        private void MainScrollView_OnScrolled(object sender, ScrolledEventArgs e)
        {
            this.Parallax();
        }
    }
}