using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Helpers;
using MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowImageAttachmentPage : PopupPage
    {
        //private readonly Color standardNavigationBarColor;

        public ShowImageAttachmentPage(object bindingContext)
        {
            this.InitializeComponent();
            //this.standardNavigationBarColor = App.NavigationBarController.Color;
            //App.NavigationBarController.Color = Color.FromHex("#000000");
            this.BindingContext = bindingContext;

            var navigationBarHeight = App.NavigationBarController.Height;
            this.NavigationBarOverlayGrid.RowDefinitions[0].Height = new GridLength(navigationBarHeight);

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
            this.ImageZoomContainer.GestureRecognizers.Add(tapGesture);

            //var screenHeight = App.NavigationBarController.ScreenHeight;
            //var navigationBarHeight = App.NavigationBarController.Height;
            //var relativeHeight = (float)navigationBarHeight / (float)screenHeight;

            //var height = this.Height;
            //this.NavigationBarOverlayFrame.HeightRequest = (float) navigationBarHeight;
            //var mainGrid = this.MainGrid;
            //var rowDefinitions = new RowDefinitionCollection();
            //var row1 = new RowDefinition();
            //row1.Height = new GridLength(1 - relativeHeight, GridUnitType.Star);

            //var row2 = new RowDefinition();
            //row2.Height = new GridLength(relativeHeight, GridUnitType.Star);

            //rowDefinitions.Add(row1);
            //rowDefinitions.Add(row2);

            //var imageView = new ShowImageAttachmentView();
            //imageView.SetValue(Grid.RowProperty, 0);
            //imageView.SetValue(Grid.RowSpanProperty, 2);

            //var overlayFrame = new Frame();
            //overlayFrame.BackgroundColor = Color.FromHex("77000000");
            //overlayFrame.SetValue(Grid.RowProperty, 1);

            //mainGrid.RowDefinitions = rowDefinitions;
            //mainGrid.Children.Add(imageView);
            //mainGrid.Children.Add(overlayFrame);

        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            this.ToggleInfoOverlay();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //App.NavigationBarController.Color = this.standardNavigationBarColor;
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        protected override Task OnAppearingAnimationEnd()
        {
            return base.OnAppearingAnimationEnd();
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            return base.OnBackButtonPressed();
            //return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            return this.CloseWhenBackgroundIsClicked;
        }

        private void ToggleInfoOverlay()
        {
            var view1 = this.DescriptionLabel;
            var view2 = this.NavigationBarOverlayFrame;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (view1.IsVisible)
                {
                    await view1.FadeTo(0, 600);
                    view1.IsVisible = false;
                }
                else
                {
                    view1.IsVisible = true;
                    await view1.FadeTo(1, 600);
                }
            });

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (view2.IsVisible)
                {
                    await view2.FadeTo(0, 600);
                    view2.IsVisible = false;
                }
                else
                {
                    view2.IsVisible = true;
                    await view2.FadeTo(1, 600);
                }
            });
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            //var view = this.DescriptionLabel;
            

            Debug.WriteLine("abc");

            //if (view.IsVisible)
            //{
            //    await view.FadeTo(0, 600);
            //    view.IsVisible = false;
            //}

            //else
            //{
            //    view.IsVisible = true;
            //    await view.FadeTo(1, 600);                         
            //}
                
            //this.BottomStackLayout.IsVisible = !this.BottomStackLayout.IsVisible;
        }
    }
}