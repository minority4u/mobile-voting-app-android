using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Converter
{
    public class MapAttachmentDescriptionToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values?[0] == null || values[1] == null)
                return false;

            var isNew = (bool) values[0];
            var text = values[1].ToString();

            if (isNew || string.IsNullOrEmpty(text))
                return false;

            return true;

        }
    }
}