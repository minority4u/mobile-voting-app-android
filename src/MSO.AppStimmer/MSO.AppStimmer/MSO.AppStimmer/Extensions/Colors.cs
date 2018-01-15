using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Extensions
{
    public static class Colors
    {
        public static string ToHexString(this Xamarin.Forms.Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            var hex = String.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", red, green, blue, alpha);

            return hex;
        }
    }
}
