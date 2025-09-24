using CoopCash.App.DTOs;

namespace CoopCash.App.Interfaces.Services
{
    public interface IInviteEmailService
    {
        Task<InviteResponseDto> SendInviteEmailAsync(InviteEmailDto dto);
    }
}
