using System;
using MSO.StimmApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellItemSelectedCustomRenderer))]
namespace MSO.StimmApp.Droid
{
    public class ViewCellItemSelectedCustomRenderer : ViewCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            cell.SetBackgroundResource(Resource.Drawable.ViewCellBackground);

            return cell;
        }
    }
}