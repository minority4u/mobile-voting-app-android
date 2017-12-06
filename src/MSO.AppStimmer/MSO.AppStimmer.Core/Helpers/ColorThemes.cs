using System;
using System.Collections.Generic;
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
    }
}
