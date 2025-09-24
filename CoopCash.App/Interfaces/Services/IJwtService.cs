using CoopCash.Domain.Entities;

namespace CoopCash.App.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(SystemUser user);
    }
}
