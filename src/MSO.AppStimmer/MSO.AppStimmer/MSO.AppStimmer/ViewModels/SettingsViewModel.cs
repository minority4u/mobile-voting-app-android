using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.ViewModels;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private string appPrimaryColor;

        [PreferredConstructor]
        public SettingsViewModel()
        {
            
        }

        public string AppPrimaryColor
        {
            get => this.appPrimaryColor;
            set => this.Set(ref this.appPrimaryColor, value);
        }
    }
}
