
namespace ServiceStackFourSquare.Model.FFCategory
{
    public class FFCategoryRoot
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
        public Category[] categories { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public Icon icon { get; set; }
        public Category[] categories { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Notification
    {
        public string type { get; set; }
        public Item item { get; set; }
    }

    public class Item
    {
        public int unreadCount { get; set; }
    }
}
