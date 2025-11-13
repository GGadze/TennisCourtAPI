namespace PZ_1_tennis_court.Models.DTO
{
    public class CourtDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurfaceType { get; set; } = null!;
        public bool IsIndoor { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
