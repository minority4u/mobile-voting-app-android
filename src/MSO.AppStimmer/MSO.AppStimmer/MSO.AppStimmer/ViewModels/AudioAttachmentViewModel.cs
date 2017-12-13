using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Plugin.MediaManager;
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

        [PreferredConstructor]
        public AudioAttachmentViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
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
