using Medilo.API.Repositories.Contracts;
using Medilo.API.Models;
using Medilo.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Address> AddressExist(Address address)
        {
            var existedAddress = await _context.Addresses
                .FirstOrDefaultAsync(a => a.City == address.City && a.Street == address.Street && a.HouseNumber == address.HouseNumber && a.ZipCode == address.ZipCode);
            Console.WriteLine(existedAddress);
            return existedAddress ?? null;
        }
    }
}
