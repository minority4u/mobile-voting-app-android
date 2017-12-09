using System;
using System.Collections.ObjectModel;

namespace MSO.StimmApp.Core.Models
{
    public class AppStimmer : EditableModelBase<AppStimmer>
    {
        private string title;
        private string appstract;
        private string description;
        private string picture;
        private ObservableCollection<AppStimmerAttachment> attachments = new ObservableCollection<AppStimmerAttachment>();

        public AppStimmer() : base(true)
        {
            this.Id = Guid.NewGuid();
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
