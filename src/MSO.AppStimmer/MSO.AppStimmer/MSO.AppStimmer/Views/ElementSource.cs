using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views
{
    [ContentProperty("ElementName")]
    public class ElementSource : IMarkupExtension
    {
        public string ElementName { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService(typeof(IRootObjectProvider));

            var rootProvider = service as IRootObjectProvider;
            if (rootProvider == null)
                return null;
            var root = rootProvider.RootObject as Element;
            if (root == null)
                return null;
            return root.FindByName<Element>(ElementName);
        }
    }
}
