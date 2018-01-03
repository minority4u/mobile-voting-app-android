using System;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerEditorPage : ContentPage
    { 
        public AppStimmerEditorPage()
        {
            this.InitializeComponent();
        }

        public AppStimmerEditorPage(AppStimmerEditorViewModel viewModel)
        {          
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }

        //protected override async void OnDisappearing()
        //{
        //    await this.FadeTo(0, 1000, Easing.BounceOut);
        //    base.OnDisappearing();
        //}

        public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        //private void OverviewTab_OnTapped(object sender, EventArgs e)
        //{
        //    this.ViewModel.DisplayType = AppStimmerEditorDisplayType.Overview;
        //}

        //private void Details_OnTapped(object sender, EventArgs e)
        //{
        //    this.ViewModel.DisplayType = AppStimmerEditorDisplayType.Details;
        //}
    }
}