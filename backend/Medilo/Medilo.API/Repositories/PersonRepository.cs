using Medilo.API.Repositories.Contracts;
using Medilo.API.Models;
using Medilo.API.Models.DTO;
using Medilo.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllWithAddress()
        {
            return await _context.Persons.Include(p => p.Address).ToListAsync();
        }

        public async Task<Person> GetWithAddress(int id)
        {
            return await _context.Persons.Include(p => p.Address).SingleAsync(p => p.Id == id);
        }
    }
}
