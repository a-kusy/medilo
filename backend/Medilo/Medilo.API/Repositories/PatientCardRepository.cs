using Medilo.API.Data;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Medilo.API.Helpers;

namespace Medilo.API.Repositories
{
    public class PatientCardRepository : RepositoryBase<PatientCard>, IPatientCardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatientCardRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PatientCard> Add(PatientCardDto patientCardDto)
        {
            if (patientCardDto == null) return null;

            PatientCard patientCard = _mapper.Map<PatientCard>(patientCardDto);
            return await AddAsync(patientCard);
        }

        public async Task<List<PatientCard>> GetAll()
        {
            return await _context.PatientCards.Include(pc => pc.Person).ToListAsync();
        }

        public Task<PatientCard> GetByPesel(string pesel)
        {
            return _context.PatientCards
                .Include(pc => pc.Person)
                .SingleAsync(pc => pc.PESEL == pesel);
        }

        public async Task Update(int id, PatientCardDto patientCardDto)
        {
            PatientCard patientCard = await GetAsync(id);
            if(patientCard != null)
            {
                patientCard.PESEL = patientCardDto.PESEL;
                patientCard.MedicalInsurance = patientCardDto.MedicalInsurance;
                patientCard.Sex = patientCardDto.Sex;
                patientCard.AttendingPhysician = patientCardDto.AttendingPhysician;

                await UpdateAsync(patientCard);
            }
        }
    }
}
