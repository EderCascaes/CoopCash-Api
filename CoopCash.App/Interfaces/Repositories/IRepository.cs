
using Microsoft.EntityFrameworkCore.Storage;

namespace CoopCash.App.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);       
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> InsertInTransactionAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
