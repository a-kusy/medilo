using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ICollection<ScheduleDto> schedulesDto)
        {
           var result = await _scheduleRepository.Add(schedulesDto);

            if (result) return Ok();
            else return BadRequest("Godziny pracy kolidują się");
        }
    }
}
