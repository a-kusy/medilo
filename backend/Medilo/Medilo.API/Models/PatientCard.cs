using System.ComponentModel.DataAnnotations;

namespace Medilo.API.Models
{
    public class PatientCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public char Sex { get; set; }

        [Required]
        public string PESEL { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [Required]
        public bool ProcessingOfPersonalData { get; set; }

        public string? AttendingPhysician { get; set; }

        public string? MedicalInsurance { get; set; }
       
    }
}
