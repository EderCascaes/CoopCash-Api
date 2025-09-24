using CoopCash.App.Interfaces.Repositories;
using CoopCash.Domain.Entities;
using CoopCash.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoopCash.Infra.Persistence.Repositories
{
    public class RepositoryAuth : IRepositoryAuth
    {
        private readonly CoopCashDbContext _context;
        private readonly DbSet<SystemUser> _dbSet;
        private readonly DbSet<InviteToken> _dbSetToken;

        public RepositoryAuth(CoopCashDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<SystemUser>();
            _dbSetToken = _context.Set<InviteToken>();
        }

        public async Task<SystemUser> GetByNameAsync(string name)
        {
            return await _dbSet
            .FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<bool> ValidateTokenRegisterAsync(string token)
        {
            var result =  await _dbSetToken
           .FirstOrDefaultAsync(u => u.Token == token);

            return result != null ? true : false;
        }
    }

        
}
