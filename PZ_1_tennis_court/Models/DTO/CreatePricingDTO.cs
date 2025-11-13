using System.ComponentModel.DataAnnotations;

namespace PZ_1_tennis_court.Models.DTO
{
    public class CreatePricingDTO
    {
        [Required(ErrorMessage = "TariffName обязателен")]
        [MinLength(1, ErrorMessage = "TariffName не может быть пустым")]
        public string TariffName { get; set; } = null!;

        [Required(ErrorMessage = "PricePerHour обязателен")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля")]
        public decimal PricePerHour { get; set; }

        [Required(ErrorMessage = "Description обязателен")]
        [MinLength(1, ErrorMessage = "Описание не может быть пустым")]
        public string Description { get; set; } = null!;
    }
}
