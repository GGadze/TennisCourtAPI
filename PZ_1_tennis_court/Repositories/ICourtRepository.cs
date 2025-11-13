using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public interface ICourtRepository : IRepository<Court>
    {
        IEnumerable<Court> GetAvailableCourts();
    }
}
