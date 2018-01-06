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
        public static ColorTheme GreenSky = new ColorTheme();
            
        public static ColorTheme NightAndDay = new ColorTheme
        {
            PrimaryColor = "#FF7043",
            TextOnPrimaryColor = "#000000",
            LightColor = "#FFA270",
            DarkColor = "#C63F17",

            SecondaryColor = "#212121",
            TextOnSecondaryColor = "#FFFFFF",
            SecondaryLightColor = "#484848",
            SecondaryDarkColor = "#000000"
        };

        public static ColorTheme Relaxed = new ColorTheme
        {
            PrimaryColor = "#3F51B5",
            TextOnPrimaryColor = "#FFFFFF",
            LightColor = "#757DE8",
            DarkColor = "#002984",

            SecondaryColor = "#C5E1A5",
            TextOnSecondaryColor = "#000000",
            SecondaryLightColor = "#F8FFD7",
            SecondaryDarkColor = "#94AF76"
        };

        public static ColorTheme WalkInTheForest = new ColorTheme
        {
            PrimaryColor = "#43A047",
            TextOnPrimaryColor = "#000000",
            LightColor = "#76D275",
            DarkColor = "#00701A",

            SecondaryColor = "#AFB42B",
            TextOnSecondaryColor = "#000000",
            SecondaryLightColor = "#E4E65E",
            SecondaryDarkColor = "#7C8500"
        };
    }
}
