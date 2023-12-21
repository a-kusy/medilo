using AutoMapper;
using Medilo.API.Data;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Appointment?> Get(int id)
        {
            return await _context.Appointments
                .Include(a => a.Specialization)
                .Include(a => a.PatientCard).ThenInclude(p => p.Person)
                .Include(a => a.Doctor).ThenInclude(d => d.Person)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<List<Appointment>> GetByPatientId(int id)
        {
            return await _context.Appointments
                .Where(a => a.PatientCardId == id)
                .Include(a => a.Specialization)
                .Include(a => a.Doctor).ThenInclude(d => d.Person)
                .ToListAsync();
        }

        public async Task<Appointment> Add(AppointmentDto appointmentDto)
        {
            Appointment appointment = _mapper.Map<Appointment>(appointmentDto);
            appointment.Status = CustomStatus.Scheduled;

            return await AddAsync(appointment);
        }
    }
}
