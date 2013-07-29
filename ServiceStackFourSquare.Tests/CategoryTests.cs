using NUnit.Framework;
using ServiceStack.ServiceClient.Web;
using ServiceStackFourSquare.Model.Service;
using ServiceStackFourSquare.Tests.Support;

namespace ServiceStackFourSquare.Tests
{
    public class CategoryTests
    {
        AppHostTest _appHost;

        [TestFixtureSetUp]
        public void TextFixtureSetUp()
        {
            _appHost = TestHelpers.Init();
        }

        //[Test]
        //public void Fail_If_Not_Authenticated()
        //{
        //    // arrange
        //    var restClient = TestHelpers.CreateRestClient(false);
        //    var responseStatus = 200;

        //    // act
        //    try
        //    {
        //        var response = restClient.Get<CategoriesResponse>("categories");
        //    }
        //    catch (WebServiceException ex)
        //    {
        //        responseStatus = ex.StatusCode;
        //    }

        //    // assert
        //    Assert.That(responseStatus, Is.EqualTo(401));
        //}

        [Test]
        public void Can_Get_List_Of_All_Categories_Tree()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<CategoriesResponse>("categories");

            // assert
            Assert.That(response.Categories.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Can_Get_List_Of_SubCategories_ByName_Food()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<SubCategoriesResponse>("subcategories/bytopcategoryname/food"); // alternative url :: subcategories?topcategoryname=food

            // assert
            Assert.That(response.Categories.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Can_Get_List_Of_SubCategories_ById_4d4b7105d754a06374d81259()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<SubCategoriesResponse>("subcategories/bytopcategoryid/4d4b7105d754a06374d81259"); // alternative url :: subcategories?topcategoryid=4d4b7105d754a06374d81259

            // assert
            Assert.That(response.Categories.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Return_Zero_SubCategories_If_Top_Category_Not_Found()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<SubCategoriesResponse>("subcategories/bytopcategoryname/non_exiting_top_category");

            // assert
            Assert.That(response.Categories.Count, Is.EqualTo(0));
        }

        [Test]
        public void Can_Get_Single_Existing_SubCategory_ByName()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);

            // act
            var response = restClient.Get<SubCategoriesResponse>("subcategories/name/korean restaurant");

            // assert
            Assert.That(response.Categories.Count, Is.EqualTo(1));
        }

        [Test]
        public void Fail_To_Find_Route_If_Parameter_Not_Supplied_In_SubCategory_Name_Search()
        {
            // arrange
            var restClient = TestHelpers.CreateRestClient(true);
            var responseStatus = 200;

            // act
            try
            {
                var response = restClient.Get<SubCategoriesResponse>("subcategories/bytopcategoryname");
            }
            catch (WebServiceException ex)
            {
                responseStatus = ex.StatusCode;
            }

            // assert
            Assert.That(responseStatus, Is.EqualTo(404));
        }
    }
}
