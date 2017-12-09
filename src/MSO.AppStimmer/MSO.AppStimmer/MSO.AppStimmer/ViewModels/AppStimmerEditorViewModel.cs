using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
        private AppStimmerEditorDisplayType displayType;
        private bool isEditable;
        private RelayCommand<AppStimmerEditorDisplayType> setDisplayModeCommand;

        public bool IsAddingAttachment
        {
            get => this.isAddingAttachment;
            set => this.Set(ref this.isAddingAttachment, value);
        }

        [PreferredConstructor]
        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService) :
            this(appStimmerService, new AppStimmer(), AppStimmerEditorDisplayType.Overview, isEditable: true)
        {
            
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer)
            : this(appStimmerService, appStimmer, AppStimmerEditorDisplayType.Overview, isEditable: true)
        {
            this.appStimmerService = appStimmerService;
            this.appStimmer = appStimmer;
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer, 
            AppStimmerEditorDisplayType displayType, bool isEditable)
        {
            this.appStimmerService = appStimmerService;
            this.appStimmer = appStimmer;
            this.displayType = displayType;
            this.isEditable = isEditable;
        }

        public AppStimmer AppStimmer
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value);
        }

        public AppStimmerEditorDisplayType DisplayType
        {
            get => this.displayType;
            set => this.Set(ref this.displayType, value);
        }

        public bool IsEditable
        {
            get => this.isEditable;
            set => this.Set(ref this.isEditable, value);
        }

        public RelayCommand<AppStimmerEditorDisplayType> SetDisplayModeCommand => this.setDisplayModeCommand ?? (this.setDisplayModeCommand =
            new RelayCommand<AppStimmerEditorDisplayType>((type) => this.SetDisplayMode(type)));

        private void SetDisplayMode(AppStimmerEditorDisplayType type)
        {
            this.DisplayType = type;
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
