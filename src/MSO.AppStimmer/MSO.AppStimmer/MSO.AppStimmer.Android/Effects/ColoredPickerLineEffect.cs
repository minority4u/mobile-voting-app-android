using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace MSO.StimmApp.Droid.Effects
{
    public class ColoredPickerLineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var picker = Control as EditText;
            if (picker == null)
                return;

            picker.BackgroundTintList = ColorStateList.ValueOf(Color.Gray);
        }

        protected override void OnDetached()
        {
            // Reset to original state
        }
    }
}