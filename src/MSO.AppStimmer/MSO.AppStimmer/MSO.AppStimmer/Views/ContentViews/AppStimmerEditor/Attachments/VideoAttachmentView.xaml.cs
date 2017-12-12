using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoAttachmentView : ContentView
    {
        public VideoAttachmentView()
        {
            this.InitializeComponent();

            var bindingContext = this.BindingContext;
            Debug.WriteLine(bindingContext);
        }

        private void VideoPreviewFrame_OnTapped(object sender, EventArgs e)
        {
            Debug.WriteLine(@"Video preview tapped..");
        }
    }
}