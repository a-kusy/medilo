using Medilo.API.Models;

namespace Medilo.API.Repositories.Contracts
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<Person> GetWithAddress(int id);
        Task<List<Person>> GetAllWithAddress();
    }
}
