using Medilo.API.Repositories.Contracts;
using Medilo.API.Models.DTO;
using Medilo.API.Models;
using Medilo.API.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class ReceptionistRepository : RepositoryBase<Receptionist>, IReceptionistRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReceptionistRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Receptionist>> GetAll()
        {
            return await _context.Receptionists
                .Include(d => d.Person)
                .ToListAsync();
        }

        public async Task<Receptionist> Add(ReceptionistDto receptionistDto)
        {
            var receptionist = _mapper.Map<Receptionist>(receptionistDto);

            return await AddAsync(receptionist);
        }

        public async Task<Receptionist> GetByUserId(int userId)
        {
            return await _context.Receptionists
                .Include(d => d.Person)
                .Include(d => d.User)
                .SingleAsync(d => d.UserId == userId);
        }
    }
}
