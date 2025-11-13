using System.ComponentModel.DataAnnotations;

namespace PZ_1_tennis_court.Models.DTO
{
    public class CreateReviewDTO
    {
        [Required(ErrorMessage = "BookingId обязателен")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "UserId обязателен")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Rating обязателен")]
        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        public int Rating { get; set; }

        public string Comment { get; set; } = null!;
    }
}
