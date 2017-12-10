using System;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAttachmentView : ContentView
	{
		public AddAttachmentView ()
		{
			this.InitializeComponent();
		}

	    public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        private void CancelAddingAttachgmentImageButton_OnTapped(object sender, EventArgs e)
        {
            // this.ViewModel.IsAddingAttachment = false;
        }
	}
}