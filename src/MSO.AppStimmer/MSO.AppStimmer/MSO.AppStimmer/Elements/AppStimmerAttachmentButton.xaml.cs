using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Maps;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using MSO.StimmApp.Views;
using MSO.StimmApp.Views.Pages;
using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.MediaManager;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
	public partial class AppStimmerAttachmentButton : ContentView
	{
	    public static readonly BindableProperty DescriptionProperty =
	        BindableProperty.Create(nameof(Description), typeof(string), typeof(AppStimmerAttachmentButton), null, BindingMode.TwoWay);

	    public static readonly BindableProperty IconSourceProperty =
	        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(AppStimmerAttachmentButton), null, BindingMode.TwoWay);

        public static readonly BindableProperty AttachmentTypeProperty =
            BindableProperty.Create(nameof(AttachmentType), typeof(AttachmentType), typeof(AppStimmerAttachmentButton), AttachmentType.Picture, BindingMode.TwoWay);

        [PreferredConstructor]
        public AppStimmerAttachmentButton ()
		{
			this.InitializeComponent();
		    this.Root.BindingContext = this;
		}

	    public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        public string Description
	    {
	        get
	        {
	            var result = (string)GetValue(DescriptionProperty);
	            return result;
	        }
	        set => SetValue(DescriptionProperty, value);
	    }

	    public string IconSource
	    {
	        get
	        {
	            var result = (string)GetValue(IconSourceProperty);
	            return result;
	        }
	        set => SetValue(IconSourceProperty, value);
	    }

        public AttachmentType AttachmentType
        {
            get
            {
                var result = (AttachmentType)GetValue(AttachmentTypeProperty);
                return result;
            }
            set => SetValue(AttachmentTypeProperty, value);
        }

        private async void AttachmentImageButton_OnTapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();

            switch (this.AttachmentType)
            {
                case AttachmentType.Audio:
                    this.AddAudio();
                    break;
                case AttachmentType.Video:
                    await this.AddVideo();
                    break;
                case AttachmentType.Picture:
                    await this.AddPicture();
                    break;
                case AttachmentType.GalleryPicture:
                    await this.AddPictureFromGallery();
                    break;
                case AttachmentType.GalleryVideo:
                    await this.AddVideoFromGallery();
                    break;
                case AttachmentType.Location:
                    this.AddLocation();

                    break;
                case AttachmentType.Text:
                    this.AddText();
                    break;
                case AttachmentType.Document:
                    this.AddDocument();
                    break;
            }
        }

	    private async Task AddVideoFromGallery()
	    {
            var file = await CrossMedia.Current.PickVideoAsync();
            if (file == null)
                return;

            var attachment = new AppStimmerAttachment
            {
                AttachmentSource = file.Path,
                AttachmentType = AttachmentType.Video
            };

            var viewModel = new ShowVideoAttachmentViewModel(attachment);
	        var page = new VideoAttachmentPreviewPage(viewModel);
	        await PopupNavigation.PushAsync(page);
        }

        private async Task AddPictureFromGallery()
        {         
            var options = new PickMediaOptions
            {
                CompressionQuality = 50
            };

	        var file = await CrossMedia.Current.PickPhotoAsync(options);
            if (file == null)
                return;

            var attachment = new AppStimmerAttachment
            {
                AttachmentSource = file.Path,
                AttachmentType = AttachmentType.Picture
            };

            var viewModel = new PictureAttachmentPreviewViewModel(attachment);
            var page = new PictureAttachmentPreviewPage(viewModel);         
            await PopupNavigation.PushAsync(page);
        }

	    private async Task AddPicture()
	    {
            await CrossMedia.Current.Initialize();

	        var options = new StoreCameraMediaOptions
	        {
	            CompressionQuality = 50
	        };

            var file = await CrossMedia.Current.TakePhotoAsync(options);
            if (file == null)
                return;

            var attachment = new AppStimmerAttachment
            {
                AttachmentSource = file.Path,
                AttachmentType = AttachmentType.Picture
            };

	        var viewModel = new PictureAttachmentPreviewViewModel(attachment);
	        var page = new PictureAttachmentPreviewPage(viewModel);
	        await PopupNavigation.PushAsync(page);
        }

	    private async Task AddVideo()
	    {
            await CrossMedia.Current.Initialize();

	        var options = new StoreVideoOptions
	        {
	            CompressionQuality = 50
	        };

            var file = await CrossMedia.Current.TakeVideoAsync(options);
            if (file == null)
                return;

            var attachment = new AppStimmerAttachment
            {
                AttachmentSource = file.Path,
                AttachmentType = AttachmentType.Video
            };

	        var viewModel = new ShowVideoAttachmentViewModel(attachment);
	        var page = new VideoAttachmentPreviewPage(viewModel);
	        await PopupNavigation.PushAsync(page);
        }

	    private void AddAudio()
	    {
	        //throw new NotImplementedException();
	    }

	    private void AddLocation()
	    {
            var attachment = new AppStimmerAttachment
	        {
	            AttachmentType = AttachmentType.Location,
                AttachmentSource = string.Empty,
            };

            var viewModel = new MapAttachmentViewModel(attachment);
	        App.NavigationService.NavigateTo(PagesKeys.MapsContent, viewModel);
	    }

	    private void AddText()
	    {
	        //   var attachment = new AppStimmerAttachment
	        //   {
	        //       AttachmentType = AttachmentType.Text
	        //   };

	        //this.ViewModel.AddAttachment(attachment);
	        //Messenger.Default.Send(new AppStimmerAttachmentAddedMessage());
	    }

	    private void AddDocument()
	    {
	        throw new NotImplementedException();
	    }
    }
}