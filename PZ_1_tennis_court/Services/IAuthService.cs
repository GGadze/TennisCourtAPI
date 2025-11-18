using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginAsync(LoginRequest request);
        Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO request);
        string GenerateToken(UserDTO user);
    }
}
