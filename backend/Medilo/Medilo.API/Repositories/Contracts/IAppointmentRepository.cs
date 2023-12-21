using Medilo.API.Models;
using Medilo.API.Models.DTO;

namespace Medilo.API.Repositories.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<List<Appointment>> GetByPatientId(int id);
        Task<Appointment> Add(AppointmentDto appointmentDto);
        Task<Appointment?> Get(int id);
    }
}
