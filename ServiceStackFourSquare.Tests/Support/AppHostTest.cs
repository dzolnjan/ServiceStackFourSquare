using Funq;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using ServiceStackFourSquare.Interface;

namespace ServiceStackFourSquare.Tests.Support
{
    public class AppHostTest : AppHostHttpListenerBase
    {
        public const string ListeningOn = "http://localhost:12345/";
        public const string FFAccessToken = "SMRF1L2YCFOSIR3XOW5TCB2AVRLDCDKOVEYL1I502ETZSWOZ";
        public const string FFVersion = "20130719";

        public AppHostTest() : base("SSFF.Services", typeof(CategoryService).Assembly) { }

        public override void Configure(Container container)
        {
            Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] {
                new BasicAuthProvider(),  
            }));

            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);


            // lets put a test user in repo 
            string hash;
            string salt;
            string password = "12345";
            new SaltedHash().GetHashAndSaltString(password, out hash, out salt);

            var user1 = userRep.CreateUserAuth(new UserAuth
            {
                Id = 1,
                DisplayName = "John Doe",
                Email = "johndoe@acme.com",
                UserName = "johndoe",
                FirstName = "John",
                LastName = "Doe",
                PasswordHash = hash,
                Salt = salt,
            }, password);


            this.Start(ListeningOn);
        }
    }
}
