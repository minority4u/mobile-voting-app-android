using System.ComponentModel;
using Android.Content;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollbarLessScrollView), typeof(Scrollbardisabledrenderer))]
namespace MSO.StimmApp.Droid.Renderers
{  
    public class Scrollbardisabledrenderer : ScrollViewRenderer
    {
        public Scrollbardisabledrenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

            e.NewElement.PropertyChanged += OnElementPropertyChanged;
        }

        protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.HorizontalScrollBarEnabled = false;
            this.VerticalScrollBarEnabled = false;
        }
    }
}