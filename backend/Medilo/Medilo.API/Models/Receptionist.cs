using System.ComponentModel.DataAnnotations;

namespace Medilo.API.Models
{
    public class Receptionist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PersonId { get; set; }

        public User User { get; set; }

        public Person Person { get; set; }
    }
}
