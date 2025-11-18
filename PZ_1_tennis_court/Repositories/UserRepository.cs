using Microsoft.EntityFrameworkCore;
using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIDBContext _context;

        public UserRepository(APIDBContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id) => _context.Users.Any(x => x.Id == id);

        public IEnumerable<User> GetAll() => _context.Users.Include(u => u.Role).ToList();

        public User? GetById(int id) => _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);

        public User? GetByLogin(string login) => _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login);

        public User? GetByEmail(string email) => _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);

        public User Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
