

using CoopCash.App.DTOs;
using CoopCash.Domain.Entities;

namespace CoopCash.App.Interfaces.Services
{
    public interface IAssociateService
    {
        Task<Associate?> GetByIdAsync(Guid id);
        Task<IEnumerable<Associate>> GetAllAsync();
        Task<Associate> InsertAsync(AssociateRegister associate);
        Task UpdateAsync(AssociateRegister associate);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }

}
