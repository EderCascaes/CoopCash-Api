using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Repositories;
using CoopCash.App.Interfaces.Services;
using CoopCash.Domain.Entities;

namespace CoopCash.App.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<SystemUser> _repository;

        public UserService(IRepository<SystemUser> repository)
        {
            _repository = repository;
        }

        public async Task<SystemUser> RegisterAsync(RegisterUserDto dto)
        {
            try
            {
                var user = new SystemUser(
                        Guid.NewGuid(),
                        dto.Name,
                        dto.Password, // Em produção -> Hash (BCrypt)
                        dto.Role,
                        dto.Permissions,
                        dto.Type
                    );
                //to do  validar senha (ver se n front já é validado)
                return await _repository.InsertAsync(user);

            }
            catch (Exception e)
            {

                throw new Exception("Erro ao inserir usúário na base de dados: "+ e.Message);
            }
        }

        public Task<SystemUser?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public async Task<SystemUser> UpdateUserAsync(RegisterUserDto dto)
        {
           
            var user = await _repository.GetByIdAsync(dto.Id);
            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado.");
           
            user.Name = dto.Name;
            user.Password = dto.Password; 
            user.Role = dto.Role;
            user.Permissions = dto.Permissions;
            user.Type = dto.Type;

           
            await _repository.UpdateAsync(user);

            return user;
        }

        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }

}
