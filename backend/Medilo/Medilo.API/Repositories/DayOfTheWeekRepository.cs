using Medilo.API.Data;
using Medilo.API.Models;
using Medilo.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class DayOfTheWeekRepository : RepositoryBase<DayOfTheWeek>, IDayOfTheWeekRepository
    {
        private readonly ApplicationDbContext _context;

        public DayOfTheWeekRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DayOfTheWeek> GetByNameAsync(string name)
        {
            var dayOfTheWeek = await _context.DayOfTheWeek.FirstOrDefaultAsync(d => d.Name == name);
            return dayOfTheWeek;
        }
    }
}
