using Microsoft.AspNetCore.Mvc;
using Medilo.API.Repositories.Contracts;
using Medilo.API.Models;

namespace Medilo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _roleRepository.GetAllAsync();
        }

    }
}
