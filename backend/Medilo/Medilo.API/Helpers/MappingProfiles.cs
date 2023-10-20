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
        }
    }
}
