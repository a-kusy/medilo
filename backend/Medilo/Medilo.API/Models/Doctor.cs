using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medilo.API.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PersonId { get; set; }

        public User User { get; set; }

        public Person Person { get; set; }

        public ICollection<Specialization> Specializations { get; set; }

        public ICollection<ScheduleValidityPeriod>? SchedulesValidityPeriod { get; set;}

        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; set; }

        [JsonIgnore]
        public ICollection<AvailableAppointment>? AvailableAppointments { get; set; }
    }
}
