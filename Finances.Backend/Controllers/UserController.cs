using Finances.Backend.Data.Dtos;
using Finances.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("new-user")]
        public async Task<IActionResult> NewUser(NewUserDto dto)
        {
            await _userService.CreateUser(dto);
            return Ok(new { message = "Usuário cadastrado com sucesso!"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _userService.Login(dto);
            return Ok(new { token });
        }
    }
}
