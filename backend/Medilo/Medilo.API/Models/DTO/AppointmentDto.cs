namespace Medilo.API.Models.DTO
{
    public class AppointmentDto
    {
        public int PatientCardId { get; set; }

        public DateTime Date { get; set; }

        public int DoctorId { get; set; }

        public int SpecializationId { get; set; }
    }
}
