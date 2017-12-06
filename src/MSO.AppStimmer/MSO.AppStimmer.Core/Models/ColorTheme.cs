namespace MSO.StimmApp.Core.Models
{
    public class ColorTheme : ModelBase
    {
        private string primaryColor = "#F9C470";
        private string secondaryColor = "#F1F4F6";
        private string menuPageColor = "#AA000000";
        private string bottomActionBarColor = "#88FFFFFF";
        private string simpleControlsColor = "#A9A9A9";
        private string listViewHeaderColor = "#808080";
        private string appStimmerAttachmentItemColor = "#FFFFFF";
        private string appStimmersItemColor = "#FFFFFF";
        private string popupColor = "#FFFFFF";
        private string activeTabIndicatorColor = "#FFFFFF";
        private string primaryTextColor = "#FFFFFF";
        private string secondaryTextColor = "#FFFFFF";
        private string subtitleTextColor = "#FFFFFF";


        public ColorTheme() : base(true)
        {
            
        }

        public string PrimaryColor
        {
            get => this.primaryColor;
            set => this.Set(ref this.primaryColor, value);
        }

        public string SecondaryColor
        {
            get => this.secondaryColor;
            set => this.Set(ref this.secondaryColor, value);
        }

        public string MenuPageColor
        {
            get => this.menuPageColor;
            set => this.Set(ref this.menuPageColor, value);
        }

        public string BottomActionBarColor
        {
            get => this.bottomActionBarColor;
            set => this.Set(ref this.bottomActionBarColor, value);
        }

        public string SimpleControlsColor
        {
            get => this.simpleControlsColor;
            set => this.Set(ref this.simpleControlsColor, value);
        }

        public string ListViewHeaderColor
        {
            get => this.listViewHeaderColor;
            set => this.Set(ref this.listViewHeaderColor, value);
        }

        public string AppStimmerAttachmentItemColor
        {
            get => this.appStimmerAttachmentItemColor;
            set => this.Set(ref this.appStimmerAttachmentItemColor, value);
        }

        public string AppStimmersItemColor
        {
            get => this.appStimmersItemColor;
            set => this.Set(ref this.appStimmersItemColor, value);
        }

        public string PopupColor
        {
            get => this.popupColor;
            set => this.Set(ref this.popupColor, value);
        }

        public string ActiveTabIndicatorColor
        {
            get => this.activeTabIndicatorColor;
            set => this.Set(ref this.activeTabIndicatorColor, value);
        }

        public string PrimaryTextColor
        {
            get => this.primaryTextColor;
            set => this.Set(ref this.primaryTextColor, value);
        }

        public string SecondaryTextColor
        {
            get => this.secondaryTextColor;
            set => this.Set(ref this.secondaryTextColor, value);
        }

        public string SubtitleTextColor
        {
            get => this.subtitleTextColor;
            set => this.Set(ref this.subtitleTextColor, value);
        }
    }
}
