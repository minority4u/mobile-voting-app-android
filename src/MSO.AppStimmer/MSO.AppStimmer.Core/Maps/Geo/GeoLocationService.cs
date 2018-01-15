using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MSO.StimmApp.Core.Maps.Geo
{
    public class GeoLocationService : IGeoLocationService
    {
        public async Task<Position> TryGetCurrentPosition(TimeSpan? timeout = null, CancellationToken? token = null, 
            bool includeHeading = false, double accuracy = 100)
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = accuracy;

                var position = await locator.GetLastKnownLocationAsync();

                // If we have a cached position, just return it
                if (position != null)
                    return position;

                // If we don't have a cached position, check geolocation availability
                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    return null;

                position = await locator.GetPositionAsync(timeout, token, includeHeading);
                return position;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
