using System;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppColorsSettingsView : ContentView
    {
        public AppColorsSettingsView()
        {
            this.InitializeComponent();

            this.RedSlider.Effects.Add(Effect.Resolve(("SliderEffects.RedSliderEffect")));
            this.GreenSlider.Effects.Add(Effect.Resolve(("SliderEffects.GreenSliderEffect")));
            this.BlueSlider.Effects.Add(Effect.Resolve(("SliderEffects.BlueSliderEffect")));
        }

        public SettingsViewModel ViewModel => this.BindingContext as SettingsViewModel;

        private void SaveColorsButton_OnClicked(object sender, EventArgs e)
        {          
            this.ViewModel.SaveSettings();
        }
    }
}