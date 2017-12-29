using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentsToMediaAddachmentCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var attachments = value as ICollection<AppStimmerAttachment>;
            if (attachments == null)
                return null;

            var count = 0;
            foreach (var attachment in attachments)
            {
                var type = attachment.AttachmentType;
                if (type == AttachmentType.Picture || type == AttachmentType.Video)
                    count += 1;
            }

            return count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
