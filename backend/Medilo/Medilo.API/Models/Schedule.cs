using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medilo.API.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set;}

        [Required]
        public int DayOfTheWeekId { get; set; }

        public DayOfTheWeek DayOfTheWeek { get; set; }

        [Required]
        public int SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        [Required]
        public int ScheduleValidityPeriodId {  get; set; }

        [JsonIgnore]
        public ScheduleValidityPeriod ScheduleValidityPeriod { get; set; }
    }
}
