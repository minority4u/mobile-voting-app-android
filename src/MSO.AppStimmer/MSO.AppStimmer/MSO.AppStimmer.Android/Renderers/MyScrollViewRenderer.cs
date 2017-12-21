//using System;
//using Android.Content;
//using Android.Views;
//using Android.Widget;
//using MSO.StimmApp.Droid.Renderers;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(Xamarin.Forms.ScrollView), typeof(MyScrollViewRenderer))]
//namespace MSO.StimmApp.Droid.Renderers
//{
//    class MyScrollViewRenderer : ScrollViewRenderer
//    {
//        private float xLastMove = 50;
//        private bool isFirstMove = true;

//        public MyScrollViewRenderer(Context context) : base(context)
//        {

//        }

//        public override bool OnTouchEvent(MotionEvent e)
//        {
//            var x = e.GetX();

//            if (isFirstMove)
//                xLastMove = x;

//            var xDifference = x - xLastMove;
//            isFirstMove = false;

//            xLastMove = x;

//            var absDifference = Math.Abs(xDifference);
//            //System.Diagnostics.Debug.WriteLine("OnTouched" + e.Action + ". X difference: " + absDifference);

//            if (absDifference > 50.0)
//                return false;

//            return base.OnTouchEvent(e);
//        }

//        public override bool OnInterceptTouchEvent(MotionEvent ev)
//        {
//            //System.Diagnostics.Debug.WriteLine("OnInterceptTouched" + ev.Action);
//            return base.OnInterceptTouchEvent(ev);
//            //switch (ev.Action)
//            //{
//            //    case MotionEventActions.Down:
//            //        return base.OnInterceptTouchEvent(ev);
//            //    case MotionEventActions.Up:
//            //        return base.OnInterceptTouchEvent(ev);
//            //    default:
//            //        return false;
//            //}
//        }

//        //protected override void OnElementChanged(VisualElementChangedEventArgs e)
//        //{
//        //    base.OnElementChanged(e);

//        //    var horizontal = this.ViewGroup.GetChildAt(0) as ViewGroup;
//        //    if (horizontal is HorizontalScrollView)
//        //    {
//        //        var content = horizontal.GetChildAt(0);
//        //        horizontal.RemoveAllViews();
//        //        this.ViewGroup.RemoveViewAt(0);
//        //        this.ViewGroup.AddView(content);
//        //    }
//        //}
//    }
//}