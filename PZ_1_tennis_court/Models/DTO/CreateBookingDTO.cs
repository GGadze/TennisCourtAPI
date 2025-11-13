using System.ComponentModel.DataAnnotations;

namespace PZ_1_tennis_court.Models.DTO
{
    public class CreateBookingDTO
    {
        [Required(ErrorMessage = "CourtId обязателен")]
        public int CourtId { get; set; }

        [Required(ErrorMessage = "UserId обязателен")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "StartTime обязателен")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime обязателен")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "PricingId обязателен")]
        public int PricingId { get; set; }
    }
}
