using System;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Object = Java.Lang.Object;
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MSO.StimmApp.Droid.Resources;
using MSO.StimmApp.Helpers;
using MSO.StimmApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MSO.StimmApp.Droid.Resources
{
    internal class GlobalLayoutListener : Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        private static InputMethodManager _inputManager;
        private readonly SoftwareKeyboardService _softwareKeyboardService;

        private static void ObtainInputManager()
        {
            _inputManager = (InputMethodManager)((Activity)Forms.Context)
                .GetSystemService(Context.InputMethodService);
        }

        public GlobalLayoutListener(SoftwareKeyboardService softwareKeyboardService)
        {
            _softwareKeyboardService = softwareKeyboardService;
            ObtainInputManager();
        }

        public void OnGlobalLayout()
        {
            if (_inputManager.Handle == IntPtr.Zero)
            {
                ObtainInputManager();
            }
            if (_inputManager.IsAcceptingText)
            {
                _softwareKeyboardService.InvokeKeyboardShow(new SoftwareKeyboardEventArgs(true));
            }
            else
            {
                _softwareKeyboardService.InvokeKeyboardHide(new SoftwareKeyboardEventArgs(false));
            }
        }
    }
}