using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Converter
{
    public class MediaAttachmentCountToViewVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
                return false;

            var attachments = values[0] as ICollection<AppStimmerAttachment>;
            if (attachments == null)
                return false;

            var count = attachments.Count;
            var isNew = (bool) values[1];

            if (isNew)
            {
                return true;
            }

            if (count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
