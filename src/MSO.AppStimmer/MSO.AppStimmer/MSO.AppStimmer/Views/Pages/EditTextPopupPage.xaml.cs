using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTextPopupPage : PopupPage
    {
        public EditTextPopupPage(EditAppStimmerTextViewModel viewModel)
        {
            try
            {
                this.InitializeComponent();
                this.BindingContext = viewModel;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }          
        }

        public EditAppStimmerTextViewModel ViewModel => this.BindingContext as EditAppStimmerTextViewModel;

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

        protected override bool OnBackgroundClicked()
        {
            base.OnBackgroundClicked();

            if (this.CloseWhenBackgroundIsClicked)
                PopupNavigation.PopAsync(true);

            return this.CloseWhenBackgroundIsClicked;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // Close Popup when a user clicks the transparent background
            await PopupNavigation.PopAsync(true);
        }

        private void FrameGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // ignore. This method is there just to prevent the view from closing when a user clicks the frame instead of the transparent page background.
        }
    }
}