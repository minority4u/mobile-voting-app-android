using System;

namespace MSO.StimmApp.Core.Models
{
    public class AppStimmer : ModelBase
    {
        private string title;
        private string appstract;
        private string description;
        private string picture;

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
    }
}
