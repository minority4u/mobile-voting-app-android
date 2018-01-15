using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ColorChannelsToColorConverter : BindableObject, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var red = (int)values[0];
                var green = (int)values[1];
                var blue = (int)values[2];

                var redHex = red.ToString("X2");
                var greenHex = green.ToString("X2");
                var blueHex = blue.ToString("X2");
                var colorStringHex = "#" + redHex + greenHex + blueHex;

                return colorStringHex;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
