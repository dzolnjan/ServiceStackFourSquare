using ServiceStack.ServiceInterface;
using ServiceStack.Text;
using ServiceStackFourSquare.Interface.Support;
using ServiceStackFourSquare.Model.FFCategory;
using ServiceStackFourSquare.Model.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ServiceStackFourSquare.Interface
{
    [Authenticate]
    public class CategoryService : Service
    {
        public CategoriesResponse Get(Categories request)
        {
            WebClient web = new WebClient();

            var url = "https://api.foursquare.com/v2/venues/categories".AppendAuth();

            var response = web.DownloadString(url);

            var ffResponse = JsonSerializer.DeserializeFromString<FFCategoryRoot>(response);

            return new CategoriesResponse()
            {
                Categories = ffResponse.response.categories.ToList()
            };
        }

        public CategoriesResponse Get(SubCategories request)
        {
            WebClient web = new WebClient();

            var url = "https://api.foursquare.com/v2/venues/categories".AppendAuth();

            var response = web.DownloadString(url);

            var ffResponse = JsonSerializer.DeserializeFromString<FFCategoryRoot>(response);

            var subCategories = new List<Category>();

            if (request.TopCategoryId != null)
            {
                subCategories = ffResponse.response.categories.Where(x => x.id == request.TopCategoryId).ToList();
            }

            if (request.TopCategoryName != null)
            {
                subCategories = ffResponse.response.categories.Where(x => x.name.ToLower().Contains(request.TopCategoryName.ToLower())).ToList();
            }

            if (request.Name != null)
            {
                subCategories = ffResponse.response.categories.SelectMany(x => x.categories).Where(x => x.name.ToLower().Contains(request.Name.ToLower())).ToList();
            }

            return new CategoriesResponse()
            {
                Categories = subCategories
            };
        }
    }
}
