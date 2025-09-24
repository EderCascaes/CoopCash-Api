using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Repositories;
using CoopCash.App.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoopCash.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IAssociateService _associateService;
        public UserController( IAssociateService associateService)
        {
            _associateService = associateService;           
        }

        [HttpPost("usuarios/cadastro")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] AssociateRegister dto)
        {

           /* var token = await _repositoryAuth.ValidateTokenRegisterAsync(dto.Token);

            if (token = false) return BadRequest("Token inválido");*/

            // valida token, salva no banco

            var associate = await _associateService.InsertAsync(dto);


            return Ok(new { associate ,Message = "Usuário cadastrado com sucesso!" });
        }

    }
}
