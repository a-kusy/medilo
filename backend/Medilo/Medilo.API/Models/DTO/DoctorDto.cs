namespace Medilo.API.Models.DTO
{
    public class DoctorDto
    {
        public int UserId { get; set; }

        public int PersonId { get; set; }

        public List<string> Specializations { get; set; }
    }
}
