using System.ComponentModel.DataAnnotations;

namespace PZ_1_tennis_court.Models.DTO
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Необходимо ввести логин или почту")]
        public string LoginOrEmail { get; set; } = null!;

        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [MinLength(8, ErrorMessage = "Минимальная длина пароля — 8 символов")]
        public string Password { get; set; } = null!;

    }
}
