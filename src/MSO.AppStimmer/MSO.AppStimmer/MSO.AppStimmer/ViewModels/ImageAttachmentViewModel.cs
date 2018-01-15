using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
{
    public class ImageAttachmentViewModel : BaseViewModel
    {
        //private AttachmentType attachmentType;
        //private string attachmentSource;
        //private string descritpion;
        private AppStimmerAttachment attachment;

        //public ImageAttachmentViewModel(AttachmentType attachmentType, string attachmentSource, string description)
        //{
        //    this.AttachmentSource = attachmentSource;
        //    this.Description = description;
        //    this.AttachmentType = attachmentType;
        //}

        public ImageAttachmentViewModel(AppStimmerAttachment arrachment)
        {
            this.Attachment = arrachment;
        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        //public AttachmentType AttachmentType
        //{
        //    get => this.attachmentType;
        //    set => this.Set(ref this.attachmentType, value);
        //}

        //public string AttachmentSource
        //{
        //    get => this.attachmentSource;
        //    set => this.Set(ref this.attachmentSource, value);
        //}

        //public string Description
        //{
        //    get => this.descritpion;
        //    set => this.Set(ref this.descritpion, value);
        //}
    }
}
