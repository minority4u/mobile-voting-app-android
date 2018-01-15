using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.Common;
using MSO.StimmApp.Extensions;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ImageSourceToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string;
            if (string.IsNullOrEmpty(source))
                return null;

            var result = Images.ImageSourceFromAnySource(source);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
