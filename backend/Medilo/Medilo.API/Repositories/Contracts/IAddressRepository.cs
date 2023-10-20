using Medilo.API.Models.DTO;
using Medilo.API.Models;

namespace Medilo.API.Repositories.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Task<Address> AddressExist(Address address);
    }
}
