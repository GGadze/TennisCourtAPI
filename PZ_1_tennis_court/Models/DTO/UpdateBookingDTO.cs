namespace PZ_1_tennis_court.Models.DTO
{
    public class UpdateBookingDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
