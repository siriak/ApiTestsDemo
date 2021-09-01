using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Refit;
using static Tests.RequestFactory;

namespace Tests
{
    public class AddPersonSecurityTests : ApiTestBase
    {
        [Test]
        public Task AddPerson_AdminCanAdd()
        {
            var addPersonCommand = CreateAddPersonCommand();

            Func<Task> act = () => AdminApiClient.PeopleApi.AddAsync(addPersonCommand);

            return act.Should().NotThrowAsync("admins can add new people");
        }

        [Test]
        public async Task AddPerson_OrdinaryUserCannotAdd()
        {
            var addPersonCommand = CreateAddPersonCommand();

            Func<Task> act = () => OrdinaryUserApiClient.PeopleApi.AddAsync(addPersonCommand);

            (await act.Should().ThrowAsync<ApiException>("ordinary users cannot add new people"))
                .Which.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}
