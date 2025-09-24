using CoopCash.App.DTOs;
using CoopCash.Domain.Entities;

namespace CoopCash.App.Interfaces.Services
{
        public interface IUserService
        {
            Task<SystemUser> RegisterAsync(RegisterUserDto user);
            Task<bool> ValidateTokenRegisterAsync(string token);
            Task<SystemUser?> GetByIdAsync(Guid id);
            Task<SystemUser?> UpdateAsync(RegisterUserDto user);
            Task DeleteAsync(Guid id);
            Task<SystemUser> LoginAsync(LoginDto dto);

    }

}
