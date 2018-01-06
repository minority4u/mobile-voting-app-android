using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Core.Maps
{
    public interface IPlacesService
    {
        Task<AutoCompleteResult> GetPlaces(string searchText, PlacesSearchOptions options);

        Task<Place> GetPlace(string placeId);
    }
}
