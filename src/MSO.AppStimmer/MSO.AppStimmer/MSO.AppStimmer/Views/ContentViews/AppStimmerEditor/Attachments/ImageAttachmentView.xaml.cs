using System;
using MSO.StimmApp.Views.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageAttachmentView : ContentView
	{
		public ImageAttachmentView ()
		{
			this.InitializeComponent ();
		}

	    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        var page = new ShowImageAttachmentPage(this.BindingContext);
	        await PopupNavigation.PushAsync(page);
        }
	}
}