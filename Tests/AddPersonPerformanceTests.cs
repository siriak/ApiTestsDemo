using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using static Tests.RequestFactory;

namespace Tests
{
    public class AddPersonPerformanceTests : ApiTestBase
    {
        [Test]
        public async Task AddPerson_PerformanceTest()
        {
            const int numberOfSamples = 1000;
            var responseTimesMs = new long[numberOfSamples];
            var stopwatch = new Stopwatch();
            for (var i = 0; i < numberOfSamples; i++)
            {
                var addPersonCommand = CreateAddPersonCommand();
                stopwatch.Restart();
                await AdminApiClient.PeopleApi.AddAsync(addPersonCommand);
                stopwatch.Stop();
                responseTimesMs[i] = stopwatch.ElapsedMilliseconds;
            }

            responseTimesMs.Max().Should().BeLessThan(300);
            responseTimesMs.Average().Should().BeLessThan(10);
        }
    }
}
