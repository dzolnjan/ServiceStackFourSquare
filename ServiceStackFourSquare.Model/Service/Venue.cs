using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStackFourSquare.Model.FFVenue;

namespace ServiceStackFourSquare.Model.Service
{
    [Route("/venues", "GET, OPTIONS")]
    public class Venues
    {
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public string Near { get; set; }
        public int? Radius { get; set; }
        public string SubCategoryName { get; set; }
    }

    public class VenuesResponse : IHasResponseStatus
    {
        public FFVenueRoot Venues { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}
