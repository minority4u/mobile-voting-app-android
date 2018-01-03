using System;
using System.Collections.ObjectModel;
using MSO.StimmApp.Core.Enums;

namespace MSO.StimmApp.Core.Models
{
    public class AppStimmer : EditableModelBase<AppStimmer>
    {
        private string title;
        private string appstract;
        private string description;
        private string picture;
        private ObservableCollection<AppStimmerAttachment> attachments;

        public AppStimmer() : base(true)
        {
            this.Id = Guid.NewGuid();
            this.attachments = new ObservableCollection<AppStimmerAttachment>();
            this.Picture = Constants.NoImageProvidedImageSource;
        }

        public string Title
        {
            get => this.title;
            set => this.Set(ref this.title, value);
        }

        public string Appstract
        {
            get => this.appstract;
            set => this.Set(ref this.appstract, value);
        }

        public string Description
        {
            get => this.description;
            set => this.Set(ref this.description, value);
        }

        public string Picture
        {
            get => this.picture;
            set => this.Set(ref this.picture, value);
        }

        public ObservableCollection<AppStimmerAttachment> Attachments
        {
            get => this.attachments;
            set => this.Set(ref this.attachments, value);
        }
    }
}
