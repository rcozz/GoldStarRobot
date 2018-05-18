using GSR_Model.Geospatial;

namespace GSR_Service.Geospatial
{
    public interface IGeospatialService
    {
        GeospatialModels.GeospatialResults FindAddressResults(string street, string city, string state, string zip);

        GeospatialModels.GeospatialResults FindAddress(string street, string city, string state, string zip);
    }
}
