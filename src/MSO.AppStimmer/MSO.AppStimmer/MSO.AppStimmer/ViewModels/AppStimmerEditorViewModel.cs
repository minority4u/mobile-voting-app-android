﻿using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
{
    public class AppStimmerEditorViewModel : BaseViewModel
    {
        private AppStimmer appStimmer;
        private IAppStimmerService appStimmerService;
        private bool isAddingAttachment;

        [PreferredConstructor]
        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService) :
            this(appStimmerService, new AppStimmer())
        {
            
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer)
        {
            this.appStimmerService = appStimmerService;
            this.appStimmer = appStimmer;
        }

        public AppStimmer AppStimmer
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value);
        }

        public bool IsAddingAttachment
        {
            get => this.isAddingAttachment;
            set => this.Set(ref this.isAddingAttachment, value);
        }

        public void AddAttachment(AttachmentType attachmentType)
        {
            var attachment = new AppStimmerAttachment
            {
                AttachmentType = attachmentType
            };

            switch (attachmentType)
            {
                case AttachmentType.Text:
                    attachment.Description = "Irgendeine Beschreibung";
                    attachment.AttachmentSource = "Irgendein sinnloser Text, den keiner braucht. Wirklich keiner.";
                    break;
                case AttachmentType.Gallery:
                    attachment.Description = "Sehr schönes Bild";
                    attachment.AttachmentSource = "MSO.StimmApp.Resources.Images.SampleProfilePicture.jpg";
                    break;
            }

            this.AppStimmer.Attachments.Add(attachment);
            this.IsAddingAttachment = false;
        }
    }
}
