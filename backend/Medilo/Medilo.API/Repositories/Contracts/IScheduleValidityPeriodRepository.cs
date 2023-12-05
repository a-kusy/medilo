using Medilo.API.Models;
using Medilo.API.Models.DTO;

namespace Medilo.API.Repositories.Contracts
{
    public interface IScheduleValidityPeriodRepository : IRepositoryBase<ScheduleValidityPeriod>
    {
        Task<ScheduleValidityPeriod> Add(ScheduleValidityPeriodDto scheduleValidityPeriodDto);
        Task<List<ScheduleValidityPeriod>> GetByDoctorId(int id);
    }
}
