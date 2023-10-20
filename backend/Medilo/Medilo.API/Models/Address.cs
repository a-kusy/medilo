using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medilo.API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        public int? ApartmentNumber { get; set; }

        [JsonIgnore]
        public ICollection<Person> Persons { get; set; }
    }
}
