
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

            SetBackground(frame.StartColor, frame.EndColor);
        }

        private void SetBackground(string startColor, string endColor)
        {
            var startColorAndroid = Color.FromHex(startColor).ToAndroid();
            var endColorAndroid = Color.FromHex(endColor).ToAndroid();

            var colors = new int[] { startColorAndroid, endColorAndroid };

            Background = new GradientDrawable(this.orientation, colors);
        }
    }
}