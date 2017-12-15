using System;
using System.Diagnostics;
using FFImageLoading.Forms;
using MSO.StimmApp.ViewModels;
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
		    this.InitializeComponent();
	        this.Root.BindingContext = this;
	    }

	    public static readonly BindableProperty ViewModelProperty =
	        BindableProperty.Create(nameof(ViewModel), typeof(ImageAttachmentViewModel), typeof(ImageAttachmentView), null, BindingMode.TwoWay);

	    public ImageAttachmentViewModel ViewModel
	    {
	        get
	        {
	            var result = (ImageAttachmentViewModel)GetValue(ViewModelProperty);
	            return result;
	        }
	        set => SetValue(ViewModelProperty, value);
	    }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        var page = new ShowImageAttachmentPage(this.ViewModel.Attachment);
	        await PopupNavigation.PushAsync(page);
        }

        private void NoPhotoPicture_OnTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("No photo tapped!");
        }

	    private void ImageView_OnError(object sender, CachedImageEvents.ErrorEventArgs e)
	    {
	        var source = Constants.NoImageProvidedImageSource;
            this.ImageView.Source = source;
	    }
	}
}