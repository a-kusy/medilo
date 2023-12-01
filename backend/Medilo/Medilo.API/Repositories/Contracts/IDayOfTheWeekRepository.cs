using Medilo.API.Models;

namespace Medilo.API.Repositories.Contracts
{
    public interface IDayOfTheWeekRepository : IRepositoryBase<DayOfTheWeek>
    {
        Task<DayOfTheWeek> GetByNameAsync(string name);
    }
}
