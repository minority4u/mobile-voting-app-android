//using System;
//using System.Collections.Generic;
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
//using Xamarin.Forms.Maps;
//using Xamarin.Forms.Maps.Android;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(Map), typeof(CustomMapRenderer))]
//namespace MSO.StimmApp.Droid.Renderers
//{
//    public class CustomMapRenderer : MapRenderer
//    {
//        public CustomMapRenderer(Context context) : base(context)
//        {

//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
//        {         
//            base.OnElementChanged(e);
//            var map = this.Control as object;
//            if (e.OldElement != null) return;

//            //var map = this.Control as object;
//            var a = "b";
//            //if (map == null) return;
//        }
//    }
//}