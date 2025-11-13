namespace PZ_1_tennis_court.Models.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public string Court { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PricingId { get; set; }
        public string Pricing { get; set; }
    }
}
