using ServiceStack.ServiceInterface;
using ServiceStack.Text;
using ServiceStackFourSquare.Interface.Support;
using ServiceStackFourSquare.Model.FFVenue;
using ServiceStackFourSquare.Model.Service;
using System.IO;
using System.Linq;
using System.Net;

namespace ServiceStackFourSquare.Interface
{
    [Authenticate]
    public class VenueService : Service
    {
        public CategoryService CategoryService { get; set; }

        public VenuesResponse Get(Venues request)
        {
            var url = "https://api.foursquare.com/v2/venues/search".AppendAuth();

            if (request.Near != null)
            {
                var near = "&near={0}".Fmt(request.Near);
                url += near;
            }

            if (request.Radius != null)
            {
                var radius = "&radius={0}".Fmt(request.Radius);
                url += radius;
            }

            // lets reuse category service here 
            if (request.SubCategoryName != null) // lets reuse category service
            {
                var category = CategoryService.Get(new SubCategories() { Name = request.SubCategoryName });

                if (category.Categories.Count != 1)
                {
                    return new VenuesResponse()
                        {
                            Venues = new FFVenueRoot()
                                {
                                    meta = new ServiceStackFourSquare.Model.FFVenue.Meta() { code = 400 }
                                }
                        };
                }

                var categoryId = "&categoryId={0}".Fmt(category.Categories.First().id);
                url += categoryId;
            }

            var web = new WebClient();

            string response = null;

            try
            {
                response = web.DownloadString(url);
            }
            catch (WebException ex)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                }
            }

            var ffReposnse = JsonSerializer.DeserializeFromString<FFVenueRoot>(response);

            return new VenuesResponse()
            {
                Venues = ffReposnse
            };
        }
    }
}
