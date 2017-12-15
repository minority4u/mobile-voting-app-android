using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.Common;
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

            ImageSource result;

            var isUrl = WebHelper.IsUrl(source);
            var isEmbeddedResource = source.StartsWith("MSO.StimmApp.Resources");

            if (isUrl)
                result = ImageSource.FromUri(new Uri(source));      
            else if (isEmbeddedResource)
                result = ImageSource.FromResource(source);           
            else
                result = ImageSource.FromFile(source);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
