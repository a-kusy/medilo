using Medilo.API.Models;
using Medilo.API.Data;
using Medilo.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext context;

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Role> GetByNameAsync(string roleName)
        {
            var role = await context.Roles.SingleOrDefaultAsync(x => x.Name == roleName);
            return role;
        }
    }
}
