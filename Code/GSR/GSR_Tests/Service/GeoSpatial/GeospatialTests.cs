using GSR_Service.Geospatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GSR_Tests.Service.GeoSpatial
{
    
    public class GeospatialTests
    {
        private const string GeospatialUrl =
            "http://navigator.state.or.us/arcgis/rest/services/Locators/gc_Composite/GeocodeServer/findAddressCandidates";

        [TestClass]
        public class FindAddressTest
        {
            [TestMethod]
            public void TestFindAddressResults()
            {

                IGeospatialService service = new ArcGisService(GeospatialUrl);

                var street = "1411 Nw Flanders St";
                var city = "Portland";
                var state = string.Empty;
                var zip = "97209";

                var results = service.FindAddressResults(street, city, state, zip);

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Candidates.Count > 1);

                //URL Encoding issues
                street = street + " #A";
                results = service.FindAddressResults(street, city, state, zip);

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Candidates.Count > 1);

                //Invalid address
                street = "55555 Nw SomethingMadeUP St";
                city = "Fake";
                zip = "97200";

                results = service.FindAddress(street, city, state, zip);
                Assert.IsNotNull(results);

                Assert.IsTrue(results.Candidates.Count == 0);
            }

            [TestMethod]
            public void TestFindAddress()
            {
                IGeospatialService service = new ArcGisService(GeospatialUrl);

                var street = "1411 Nw Flanders St";
                var city = "Portland";
                var state = string.Empty;
                var zip = "97209";

                var results = service.FindAddress(street, city, state, zip);

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Candidates.Count == 1);

                //Invalid address
                street = "55555 Nw SomethingMadeUP St";
                city = "Fake";
                zip = "97200";

                results = service.FindAddress(street, city, state, zip);
                Assert.IsNotNull(results);

                Assert.IsTrue(results.Candidates.Count == 0);


            }
        }
    }
}