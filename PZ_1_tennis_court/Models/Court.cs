namespace PZ_1_tennis_court.Models
{
    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurfaceType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;
        public List<Booking> Bookings { get; set; } = new();
    }
}
