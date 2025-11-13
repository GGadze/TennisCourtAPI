using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court.Services
{
    public interface IUserService
    {
        UserDTO GetById(int id);
        IEnumerable<UserDTO> GetAll();
        UserDTO Create(CreateUserDTO createUserDTO);
        UserDTO Update(int id, UpdateUserDTO updateUserDTO);
        bool Delete(int id);
        bool ValidateUserCredentials(string login, string password);
    }
}
