using Newtonsoft.Json;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Rivington.IG.Domain
{
    public class MapService : IMapService
    {
        public TempPolicy GetAddressGeocode(TempPolicy policy)
        {  
            string requestUri = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(policy.Address)}&key=AIzaSyD93rX1ZlgbN3tEieWTMtqH9BwoXEHLDI0";
            var result = new System.Net.WebClient().DownloadString(requestUri);
            GoogleMapApiResponse googleResponse = JsonConvert.DeserializeObject<GoogleMapApiResponse>(result);

            if (googleResponse.results.Length != 0)
            {
                policy.Latitude = googleResponse.results.First().geometry.location.lat.ToString();
                policy.Longitude = googleResponse.results.First().geometry.location.lng.ToString();
            }

            return policy;
        }

        public Policy GetAddressGeocode(Policy policy)
        {
            var ApiKey = AppSettings.Configuration["JsMapApiKey"];
            string requestUri = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(policy.Address)}&key={ApiKey}";
            var result = new System.Net.WebClient().DownloadString(requestUri);
            GoogleMapApiResponse googleResponse = JsonConvert.DeserializeObject<GoogleMapApiResponse>(result);

            if (googleResponse.results.Length != 0)
            {
                policy.Latitude = googleResponse.results.First().geometry.location.lat.ToString();
                policy.Longitude = googleResponse.results.First().geometry.location.lng.ToString();
            }

            return policy;
        }
    }
}
