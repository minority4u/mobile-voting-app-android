using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BottomlineColoredExpandableEditor), typeof(BottomlineColoredExpandableEditorRenderer))]
namespace MSO.StimmApp.Droid.Renderers
{
    class BottomlineColoredExpandableEditorRenderer : EditorRenderer
    {
        public BottomlineColoredExpandableEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var editor = e.NewElement as BottomlineColoredExpandableEditor;
            this.UpdateBottomlineColor(editor);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var editor = (BottomlineColoredExpandableEditor) sender;
            this.UpdateBottomlineColor(editor);
        }

        private void UpdateBottomlineColor(BottomlineColoredExpandableEditor editor)
        {
            var focusColor = editor?.FocusColor;
            var noFocusColor = editor?.NoFocusColor;
            if (string.IsNullOrEmpty(focusColor) || string.IsNullOrEmpty(noFocusColor))
                return;

            Xamarin.Forms.Color color;
            if (editor.IsFocused)
                color = Xamarin.Forms.Color.FromHex(focusColor);
            else
                color = Xamarin.Forms.Color.FromHex(noFocusColor);

            var colorAndroid = color.ToAndroid();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, 0); // replace 0 with a Resource.Drawable.my_cursor 

                Control.BackgroundTintList = ColorStateList.ValueOf(colorAndroid);
            }
            else
            {
                Control.Background.SetColorFilter(colorAndroid, PorterDuff.Mode.SrcAtop);
            }

            var textLength = editor.Text?.Length;
            if (textLength == 0)
            {
                editor.TextColor = color;
            }
            else
            {
                editor.TextColor = Xamarin.Forms.Color.Black;
            }
        }
    }
}