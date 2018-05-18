
using System.Collections.Generic;

namespace GSR_Model.Geospatial
{
    public class GeospatialModels
    {
        public class GeospatialResults
        {
            public GeospatialReference SpatialReference { get; set; }
            public List<GeospatialCandidate> Candidates { get; set; }
        }

        public class GeospatialReference
        {
            public string Wkid { get; set; }
            public string LatestWkid { get; set; }
        }

        public class GeospatialCandidate
        {
            public string Address { get; set; }
            public GeospatialLocation Location { get; set; }
            public GeospatialAttributes Attributes { get; set; }
            public string Score { get; set; }
        }

        public class GeospatialLocation
        {
            public string X { get; set; }
            public string Y { get; set; }
        }

        public class GeospatialAttributes
        {
            public string Loc_name { get; set; }
            public string Score { get; set; }
            public string Match_addr { get; set; }
            public string House { get; set; }
            public string Side { get; set; }
            public string PreDir { get; set; }
            public string StreetName { get; set; }
            public string SufType { get; set; }
            public string SufDir { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZIP { get; set; }
            public string X { get; set; }
            public string Y { get; set; }
            public string Addr_type { get; set; }
            public string FromAddr { get; set; }
            public string ToAddr { get; set; }
            public string User_fld { get; set; }
            public string KeyField { get; set; }
            public string PlaceName { get; set; }
            public string Country { get; set; }
            public string Descr { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string North_Lat { get; set; }
            public string South_Lat { get; set; }
            public string West_Lon { get; set; }
            public string East_Lon { get; set; }
            public string Priority { get; set; }
            public string County { get; set; }
            public string State_Abbr { get; set; }
            public string Cntry_Abbr { get; set; }
            public string Language { get; set; }
        }
    }
}
