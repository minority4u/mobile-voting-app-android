
using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using MSO.StimmApp;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientFrame), typeof(GradientFrameRenderer))]

namespace MSO.StimmApp.Droid.Renderers
{
    class GradientFrameRenderer : FrameRenderer
    {
        private string startColor;
        private string endColor;
        private string backgroundColor;
        private bool drawNormalBackground;
        private GradientFrame myFrame;

        private readonly GradientDrawable.Orientation orientation;


        public GradientFrameRenderer(Context context) : base(context)
        {
            this.orientation = GradientDrawable.Orientation.TopBottom;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var frame = e.NewElement as GradientFrame;
            if (frame == null)
                return;

            this.myFrame = frame;
            SetBackground();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "BackgroundColor" && this.myFrame != null)
            {
                var color = this.myFrame.BackgroundColor;
                var alpha = color.A;
                if (Math.Abs(alpha) > 0.0)
                {
                    this.SetBackgroundColor(color.ToAndroid());
                }
                else
                {
                    SetBackground();
                }
            }

            if ((e.PropertyName == "EndColor" || e.PropertyName == "StartColor") && this.myFrame != null)
            {
                SetBackground();
            }
        }

        private void SetBackground()
        {
            if (string.IsNullOrEmpty(myFrame.StartColor) || string.IsNullOrEmpty(myFrame.EndColor))
                return;

            var startColorAndroid = Color.FromHex(myFrame.StartColor).ToAndroid();
            var endColorAndroid = Color.FromHex(myFrame.EndColor).ToAndroid();

            var colors = new int[] { startColorAndroid, endColorAndroid };

            Background = new GradientDrawable(this.orientation, colors);
        }
    }
}