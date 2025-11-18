using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Services;

namespace PZ_1_tennis_court.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound(new { message = $"Пользователь с ID {id} не найден" });
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDTO> Create(CreateUserDTO createUserDTO)
        {
            var createdUser = _userService.Create(createUserDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDTO> Update(int id, UpdateUserDTO updateUserDTO)
        {
            var updatedUser = _userService.Update(id, updateUserDTO);
            if (updatedUser == null)
                return NotFound(new { message = $"Пользователь с ID {id} не найден" });
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _userService.Delete(id);
            if (!deleted)
                return NotFound(new { message = $"Пользователь с ID {id} не найден" });
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isValid = _userService.ValidateUserCredentials(loginRequest.LoginOrEmail, loginRequest.Password);
            if (!isValid)
                return Unauthorized(new { message = "Неверный логин или пароль" });

            return Ok(new { message = "Успешный вход", roleId = loginRequest.RoleId });
        }
    }
}
