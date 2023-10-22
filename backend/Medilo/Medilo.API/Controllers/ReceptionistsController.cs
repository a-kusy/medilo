using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Repositories.Contracts;
using Medilo.API.Models.DTO;
using Medilo.API.Models;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistsController : ControllerBase
    {
        private readonly IReceptionistRepository _receptionistRepository;

        public ReceptionistsController(IReceptionistRepository receptionistRepository)
        {
            _receptionistRepository = receptionistRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receptionist>> GetReceptionist(int id)
        {
            return await _receptionistRepository.GetAsync(id);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receptionist>>> GetAll()
        {
            return await _receptionistRepository.GetAll();
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<Receptionist>> GetReceptionistByUserId(int userId)
        {
            return await _receptionistRepository.GetByUserId(userId);
        }

        [HttpPost]
        public async Task<ActionResult<Receptionist>> AddReceptionist([FromBody] ReceptionistDto receptionistDto)
        {
            return await _receptionistRepository.Add(receptionistDto);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReceptionist(int id)
        {
            await _receptionistRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
