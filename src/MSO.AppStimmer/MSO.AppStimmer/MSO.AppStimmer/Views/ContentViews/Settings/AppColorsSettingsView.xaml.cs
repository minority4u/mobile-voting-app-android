using System;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.Settings
{
    public partial class AppColorsSettingsView : ContentView
    {
        public AppColorsSettingsView()
        {
            this.InitializeComponent();

            this.ColorThemePicker.Effects.Add(Effect.Resolve(("AndroidEffects.ColoredPickerLineEffect")));
        }

        public SettingsViewModel ViewModel => this.BindingContext as SettingsViewModel;

        private void SaveColorsButton_OnClicked(object sender, EventArgs e)
        {          
            this.ViewModel.SaveSettings();
        }
    }
}