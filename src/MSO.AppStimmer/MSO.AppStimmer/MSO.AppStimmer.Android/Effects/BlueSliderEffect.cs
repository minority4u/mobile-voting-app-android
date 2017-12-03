using Android.Graphics;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace MSO.StimmApp.Droid.Effects
{
    public class BlueSliderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var seekBar = (SeekBar)Control;
            var blueColor = Xamarin.Forms.Color.DodgerBlue.ToAndroid();

            seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(blueColor, PorterDuff.Mode.SrcIn));
            seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(blueColor, PorterDuff.Mode.SrcIn));
        }

        protected override void OnDetached()
        {
            // Reset to original state
        }
    }
}