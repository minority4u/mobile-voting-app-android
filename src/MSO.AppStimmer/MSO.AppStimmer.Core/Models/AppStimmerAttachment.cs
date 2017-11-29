using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;

namespace MSO.StimmApp.Core.Models
{
    public class AppStimmerAttachment : ModelBase
    {
        private string source;
        private string description;
        private AttachmentType attachmentType;

        public AppStimmerAttachment() : base(true)
        {
            this.Id = Guid.NewGuid();
        }

        public string Source
        {
            get => this.source;
            set => this.Set(ref this.source, value);
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
