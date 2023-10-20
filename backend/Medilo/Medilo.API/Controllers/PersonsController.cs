using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Repositories.Contracts;
using Medilo.API.Models;
using Medilo.API.Services;
using Medilo.API.Models.DTO;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;

        public PersonsController(IPersonRepository personRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return await _personRepository.GetAllWithAddress();
        }

        //GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            return await _personRepository.GetWithAddress(id);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson([FromBody] PersonAddressDto personAddress)
        {
            return await _personService.AddPersonWithAddress(personAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonAddressDto personAddress)
        {
            await _personService.UpdatePersonWithAddress(id, personAddress);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
