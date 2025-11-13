using System.Security.Cryptography;
using System.Text;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Repositories;

namespace PZ_1_tennis_court.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        private static UserDTO MapUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                RoleName = user.Role?.Name
            };
        }

        public bool ValidateUserCredentials(string loginOrEmail, string password)
        {
            var user = _userRepo.GetAll()
                .FirstOrDefault(u => u.Login == loginOrEmail || u.Email == loginOrEmail);

            if (user == null)
                return false;

            var hashedPassword = HashPassword(password);
            return user.PasswordHash == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _userRepo.GetAll().Select(MapUserDTO);
        }

        public UserDTO GetById(int id)
        {
            var user = _userRepo.GetById(id);
            return user == null ? null : MapUserDTO(user);
        }

        public UserDTO Create(CreateUserDTO createUserDTO)
        {
            var hashedPassword = HashPassword(createUserDTO.Password);

            User newUser = new User
            {
                Login = createUserDTO.Login,
                Email = createUserDTO.Email,
                PasswordHash = hashedPassword,
                RoleId = createUserDTO.RoleId,
                IsActive = true
            };

            var createdUser = _userRepo.Create(newUser);
            return MapUserDTO(createdUser);
        }

        public UserDTO Update(int id, UpdateUserDTO updateUserDTO)
        {
            var user = _userRepo.GetById(id);
            if (user == null) return null;

            user.Login = updateUserDTO.Login;
            user.Email = updateUserDTO.Email;
            user.RoleId = updateUserDTO.RoleId;

            var updatedUser = _userRepo.Update(user);
            return MapUserDTO(updatedUser);
        }

        public bool Delete(int id)
        {
            return _userRepo.Delete(id);
        }
    }
}
