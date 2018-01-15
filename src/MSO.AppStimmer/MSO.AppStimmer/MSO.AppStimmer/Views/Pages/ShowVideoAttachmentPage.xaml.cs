using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceOrientation.Forms.Plugin.Abstractions;
using MSO.StimmApp.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    public partial class ShowVideoAttachmentPage : PopupPage
    {
        private bool showControls = true;

        public ShowVideoAttachmentPage(ShowVideoAttachmentViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;

            var navigationBarHeight = App.NavigationBarController.Height;
            this.MainGrid.RowDefinitions[0].Height = new GridLength(navigationBarHeight);
            this.MainGrid.RowDefinitions[2].Height = new GridLength(navigationBarHeight);

            //var deviceOrientiation = App.DeviceOrientationService.GetOrientation();
            //this.OnDeviceOrientationChanged(deviceOrientiation);

            //MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
            //{
            //    var deviceOrientation = message.Orientation;
            //    this.OnDeviceOrientationChanged(deviceOrientation);
            //});

            App.NavigationBarController.HideNavigationBar();
        }

        private void OnDeviceOrientationChanged(DeviceOrientations orientation)
        {
            //if (orientation == DeviceOrientations.Portrait)
            //{
            //    this.VideoView.SetValue(Grid.RowProperty, 1);
            //    this.VideoView.SetValue(Grid.RowSpanProperty, 1);
            //}
            //if (orientation == DeviceOrientations.Landscape)
            //{
            //    this.VideoView.SetValue(Grid.RowProperty, 0);
            //    this.VideoView.SetValue(Grid.RowSpanProperty, this.VideoPlayerGrid.RowDefinitions.Count);
            //}
        }

        public ShowVideoAttachmentViewModel ViewModel => this.BindingContext as ShowVideoAttachmentViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VideoView.Source = this.ViewModel.Attachment.AttachmentSource;
            this.ViewModel.Start();          
        }

        protected override void OnDisappearing()
        {
            App.NavigationBarController.ShowNavigationBar();
        }

        private void VideoView_OnTapped(object sender, EventArgs e)
        {
            if (this.showControls)
            {
                this.ControlsStackLayout.FadeTo(0, 250, Easing.Linear);
                App.NavigationBarController.HideNavigationBar();               
            }
            else
            {
                this.ControlsStackLayout.FadeTo(1, 250, Easing.Linear);
                App.NavigationBarController.ShowNavigationBar();
            }

            this.showControls = !this.showControls;
        }

        void PlayClicked(object sender, System.EventArgs e)
        {
            //PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            //PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            //PlaybackController.Stop();
        }
        private void SetVolumeBtn_OnClicked(object sender, EventArgs e)
        {
            //int.TryParse(this.volumeEntry.Text, out var vol);
            //CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
        }

        private void MutedBtn_OnClicked(object sender, EventArgs e)
        {
            //if (CrossMediaManager.Current.VolumeManager.Muted)
            //{
            //    CrossMediaManager.Current.VolumeManager.Muted = false;
            //    mutedBtn.Text = "Mute";
            //}
            //else
            //{
            //    CrossMediaManager.Current.VolumeManager.Muted = true;
            //    mutedBtn.Text = "Unmute";
            //}
        }
    }
}