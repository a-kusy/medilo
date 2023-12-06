using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Medilo.API.Repositories.Contracts
{
    public interface IScheduleRepository : IRepositoryBase<Schedule>
    {
        Task<bool> Add(ICollection<ScheduleDto> schedulesDto);
    }
}
