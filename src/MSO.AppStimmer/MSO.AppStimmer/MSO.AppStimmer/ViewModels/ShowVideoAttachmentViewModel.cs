using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.EventArguments;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class ShowVideoAttachmentViewModel : BaseViewModel
    {
        private string videoPath;
        private double progressValue;
        private double totalLength;
        private double elapsed;
        private RelayCommand seekCommand;
        private RelayCommand togglePlaybackCommand;
        private bool isPlaying;

        [PreferredConstructor]
        public ShowVideoAttachmentViewModel(string videoPath)
        {
            this.VideoPath = videoPath;
            this.IsPlaying = true;

            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.ProgressValue = e.Progress;
                    this.TotalLength = e.Duration.TotalSeconds;
                    this.Elapsed = e.Position.TotalSeconds;
                });
            };

            App.NavigationBarController.HideNavigationBar();
        }

        public RelayCommand SeekCommand => this.seekCommand ?? (this.seekCommand =
            new RelayCommand(this.Seek));

        public RelayCommand TogglePlaybackCommand => this.togglePlaybackCommand?? (this.togglePlaybackCommand =
            new RelayCommand(this.TogglePlayback));

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

        private void Seek()
        {
            CrossMediaManager.Current.Seek(TimeSpan.FromMilliseconds(this.ProgressValue * this.TotalLength));
        }

        public string VideoPath
        {
            get => this.videoPath;
            set => this.Set(ref this.videoPath, value);
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
    }
}
