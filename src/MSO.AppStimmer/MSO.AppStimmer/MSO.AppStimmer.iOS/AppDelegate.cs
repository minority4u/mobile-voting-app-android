
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using UIKit;

namespace MSO.AppStimmer.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
		    Xamarin.FormsMaps.Init();

            SfListViewRenderer.Init();
            LoadApplication(new StimmApp.App());

			return base.FinishedLaunching(app, options);
		}
	}
}
