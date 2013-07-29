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

        public static JsonServiceClient CreateRestClient(bool authenticated)
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
