using AutoMapper;
using Medilo.API.Data;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Medilo.API.Repositories
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        private readonly IMapper _mapper;

        public ScheduleRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<bool> Add(ICollection<ScheduleDto> schedulesDto) 
        {
            var schedules = _mapper.Map<List<Schedule>>(schedulesDto);

            if (!IsScheduleOverlap(schedules))
            {
                await AddRangeAsync(schedules);
                return true;
            }

            return false;
        }

        private bool IsScheduleOverlap(List<Schedule> schedules)
        {
            for (int i = 0; i < schedules.Count - 1; i++)
            {
                for (int j = i + 1; j < schedules.Count; j++)
                {
                    if (schedules[i].DayOfTheWeekId == schedules[j].DayOfTheWeekId)
                    {
                        if (
                            (schedules[i].StartTime > schedules[j].StartTime && schedules[i].EndTime < schedules[j].EndTime) ||
                            (schedules[i].StartTime < schedules[j].EndTime && schedules[i].EndTime > schedules[j].EndTime) ||
                            (schedules[i].StartTime < schedules[j].StartTime && schedules[i].EndTime > schedules[j].StartTime) ||
                            (schedules[i].StartTime < schedules[j].StartTime && schedules[i].EndTime > schedules[j].EndTime)
                            ) return true;
                    }
                }
            }

            return false;
        }
    }
}
