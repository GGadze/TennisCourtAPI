using Microsoft.EntityFrameworkCore;
namespace PZ_1_tennis_court.Models
{
    public class APIDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Court> Courts { get; set; }            
        public DbSet<Booking> Bookings { get; set; }        
        public DbSet<Pricing> Pricings { get; set; }        
        public DbSet<Review> Reviews { get; set; }          

        public APIDBContext(DbContextOptions<APIDBContext> options)
            : base(options)
        {
        }
    }
}
