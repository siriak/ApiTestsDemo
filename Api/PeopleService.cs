using System.Data;

namespace Api
{
    public record GetPersonRequest(int Id);
    public record AddPersonCommand(string FirstName, string LastName);
    public record Person(int Id, string FirstName, string LastName);

    public class PeopleService
    {
        private static readonly List<Person> People = new();
        private static int _lastId;
        private static int NextId => ++_lastId;

        public int Add(AddPersonCommand addPersonCommand)
        {
            if (People.Any(p => p.FirstName == addPersonCommand.FirstName && p.LastName == addPersonCommand.LastName))
            {
                throw new DuplicateNameException("This person already exists");
            }

            var (firstName, lastName) = addPersonCommand;
            var person = new Person(NextId, firstName, lastName);
            People.Add(person);
            return person.Id;
        }

        public Person? Get(GetPersonRequest request) => People.FirstOrDefault(p => p.Id == request.Id);
    }
}
