using Medilo.API.Models.DTO;
using Medilo.API.Models;
namespace Medilo.API.Repositories.Contracts
{
    public interface IReceptionistRepository : IRepositoryBase<Receptionist>
    {
        Task<Receptionist> Add(ReceptionistDto receptionistDto);
        Task<Receptionist> GetByUserId(int userId);
        Task<List<Receptionist>> GetAll();
    }
}
