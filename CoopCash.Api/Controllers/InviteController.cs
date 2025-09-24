using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoopCash.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InviteController : ControllerBase
    {
        private readonly IInviteEmailService _inviteEmailService;

        public InviteController(IInviteEmailService inviteEmailService)
        {
            _inviteEmailService = inviteEmailService;
        }

        /// <summary>
        /// Envia e-mail de convite para cadastro.
        /// </summary>
        [HttpPost("send-email")]
        public async Task<IActionResult> SendInvite([FromBody] InviteEmailDto dto)
        {
            
            await _inviteEmailService.SendInviteEmailAsync(dto);
            return Ok();
        }

    }
}
