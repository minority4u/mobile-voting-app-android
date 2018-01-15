using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class CrossAudioManagerTimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var totalSeconds = (double)value;
            var par = parameter.ToString();

            var timespan = TimeSpan.FromSeconds(totalSeconds);

            var hours = timespan.Hours.ToString().PadLeft(2, '0');
            var minutes = timespan.Minutes.ToString().PadLeft(2, '0');
            var seconds = timespan.Seconds.ToString().PadLeft(2, '0');

            var result = string.Empty;
            if (par == "short")
            {
                result = string.Format("{0}:{1}", minutes, seconds);
            }
            if (par == "long")
            {
                result = string.Format("{0}:{1}:{2}", hours, minutes, seconds);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
