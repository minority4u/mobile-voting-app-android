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
        private RelayCommand<ModelEditFinishedType> endEditCommand;

        public bool IsAddingAttachment
        {
            get => this.isAddingAttachment;
            set => this.Set(ref this.isAddingAttachment, value);
        }

        [PreferredConstructor]
        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService) :
            this(appStimmerService, new AppStimmer(), AppStimmerEditorDisplayType.Overview, isEditable: true)
        {
            Debug.WriteLine(@"First constructor called. IsEditable: " + isEditable);
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer)
            : this(appStimmerService, appStimmer, AppStimmerEditorDisplayType.Overview, isEditable: true)
        {
            Debug.WriteLine(@"Second constructor called. IsEditable: " + isEditable);
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer,
            AppStimmerEditorDisplayType displayType, bool isEditable)
        {
            Debug.WriteLine(@"Third constructor called. IsEditable: " + isEditable);
            this.appStimmerService = appStimmerService;
            this.AppStimmer = appStimmer;
            this.DisplayType = displayType;
            this.IsEditable = isEditable;

            if (this.isEditable)
            {
                this.BeginAppStimmerEdit();
            }
        }

        private void BeginAppStimmerEdit()
        {
            this.AppStimmer.BeginEdit();
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

        public RelayCommand<ModelEditFinishedType> EndEditCommand => this.endEditCommand ?? (this.endEditCommand =
            new RelayCommand<ModelEditFinishedType>((type) => this.EndEdit(type)));

        private void SetDisplayMode(AppStimmerEditorDisplayType type)
        {
            this.DisplayType = type;
        }

        private void EndEdit(ModelEditFinishedType type)
        {
            Debug.WriteLine(("Finished model edit: " + type));
            if (type == ModelEditFinishedType.Cancel)
            {
                this.AppStimmer.CancelEdit();
            }
            else if (type == ModelEditFinishedType.Save)
            {
                this.AppStimmer.EndEdit();
            }

            App.NavigationService.GoBack();
        }


        public void AddAttachment(AppStimmerAttachment attachment)
        {
            switch (attachment.AttachmentType)
            {
                //case AttachmentType.Text:
                //    attachment.Description = "Irgendeine Beschreibung";
                //    attachment.AttachmentSource = "Irgendein sinnloser Text, den keiner braucht. Wirklich keiner.";
                //    break;
                //case AttachmentType.Gallery:
                //    attachment.Description = "Sehr schönes Bild";
                //    attachment.AttachmentSource = "MSO.StimmApp.Resources.Images.SampleProfilePicture.jpg";
                //    break;
                //case AttachmentType.Video:
                //    attachment.Description = "Irgendein Video";
                //    attachment.AttachmentSource = "https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4";
                //    break;
            }

            this.AppStimmer.Attachments.Add(attachment);
        }
    }
}
