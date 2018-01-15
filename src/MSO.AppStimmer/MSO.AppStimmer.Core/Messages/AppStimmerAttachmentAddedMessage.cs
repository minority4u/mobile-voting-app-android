using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Messages
{
    public class AppStimmerAttachmentAddedMessage
    {
        public AppStimmerAttachmentAddedMessage(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
            this.Attachment.IsNew = false;
        }

        public AppStimmerAttachment Attachment { get; set; }
    }
}
