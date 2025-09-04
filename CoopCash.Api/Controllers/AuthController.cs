using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Services;
using CoopCash.Domain.Entities;
using CoopCash.Infra.Security;
using Microsoft.AspNetCore.Mvc;

namespace CoopCash.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto dto)
        {
            _userService.RegisterAsync(dto);
            return Ok(new { message = "Usuário registrado com sucesso!" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = "";//_userService.FirstOrDefault(u => u.Name == dto.Name && u.Password == dto.Password);
            if (user == null)
                return Unauthorized("Credenciais inválidas.");

            var token = "";// _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
