namespace PZ_1_tennis_court.Models.DTO
{
    public class PricingDTO
    {
        public int Id { get; set; }
        public string TariffName { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public string Description { get; set; } = null!;
    }
}
