using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ImageAttachmentToImageAttachmentViewModel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var attachment = value as AppStimmerAttachment;
            if (attachment == null)
                return null;

            var viewModel = new ImageAttachmentViewModel(attachment);
            return viewModel;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
