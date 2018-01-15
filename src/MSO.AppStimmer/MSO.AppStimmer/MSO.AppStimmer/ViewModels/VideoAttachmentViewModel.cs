using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Plugin.MediaManager;

namespace MSO.StimmApp.ViewModels
{
    public class VideoAttachmentViewModel : BaseViewModel
    {
        private AppStimmerAttachment attachment;

        public VideoAttachmentViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
            //this.Seek();
            //App.PlaybackController.Pause();
        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        private void Seek()
        {
            CrossMediaManager.Current.Seek(TimeSpan.FromMilliseconds(1000));
        }
    }
}
