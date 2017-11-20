using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Controls
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