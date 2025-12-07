using System.Net.Http.Headers;
using Refit;

namespace Tests
{
    public class ApiClient
    {
        public IPeopleApi PeopleApi { get; }
        // public IThingApi ThingApi { get; }
        // public IAnotherThingApi AnotherThingApi { get; }

        public ApiClient(HttpClient client, string authenticationToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                authenticationToken);
            PeopleApi = RestService.For<IPeopleApi>(client);
        }
    }
}
