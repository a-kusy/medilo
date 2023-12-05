namespace Medilo.API.Models.DTO
{
    public class ScheduleValidityPeriodDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DoctorId { get; set; }
    }
}
