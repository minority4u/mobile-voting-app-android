using System;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.ViewModels;
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