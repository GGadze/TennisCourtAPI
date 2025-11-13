namespace PZ_1_tennis_court.Models.DTO
{
    public class CreateBookingDTO
    {
        public int CourtId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
