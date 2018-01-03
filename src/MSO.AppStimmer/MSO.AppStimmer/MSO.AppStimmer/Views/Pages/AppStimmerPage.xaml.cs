using System;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerPage : ContentPage
    {
        public AppStimmerPage()
        {
            this.InitializeComponent();
        }

        AppStimmerViewModel ViewModel => this.BindingContext as AppStimmerViewModel;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.ViewModel.LoadAppStimmers();
        }
    }
}