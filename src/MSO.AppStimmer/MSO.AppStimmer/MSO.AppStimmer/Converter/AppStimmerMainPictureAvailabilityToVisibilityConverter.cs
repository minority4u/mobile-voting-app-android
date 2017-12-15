using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerMainPictureAvailabilityToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var attachment = value as AppStimmerAttachment;
            if (attachment == null)
                return false;

            if (attachment.IsMainAttachment && string.IsNullOrEmpty(attachment.AttachmentSource))
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
