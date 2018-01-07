using System;
using System.Collections.Generic;
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
    public partial class AddAttachmentPopupPage : PopupPage
    {
        public AddAttachmentPopupPage(AppStimmerEditorViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
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