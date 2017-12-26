using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.Common;
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
        private double imageHeight = 0;

        private string baseTitleBarColor;

        public AppStimmerEditorDetailsView_2()
        {
            this.InitializeComponent();
            //this.baseTitleBarColor = App.Settings.AppColors.TitleBarColor;
        }

        public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        private async void AddAttachmentImageButton_OnTapped(object sender, EventArgs e)
        {
            //this.ViewModel.IsAddingAttachment = true;

            var page = new AddAttachmentPopupPage(this.ViewModel);
            await PopupNavigation.PushAsync(page);
        }

        private void MainScrollView_OnScrolled(object sender, ScrolledEventArgs e)
        {
            this.Parallax();
        }

        private void Parallax()
        {
            this.AdjustMainPicture();
            this.AdjustTitleBarColor();
            //this.AdjustMainPictureOverlay();
        }

        private void AdjustTitleBarColor()
        {
            var scrollView = this.MainScrollView;
            var photoImage = this.MainPicture;

            var scrolled = scrollView.ScrollY;
            var imgHeight = photoImage.Height;

            var percentageScrolled = scrolled / imgHeight;

            var settings = App.Settings.AppColors;
            //var cloned = settings.CloneJson();

            //if (percentageScrolled > 0.5)
            //{
            //    cloned.TitleBarColor = "#000000FF";             
            //}
            //else
            //{
            //    cloned.TitleBarColor = this.baseTitleBarColor;
            //}

            //App.Settings.AppColors = cloned;
        }


        private void AdjustMainPictureOverlay()
        {
            var scrollView = this.MainScrollView;
            var overlayFrame = this.MainPictureOverlayFrame;
            var photoImage = this.MainPicture;

            var scrolled = scrollView.ScrollY;
            var imgHeight = photoImage.Height;

            var percentageScrolled = scrolled / imgHeight;

            //Debug.WriteLine("Percentage scrolled: " + percentageScrolled);
            //overlayFrame.Opacity = percentageScrolled;
        }

        //private void Parallax2()
        //{
        //    var image = this.MainnPicture;
        //    var imageHeight = image.Height * 3;
        //    var scrollRegion = grid.Height - scrollView.Height;
        //    var parallexRegion = imageHeight - scrollView.Height;
        //    image.TranslationY = scrollView.ScrollY - parallexRegion * (scrollView.ScrollY / scrollRegion);
        //}

        private void AdjustMainPicture()
        {
            var scrollView = this.MainScrollView;
            var photoImage = this.MainPicture;
            var title = this.TitleFrame;

            if (this.imageHeight <= 0)
                this.imageHeight = photoImage.Height;

            var y = scrollView.ScrollY * .4;

            if (y >= 0)
            {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
                photoImage.Scale = 1;
                photoImage.TranslationY = y;
                title.TranslationY = -y;
            }
            else
            {
                Debug.WriteLine("Else");
                ////Calculate a scale that equalizes the height vs scroll
                double newHeight = this.imageHeight + (scrollView.ScrollY * -1);
                photoImage.Scale = newHeight / this.imageHeight;
                photoImage.TranslationY = scrollView.ScrollY / 2;
            }
        }
    }
}