using Medilo.API.Models;

namespace Medilo.API.Repositories.Contracts
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<Role> GetByNameAsync(string roleName);
    }
}