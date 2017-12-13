//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using MSO.StimmApp.Droid.Renderers;
//using MSO.StimmApp.Elements;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(ExpandableEditor), typeof(PlaceholderEditorRenderer))]
//namespace MSO.StimmApp.Droid.Renderers
//{
//    public class PlaceholderEditorRenderer : EditorRenderer
//    {
//        public PlaceholderEditorRenderer(Context context) : base(context)
//        {
//        }

//        protected override void OnElementChanged(
//            ElementChangedEventArgs<Editor> e)
//        {
//            base.OnElementChanged(e);

//            if (e.NewElement != null)
//            {
//                var element = e.NewElement as ExpandableEditor;
//                this.Control.Hint = element.Placeholder;
//            }
//        }

//        protected override void OnElementPropertyChanged(
//            object sender,
//            PropertyChangedEventArgs e)
//        {
//            base.OnElementPropertyChanged(sender, e);

//            if (e.PropertyName == ExpandableEditor.PlaceholderProperty.PropertyName)
//            {
//                var element = this.Element as ExpandableEditor;
//                this.Control.Hint = element.Placeholder;
//            }
//        }
//    }
//}