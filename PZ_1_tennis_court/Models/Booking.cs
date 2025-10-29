namespace PZ_1_tennis_court.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int CourtId { get; set; }
        public Court Court { get; set; } = null!;
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
    }
}
