
using System.ComponentModel;
using Android.Content;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BottomlinelessEntry), typeof(BottomlinelessEntryRenderer))]
namespace MSO.StimmApp.Droid.Renderers
{
    class BottomlinelessEntryRenderer : EntryRenderer
    {
        //public BottomlinelessEntryRenderer(Context context) : base(context)
        //{
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }


        public BottomlinelessEntryRenderer(Context context) : base(context)
        {
        }
    }
}