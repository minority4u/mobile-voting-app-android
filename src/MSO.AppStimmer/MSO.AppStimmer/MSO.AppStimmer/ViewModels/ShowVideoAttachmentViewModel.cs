using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class ShowVideoAttachmentViewModel : BaseViewModel
    {
        private AppStimmerAttachment attachment;
        private double progressValue;
        private double totalLength;
        private double elapsed;
        private RelayCommand seekCommand;
        private RelayCommand togglePlaybackCommand;
        private bool isPlaying;
        private RelayCommand submitCommand;

        [PreferredConstructor]
        public ShowVideoAttachmentViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
            this.IsPlaying = true;

            CrossMediaManager.Current.VideoPlayer.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.ProgressValue = e.Progress;
                    this.TotalLength = e.Duration.TotalSeconds;
                    this.Elapsed = e.Position.TotalSeconds;
                });
            };
        }

        public RelayCommand SeekCommand => this.seekCommand ?? (this.seekCommand =
            new RelayCommand(this.Seek));

        public RelayCommand TogglePlaybackCommand => this.togglePlaybackCommand?? (this.togglePlaybackCommand =
            new RelayCommand(this.TogglePlayback));

        public RelayCommand SubmitCommand => this.submitCommand ?? (this.submitCommand =
            new RelayCommand(this.Submit));

        private async void Submit()
        {
            Messenger.Default.Send(new AppStimmerAttachmentAddedMessage(this.Attachment));
            await PopupNavigation.PopAllAsync();
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

        public void Start()
        {
            CrossMediaManager.Current.VideoPlayer.Play();
            this.IsPlaying = true;
        }

        private void Seek()
        {
            CrossMediaManager.Current.VideoPlayer.Seek(TimeSpan.FromMilliseconds(this.ProgressValue * this.TotalLength));
        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        public bool IsPlaying
        {
            get => this.isPlaying;
            set => this.Set(ref this.isPlaying, value);
        }

        public double ProgressValue
        {
            get
            {
                return this.progressValue;
            } 
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
