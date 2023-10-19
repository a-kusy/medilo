using Medilo.API.Models;

namespace Medilo.API.Services
{
    public interface IAuthService
    {
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<AuthenticateResponse> Login(AuthenticateRequest request);
    }
}
