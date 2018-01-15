using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class LocalImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string;
            if (string.IsNullOrWhiteSpace(source))
                return null;

            ImageSource result;
            try
            {
                var url = new Uri(source);
                result = ImageSource.FromUri(url);
            }
            catch (Exception e)
            {
                result = ImageSource.FromFile(source);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
