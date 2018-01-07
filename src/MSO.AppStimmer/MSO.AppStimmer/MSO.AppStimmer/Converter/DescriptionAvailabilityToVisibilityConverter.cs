using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Converter
{
    public class DescriptionAvailabilityToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return false;

            var isNew = (bool)values[0];
            var description = values[1]?.ToString();
            
            if (isNew)
            {
                return true;
            }

            if (string.IsNullOrEmpty(description))
            {
                return false;
            }

            return true;
        }
    }
}
