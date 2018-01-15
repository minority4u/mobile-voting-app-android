using System;
using System.Threading.Tasks;
using MSO.StimmApp.Services;
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

        protected override async void OnAppearing()
        {
            this.AppStimmerView.Opacity = this.AppStimmerView.Scale = 0;
            this.ButtonsView.Opacity = this.ButtonsView.Scale = 0;

            await Task.Delay(Animator.DelaySpeed);

            await Animator.SimpleFade(this.AppStimmerView, Animator.FadeType.In);
            Animator.SimpleFade(this.ButtonsView, Animator.FadeType.In);      
        }

        AppStimmerViewModel ViewModel => this.BindingContext as AppStimmerViewModel;

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await this.ViewModel.LoadAppStimmers();
        //}
    }
}