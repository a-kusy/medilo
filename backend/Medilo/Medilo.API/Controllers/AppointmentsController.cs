using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentsRepository = appointmentRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Add([FromBody] AppointmentDto appointmentDto)
        {
            return await _appointmentsRepository.Add(appointmentDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
        {
            return await _appointmentsRepository.GetAllAsync();
        }

        [HttpGet("patientId/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetByPatientId(int id)
        {
            return await _appointmentsRepository.GetByPatientId(id);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment?>> Get(int id)
        {
            return await _appointmentsRepository.Get(id);
        }
    }
}
