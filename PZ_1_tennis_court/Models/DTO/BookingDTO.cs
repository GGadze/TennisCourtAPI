namespace PZ_1_tennis_court.Models.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public CourtDTO? Court { get; set; }
        public int UserId { get; set; }
        public UserDTO? User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PricingId { get; set; }
        public PricingDTO? Pricing { get; set; }
    }
}
