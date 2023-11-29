using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medilo.API.Services;
using Medilo.API.Models;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountsController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<AuthenticateResponse>> Register([FromBody]RegistrationRequest user)
        {
            var res = await _authService.Register(user);
            return Ok(res);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<AuthenticateResponse>> Login([FromBody]AuthenticateRequest request)
        {
            Console.WriteLine("log");
            var res = await _authService.Login(request);
            return Ok(res);
        }
    }
}
