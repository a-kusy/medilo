namespace Medilo.API.Models.DTO
{
    public class ScheduleDto
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int DayOfTheWeekId { get; set; }

        public int SpecializationId { get; set; }

        public int ScheduleValidityPeriodId { get; set; }
    }
}
