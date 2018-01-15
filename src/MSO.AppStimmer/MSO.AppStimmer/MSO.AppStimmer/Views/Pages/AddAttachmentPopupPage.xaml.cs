using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Services;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAttachmentPopupPage : PopupPage
    {
        public AddAttachmentPopupPage(AppStimmerEditorViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            var buttons = new List<View>
            {
                this.AddPictureButton,
                this.AddGalleryPictureButton,
                this.AddLocationButton,
                this.AddVideoButton,
                this.AddGalleryVideoButton,
                this.AddDocumentButton,
            };

            foreach (var button in buttons)
            {
                button.Opacity = button.Scale = 0;
            }

            base.OnAppearing();

            await Task.Delay(100);

            foreach (var button in buttons)
            {
                Animator.SimpleFade(button, Animator.FadeType.In, 250);
                await Task.Delay(40);
            }
        }

        public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }

        private void FrameGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // ignore. This method is there just to prevent the view from closing when a user clicks the frame instead of the transparent page background.
        }
    }
}