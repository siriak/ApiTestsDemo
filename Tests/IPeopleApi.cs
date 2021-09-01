using System.Threading.Tasks;
using Api;
using Refit;

namespace Tests
{
    public interface IPeopleApi
    {
        [Post("/people")]
        Task<int> AddAsync([Body] AddPersonCommand command);

        [Get("/people/{id}")]
        Task<Person> GetAsync(int id);
    }
}
