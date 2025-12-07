using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace Tests
{
    public class ApiTestBase
    {
        private static WebApplicationFactory<Program>? WebAppFactory { get; set; }
        protected ApiClient AdminApiClient { get; set; } = null!;
        protected ApiClient OrdinaryUserApiClient { get; set; } = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WebAppFactory = new WebApplicationFactory<Program>();
            AdminApiClient = GetAdminApiClient();
            OrdinaryUserApiClient = GetOrdinaryUserApiClient();
        }

        private static ApiClient GetAdminApiClient() => new(
                WebAppFactory!.CreateDefaultClient(),
                "SecretAdminAuthenticationToken");

        private static ApiClient GetOrdinaryUserApiClient() => new(
                WebAppFactory!.CreateDefaultClient(),
                "SecretOrdinaryUserAuthenticationToken");
    }
}
