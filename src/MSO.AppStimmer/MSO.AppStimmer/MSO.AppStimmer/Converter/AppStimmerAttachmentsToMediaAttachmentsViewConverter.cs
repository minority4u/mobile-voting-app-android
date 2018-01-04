using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Models;
using MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerAttachmentsToMediaAttachmentsViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var allAttachmehts = value as ICollection<AppStimmerAttachment>;
            if (allAttachmehts == null)
                return null;

            var mediaAttachmentsViewEntries = new ObservableCollection<MediaAttachmentViewEntry>();

            foreach (var attachment in allAttachmehts)
            {
                var entry = new MediaAttachmentViewEntry {Attachment = attachment};

                switch (attachment.AttachmentType)
                {
                    case AttachmentType.Picture:
                        entry.View = new ImageAttachmentView(attachment);
                        mediaAttachmentsViewEntries.Add(entry);
                        break;
                    case AttachmentType.Video:
                        entry.View = new VideoAttachmentView(attachment);
                        mediaAttachmentsViewEntries.Add(entry);
                        break;
                    case AttachmentType.Location:
                        entry.View = new LocationAttachmentView(attachment);
                        mediaAttachmentsViewEntries.Add(entry);
                        break;
                }
            }

            return mediaAttachmentsViewEntries;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var entries = value as ObservableCollection<MediaAttachmentViewEntry>;
            if (entries == null)
                return null;

            var attachments = new ObservableCollection<AppStimmerAttachment>();
            foreach (var entry in entries)
            {
                attachments.Add(entry.Attachment);
            }

            return attachments;
        }
    }
}
