using System;
using GSR_Model.Geospatial;

namespace GSR_Service.Geospatial
{
    public abstract class BaseGeospatialService : IGeospatialService
    {

        protected const string InvalidLocationErrorMessage = "Location Not Found";
        protected const string InvalidGeospatialUrl = "Invalid Geospatial Url";
        protected const string ApplicationConfigurationKey = "AppConfiguration";
        protected const string GeospatialUrlKey = "GeospatialUrl";

        public virtual GeospatialModels.GeospatialResults FindAddressResults(string street, string city, string state, string zip)
        {
            throw new NotImplementedException();
        }

        public virtual GeospatialModels.GeospatialResults FindAddress(string street, string city, string state, string zip)
        {
            throw new NotImplementedException();
        }


    }
}
