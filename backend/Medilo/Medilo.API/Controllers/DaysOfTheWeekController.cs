using Microsoft.AspNetCore.Mvc;
using Medilo.API.Models;
using Medilo.API.Repositories.Contracts;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysOfTheWeekController : ControllerBase
    {
        private readonly IDayOfTheWeekRepository _dayOfTheWeekRepository;

        public DaysOfTheWeekController(IDayOfTheWeekRepository dayOfTheWeekRepository)
        {
            _dayOfTheWeekRepository = dayOfTheWeekRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayOfTheWeek>>> GetAll()
        {
            return await _dayOfTheWeekRepository.GetAllAsync();
        }
    }
}
