using Medilo.API.Models;

namespace Medilo.API.Services
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> Register(RegistrationRequest request);
        Task<AuthenticateResponse> Login(AuthenticateRequest request);
    }
}
