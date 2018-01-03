using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using Xamarin.Forms;

namespace MSO.StimmApp.Models
{
    public class MediaAttachmentViewEntry : ModelBase
    {
        private AppStimmerAttachment attachment;
        private ContentView view;

        public MediaAttachmentViewEntry() : base (true)
        {

        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        public ContentView View
        {
            get => this.view;
            set => this.Set(ref this.view, value);
        }
    }
}
