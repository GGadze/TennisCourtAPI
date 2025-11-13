using PZ_1_tennis_court.Models;
using Microsoft.EntityFrameworkCore;

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
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(x => x.Id == id);
        }

        public User? GetByLogin(string login)
        {
            return _context.Users.Include(u => u.Role)
                                 .FirstOrDefault(u => u.Login == login);
        }

        public User Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
