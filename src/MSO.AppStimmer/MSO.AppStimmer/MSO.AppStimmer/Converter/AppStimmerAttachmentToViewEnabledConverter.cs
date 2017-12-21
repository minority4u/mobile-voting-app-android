using System;
using System.Globalization;
using MSO.StimmApp.Core.Enums;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentToViewEnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
            {
                return false; 
            }

            var type = (AttachmentType)values[0];
            var isMainAttachment = (bool) values[1];
            var par = parameter.ToString();

            if (isMainAttachment)
            {
                return false;
            }


            if ((type == AttachmentType.Picture || type == AttachmentType.GalleryPicture) && par == "Picture")
                return true;
            if (type == AttachmentType.Text && par == "Text")
                return true;
            if ((type == AttachmentType.Video || type == AttachmentType.GalleryVideo) && par == "Video")
                return true;
            if (type == AttachmentType.Audio && par == "Audio")
                return true;

            return false;
        }
    }
}