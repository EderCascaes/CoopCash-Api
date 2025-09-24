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
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<SystemUser>> Register([FromBody] RegisterUserDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }


        [HttpPost("validate-token")]
        public async Task<ActionResult<SystemUser>> ValidateTokenRegister(string token)
        {
            var user = await _userService.ValidateTokenRegisterAsync(token);

            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            // Gera o token JWT
            var token = _jwtService.GenerateToken(user);

            // Retorna token junto com informações do usuário
            return Ok(new
            {
                message = "Login realizado com sucesso",
                token = token,
                user = user               
            });
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SystemUser>> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

    }
}
