using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceOrientation.Forms.Plugin.Abstractions;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoAttachmentPreviewPage : PopupPage
    {
        public VideoAttachmentPreviewPage(ShowVideoAttachmentViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;

            var deviceOrientiation = App.DeviceOrientationService.GetOrientation();
            this.OnDeviceOrientationChanged(deviceOrientiation);

            MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
            {
                var deviceOrientation = message.Orientation;
                this.OnDeviceOrientationChanged(deviceOrientation);
            });
        }

        public ShowVideoAttachmentViewModel ViewModel => this.BindingContext as ShowVideoAttachmentViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VideoView.Source = this.ViewModel.Attachment.AttachmentSource;
            this.ViewModel.Start();         
        }

        private void OnDeviceOrientationChanged(DeviceOrientations orientation)
        {
            if (orientation == DeviceOrientations.Portrait)
            {
                this.VideoView.SetValue(Grid.RowProperty, 1);
                this.VideoView.SetValue(Grid.RowSpanProperty, 1);
            }
            if (orientation == DeviceOrientations.Landscape)
            {
                this.VideoView.SetValue(Grid.RowProperty, 0);
                this.VideoView.SetValue(Grid.RowSpanProperty, this.VideoPlayerGrid.RowDefinitions.Count);
            }
        }

    }
}