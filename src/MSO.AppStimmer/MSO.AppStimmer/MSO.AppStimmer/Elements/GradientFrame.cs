using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class GradientFrame : Frame
    {
        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create(nameof(StartColor), typeof(string), typeof(GradientFrame), null, BindingMode.TwoWay);

        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create(nameof(EndColor), typeof(string), typeof(GradientFrame), null, BindingMode.TwoWay);

        public string StartColor
        {
            get
            {
                var result = (string)GetValue(StartColorProperty);
                return result;
            }
            set => SetValue(StartColorProperty, value);
        }

        public string EndColor
        {
            get
            {
                var result = (string)GetValue(EndColorProperty);
                return result;
            }
            set => SetValue(EndColorProperty, value);
        }
    }
}
