using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Views
{
    public class ExtendedViewCell : ViewCell
    {
        public static BindableProperty ParentBindingContextProperty = BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(ExtendedViewCell), null);

        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }
    }
}
