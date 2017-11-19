using System;
using Microsoft.Practices.ServiceLocation;
using MSO.StimmApp.Services;
using MSO.StimmApp.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MSO.StimmApp
{
    public partial class App : Application
    {
        public static NavigationService NavigationService
            => ServiceLocator.Current.GetInstance<NavigationService>();

        public static bool IsTestMode = true;

        public App()
        {
            this.InitializeComponent();
            //this.InitializeApplicationCache();
 
            var menuPage = new MenuPage();

            var standardPage = (Page)Activator.CreateInstance(typeof(AppStimmerPage));
            menuPage.InitializePage(standardPage);

            this.MainPage = menuPage;
        }

        //private void InitializeApplicationCache()
        //{
        //    Device.OnPlatform
        //    (
        //        Android: () => BlobCache.ApplicationName = "HSApp.Android",
        //        iOS: () => BlobCache.ApplicationName = "HSApp.iOS",
        //        WinPhone: () => BlobCache.ApplicationName = "HSApp.WinPhone",
        //        Default: () => BlobCache.ApplicationName = "HSApp.CrossPlatform"
        //    );
        //}
    }
}
