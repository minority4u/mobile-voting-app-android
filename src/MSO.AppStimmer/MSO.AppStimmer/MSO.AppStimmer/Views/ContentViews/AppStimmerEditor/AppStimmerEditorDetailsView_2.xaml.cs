using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MSO.Common;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using MSO.StimmApp.Views.Pages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerEditorDetailsView_2 : ContentView
    {
        private double imageHeight = 0;
        private string baseGradient;
        private double dragStarted;
        private double previousOffset;
        private ScrollState currentScrollState;
        private ScrollView scrollView;
        private static int addAttachmentButtonVisibilityScroledOffset = 75;

        public AppStimmerEditorDetailsView_2()
        {
            this.InitializeComponent();
            this.baseGradient = "#55000000";

            scrollView = this.AttachmentsScrollView.GetScrollView();
            scrollView.Scrolled += AttachmentsScrollVIew_OnScrolled;

            Messenger.Default.Register<AppStimmerAttachmentAddedMessage>(this, this.OnAppStimmerAttachmentAdded);
            //this.Parallax();
        }

        private async void OnAppStimmerAttachmentAdded(AppStimmerAttachmentAddedMessage message)
        {  
            await Task.Delay(250);
            this.AttachmentsScrollView.ScrollTo(1000);
        }

        private void AttachmentsScrollView_OnScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            this.currentScrollState = e.ScrollState;
            switch (this.currentScrollState)
            {
                case ScrollState.Dragging:
                    this.dragStarted = this.scrollView.ScrollX;
                    break;
            }
        }

        private async void AttachmentsScrollVIew_OnScrolled(object sender, ScrolledEventArgs e)
        {
            var scrolled = this.scrollView.ScrollX;
            var dragged = scrolled - this.dragStarted;

            if (dragged > addAttachmentButtonVisibilityScroledOffset)
            {
                await this.AddAttachmentButton.TranslateTo(130, 0, 250U, Easing.Linear);
                //this.AddAttachmentButton.IsVisible = false;
            }
            if (dragged < addAttachmentButtonVisibilityScroledOffset)
            {
                await this.AddAttachmentButton.TranslateTo(0, 0, 250U, Easing.Linear);
            }           
        }

        private void AdjustGradientsIntensity(double scrollY, double imgHeight)
        {
            var percentageScrolled = scrollY / (imgHeight - this.TopBarGradientFrame.Height);
            if (percentageScrolled <= 0.5 || percentageScrolled >= 1.0)
                return;

            var baseColor = Color.FromHex(this.baseGradient);
            var baseAlpha = baseColor.A;
            var targetAlpha = 0.0;
            var differenceAlpha = baseAlpha - targetAlpha;

            var alphaReduced = ((percentageScrolled - 0.5) * 2) * differenceAlpha;
            var newAlpha = baseAlpha - alphaReduced;

            var intValue = (int) (newAlpha * 255);
            var alphaHex = intValue.ToString("X2");

            var newColor = "#" + alphaHex + "000000";
            this.TitleFrame.EndColor = newColor;
            this.TopBarGradientFrame.StartColor = newColor;

            //Debug.WriteLine("Percentage scrolled: " + percentageScrolled + " Old apha: " + baseAlpha + " New alpha: " + newAlpha + " hex: " + alphaHex);
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
            var scrollY = this.MainScrollView.ScrollY;
            var imgHeight = this.MainPicture.Height;

            this.AdjustMainPicture(scrollY);
            this.AdjustMainPictureOverlay(scrollY, imgHeight);
            this.AdjustTopBarOverlayPosition(scrollY);
            this.AdjustTitlePosition(scrollY, imgHeight);
            this.AdjustGradientsIntensity(scrollY, imgHeight);
            this.AdjustSubmitButtonOpacity(scrollY, imgHeight);
            //this.AdjustTitleBarColor();
            //this.AdjustMainPictureOverlay();
        }

        private void AdjustSubmitButtonOpacity(double scrollY, double imgHeight)
        {
            var percentageScrolled = scrollY / (imgHeight - this.TopBarGradientFrame.Height);

            if (percentageScrolled <= 0.66)
            {
                this.SubmitButton.Opacity = 1.0;
                return;
            }

            var submitButtonOpacity = (percentageScrolled - 0.66) * 3;
            this.SubmitButton.Opacity = 1 - submitButtonOpacity;
        }

        private void AdjustTitlePosition(double scrollY, double imgHeight)
        {
            const int baseFontSize = 30;
            const int targetFontSize = 20;

            const int baseLeftMargin = 15;
            const int targetLeftMargin = 57;

            const int baseTopMargin = 10;
            const int baseBottomMargin = 10;
            const int targetBottomMargin = 13;

            var percentageScrolled = scrollY / (imgHeight - this.TopBarGradientFrame.Height);

            if (percentageScrolled >= 1.0)
            {
                this.ViewModel.DisplayNavigationBarTitle = true;
            }
            else
            {
                this.ViewModel.DisplayNavigationBarTitle = false;
            }

            if (percentageScrolled <= 0.5)
            {
                this.TitleLabel.FontSize = baseFontSize;
                this.TitleLabel.Margin = new Thickness(baseLeftMargin, baseTopMargin, 0, baseBottomMargin);
                return;
            }

            var currentMargin = this.TitleLabel.Margin;

            var leftMarginDifference = targetLeftMargin - baseLeftMargin;
            var addiotionalMargin = ((percentageScrolled - 0.5) * 2) * leftMarginDifference;
            var newLeftMargin = baseLeftMargin + addiotionalMargin;

            var bottomMarginDifference = targetBottomMargin - baseBottomMargin;
            var additionalBottomMargin = ((percentageScrolled - 0.5) * 2) * bottomMarginDifference;
            var newBottomMargin = baseBottomMargin + additionalBottomMargin;

            this.TitleLabel.Margin =
                new Thickness(newLeftMargin, currentMargin.Top, currentMargin.Right, newBottomMargin);

            var difference = baseFontSize - targetFontSize;
            var reached = ((percentageScrolled - 0.5) * 2) * difference;
            var newFontSize = baseFontSize - reached;

            this.TitleLabel.FontSize = newFontSize;
        }

        private void AdjustTopBarOverlayPosition(double scrollY)
        {
            //this.TopBarGradientFrame.TranslationY = scrollY;
        }


        private void AdjustMainPictureOverlay(double scrollY, double imgHeight)
        {
            var percentageScrolled = scrollY / (imgHeight - this.TopBarGradientFrame.Height);
            if (percentageScrolled <= 0.5)
            {
                this.SetNavigationBarOpacity(0);
                this.MainPictureOverlayFrame.Opacity = 0;
                return;
            }

            this.SetNavigationBarOpacity(1);

            var visibleImageHeight = imgHeight - scrollY;
            if (visibleImageHeight <= this.TopBarGradientFrame.Height)
            {
                this.SetNavigationBarOpacity(255);
            }
            else
            {
                this.SetNavigationBarOpacity(0);
                var overlayFrameOpacity = (percentageScrolled - 0.5) * 2;
                //if (overlayFrameOpacity >= 0.9)
                //    overlayFrameOpacity = 0.9;

                this.MainPictureOverlayFrame.Opacity = overlayFrameOpacity;
            }
        }

        private void SetNavigationBarOpacity(int alpha)
        {
            var oldColor = this.ViewModel.NavigationBarBackgroundColor;
            var newColor = new Color(oldColor.R, oldColor.G, oldColor.B, alpha);
            this.ViewModel.NavigationBarBackgroundColor = newColor;
        }

        private void AdjustTitleBarColor()
        {
            //var scrollView = this.MainScrollView;
            //var photoImage = this.MainPicture;

            //var scrolled = scrollView.ScrollY;
            //var imgHeight = 

            //var percentageScrolled = scrolled / imgHeight;

            //var settings = App.Settings.AppColors;
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


        //private void AdjustMainPictureOverlay()
        //{
        //    var scrollView = this.MainScrollView;
        //    var overlayFrame = this.MainPictureOverlayFrame;
        //    var photoImage = this.MainPicture;

        //    var scrolled = scrollView.ScrollY;
        //    var imgHeight = photoImage.Height;

        //    var percentageScrolled = scrolled / imgHeight;

        //    //Debug.WriteLine("Percentage scrolled: " + percentageScrolled);
        //    //overlayFrame.Opacity = percentageScrolled;
        //}

        //private void Parallax2()
        //{
        //    var image = this.MainnPicture;
        //    var imageHeight = image.Height * 3;
        //    var scrollRegion = grid.Height - scrollView.Height;
        //    var parallexRegion = imageHeight - scrollView.Height;
        //    image.TranslationY = scrollView.ScrollY - parallexRegion * (scrollView.ScrollY / scrollRegion);
        //}

        private void AdjustMainPicture(double scrollY)
        {
            var image = this.MainPicture;

            if (this.imageHeight <= 0)
                this.imageHeight = image.Height;

            var y = scrollY * .5;

            if (y >= 0)
            {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
                image.Scale = 1;
                image.TranslationY = y;
            }
            else
            {
                ////Calculate a scale that equalizes the height vs scroll
                var newHeight = this.imageHeight + (scrollY * -1);
                image.Scale = newHeight / this.imageHeight;
                image.TranslationY = scrollY / 2;
            }
        }

        private void BackButtonImage_OnTapped(object sender, EventArgs e)
        {
            //    var page = this.Parent.Parent;

            //    await this.FadeTo(0, 1000, Easing.BounceOut);
            //    
            //}

            if (App.NavigationService.CanGoBack())
            {
                App.NavigationService.GoBack();
            }
            else
            {

            }
        }

        private async void EditDescriptionButton_OnTapped(object sender, EventArgs e)
        {
            if (!this.ViewModel.IsEditable)
                return;

            var viewModel = new EditAppStimmerDescriptionViewModel(this.ViewModel.AppStimmer);
            var page = new EditAppStimmerDescriptionPopupPage(viewModel);

            await PopupNavigation.PushAsync(page);
        }

        private void AttachmentsScrollView_OnSwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            Debug.WriteLine("Swipe started: " + e.SwipeDirection);
        }

        private void AttachmentsScrollView_OnSwiping(object sender, SwipingEventArgs e)
        {
            Debug.WriteLine("Swiping " + e.SwipeDirection);
        }

        private async void MainPicture_OnTapped(object sender, EventArgs e)
        {
            if (!this.ViewModel.IsEditable)
                return;

            var options = new PickMediaOptions
            {
                CompressionQuality = 92
            };
            var file = await CrossMedia.Current.PickPhotoAsync(options);
            if (file == null)
                return;

            var path = file.Path;
            this.ViewModel.AppStimmer.Picture = path;
        }
    }
}