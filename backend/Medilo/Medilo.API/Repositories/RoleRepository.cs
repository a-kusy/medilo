using Medilo.API.Models;
using Medilo.API.Data;
using Medilo.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetByNameAsync(string roleName)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(x => x.Name == roleName);
            return role;
        }
    }
}
