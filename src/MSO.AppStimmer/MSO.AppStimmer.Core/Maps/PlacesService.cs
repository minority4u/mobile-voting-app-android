using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MSO.StimmApp.Core.Maps
{
    public class PlacesService : IPlacesService
    {
        private const string ApiUrl = "https://maps.googleapis.com/maps/api/place/autocomplete/json";
        private const string DetailsUrl = "https://maps.googleapis.com/maps/api/place/details/json";
        private const string ApiKey = "AIzaSyBYePfJo7nYCRSo34l5Ujsa275qcFFBt9k";

        public async Task<AutoCompleteResult> GetPlaces(string searchText, PlacesSearchOptions options)
        {
            var client = new HttpClient();
            var requestUrl = BuildRequestUri(searchText, options);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new PlacesException("Places HTTP request denied.");
            }

            var result = await response.Content.ReadAsStringAsync();

            if (result == "ERROR")
            {
                throw new PlacesException("PlacesSearchBar Google Places API returned ERROR: ");
            }

            var places = JsonConvert.DeserializeObject<AutoCompleteResult>(result);
            return places;
        }

        public async Task<Place> GetPlace(string placeId)
        {
            var requestUrl = CreateDetailsRequestUri(placeId);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new PlacesException("Places HTTP request denied.");
            }

            var result = await response.Content.ReadAsStringAsync();

            if (result == "ERROR")
            {
                throw new PlacesException("PlacesSearchBar Google Places API returned ERROR: ");
            }

            var place = new Place(JObject.Parse(result));
            return place;
        }

        private string CreateDetailsRequestUri(string placeId)
        {
            return $"{DetailsUrl}?placeid={Uri.EscapeUriString(placeId)}&key={ApiKey}";
        }

        private string BuildRequestUri(string searchText, PlacesSearchOptions options)
        {
            var baseUrl = ApiUrl;
            var location = options.BaseLocation;
            var radius = options.Radius;
            var components = options.Countries;

            var url = $"{baseUrl}?input={searchText}&key={ApiKey}&location={location}&radius={radius}&components={components}";
            return url;
        }
    }
}
