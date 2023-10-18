using Medilo.API.Models;

namespace Medilo.API.Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<User>> GetAllWithRoleAsync();
        Task<bool> EmailExist(string email);
        Task<bool> PeselExist(string pesel);
        Task AcceptUser(int id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByPeselAsync(string pesel);
    }
}
