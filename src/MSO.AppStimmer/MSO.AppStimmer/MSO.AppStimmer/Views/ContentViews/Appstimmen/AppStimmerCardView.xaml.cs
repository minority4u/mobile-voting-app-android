using System;
using FFImageLoading.Svg.Forms;
using MSO.StimmApp.Elements;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShapeView;

namespace MSO.StimmApp.Views.ContentViews.Appstimmen
{
	public partial class AppStimmerCardView : ContentView
	{
		public AppStimmerCardView ()
		{
			this.InitializeComponent();

		    this.LayoutChanged += (sender, e) =>
		    {
		        this.SwipeCardView.CardMoveDistance = (int)(this.Width * 0.40f);
		    };
		}

	    public AppStimmerViewModel ViewModel => this.BindingContext as AppStimmerViewModel;

	    private void ShowDetailsImageButton_OnTapped(object sender, EventArgs e)
	    {
	        this.ViewModel.ShowDetailsForCurrentAppStimmer();
	    }
	}
}