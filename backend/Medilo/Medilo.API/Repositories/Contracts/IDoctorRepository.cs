using Medilo.API.Models.DTO;
using Medilo.API.Models;
namespace Medilo.API.Repositories.Contracts
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        Task<Doctor> Add(DoctorDto doctorDto);
        Task<Doctor> Get(int id);
        Task<Doctor> GetByUserId(int userId);
        Task<List<Doctor>> GetAll();
        Task<List<Specialization>> GetDoctorSpecializations(int id);
    }
}
