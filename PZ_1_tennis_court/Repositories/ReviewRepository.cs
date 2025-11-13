using PZ_1_tennis_court.Models;
using Microsoft.EntityFrameworkCore;


namespace PZ_1_tennis_court.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly APIDBContext _context;
        public ReviewRepository(APIDBContext context)
        {
            _context = context;
        }

        public Review Create(Review entity)
        {
            _context.Reviews.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var review = GetById(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            return _context.Reviews.Any(x => x.Id == id);
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews
                .Include(x => x.User)
                .Include(x => x.Court)
                .ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews
                .Include(x => x.User)
                .Include(x => x.Court)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Review> GetReviewsByCourt(int courtId)
        {
            return _context.Reviews
                .Include(x => x.User)
                .Where(x => x.CourtId == courtId)
                .ToList();
        }

        public Review Update(Review entity)
        {
            _context.Reviews.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
