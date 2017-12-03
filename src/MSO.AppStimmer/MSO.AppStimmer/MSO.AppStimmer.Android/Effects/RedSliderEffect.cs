using Android.Graphics;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace MSO.StimmApp.Droid.Effects
{
    public class RedSliderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var seekBar = (SeekBar)Control;
            var redColor = Xamarin.Forms.Color.MediumVioletRed.ToAndroid();

            seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(redColor, PorterDuff.Mode.SrcIn));
            seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(redColor, PorterDuff.Mode.SrcIn));
        }

        protected override void OnDetached()
        {
            // Reset to original state
        }
    }
}