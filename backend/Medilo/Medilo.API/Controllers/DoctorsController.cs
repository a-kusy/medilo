using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Repositories.Contracts;
using Medilo.API.Models.DTO;
using Medilo.API.Models;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetDoctor()
        {
            return await _doctorRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Doctor> GetDoctor(int id)
        {
            return await _doctorRepository.Get(id);
        }

        [HttpGet("userId/{id}")]
        public async Task<Doctor> GetDoctorByUserId(int userId)
        {
            return await _doctorRepository.GetByUserId(userId);
        }


        [HttpPost]
        public async Task<ActionResult<Doctor>> AddDoctor([FromBody] DoctorDto doctor)
        {
            return await _doctorRepository.Add(doctor);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteAsync(id);
            return Ok();
        }

    }
}
