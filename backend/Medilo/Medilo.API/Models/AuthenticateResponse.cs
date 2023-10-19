namespace Medilo.API.Models
{
    public class AuthenticateResponse
    {
        public string PESEL { get; set; }

        public string Token { get; set; }

        public bool IsSuccessfull { get; set; }

        public string Message { get; set; }

        public static AuthenticateResponse Success(string token, string pesel)
        {
            return new AuthenticateResponse { 
                PESEL = pesel,
                Token = token,
                IsSuccessfull = true,
                Message = "Login successfull"
            };
        }

        public static AuthenticateResponse Error(string message)
        {
            return new AuthenticateResponse { 
                IsSuccessfull = false, 
                Message = message 
            };
        }
    }
}
