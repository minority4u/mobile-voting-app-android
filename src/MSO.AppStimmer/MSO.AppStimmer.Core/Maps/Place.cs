using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MSO.StimmApp.Core.Maps
{
    public class Place
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Raw { get; set; }

        public Place(JObject jsonObject)
        {
            Name = (string)jsonObject["result"]["name"];
            Latitude = (double)jsonObject["result"]["geometry"]["location"]["lat"];
            Longitude = (double)jsonObject["result"]["geometry"]["location"]["lng"];
            Raw = jsonObject.ToString();
        }
    }
}
