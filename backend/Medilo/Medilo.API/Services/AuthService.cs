using Medilo.API.Models;
using Medilo.API.Repositories.Contracts;
using Medilo.API.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace Medilo.API.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<AuthenticateResponse> Login(AuthenticateRequest request)
        {
            if (request == null || request.Email == null || request.Password == null)
                return AuthenticateResponse.Error("Login failed");

            bool userExist = await _userRepository.EmailExist(request.Email);

            if (!userExist) return AuthenticateResponse.Error("User doesn't exist");

            User user = await _userRepository.GetByEmailAsync(request.Email);

            if (!user.Accepted) return AuthenticateResponse.Error("Account is not accepted");

            bool IsVerified = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!IsVerified) return AuthenticateResponse.Error("Invalid password");

            string token = GenerateToken(user);

            return AuthenticateResponse.Success(token, user.PESEL);
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            if (request == null || request.Email == null || request.PESEL == null || request.Password == null)
                return RegistrationResponse.Error("Registration failed");

            bool peselExist = await _userRepository.PeselExist(request.PESEL);
            bool emailExist = await _userRepository.EmailExist(request.Email);

            if (peselExist || emailExist) return RegistrationResponse.Error("Email or PESEL already exist");

            if (!VerifyPesel(request.PESEL)) return RegistrationResponse.Error("Invalid PESEL");

            Role? role = await _roleRepository.GetByNameAsync(request.Role);

            string hashedPassword = HashPassword(request.Password);

            var user = new User
            {
                PESEL = request.PESEL,
                Email = request.Email,
                Password = hashedPassword,
                Accepted = (request.Role == CustomRoles.Patient || request.Role == CustomRoles.Admin),
                Roles = new List<Role> { role }
            };

            await _userRepository.AddAsync(user);

            return RegistrationResponse.Success(user.PESEL);
        }

        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        private string GenerateToken(User user)
        { 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var claims = new List<Claim> { new Claim("id", user.Id.ToString()) };
            
            foreach(var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private bool VerifyPesel(string pesel)
        {
            if (pesel.Length != 11) return false;

            foreach (char c in pesel)
            {
                if (!char.IsDigit(c)) return false;
            }

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += (pesel[i] - '0') * weights[i];
            }

            int control = (10 - (sum % 10)) % 10;

            if (control != (pesel[10] - '0')) return false;

            return true;
        }
    }
}