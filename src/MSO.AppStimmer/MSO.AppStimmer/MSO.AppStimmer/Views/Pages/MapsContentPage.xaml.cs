using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsContentPage : PopupPage
    {
        public MapsContentPage()
        {
            InitializeComponent();
            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(37, -122), Distance.FromMiles(1)));
        }
    }
}