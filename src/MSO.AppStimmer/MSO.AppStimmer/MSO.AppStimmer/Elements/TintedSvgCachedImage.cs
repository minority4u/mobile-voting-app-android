using System.Collections.Generic;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class TintedSvgCachedImage : SvgCachedImage
    {
        public static BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TintedSvgCachedImage), Color.Transparent, propertyChanged: UpdateColor);

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        private static void UpdateColor(BindableObject bindable, object oldColor, object newColor)
        {
            var oldcolor = (Color) oldColor;
            var newcolor = (Color) newColor;

            if (oldcolor.Equals(newcolor))
                return;

            var view = (TintedSvgCachedImage)bindable;
            var transformations = new List<ITransformation>() {
                new TintTransformation((int) (newcolor.R * 255), (int) (newcolor.G * 255), (int) (newcolor.B * 255), (int) (newcolor.A * 255)) {
                    EnableSolidColor = true
                }
            };
            view.Transformations = transformations;
        }
    }
}
