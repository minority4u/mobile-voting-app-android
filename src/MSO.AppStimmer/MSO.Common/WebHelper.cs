using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.Common
{
    public static class WebHelper
    {
        public static bool IsUrl(string str)
        {
            Uri uriResult;
            var result = Uri.TryCreate(str, UriKind.Absolute, out uriResult) && (uriResult.Scheme == "http" || uriResult.Scheme == "https");
            var isUrl = result && (uriResult != null);

            return isUrl;
        }
    }
}
