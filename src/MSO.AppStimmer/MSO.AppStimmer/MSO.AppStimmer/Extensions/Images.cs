using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Work;
using MSO.Common;

namespace MSO.StimmApp.Extensions
{
    public static class Images
    {
        public static Xamarin.Forms.ImageSource ImageSourceFromAnySource(string source)
        {
            var isUrl = WebHelper.IsUrl(source);
            var isEmbeddedResource = source.StartsWith("MSO.StimmApp.Resources");

            Xamarin.Forms.ImageSource result;

            if (isUrl)
                result = Xamarin.Forms.ImageSource.FromUri(new Uri(source));
            else if (isEmbeddedResource)
                result = Xamarin.Forms.ImageSource.FromResource(source);
            else
                result = Xamarin.Forms.ImageSource.FromFile(source);

            return result;
        }
    }
}
