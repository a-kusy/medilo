using Medilo.API.Repositories.Contracts;
using Medilo.API.Models;
using Medilo.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medilo.API.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> EmailExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllWithRoleAsync()
        {
            return await _context.Users.Include(u => u.Roles).ToListAsync();
        }

        public async Task<bool> PeselExist(string pesel)
        {
            return await _context.Users.AnyAsync(u => u.PESEL == pesel);
        }

        public async Task AcceptUser(int id)
        {
            var user = await GetAsync(id);
            if (user != null)
            {
                user.Accepted = true;
                await UpdateAsync(user);
            }
            else _logger.LogInformation("User with given id doesn't exist");
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Roles).SingleAsync(u => u.Email == email);
        }

        public async Task<User> GetByPeselAsync(string pesel)
        {
            return await _context.Users.Include(u => u.Roles).SingleAsync(u => u.PESEL == pesel);
        }

        public async Task UpdateUser(int id, AuthenticateRequest userDto)
        {
            User user = await GetAsync(id);
            if (user != null)
            {
                user.Email = userDto.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password, BCrypt.Net.BCrypt.GenerateSalt());

                await UpdateAsync(user);
            }
           
        }
    }
}
