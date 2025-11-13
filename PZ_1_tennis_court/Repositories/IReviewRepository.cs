using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetReviewsByCourt(int courtId);
    }
}
