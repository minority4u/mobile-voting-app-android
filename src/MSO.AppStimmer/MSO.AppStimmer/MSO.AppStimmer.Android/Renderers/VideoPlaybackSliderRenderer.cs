using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(VideoPlaybackSlider), typeof(VideoPlaybackSliderRenderer))]
namespace MSO.StimmApp.Droid.Renderers
{
    class VideoPlaybackSliderRenderer : SliderRenderer
    {
        public VideoPlaybackSliderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.Touch += ControlTouch;
        }

        private void ControlTouch(object sender, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var slider = Element as VideoPlaybackSlider;
                if (slider?.FinishedSelectionCommand != null && slider.FinishedSelectionCommand.CanExecute(null))
                    slider.FinishedSelectionCommand.Execute(null);

                e.Handled = false;
            }
            else if (e.Event.Action == MotionEventActions.Move)
                e.Handled = false;
        }
    }
}