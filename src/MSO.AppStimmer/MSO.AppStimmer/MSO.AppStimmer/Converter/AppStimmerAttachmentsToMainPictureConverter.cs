using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Extensions;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentsToMainPictureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var attachments = value as ICollection<AppStimmerAttachment>;
            if (attachments == null)
                return null;

            foreach (var attachment in attachments)
            {
                if (attachment.IsMainAttachment && attachment.AttachmentType == AttachmentType.Picture)
                {
                    Xamarin.Forms.ImageSource imgSource = null;

                    try
                    {
                        imgSource = Images.ImageSourceFromAnySource(attachment.AttachmentSource);
                    }
                    catch (Exception e)
                    {
                        imgSource = Constants.NoImageProvidedImageSource;
                    }
                    
                    return imgSource;
                }                         
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
