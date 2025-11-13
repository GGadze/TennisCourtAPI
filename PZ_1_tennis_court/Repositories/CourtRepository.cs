using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public class CourtRepository : ICourtRepository
    {
        private readonly APIDBContext _context;
        public CourtRepository(APIDBContext context)
        {
            _context = context;
        }

        public Court Create(Court entity)
        {
            _context.Courts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var court = GetById(id);
            if (court != null)
            {
                _context.Courts.Remove(court);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            return _context.Courts.Any(x => x.Id == id);
        }

        public IEnumerable<Court> GetAll()
        {
            return _context.Courts.ToList();
        }

        public Court GetById(int id)
        {
            return _context.Courts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Court> GetAvailableCourts()
        {
            return _context.Courts.Where(x => x.IsAvailable).ToList();
        }

        public Court Update(Court entity)
        {
            _context.Courts.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
