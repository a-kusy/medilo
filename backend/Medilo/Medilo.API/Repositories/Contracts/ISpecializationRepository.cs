using Medilo.API.Models.DTO;
using Medilo.API.Models;

namespace Medilo.API.Repositories.Contracts
{
    public interface ISpecializationRepository : IRepositoryBase<Specialization>
    {
        Task<Specialization> GetByNameAsync(string specName);
        Task<Specialization> Add(SpecializationDto specializationDto);
        Task Update(int id, SpecializationDto specializationDto);
    }
}
