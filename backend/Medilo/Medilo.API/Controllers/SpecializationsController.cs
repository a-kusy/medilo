using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Models.DTO;
using Medilo.API.Models;
using Medilo.API.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Medilo.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationRepository _specializationRepository;

        public SpecializationsController(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialization>>> GetAll()
        {
            return await _specializationRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Specialization>> Get(int id)
        {
            return await _specializationRepository.GetAsync(id);
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddSpecialization([FromBody] SpecializationDto specializationDto)
        {
            var res = await _specializationRepository.Add(specializationDto);
            return Ok(res);
        }

        //[Authorize(Policy = CustomRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            await _specializationRepository.DeleteAsync(id);
            return Ok();
        }

        //[Authorize(Policy = CustomRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> EditSpecialization(int id, [FromBody] SpecializationDto specializationDto)
        {
            await _specializationRepository.Update(id, specializationDto);
            return Ok();
        }
    }
}
