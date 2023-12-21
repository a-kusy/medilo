using System.ComponentModel.DataAnnotations;

namespace Medilo.API.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientCardId { get; set; }

        public PatientCard PatientCard { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int SpecializationId {  get; set; }

        public Specialization Specialization { get; set; }
    }
}
