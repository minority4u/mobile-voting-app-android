using System;

namespace MSO.StimmApp.Core.Models
{
    public class BaseAttachment : EditableModelBase<AppStimmerAttachment>
    {
        private bool isMainAttachment;
        public BaseAttachment(bool isMainAttachment) : base(true)
        {
            this.IsMainAttachment = isMainAttachment;
        }

        public bool IsMainAttachment
        {
            get => this.isMainAttachment;
            set => this.Set(ref this.isMainAttachment, value);
        }
    }
}