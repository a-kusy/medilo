using Medilo.API.Models.DTO;
using Medilo.API.Models;

namespace Medilo.API.Services
{
    public interface IPersonService
    {
        Task<Person> AddPersonWithAddress(PersonAddressDto personAddress);
        Task UpdatePersonWithAddress(int id, PersonAddressDto personAddressDto);
    }
}
