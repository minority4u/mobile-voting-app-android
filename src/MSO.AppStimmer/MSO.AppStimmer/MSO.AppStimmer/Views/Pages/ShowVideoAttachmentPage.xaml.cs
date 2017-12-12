using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowVideoAttachmentPage : PopupPage
    {
        public ShowVideoAttachmentPage()
        {
            this.InitializeComponent();
        }

        public ShowVideoAttachmentViewModel ViewModel => this.BindingContext as ShowVideoAttachmentViewModel;

        public ShowVideoAttachmentPage(ShowVideoAttachmentViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
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
    }
}