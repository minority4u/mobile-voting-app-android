using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    public partial class ShowVideoAttachmentPage : PopupPage
    {
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public ShowVideoAttachmentPage()
        {
            this.InitializeComponent();
            this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
            //Initialize Volume settings to match interface
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
            //CrossMediaManager.Current.VolumeManager.Muted = false;

            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ProgressBar.Progress = e.Progress;
                    Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
                });
            };
        }

        protected override void OnAppearing()
        {
            videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
            base.OnAppearing();
        }

        void PlayClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Stop();
        }
        private void SetVolumeBtn_OnClicked(object sender, EventArgs e)
        {
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
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