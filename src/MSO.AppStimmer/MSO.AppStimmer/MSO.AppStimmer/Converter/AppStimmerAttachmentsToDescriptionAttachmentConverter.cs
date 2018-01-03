using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentsToDescriptionAttachmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var allAttachments = value as ICollection<AppStimmerAttachment>;
            if (allAttachments == null)
                return null;

            foreach (var attachment in allAttachments)
            {
                if (attachment.IsMainAttachment)
                    continue;

                var type = attachment.AttachmentType;
                if (type == AttachmentType.Text)
                    return attachment.AttachmentSource;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
