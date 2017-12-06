using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Helpers
{
    public static class ColorThemes
    {
        public static ColorTheme SummerBreeze = new ColorTheme
        {
            PrimaryColor = "#F9C470",
            SecondaryColor = "#F1F4F6",
            MenuPageColor = "#AA000000",
            BottomActionBarColor = "#88FFFFFF",
            SimpleControlsColor = "#A9A9A9",
            ListViewHeaderColor = "#808080",
            AppStimmerAttachmentItemColor = "#FFFFFF",
            AppStimmersItemColor = "#FFFFFF",
            PopupColor = "#FFFFFF",
            ActiveTabIndicatorColor = "#FFFFFF",
            PrimaryTextColor = "#FFFFFF",
            SecondaryTextColor = "#000000",
            SubtitleTextColor = "#696969",
            PopupTextColor = "#FFFFFF",
            MenuPageTextColor = "#FFFFFF"
    };

        public static ColorTheme DarkMenace = new ColorTheme
        {
            PrimaryColor = "#000000",
            SecondaryColor = "#FFFFFF",
            MenuPageColor = "#AA000000",
            BottomActionBarColor = "#88FFFFFF",
            SimpleControlsColor = "#A9A9A9",
            ListViewHeaderColor = "#808080",
            AppStimmerAttachmentItemColor = "#FFFFFF",
            AppStimmersItemColor = "#FFFFFF",
            PopupColor = "#FFFFFF",
            ActiveTabIndicatorColor = "#FFFFFF",
        };

        public static ColorTheme PurplePassion = new ColorTheme
        {
            PrimaryColor = "#8A2BE2",
            SecondaryColor = "#FFFFFF",
            MenuPageColor = "#AA000000",
            BottomActionBarColor = "#88FFFFFF",
            SimpleControlsColor = "#A9A9A9",
            ListViewHeaderColor = "#808080",
            AppStimmerAttachmentItemColor = "#FFFFFF",
            AppStimmersItemColor = "#FFFFFF",
            PopupColor = "#FFFFFF",
            ActiveTabIndicatorColor = "#FFFFFF",
        };

        public static ColorTheme MintGreen = new ColorTheme
        {
            PrimaryColor = "#3CB5B8",
            SecondaryColor = "#F1F4F6",
            MenuPageColor = "#AA000000",                    
            ListViewHeaderColor = "#A67CAD",
            MenuPageIconColor = "#3CB5B8",

            NoSwipeIndicatorColor = "#FFFFFF",
            SimpleControlsColor = "#A9A9A9",
            ActiveTabIndicatorColor = "#FFFFFF",
            BottomActionBarColor = "#FFFFFF",
            AppStimmerAttachmentItemColor = "#FFFFFF",
            AppStimmersItemColor = "#FFFFFF",
            PopupColor = "#FFFFFF",
        };
    }
}
