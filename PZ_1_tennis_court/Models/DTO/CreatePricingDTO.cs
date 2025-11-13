namespace PZ_1_tennis_court.Models.DTO
{
    public class CreatePricingDTO
    {
        public string TariffName { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Description { get; set; } = null!;
    }
}
