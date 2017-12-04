using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using FFImageLoading.Forms.Droid;
using MSO.StimmApp.Droid;

namespace MSO.AppStimmer.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init();

            LoadApplication(new StimmApp.App());

            Window.SetStatusBarColor(Color.Black);
        }
    }
}