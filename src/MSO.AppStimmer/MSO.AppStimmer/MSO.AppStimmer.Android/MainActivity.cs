using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using DeviceOrientation.Forms.Plugin.Droid;
using FFImageLoading.Forms.Droid;
using MSO.StimmApp.Droid.Resources;
using MSO.StimmApp.Services;
using Plugin.MediaManager.Forms.Android;
using Xamarin.Forms.Platform.Android;
using Resource = MSO.StimmApp.Droid.Resource;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Color = Android.Graphics.Color;
using Permission = Android.Content.PM.Permission;

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

            DependencyService.Register<ISoftwareKeyboardService, SoftwareKeyboardService>();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init();
            VideoViewRenderer.Init();
            DeviceOrientationImplementation.Init();

            LoadApplication(new StimmApp.App());

            Window.SetStatusBarColor(Color.Black);
            Window.SetNavigationBarColor(Color.Black);

            //Notification.Builder builder = new Notification.Builder(this)
            //    .SetContentTitle("Sample Notification")
            //    .SetContentText("Hello World! This is my first notification!")
            //    .SetSmallIcon(Resource.Drawable.ic_group_expand_02);

            //// Build the notification:
            //Notification notification = builder.Build();

            //// Get the notification manager:
            //NotificationManager notificationManager =
            //    GetSystemService(Context.NotificationService) as NotificationManager;

            //// Publish the notification:
            //const int notificationId = 0;
            //notificationManager.Notify(notificationId, notification);

            //XFGloss.Droid.Library.Init(this, bundle);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnConfigurationChanged(global::Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            DeviceOrientationImplementation.NotifyOrientationChange(newConfig);
        }
    }
}