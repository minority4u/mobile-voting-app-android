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
using MSO.StimmApp.Droid;
using MSO.StimmApp.Droid.Effects;
using Xamarin.Forms;

[assembly: ResolutionGroupName("SliderEffects")]
[assembly: ExportEffect(typeof(RedSliderEffect), "RedSliderEffect")]
[assembly: ExportEffect(typeof(GreenSliderEffect), "GreenSliderEffect")]
[assembly: ExportEffect(typeof(BlueSliderEffect), "BlueSliderEffect")]
namespace MSO.StimmApp.Droid.Effects
{
   
}