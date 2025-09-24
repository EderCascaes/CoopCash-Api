using CoopCash.Domain.Entities;

namespace CoopCash.App.Interfaces.Repositories
{
    public interface IRepositoryAuth
    {
        Task<SystemUser> GetByNameAsync(string name);
        Task<bool> ValidateTokenRegisterAsync(string token);
    }
}
