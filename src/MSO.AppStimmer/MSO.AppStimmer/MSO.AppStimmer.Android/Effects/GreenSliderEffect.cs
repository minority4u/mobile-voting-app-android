using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace MSO.StimmApp.Droid.Effects
{
    public class GreenSliderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            //var seekBar = (SeekBar) Control;
            //var greenColor = Xamarin.Forms.Color.LightSeaGreen.ToAndroid();

            //seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(greenColor, PorterDuff.Mode.SrcIn));
            //seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(greenColor, PorterDuff.Mode.SrcIn));
        }

        protected override void OnDetached()
        {
            // Reset to original state
        }
    }
}