using ServiceStack.Text;
using System;

namespace ServiceStackFourSquare.Interface.Support
{
    public static class FFAuth
    {
        // get auth token for service calls simply here https://developer.foursquare.com/docs/explore#req=venues/categories
        const string access_token = "SMRF1L2YCFOSIR3XOW5TCB2AVRLDCDKOVEYL1I502ETZSWOZ";

        public static string GetAuthQueryString()
        {
            return "oauth_token={0}&v={1}".Fmt(access_token, DateTime.Today.ToString("yyyyMMdd"));
        }

        public static string AppendAuth(this string url)
        {
            return url + "?" + GetAuthQueryString();
        }
    }
}
