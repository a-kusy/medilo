namespace Medilo.API.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }

        public bool IsSuccessfull { get; set; }

        public string Message { get; set; }

        public static AuthenticateResponse Success(string token)
        {
            return new AuthenticateResponse { 
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
