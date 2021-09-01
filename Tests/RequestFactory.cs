using Api;
using NUnit.Framework.Internal;

namespace Tests
{
    public class RequestFactory
    {
        public static AddPersonCommand CreateAddPersonCommand()
        {
            var randomizer = Randomizer.CreateRandomizer();
            return new(
                $"FirstName-{randomizer.GetString(10)}",
                $"LastName-{randomizer.GetString(10)}");
        }
    }
}
