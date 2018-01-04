namespace MSO.StimmApp.Core.Models
{
    public class ColorTheme : ModelBase
    {
        private string primaryColor = "#4DD0E1";
        private string lightColor = "#8BF6FF";
        private string darkColor = "#0093C4";

        private string secondaryColor = "#BDBDBD";
        private string secondaryLightColor = "#EFEFEF";
        private string secondaryDarkColor = "#8D8D8D";
        
        private string menuPageColor = "#AA000000";
        private string bottomActionBarColor = "#88FFFFFF";
        private string simpleControlsColor = "#A9A9A9";
        private string listViewHeaderColor = "#808080";
        private string listViewItemBorderColor = "#FF000000";
        private string appStimmerAttachmentItemColor = "#F9C470";
        private string appStimmerAttachmentItemTextColor = "#000000";
        private string appStimmersItemColor = "#FFFFFF";
        private string appStimmersItemTitleColor = "#F9C470";
        private string popupColor = "#FFFFFF";
        private string activeTabIndicatorColor = "#FFFFFF";
        private string primaryTextColor = "#FFFFFF";
        private string secondaryTextColor = "#000000";
        private string subtitleTextColor = "#696969";
        private string popupTextColor = "#FFFFFF";
        private string popupBorderColor = "#FFFFFFFF";
        private string menuPageTextColor = "#FFFFFF";
        private string menuPageIconColor = "#F9C470";
        private string swipeLeftIndicatorColor = "#DB6E7A";
        private string swipeRightIndicatorColor = "#6EDBCF";
        private string noSwipeIndicatorColor = "#00FFFFFF";
        private string swipeCardColor = "#FFFFFF";
        private string swipeCardBackgroundColor = "#FFFFFF";
        private string standardButtonColor = "#F9C470";


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

        public string AppStimmerAttachmentItemTextColor
        {
            get => this.appStimmerAttachmentItemTextColor;
            set => this.Set(ref this.appStimmerAttachmentItemTextColor, value);
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

        public string PopupTextColor
        {
            get => this.popupTextColor;
            set => this.Set(ref this.popupTextColor, value);
        }

        public string MenuPageTextColor
        {
            get => this.menuPageTextColor;
            set => this.Set(ref this.menuPageTextColor, value);
        }

        public string MenuPageIconColor
        {
            get => this.menuPageIconColor;
            set => this.Set(ref this.menuPageIconColor, value);
        }

        public string SwipeLeftIndicatorColor
        {
            get => this.swipeLeftIndicatorColor;
            set => this.Set(ref this.swipeLeftIndicatorColor, value);
        }

        public string SwipeRightIndicatorColor
        {
            get => this.swipeRightIndicatorColor;
            set => this.Set(ref this.swipeRightIndicatorColor, value);
        }

        public string NoSwipeIndicatorColor
        {
            get => this.noSwipeIndicatorColor;
            set => this.Set(ref this.noSwipeIndicatorColor, value);
        }

        public string AppStimmersItemTitleColor
        {
            get => this.appStimmersItemTitleColor;
            set => this.Set(ref this.appStimmersItemTitleColor, value);
        }

        public string SwipeCardColor
        {
            get => this.swipeCardColor;
            set => this.Set(ref this.swipeCardColor, value);
        }

        public string StandardButtonColor
        {
            get => this.standardButtonColor;
            set => this.Set(ref this.standardButtonColor, value);
        }

        public string SwipeCardBackgroundColor
        {
            get => this.swipeCardBackgroundColor;
            set => this.Set(ref this.swipeCardBackgroundColor, value);
        }

        public string ListViewItemBorderColor
        {
            get => this.listViewItemBorderColor;
            set => this.Set(ref this.listViewItemBorderColor, value);
        }

        public string PopupBorderColor
        {
            get => this.popupBorderColor;
            set => this.Set(ref this.popupColor, value);
        }

        public string LightColor
        {
            get => this.lightColor;
            set => this.Set(ref this.lightColor, value);
        }

        public string DarkColor
        {
            get => this.darkColor;
            set => this.Set(ref this.darkColor, value);
        }

        public string SecondaryLightColor
        {
            get => this.secondaryLightColor;
            set => this.Set(ref this.secondaryLightColor, value);
        }

        public string SecondaryDarkColor
        {
            get => this.secondaryDarkColor;
            set => this.Set(ref this.secondaryDarkColor, value);
        }
    }
}
