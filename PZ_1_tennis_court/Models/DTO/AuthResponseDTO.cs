namespace PZ_1_tennis_court.Models.DTO
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
    }

}
