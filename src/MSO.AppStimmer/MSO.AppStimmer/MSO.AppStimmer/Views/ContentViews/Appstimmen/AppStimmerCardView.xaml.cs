using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.Appstimmen
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppStimmerCardView : ContentView
	{
		public AppStimmerCardView ()
		{
			InitializeComponent ();

		    this.LayoutChanged += (sender, e) =>
		    {
		        this.SwipeCardView.CardMoveDistance = (int)(this.Width * 0.20f);
		    };	    
        }
	}
}