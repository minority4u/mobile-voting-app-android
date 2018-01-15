using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSO.StimmApp.Core.Maps.Geo
{
    public interface IGeoLocationService
    {
        Task<Plugin.Geolocator.Abstractions.Position> TryGetCurrentPosition(TimeSpan? timeout = null,
            CancellationToken? token = null, bool includeHeading = false, double accuracy = 100);
    }
}
