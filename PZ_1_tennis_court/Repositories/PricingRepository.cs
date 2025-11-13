using PZ_1_tennis_court.Models;

namespace PZ_1_tennis_court.Repositories
{
    public class PricingRepository : IPricingRepository
    {
        private readonly APIDBContext _context;
        public PricingRepository(APIDBContext context)
        {
            _context = context;
        }

        public Pricing Create(Pricing entity)
        {
            _context.Pricings.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var pricing = GetById(id);
            if (pricing != null)
            {
                _context.Pricings.Remove(pricing);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            return _context.Pricings.Any(x => x.Id == id);
        }

        public IEnumerable<Pricing> GetAll()
        {
            return _context.Pricings.ToList();
        }

        public Pricing GetById(int id)
        {
            return _context.Pricings.FirstOrDefault(x => x.Id == id);
        }

        public Pricing Update(Pricing entity)
        {
            _context.Pricings.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
