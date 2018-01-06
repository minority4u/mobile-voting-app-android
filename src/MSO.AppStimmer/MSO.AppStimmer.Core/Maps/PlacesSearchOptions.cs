using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Core.Maps
{
    public class PlacesSearchOptions
    {
        public PlaceType PlaceType { get; set; } = PlaceType.All;

        public MapLocation BaseLocation { get; set; } = new MapLocation {Latitude = 0, Longitude = 0};

        public int Radius { get; set; } = 40000 * 1000;

        public string Countries { get; set; } = "country:de";
    }
}
