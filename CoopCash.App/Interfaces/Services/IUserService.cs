using CoopCash.App.DTOs;
using CoopCash.Domain.Entities;

namespace CoopCash.App.Interfaces.Services
{
        public interface IUserService
        {
            Task<SystemUser> RegisterAsync(RegisterUserDto user);
            Task<SystemUser?> GetByIdAsync(Guid id);
            Task UpdateAsync(RegisterUserDto user);
            Task DeleteAsync(Guid id);
        }

}
