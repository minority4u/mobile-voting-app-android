using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class BottomlineColoredExpandableEditor : Editor
    {
        public static readonly BindableProperty FocusColorProperty =
            BindableProperty.Create(nameof(FocusColor), typeof(string), typeof(BottomlineColoredExpandableEditor), null, BindingMode.TwoWay);

        public static readonly BindableProperty NoFocusColorProperty =
            BindableProperty.Create(nameof(NoFocusColor), typeof(string), typeof(BottomlineColoredExpandableEditor), null, BindingMode.TwoWay);

        public string FocusColor
        {
            get
            {
                var result = (string) GetValue(FocusColorProperty);
                return result;
            }
            set => SetValue(FocusColorProperty, value);
        }

        public string NoFocusColor
        {
            get
            {
                var result = (string)GetValue(NoFocusColorProperty);
                return result;
            }
            set => SetValue(NoFocusColorProperty, value);
        }

        public BottomlineColoredExpandableEditor()
        {
            this.TextChanged += (sender, e) => { this.InvalidateMeasure(); };
        }
    }
}
