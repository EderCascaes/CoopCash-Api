

using CoopCash.App.DTOs;

namespace CoopCash.App.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string Email, string subject ,string body);
    }
}
