using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
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

            await PopupNavigation.PopAllAsync();
        }

	    private void AddDocument()
	    {
	        throw new NotImplementedException();
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

	        this.ViewModel.AddAttachment(attachment);
	        Messenger.Default.Send(new AppStimmerAttachmentAddedMessage());
	    }

	    private async Task AddPictureFromGallery()
        {
            var options = new PickMediaOptions
            {
                CompressionQuality = 92
            };
	        var file = await CrossMedia.Current.PickPhotoAsync(options);
            if (file == null)
                return;

            var attachment = new AppStimmerAttachment
            {
                AttachmentSource = file.Path,
                AttachmentType = AttachmentType.Picture
            };

            this.ViewModel.AddAttachment(attachment);
            Messenger.Default.Send(new AppStimmerAttachmentAddedMessage());
        }

	    private void AddLocation()
	    {
	        throw new NotImplementedException();
	    }

	    private void AddText()
	    {
            var attachment = new AppStimmerAttachment
            {
                AttachmentType = AttachmentType.Text
            };

	        this.ViewModel.AddAttachment(attachment);
	        Messenger.Default.Send(new AppStimmerAttachmentAddedMessage());
        }

	    private async Task AddPicture()
	    {
	        await CrossMedia.Current.Initialize();


	        var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
	        if (file == null)
	            return;

	        var attachment = new AppStimmerAttachment
	        {
	            AttachmentSource = file.Path,
	            AttachmentType = AttachmentType.Picture
	        };

	        this.ViewModel.AddAttachment(attachment);
	        Messenger.Default.Send(new AppStimmerAttachmentAddedMessage());
        }

	    private async Task AddVideo()
	    {
	        await CrossMedia.Current.Initialize();

	        var file = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions());
	        if (file == null)
	            return;

	        var attachment = new AppStimmerAttachment
	        {
	            AttachmentSource = file.Path,
	            AttachmentType = AttachmentType.Video
	        };

	        this.ViewModel.AddAttachment(attachment);
	        Messenger.Default.Send(new AppStimmerAttachmentAddedMessage());
        }

	    private void AddAudio()
	    {
	        throw new NotImplementedException();
	    }
	}
}