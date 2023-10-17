namespace Medilo.API.Models
{
    public class RegistrationResponse
    {

        public string PESEL { get; set; }

        public bool IsSuccessfull { get; set; }

        public string Message { get; set; }

        public static RegistrationResponse Success(string pesel)
        {
            return new RegistrationResponse
            {
                PESEL = pesel,
                IsSuccessfull = true,
                Message = "Registration successfull"
            };
        }

        public static RegistrationResponse Error(string message)
        {
            return new RegistrationResponse
            {
                IsSuccessfull = false,
                Message = message
            };
        }

    }
}
