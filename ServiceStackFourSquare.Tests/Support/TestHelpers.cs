using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Service;
using ServiceStack.ServiceClient.Web;

namespace ServiceStackFourSquare.Tests.Support
{
    public static class TestHelpers
    {
        static AppHostTest _appHost;

        public static AppHostTest Init()
        {
            if (_appHost == null)
            {
                _appHost = new AppHostTest();
                _appHost.Init();
            }

            return _appHost;
        }

        public static IRestClient CreateRestClient(bool authenticated)
        {
            return authenticated ?
                new JsonServiceClient(AppHostTest.ListeningOn)
                {
                    UserName = "johndoe",
                    Password = "12345",
                }
                :
                new JsonServiceClient(AppHostTest.ListeningOn);
        }
    }
}
