using PZ_1_tennis_court.Models;
using Microsoft.EntityFrameworkCore;


namespace PZ_1_tennis_court.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly APIDBContext _context;
        public BookingRepository(APIDBContext context)
        {
            _context = context;
        }

        public Booking Create(Booking entity)
        {
            _context.Bookings.Add(entity);
            _context.SaveChanges();

            _context.Entry(entity).Reference(p => p.Court).Load();
            _context.Entry(entity).Reference(p => p.User).Load();
            _context.Entry(entity).Reference(p => p.Pricing).Load();
            return entity;
        }

        public bool Delete(int id)
        {
            var booking = GetById(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            return _context.Bookings.Any(x => x.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Court)
                .Include(x => x.Pricing)
                .ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Court)
                .Include(x => x.Pricing)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Booking> GetBookingsByUser(int userId)
        {
            return _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Court)
                .Include(x => x.Pricing)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public Booking Update(Booking entity)
        {
            _context.Bookings.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
