using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByLogin(string login);
        User? GetByEmail(string email);
    }
}
