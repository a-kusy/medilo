using Medilo.API.Repositories.Contracts;
using Medilo.API.Models.DTO;
using Medilo.API.Models;
using Medilo.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Medilo.API.Repositories
{
    public class SpecializationRepository : RepositoryBase<Specialization>, ISpecializationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SpecializationRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Specialization> GetByNameAsync(string specName)
        {
            var specialization = await _context.Specializations.SingleOrDefaultAsync(s => s.Name == specName);
            return specialization;
        }

        public async Task<Specialization> Add(SpecializationDto specializationDto)
        {
            var existingSpec = await GetByNameAsync(specializationDto.Name);

            if (existingSpec != null) return null;

            Specialization specialization = _mapper.Map<Specialization>(specializationDto);

            return await AddAsync(specialization);
        }

        public async Task Update(int id, SpecializationDto specializationDto)
        {
            Specialization specialization = await GetAsync(id);
            if(specialization != null)
            {
                specialization.Name = specializationDto.Name;
                await UpdateAsync(specialization);
            }
        }
    }
}
