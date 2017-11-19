using System;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var source = value as string;
            if (string.IsNullOrWhiteSpace(source))
                return null;

            var result = ImageSource.FromResource(source);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
