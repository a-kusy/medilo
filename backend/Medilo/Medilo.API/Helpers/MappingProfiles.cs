using AutoMapper;
using Medilo.API.Models.DTO;
using Medilo.API.Models;

namespace Medilo.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<Receptionist, ReceptionistDto>();
            CreateMap<ReceptionistDto, Receptionist>();
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<Specialization, SpecializationDto>();
            CreateMap<SpecializationDto, Specialization>();
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<PatientCard, PatientCardDto>();
            CreateMap<PatientCardDto, PatientCard>();
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)));
            CreateMap<ScheduleValidityPeriod, ScheduleValidityPeriodDto>();
            CreateMap<ScheduleValidityPeriodDto, ScheduleValidityPeriod>();
        }
    }
}
