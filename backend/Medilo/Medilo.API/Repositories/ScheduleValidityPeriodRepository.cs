using AutoMapper;
using Medilo.API.Data;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class ScheduleValidityPeriodRepository : RepositoryBase<ScheduleValidityPeriod>, IScheduleValidityPeriodRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleValidityPeriodRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ScheduleValidityPeriod> Add(ScheduleValidityPeriodDto scheduleValidityPeriodDto)
        {
            var newPeriod = _mapper.Map<ScheduleValidityPeriod>(scheduleValidityPeriodDto);

            if (await IsScheduleOverlap(newPeriod)) return null;
            return await AddAsync(newPeriod);
        }

        public Task<List<ScheduleValidityPeriod>> GetByDoctorId(int id)
        {
            return _context.SchedulesValidityPeriod
                .Where(s => s.DoctorId == id)
                .Include(s => s.Schedules)
                .ToListAsync();
        }

        private async Task<bool> IsScheduleOverlap(ScheduleValidityPeriod newPeriod) 
        {
            var existingPeriods = await GetByDoctorId(newPeriod.DoctorId);

            foreach (var period in existingPeriods) { 
                if(
                    (period.StartDate <= newPeriod.EndDate && period.StartDate >= newPeriod.StartDate) || 
                    (period.StartDate <= newPeriod.StartDate && period.EndDate >= newPeriod.EndDate) || 
                    (period.EndDate >= newPeriod.StartDate && period.StartDate <= newPeriod.StartDate) || 
                    (period.StartDate >= newPeriod.StartDate && period.EndDate <= newPeriod.EndDate)
                    ) { return true; }
            }

            return false;
        }
    }
}
