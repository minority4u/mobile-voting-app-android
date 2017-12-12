using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Plugin.MediaManager.Forms.Android;
using Xamarin.Forms.Platform.Android;
using Resource = MSO.StimmApp.Droid.Resource;

namespace MSO.AppStimmer.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init();
            VideoViewRenderer.Init();

            LoadApplication(new StimmApp.App());

            Window.SetStatusBarColor(Color.Black);
            Window.SetNavigationBarColor(Color.Black);

            //XFGloss.Droid.Library.Init(this, bundle);
        }
    }
}