namespace PZ_1_tennis_court.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string TariffName { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }
}
