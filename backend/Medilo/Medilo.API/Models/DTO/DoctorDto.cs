using Medilo.API.Models;

namespace Medilo.API.Models.DTO
{
    public class DoctorDto
    {
        public int UserId { get; set; }

        public int PersonId { get; set; }

        public List<Specialization> Specializations { get; set; }
    }
}
