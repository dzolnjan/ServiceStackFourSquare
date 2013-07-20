
namespace ServiceStackFourSquare.Model.FFVenue
{
    public class FFVenueRoot
    {
        public Meta meta { get; set; }
        public Notification[] notifications { get; set; }
        public Response response { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
    }

    public class Response
    {
        public Venue[] venues { get; set; }
        public Geocode geocode { get; set; }
    }

    public class Geocode
    {
        public string what { get; set; }
        public string where { get; set; }
        public Feature feature { get; set; }
        public object[] parents { get; set; }
    }

    public class Feature
    {
        public string cc { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string matchedName { get; set; }
        public string highlightedName { get; set; }
        public int woeType { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public bool hasCityPage { get; set; }
        public bool allowExplore { get; set; }
    }

    public class Geometry
    {
        public Center center { get; set; }
    }

    public class Center
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public string canonicalUrl { get; set; }
        public Category[] categories { get; set; }
        public bool verified { get; set; }
        public Stats stats { get; set; }
        public string url { get; set; }
        public Specials specials { get; set; }
        public Herenow hereNow { get; set; }
        public string storeId { get; set; }
        public string referralId { get; set; }
        public Menu menu { get; set; }
        public Venuepage venuePage { get; set; }
    }

    public class Contact
    {
        public string phone { get; set; }
        public string formattedPhone { get; set; }
        public string twitter { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string cc { get; set; }
    }

    public class Stats
    {
        public int checkinsCount { get; set; }
        public int usersCount { get; set; }
        public int tipCount { get; set; }
    }

    public class Specials
    {
        public int count { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public string description { get; set; }
        public string finePrint { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string provider { get; set; }
        public string redemption { get; set; }
        public Page page { get; set; }
    }

    public class Page
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string gender { get; set; }
        public Photo photo { get; set; }
        public string type { get; set; }
        public Followers followers { get; set; }
        public Tips tips { get; set; }
        public string homeCity { get; set; }
        public string bio { get; set; }
        public Contact1 contact { get; set; }
        public Venue1 venue { get; set; }
        public Lists lists { get; set; }
    }

    public class Photo
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Followers
    {
        public int count { get; set; }
        public object[] groups { get; set; }
    }

    public class Tips
    {
        public int count { get; set; }
    }

    public class Contact1
    {
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class Venue1
    {
        public string id { get; set; }
    }

    public class Lists
    {
        public Group[] groups { get; set; }
    }

    public class Group
    {
        public string type { get; set; }
        public int count { get; set; }
        public object[] items { get; set; }
    }

    public class Herenow
    {
        public int count { get; set; }
        public Group1[] groups { get; set; }
    }

    public class Group1
    {
        public string type { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public object[] items { get; set; }
    }

    public class Menu
    {
        public string type { get; set; }
        public string label { get; set; }
        public string anchor { get; set; }
        public string url { get; set; }
        public string mobileUrl { get; set; }
    }

    public class Venuepage
    {
        public string id { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public Icon icon { get; set; }
        public bool primary { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Notification
    {
        public string type { get; set; }
        public Item1 item { get; set; }
    }

    public class Item1
    {
        public int unreadCount { get; set; }
    }

}
