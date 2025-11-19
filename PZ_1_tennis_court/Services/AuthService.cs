using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Repositories;

namespace PZ_1_tennis_court.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository users, IConfiguration configuration)
        {
            _users = users;
            _config = configuration;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginRequest request)
        {
            var user = _users.GetByLogin(request.LoginOrEmail) ?? _users.GetByEmail(request.LoginOrEmail);

            if (user == null)
                throw new Exception("User not found");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid password");

            var userDto = new UserDTO
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                RoleName = user.Role?.Name ?? "User"
            };

            var token = GenerateToken(userDto);

            return await Task.FromResult(new AuthResponseDTO
            {
                Token = token,
                UserId = user.Id,
                Expires = DateTime.UtcNow.AddHours(6)
            });
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO request)
        {
            if (_users.GetByLogin(request.Login) != null)
                throw new Exception("User already exists");

            var newUser = new User
            {
                Login = request.Login,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = request.RoleId
            };

            _users.Create(newUser);

            var userDto = new UserDTO
            {
                Id = newUser.Id,
                Login = newUser.Login,
                Email = newUser.Email,
                RoleName = newUser.Role.Name
            };

            var token = GenerateToken(userDto);

            return await Task.FromResult(new AuthResponseDTO
            {
                Token = token,
                UserId = newUser.Id,
                Expires = DateTime.UtcNow.AddHours(6)
            });
        }

        public string GenerateToken(UserDTO user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleName)
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
