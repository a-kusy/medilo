using Microsoft.AspNetCore.Mvc;
using Medilo.API.Models;
using Medilo.API.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userRepository.GetAllWithRoleAsync();
        }

       // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,[FromBody] AuthenticateRequest user)
        {
            await _userRepository.UpdateUser(id, user);
            return Ok();
        }


        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPut("accept/{id}")]
        public async Task<IActionResult> AcceptUser(int id)
        {
            await _userRepository.AcceptUser(id);
            return Ok();
        }


        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);

            return Ok();
        }

    }
}
