using System.ComponentModel.DataAnnotations;

namespace PZ_1_tennis_court.Models.DTO
{
    public class CreateCourtDTO
    {
        [Required(ErrorMessage = "Поле Name обязательно")]
        [MinLength(1, ErrorMessage = "Имя корта не может быть пустым")]
        public string Name { get; set; } = null!;

        [Required]
        public string SurfaceType { get; set; } = null!;

        [Required]
        public bool IsIndoor { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля")]
        public decimal PricePerHour { get; set; }
    }
}
