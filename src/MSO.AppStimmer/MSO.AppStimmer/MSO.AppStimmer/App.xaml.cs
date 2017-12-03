﻿using System;
using System.Collections.Generic;
using Akavache;
using Microsoft.Practices.ServiceLocation;
using MSO.StimmApp.Core.Helpers;
using MSO.StimmApp.Services;
using MSO.StimmApp.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MSO.StimmApp
{
    public partial class App : Application
    {
        public static NavigationService NavigationService
            => ServiceLocator.Current.GetInstance<NavigationService>();

        public static Dictionary<string, string> ReplaceSvgStringMap = new Dictionary<string, string>();

        public static bool IsTestMode = true;

        public static Settings Settings => Settings.Current;

        public App()
        {
            this.InitializeComponent();
            this.InitializeApplicationCache();
 
            var menuPage = new MenuPage();

            var standardPage = (Page) Activator.CreateInstance(typeof(AppStimmerPage));
            menuPage.InitializePage(standardPage);

            this.MainPage = menuPage;
        }

        private void InitializeApplicationCache()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    BlobCache.ApplicationName = "StimmApp.Android";
                    break;
                case Device.iOS:
                    BlobCache.ApplicationName = "StimmApp.iOS";
                    break;
                case Device.WinPhone:
                    BlobCache.ApplicationName = "StimmApp.WindowsPhone";
                    break;
                default:
                    BlobCache.ApplicationName = "StimmApp";
                    break;
            }
        }
    }
}
