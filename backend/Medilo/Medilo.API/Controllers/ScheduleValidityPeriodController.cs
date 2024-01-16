using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleValidityPeriodController : ControllerBase
    {
        private readonly IScheduleValidityPeriodRepository _repository;

        public ScheduleValidityPeriodController(IScheduleValidityPeriodRepository scheduleValidityPeriodRepository) {
            _repository = scheduleValidityPeriodRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleValidityPeriod>> Add([FromBody] ScheduleValidityPeriodDto scheduleValidityPeriodDto)
        {
            return await _repository.Add(scheduleValidityPeriodDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleValidityPeriod>>> GetByDoctorId(int id)
        {
            return await _repository.GetByDoctorId(id);
        }
    }
}
