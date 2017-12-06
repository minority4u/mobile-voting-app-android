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
        // this is the default color theme. The values are stored in the model as default values.
        // No need to specify them here.
        public static ColorTheme SummerBreeze = new ColorTheme();
            
        public static ColorTheme DarkMenace = new ColorTheme
        {
            PrimaryColor = "#000000",
            SecondaryColor = "#000000",
            MenuPageColor = "#000000",
            ListViewHeaderColor = "#B81215",
            MenuPageIconColor = "#B81215",
            AppStimmersItemTitleColor = "#B81215",
            StandardButtonColor = "#B81215",
            SimpleControlsColor = "#B81215",
            ActiveTabIndicatorColor = "#B81215",
            BottomActionBarColor = "#FF000000",
            AppStimmerAttachmentItemColor = "#000000",
            AppStimmerAttachmentItemTextColor = "#FFFFFF",
            AppStimmersItemColor = "#000000",
            PopupColor = "#B81215",
            PrimaryTextColor = "#FFFFFF",
            SecondaryTextColor = "#FFFFFF",
            SubtitleTextColor = "#696969",
            PopupTextColor = "#FFFFFF",
            MenuPageTextColor = "#FFFFFF",
            SwipeLeftIndicatorColor = "#B81215",
            SwipeRightIndicatorColor = "#3B83BC",
            NoSwipeIndicatorColor = "#000000",
            SwipeCardColor = "#000000",
            SwipeCardBackgroundColor = "#000000"
        };

        public static ColorTheme PurplePassion = new ColorTheme
        {
            PrimaryColor = "#8A2BE2",
            ListViewHeaderColor = "#8A2BE2",
            MenuPageIconColor = "#8A2BE2",
            AppStimmersItemTitleColor = "#8A2BE2",
            StandardButtonColor = "#8A2BE2",
            PopupColor = "#8A2BE2",
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
            PrimaryTextColor = "#FFFFFF",
            SecondaryTextColor = "#000000",
            SubtitleTextColor = "#696969",
            PopupTextColor = "#FFFFFF",
            MenuPageTextColor = "#FFFFFF",
    };
    }
}
