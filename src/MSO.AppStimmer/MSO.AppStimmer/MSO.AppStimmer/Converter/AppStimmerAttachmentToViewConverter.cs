using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Views.Attachments;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentToViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var appStimmerAttachment = value as AppStimmerAttachment;
            ContentView view = null;

            if (appStimmerAttachment != null)
            {
                var attachmentType = appStimmerAttachment.AttachmentType;
                switch (attachmentType)
                {
                    case AttachmentType.Text:
                        view = new TextAttachmentView();
                        break;
                    case AttachmentType.Picture:
                        view = new TextAttachmentView();
                        break;
                }
            }

            return view;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
