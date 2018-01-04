using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsContentPage : PopupPage
    {
        public MapsContentPage()
        {
            this.InitializeComponent();

            var map = new TKCustomMap(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(10)));
            map.MapLongPress += MapOnMapLongPress;

            var pin = new TKCustomMapPin
            {
                Position = new Position(37, -122),

            };

            var pins = new ObservableCollection<TKCustomMapPin>();
            pins.Add(pin);

            map.Pins = pins;
            map.SelectedPin = pin;
            //var pin = new Pin()
            //{
            //    Position = new Position(37, -122),
            //    Label = "Some Pin!"
            //};
            //map.Pins.Add(pin);

            this.Content = map;


            //MyMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //        new Position(37, -122), Distance.FromMiles(1)));
        }

        private void MapOnMapLongPress(object sender, TKGenericEventArgs<Position> tkGenericEventArgs)
        {
            Debug.WriteLine("Latitude: " + tkGenericEventArgs.Value.Latitude);
            Debug.WriteLine("Longitude: " + tkGenericEventArgs.Value.Longitude);
        }
    }
}