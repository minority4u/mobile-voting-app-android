using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Converter
{
    public class CharactersAndMaxCharactersToStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return string.Empty;

            if (values[0] == null || values[1] == null)
                return string.Empty;

            var characters = (int) values[0];
            var maxCharacters = (int) values[1];

            var str = characters + " / " + maxCharacters;
            return str;
        }
    }
}
