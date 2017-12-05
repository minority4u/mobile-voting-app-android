using System;
using GalaSoft.MvvmLight.Ioc;
using MSO.Common;
using MSO.StimmApp.Core.ViewModels;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private int appPrimaryColorRedChannel;
        private int appPrimaryColorGreenChannel;
        private int appPrimaryColorBlueChannel;

        [PreferredConstructor]
        public SettingsViewModel()
        {
            var colorFromSettingsHex = App.Settings.AppPrimaryColor;
            var colorFromSettings = Color.FromHex(colorFromSettingsHex);

            this.AppPrimaryColorRedChannel = Convert.ToInt32(255 * colorFromSettings.R);
            this.AppPrimaryColorGreenChannel = Convert.ToInt32(255 * colorFromSettings.G);
            this.AppPrimaryColorBlueChannel = Convert.ToInt32(255 * colorFromSettings.B);
        }

        public int AppPrimaryColorRedChannel
        {
            get => this.appPrimaryColorRedChannel;
            set => this.Set(ref this.appPrimaryColorRedChannel, value);
        }

        public int AppPrimaryColorGreenChannel
        {
            get => this.appPrimaryColorGreenChannel;
            set => this.Set(ref this.appPrimaryColorGreenChannel, value);
        }

        public int AppPrimaryColorBlueChannel
        {
            get => this.appPrimaryColorBlueChannel;
            set => this.Set(ref this.appPrimaryColorBlueChannel, value);
        }

        public void SaveSettings()
        {
            var redHex = AppPrimaryColorRedChannel.ToString("X2");
            var greenHex = AppPrimaryColorGreenChannel.ToString("X2");
            var blueHex = AppPrimaryColorBlueChannel.ToString("X2");
            var colorStringHex = "#" + redHex + greenHex + blueHex;

            var newAppColors = App.Settings.AppColors.CloneJson();
            newAppColors.AppPrimaryColor = colorStringHex;

            App.Settings.AppColors = newAppColors;
        }
    }
}
