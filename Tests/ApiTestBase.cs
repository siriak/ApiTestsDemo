using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace Tests
{
    public class ApiTestBase
    {
        private static WebApplicationFactory<Startup> WebAppFactory { get; set; }
        protected ApiClient AdminApiClient { get; set; }
        protected ApiClient OrdinaryUserApiClient { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebAppFactory = new WebApplicationFactory<Startup>();
            AdminApiClient = GetAdminApiClient();
            OrdinaryUserApiClient = GetOrdinaryUserApiClient();
        }

        private static ApiClient GetAdminApiClient() => new(
                WebAppFactory.CreateDefaultClient(),
                "SecretAdminAuthenticationToken");

        private static ApiClient GetOrdinaryUserApiClient() => new(
                WebAppFactory.CreateDefaultClient(),
                "SecretOrdinaryUserAuthenticationToken");
    }
}
