using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Medilo.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PESEL { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        [Required, DataType(DataType.Password), MinLength(4)]
        public string Password { get; set; }

        [Required]
        public bool Accepted { get; set; }

        public ICollection<Role> Roles { get; set; } 
    }
}
