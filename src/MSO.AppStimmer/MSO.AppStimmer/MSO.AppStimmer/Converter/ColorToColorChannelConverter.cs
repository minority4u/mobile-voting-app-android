using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ColorToColorChannelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexStringColor = value.ToString();
            var color = Color.FromHex(hexStringColor);
            var par = parameter.ToString();

            switch (par)
            {
                case "Red":
                    return System.Convert.ToInt32(color.R);
                case "Green":
                    return System.Convert.ToInt32(color.G);
                case "Blue":
                    return System.Convert.ToInt32(color.B);
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexStringColor = value.ToString();
            var color = Color.FromHex(hexStringColor);
            var par = parameter.ToString();

            switch (par)
            {
                case "Red":
                    return System.Convert.ToInt32(color.R);
                case "Green":
                    return System.Convert.ToInt32(color.G);
                case "Blue":
                    return System.Convert.ToInt32(color.B);
            }

            return 0;
        }
    }
}
