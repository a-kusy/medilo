namespace Medilo.API.Models.DTO
{
    public class PatientCardDto
    {
        public char Sex { get; set; }

        public string PESEL { get; set; }

        public int PersonId { get; set; }

        public bool ProcessingOfPersonalData { get; set; }

        public string? AttendingPhysician { get; set; }

        public string? MedicalInsurance { get; set; }
    }
}
