using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService) => _peopleService = peopleService;

        [HttpGet("{id}")]
        public ActionResult<Person> Get([FromRoute] GetPersonRequest request)
        {
            var person = _peopleService.Get(request);
            return person is null
                ? NotFound()
                : Ok(person);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult<int> Add(AddPersonCommand addPersonCommand)
        {
            try
            {
                return _peopleService.Add(addPersonCommand);
            }
            catch (DuplicateNameException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
