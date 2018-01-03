using System;

namespace MSO.StimmApp.Models
{
    public class MenuPageItem
    {
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }

        public string PageKey { get; set; }

        public MenuPageItem(Type targetType, string pageKey, string title, string icon = null)
        {
            this.TargetType = targetType;
            this.Title = title;
            this.Icon = icon;
            this.PageKey = pageKey;
        }
    }
}
