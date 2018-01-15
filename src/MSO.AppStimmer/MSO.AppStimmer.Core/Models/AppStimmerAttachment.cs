using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;

namespace MSO.StimmApp.Core.Models
{
    public class AppStimmerAttachment : BaseAttachment
    {
        private string attachmentSource;
        private string description;
        private AttachmentType attachmentType;

        public AppStimmerAttachment() : base(false)
        {
            this.Id = Guid.NewGuid();
        }

        public string AttachmentSource
        {
            get => this.attachmentSource;
            set => this.Set(ref this.attachmentSource, value);
        }

        public string Description
        {
            get => this.description;
            set => this.Set(ref this.description, value);
        }

        public AttachmentType AttachmentType
        {
            get => this.attachmentType;
            set => this.Set(ref this.attachmentType, value);
        }
    }
}
