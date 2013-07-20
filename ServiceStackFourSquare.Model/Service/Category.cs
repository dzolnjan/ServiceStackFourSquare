using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStackFourSquare.Model.FFCategory;
using System.Collections.Generic;

namespace ServiceStackFourSquare.Model.Service
{
    [Route("/categories", "GET, OPTIONS")]
    public class Categories
    {

    }

    public class CategoriesResponse : IHasResponseStatus
    {
        public List<Category> Categories { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}
