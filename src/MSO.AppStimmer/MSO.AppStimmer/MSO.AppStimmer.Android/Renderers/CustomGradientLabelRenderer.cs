
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using MSO.StimmApp;
using MSO.StimmApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientFrame), typeof(CustomGradientLabelRenderer))]

namespace MSO.StimmApp.Droid.Renderers
{
    class CustomGradientLabelRenderer : FrameRenderer
    {
        public CustomGradientLabelRenderer(Context context) : base(context)
        {

        }

        //protected override void OnVisibilityChanged(Android.Views.View changedView, ViewStates visibility)
        //{
        //    base.OnVisibilityChanged(changedView, visibility);
        //    SetBackground();
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            SetBackground();
        }

        //protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        //{
        //    var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
        //        StartColor.ToAndroid(),
        //        EndColor.ToAndroid(),
        //        Android.Graphics.Shader.TileMode.Mirror);
        //    var paint = new Android.Graphics.Paint()
        //    {
        //        Dither = true,
        //    };
        //    paint.SetShader(gradient);
        //    canvas.DrawPaint(paint);
        //    base.DispatchDraw(canvas);
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null || Element == null)
        //    {
        //        return;
        //    }

        //    var page = e.NewElement as GradientLabel;
        //    StartColor = page.StartColor;
        //    EndColor = page.EndColor;

        //    Bac
        //}

        private void SetBackground()
        {
            var startColor = Color.Transparent.ToAndroid();
            var endColor = Color.FromHex("#BB000000").ToAndroid();

            var colors = new int[] { startColor, endColor };

            Background = new GradientDrawable(GradientDrawable.Orientation.TopBottom, colors);
        }
    }
}