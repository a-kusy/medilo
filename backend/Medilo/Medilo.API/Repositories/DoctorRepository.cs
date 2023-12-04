using Medilo.API.Repositories.Contracts;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Medilo.API.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IMapper _mapper;

        public DoctorRepository(ApplicationDbContext context, ISpecializationRepository specializationRepository, IMapper mapper) : base(context)
        {
            _context = context;
            _specializationRepository = specializationRepository;
            _mapper = mapper;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _context.Doctors.Include(d => d.Person).Include(d => d.Specializations).ToListAsync();
        }

        public async Task<Doctor> Get(int id)
        {
            return await _context.Doctors
                .Include(d => d.Specializations)
                .Include(d => d.Person)
                .Include(d => d.User).ThenInclude(u => u.Roles)
                .SingleAsync(d => d.Id == id);
        }

        public async Task<Doctor> GetByUserId(int userId)
        {
            return await _context.Doctors
                .Include(d => d.Specializations)
                .Include(d => d.Person)
                .Include(d => d.User)
                .SingleAsync(d => d.UserId == userId);
        }

        public async Task<Doctor> Add(DoctorDto doctorDto)
        {

            List<Specialization> specializations = new();

            foreach (var spec in doctorDto.Specializations)
            {
                Specialization? specialization = await _specializationRepository.GetAsync(spec.Id);
                specializations.Add(specialization);
            }

            Doctor doctor = _mapper.Map<Doctor>(doctorDto);
            doctor.Specializations = specializations;

            return await AddAsync(doctor);
        }

        public async Task<List<Specialization>> GetDoctorSpecializations(int id)
        {
            var doctor = await _context.Doctors
                .Where(d => d.Id == id)
                .Include(d => d.Specializations)
                .FirstOrDefaultAsync();

            return doctor?.Specializations?.ToList() ?? new List<Specialization>();
        }

    }
}
