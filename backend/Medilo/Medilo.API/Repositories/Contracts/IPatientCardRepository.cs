using Medilo.API.Models;
using Medilo.API.Models.DTO;

namespace Medilo.API.Repositories.Contracts
{
    public interface IPatientCardRepository : IRepositoryBase<PatientCard>
    {
        Task<List<PatientCard>> GetAll();
        Task<PatientCard> GetByPesel(string pesel);
        Task<PatientCard> Add(PatientCardDto patientCardDto);
        Task Update(int id, PatientCardDto patientCardDto);
    }
}
