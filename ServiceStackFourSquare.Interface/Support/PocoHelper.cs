using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ServiceStackFourSquare.Interface.Support
{
    public static class PocoHelper
    {
        public static string ToFFUrl(this object poco)
        {
            return "".AppendAuth() + "&" + PocoToUrl(poco);
        }

        public static string PocoToUrl(object poco)
        {
            Type t = poco.GetType();
            NameValueCollection nvc = new NameValueCollection();
            foreach (var p in t.GetProperties())
            {
                var name = p.Name;
                var value = p.GetValue(poco, null).ToString();
                nvc.Add(name, value);
            }

            var result = ConstructQueryString(nvc);
            return result;
        }

        public static string ConstructQueryString(NameValueCollection Params)
        {
            List<string> items = new List<string>();

            foreach (string name in Params)
                items.Add(String.Concat(name, "=", Params[name].UrlEncode()));

            return string.Join("&", items.ToArray());
        }
    }
}
