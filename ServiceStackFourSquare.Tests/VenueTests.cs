using NUnit.Framework;
using ServiceStack.ServiceClient.Web;
using ServiceStackFourSquare.Interface.Support;
using ServiceStackFourSquare.Model.FFVenue;
using ServiceStackFourSquare.Model.Service;
using ServiceStackFourSquare.Tests.Support;
using System.Linq;

namespace ServiceStackFourSquare.Tests
{
    public class VenueTests
    {
        AppHostTest _appHost;

        [TestFixtureSetUp]
        public void TextFixtureSetUp()
        {
            _appHost = TestHelpers.Init();
        }

        [Test]
        public void Fail_If_Not_Authenticated()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(false);
            var responseStatus = 200;

            // act
            try
            {
                var response = restClient.Get<VenuesResponse>("venues");
            }
            catch (WebServiceException ex)
            {
                responseStatus = ex.StatusCode;
            }

            // assert
            Assert.That(responseStatus, Is.EqualTo(401));
        }

        [Test]
        public void Can_Get_List_Of_Venus_By_Params_Near_And_Radius()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<VenuesResponse>("venues?near=empire state building&radius=1609");  // 1 mile ~ 1609 meters

            // assert
            Assert.That(response.Venues.response.venues.ToList().Count, Is.GreaterThan(0));
        }

        [Test]
        public void Can_Get_List_Of_Venus_By_Params_Near_And_Radius_SubCategoryName()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<VenuesResponse>("venues?near=empire state building&radius=1609&subcategoryname=Korean Restaurant");  

            // assert
            Assert.That(response.Venues.response.venues.ToList().Count, Is.GreaterThan(0));
        }

        [Test]
        public void Return_Zero_Results_If_SubCategory_Is_Not_Existing()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<VenuesResponse>("venues?near=empire state building&radius=1609&subcategoryname=non exiting subcategory name");  

            // assert
            Assert.That(response.Venues.meta.code, Is.EqualTo(400));
        }

        [Test]
        public void Fail_If_Venues_Search_By_Param_Near_Of_Non_Existing_Geo_Location()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<VenuesResponse>("venues?near=non exiting location");

            // assert
            Assert.That(response.Venues.meta.code, Is.EqualTo(400));
        }

        [Test]
        public void Use_RestClient_To_Send_Poco_And_Receive_Poco()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);
            var ffRequestPoco = new FFRequestVenueSearchPOCO { near = "empire state building", radius = 1609 };

            // act
            var pocoToUrl = ffRequestPoco.ToFFUrl();
            var response = restClient.Get<FFVenueRoot>("https://api.foursquare.com/v2/venues/search" + pocoToUrl);  // 1 mile ~ 1609 meters

            // assert
            Assert.That(response.response.venues.ToList().Count, Is.GreaterThan(0));
        }

    }
}
