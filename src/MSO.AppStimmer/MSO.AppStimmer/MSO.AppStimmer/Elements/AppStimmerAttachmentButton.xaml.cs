using System;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Controls
{
	public partial class AppStimmerAttachmentButton : ContentView
	{
	    public static readonly BindableProperty DescriptionProperty =
	        BindableProperty.Create(nameof(Description), typeof(string), typeof(AppStimmerAttachmentButton), null, BindingMode.TwoWay);

	    public static readonly BindableProperty IconSourceProperty =
	        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(AppStimmerAttachmentButton), null, BindingMode.TwoWay);

        public static readonly BindableProperty AttachmentTypeProperty =
            BindableProperty.Create(nameof(AttachmentType), typeof(AttachmentType), typeof(AppStimmerAttachmentButton), AttachmentType.Gallery, BindingMode.TwoWay);

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
            await PopupNavigation.PopAllAsync();
            this.ViewModel.AddAttachment(this.AttachmentType);
        }
	}
}