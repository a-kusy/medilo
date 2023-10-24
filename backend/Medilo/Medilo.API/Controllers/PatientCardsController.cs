using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Repositories.Contracts;
using Medilo.API.Models.DTO;
using Medilo.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardsController : ControllerBase
    {
        private readonly IPatientCardRepository _patientCardRepository;

        public PatientCardsController(IPatientCardRepository patientCardRepository)
        {
            _patientCardRepository = patientCardRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PatientCard>> GetAll()
        {
            return await _patientCardRepository.GetAll();
        }


        [HttpGet("{pesel}")]
        public async Task<PatientCard> Get(string pesel)
        {
            return await _patientCardRepository.GetByPesel(pesel);
        }

        [HttpPost]
        public async Task<ActionResult<PatientCard>> Add([FromBody] PatientCardDto patientCardDto)
        {
            var res = await _patientCardRepository.Add(patientCardDto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]PatientCardDto patientCardDto)
        {
             await _patientCardRepository.Update(id, patientCardDto);
            return Ok();
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientCardRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
