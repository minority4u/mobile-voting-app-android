using Android.App;
using MSO.StimmApp.Droid;
using MSO.StimmApp.Services;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace MSO.StimmApp.Droid.Resources
{
    public class SoftwareKeyboardService : SoftwareKeyboardServiceBase
    {
        private readonly Activity _activity;
        private GlobalLayoutListener _globalLayoutListener;

        public SoftwareKeyboardService()
        {
            _activity = ((Activity)Forms.Context);
        }

        public override event SoftwareKeyboardEventHandler Hide
        {
            add
            {
                base.Hide += value;
                CheckListener();
            }
            remove { base.Hide -= value; }
        }

        public override event SoftwareKeyboardEventHandler Show
        {
            add
            {
                base.Show += value;
                CheckListener();
            }
            remove { base.Show -= value; }
        }

        private void CheckListener()
        {
            if (_globalLayoutListener == null)
            {
                _globalLayoutListener = new GlobalLayoutListener(this);
                _activity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(_globalLayoutListener);
            }
        }
    }
}