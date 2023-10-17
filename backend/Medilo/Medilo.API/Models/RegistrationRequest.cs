namespace Medilo.API.Models
{
    public class RegistrationRequest
    {
        public string PESEL { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
