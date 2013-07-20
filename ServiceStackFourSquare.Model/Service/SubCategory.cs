using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStackFourSquare.Model.FFCategory;
using System.Collections.Generic;

namespace ServiceStackFourSquare.Model.Service
{
    [Route("/subcategories/", "GET, OPTIONS")]                                      // general search route (send params in query string)
    [Route("/subcategories/bytopcategoryname/{topcategoryname}", "GET, OPTIONS")]   // specialized route for name only search
    [Route("/subcategories/bytopcategoryid/{topcategoryid}", "GET, OPTIONS")]       // specialized route for id only search
    [Route("/subcategories/name/{name}", "GET, OPTIONS")]                           // specialized route for direct subcategory search by name 
    public class SubCategories
    {
        public string TopCategoryName { get; set; }
        public string TopCategoryId { get; set; }
        public string Name { get; set; }
    }

    public class SubCategoriesResponse : IHasResponseStatus
    {
        public List<Category> Categories { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}
