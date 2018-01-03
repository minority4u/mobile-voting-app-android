using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ColorToDarkerColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameters = parameter.ToString().Split(' ');
            var baseColor = Color.FromHex(parameters[0]);
            var percentageDarkened = System.Convert.ToDouble(parameters[1], CultureInfo.InvariantCulture);

            var newColor = new Color(baseColor.R * percentageDarkened, baseColor.G * percentageDarkened,
                baseColor.B * percentageDarkened);

            if (string.IsNullOrEmpty(value?.ToString()))
                return newColor;


            return baseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
