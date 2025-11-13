namespace PZ_1_tennis_court.Models.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
