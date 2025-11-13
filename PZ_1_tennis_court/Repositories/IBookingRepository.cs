using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetBookingsByUser(int userId);
    }
}
