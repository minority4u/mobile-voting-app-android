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
    public partial class EditAppStimmerDescriptionPopupPage : ContentPage
    {
        public EditAppStimmerDescriptionPopupPage(EditAppStimmerDescriptionViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }

        public EditAppStimmerDescriptionViewModel ViewModel => this.BindingContext as EditAppStimmerDescriptionViewModel;

        private async void BackButtonImage_OnTapped(object sender, EventArgs e)
        {
            await App.NavigationService.GoBack();
        }

        private async void CancelButton_OnClicked(object sender, EventArgs e)
        {
            await App.NavigationService.GoBack();
        }
    }
}