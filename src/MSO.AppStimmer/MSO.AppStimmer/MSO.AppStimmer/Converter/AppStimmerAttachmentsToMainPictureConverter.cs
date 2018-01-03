using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core;
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
            var picturePath = value as string;
            if (string.IsNullOrEmpty(picturePath))
                return null;

            ImageSource imgSource;

            try
            {
                imgSource = Images.ImageSourceFromAnySource(picturePath);
            }
            catch (Exception)
            {
                imgSource = ImageSource.FromResource(Constants.NoImageProvidedImageSource);
            }

            return imgSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
