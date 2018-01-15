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
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BottomlinelessExpandableEditor), typeof(BottomlinelessExpandableEditorRenderer))]
namespace MSO.StimmApp.Droid.Renderers
{
    class BottomlinelessExpandableEditorRenderer : EditorRenderer
    {
        public BottomlinelessExpandableEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}