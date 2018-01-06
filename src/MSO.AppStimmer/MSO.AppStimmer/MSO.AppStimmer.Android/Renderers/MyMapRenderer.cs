using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using TK.CustomMap;
using TK.CustomMap.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Void = Java.Lang.Void;

[assembly: ExportRenderer(typeof(CustomTkCustomMap), typeof(MyMapRenderer))]
namespace MSO.StimmApp.Droid.Renderers
{
    public class MyMapRenderer : TKCustomMapRenderer
    {
        private GoogleMap googleMap;
        private TKCustomMap customMap;
        private MarkerOptions marker;

        public MyMapRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TKCustomMap> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                this.customMap = e.NewElement;            
        }

        private void UpdatePinss()
        {
            if (this.googleMap == null || this.customMap == null)
                return;

            var pin = this.customMap.SelectedPin;
            if (pin == null)
                return;

            var markerWithIcon = new MarkerOptions();
            markerWithIcon.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            markerWithIcon.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.marker_appStimmer));

            this.googleMap.Clear();
            this.googleMap.AddMarker(markerWithIcon);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);           
            this.UpdatePinss();
        }

        public override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            if (map != null)
            {
                map.UiSettings.ZoomControlsEnabled = false;
                this.googleMap = map;
                this.UpdatePinss();
            }
        }
    }
}