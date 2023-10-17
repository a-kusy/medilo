using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medilo.API.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Doctor> Doctors { get; set; }
    }
}
