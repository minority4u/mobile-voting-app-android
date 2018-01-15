using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Implementations;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class AudioAttachmentViewModel : BaseViewModel
    {
        private AppStimmerAttachment attachment;
        private double progressValue;
        private double totalLength;
        private double elapsed;
        private bool isPlaying;
        private RelayCommand seekCommand;
        private RelayCommand togglePlaybackCommand;
        private RelayCommand startCommand;

        [PreferredConstructor]
        public AudioAttachmentViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
            this.IsPlaying = true;

            CrossMediaManager.Current.AudioPlayer.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Debug.WriteLine("progress: " + e.Progress);
                    this.ProgressValue = e.Progress / 100;
                    this.TotalLength = e.Duration.TotalSeconds;
                    this.Elapsed = e.Position.TotalSeconds;
                });
            };
        }

        public RelayCommand SeekCommand => this.seekCommand ?? (this.seekCommand =
            new RelayCommand(this.Seek));

        public RelayCommand TogglePlaybackCommand => this.togglePlaybackCommand ?? (this.togglePlaybackCommand =
            new RelayCommand(this.TogglePlayback));

        public RelayCommand StartCommand => this.startCommand ?? (this.startCommand =
            new RelayCommand(this.Start));

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        public async void Start()
        {
            await CrossMediaManager.Current.AudioPlayer.Play(new MediaFile(this.Attachment.AttachmentSource));
        }

        public bool IsPlaying
        {
            get => this.isPlaying;
            set => this.Set(ref this.isPlaying, value);
        }

        public double ProgressValue
        {
            get => this.progressValue;
            set => this.Set(ref this.progressValue, value);
        }

        public double TotalLength
        {
            get => this.totalLength;
            set => this.Set(ref this.totalLength, value);
        }

        public double Elapsed
        {
            get => this.elapsed;
            set => this.Set(ref this.elapsed, value);
        }

        private void Seek()
        {
            CrossMediaManager.Current.VideoPlayer.Seek(TimeSpan.FromMilliseconds(this.ProgressValue * this.TotalLength));
        }

        private void TogglePlayback()
        {
            if (this.IsPlaying)
            {
                App.PlaybackController.Pause();
            }
            else
            {
                App.PlaybackController.Play();
            }

            this.IsPlaying = !this.IsPlaying;
        }

    }
}
