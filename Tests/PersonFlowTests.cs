using Api;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using static Tests.RequestFactory;

namespace Tests
{
    public class PersonFlowTests : ApiTestBase
    {
        private int PersonId { get; set; }
        private AddPersonCommand AddPersonCommand { get; set; } = null!;

        [Test]
        [Order(1)]
        public async Task AddPerson_IdReturned()
        {
            AddPersonCommand = CreateAddPersonCommand();

            PersonId = await AdminApiClient.PeopleApi.AddAsync(AddPersonCommand);

            PersonId.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public async Task GetPerson_DataIsCorrect()
        {
            var person = await AdminApiClient.PeopleApi.GetAsync(PersonId);

            using var assertionScope = new AssertionScope();
            person.Id.Should().Be(PersonId);
            person.FirstName.Should().Be(AddPersonCommand.FirstName);
            person.LastName.Should().Be(AddPersonCommand.LastName);
        }
    }
}
