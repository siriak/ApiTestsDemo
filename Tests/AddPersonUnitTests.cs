using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Refit;
using static Tests.RequestFactory;

namespace Tests
{
    public class AddPersonUnitTests : ApiTestBase
    {
        [Test]
        public Task AddPerson_CanAddUnique()
        {
            var addPersonCommand = CreateAddPersonCommand();

            Func<Task> act = () => AdminApiClient.PeopleApi.AddAsync(addPersonCommand);

            return act.Should().NotThrowAsync();
        }

        [Test]
        public async Task AddPerson_CannotAddDuplicate()
        {
            var addPersonCommand = CreateAddPersonCommand();

            await AdminApiClient.PeopleApi.AddAsync(addPersonCommand);
            Func<Task> act = () => AdminApiClient.PeopleApi.AddAsync(addPersonCommand);

            (await act.Should().ThrowAsync<ApiException>("cannot add duplicates"))
                .Which.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
