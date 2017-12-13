using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MSO.StimmApp.Droid.Resources;
using MSO.StimmApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(NavigationBarController))]
namespace MSO.StimmApp.Droid.Resources
{
    public class NavigationBarController: INavigationBarController
    {
        //Context CurrentContext => CrossCurrentActivity.Current.Activity;

        public void SetStatusBarColor(Xamarin.Forms.Color color)
        {
            var androidColor = color.ToAndroid();
            ((Activity)Forms.Context).Window.SetNavigationBarColor(androidColor);
        }

        public Color GetStatusBarColor()
        {
            var color = ((Activity) Forms.Context).Window.NavigationBarColor;
            var result = new Color(color);
            return result;
        }

        public Xamarin.Forms.Color Color
        {
            get => this.GetStatusBarColor();
            set => this.SetStatusBarColor(value);
        }

        public int Height
        {
            get => this.GetStatusBarHeight();
        }

        public int ScreenHeight
        {
            get => this.GetScreenHeight();
        }

        public void HideNavigationBar()
        {
            var uiOptions =
                SystemUiFlags.HideNavigation |
                SystemUiFlags.LayoutHideNavigation |
                SystemUiFlags.LayoutFullscreen |
                SystemUiFlags.Fullscreen |
                SystemUiFlags.LayoutStable |
                SystemUiFlags.ImmersiveSticky;

            ((Activity)Forms.Context).Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / ((Activity)Forms.Context).Resources.DisplayMetrics.Density);
            return dp;
        }

        private int GetScreenHeight()
        {
            var metrics = ((Activity)Forms.Context).Resources.DisplayMetrics;
            //var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            var height = metrics.HeightPixels;
            return heightInDp;
        }

        private int GetStatusBarHeight()
        {
            //var height = ViewConfiguration.Get(Android.App.Application.Context).HasPermane
            var resources = ((Activity)Forms.Context).Resources;
            int resourceId = resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                var result = resources.GetDimensionPixelSize(resourceId);
                var result2 = ConvertPixelsToDp(result);
                return result2;
            }
            return 0;
        }
    }
}