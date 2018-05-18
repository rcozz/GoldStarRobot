using System;
using System.Net;
using System.Web;
using GSR_Model.Geospatial;
using Newtonsoft.Json;

namespace GSR_Service.Geospatial
{
    public class ArcGisService : BaseGeospatialService
    {
        public ArcGisService(string geospatialUrl)
        {
            GeospatialUrl = geospatialUrl;
        }

        private string GeospatialUrl { get;}

        public const int MaxLocations = 25;
        public const string OutFields = "&outFields=*";
        public const string OutSr = "&outSR=4326";
        public const string MaxLocationsParameter = "&maxLocations=";
        public const string ResultFormat = "&f=pjson";


        
        public override GeospatialModels.GeospatialResults FindAddressResults(string street, string city, string state, string zip)
        {
            try
            {
                var address = GetAddressFormatted(street, city, state, zip);
                return GetResults(MaxLocations, address);
            }
            catch (Exception)
            {
                throw new Exception(InvalidLocationErrorMessage);
            }

        }

        public override GeospatialModels.GeospatialResults FindAddress(string street, string city, string state, string zip)
        {
            try
            {
                return GetResults(1, GetAddressFormatted(street, city, state, zip));
            }
            catch (Exception)
            {
                throw new Exception(InvalidLocationErrorMessage);
            }
        }

        private string FormulateUrl(int maxLocations, string address)
        {
            var url = GeospatialUrl;

            if (string.IsNullOrEmpty(url))
            {
                throw new ApplicationException(InvalidGeospatialUrl);
            }
            url = url + "?&Address=" + address.ToUpper() + OutFields + MaxLocationsParameter + maxLocations + OutSr +
                  ResultFormat;

            return url;
        }

        private GeospatialModels.GeospatialResults GetResults(int maxLocations, string address)
        {
            var url = FormulateUrl(maxLocations, address);

            var result = new WebClient().DownloadString(url);

            return JsonConvert.DeserializeObject<GeospatialModels.GeospatialResults>(result);

        }

        private string GetAddressFormatted(string street, string city, string state, string zip)
        {
            if (string.IsNullOrEmpty(state))
            {
                return HttpUtility.UrlEncode(street.ToUpper()) +
                                             "&City=" + HttpUtility.UrlEncode(city.ToUpper()) +
                                             "&Zip=" + zip.ToUpper().Replace(" ", "+");
            }

            return HttpUtility.UrlEncode(street.ToUpper()) +
                   "&City=" + HttpUtility.UrlEncode(city.ToUpper()) +
                   "&State=" + HttpUtility.UrlEncode(state.ToUpper()) +
                   "&Zip=" + zip.ToUpper().Replace(" ", "+");


        }
    }
}
