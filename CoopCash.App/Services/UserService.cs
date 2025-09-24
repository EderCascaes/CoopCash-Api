using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Repositories;
using CoopCash.App.Interfaces.Services;
using CoopCash.Domain.Entities;


namespace CoopCash.App.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<SystemUser> _repository;
        private readonly IRepositoryAuth _repositoryAuth;

        public UserService(IRepository<SystemUser> repository, IRepositoryAuth repositoryAuth)
        {
            _repository = repository;
            _repositoryAuth = repositoryAuth;
        }

        public async Task<SystemUser> RegisterAsync(RegisterUserDto dto)
        {
            try
            {
                var existingUser = await _repositoryAuth.GetByNameAsync(dto.Name);
                
                if (existingUser != null)
                       throw new Exception("Nome de usuário já existe.");
                

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                var user = new SystemUser(
                        Guid.NewGuid(),
                        dto.Name,
                        passwordHash, 
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

        public async Task<SystemUser> UpdateAsync(RegisterUserDto dto)
        {
            if (dto.Id == null)
                throw new ArgumentException("Id do usuário não pode ser nulo.", nameof(dto.Id));

            var user = await _repository.GetByIdAsync(dto.Id.Value);
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

        public async Task<SystemUser?> LoginAsync(LoginDto dto)
        {
            var user = await _repositoryAuth.GetByNameAsync(dto.Name);
            if (user == null)
                return null;

            // Verificar senha
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isPasswordValid)
                return null;

            user.Password = string.Empty;
            return user;
        }

        public async Task<bool> ValidateTokenRegisterAsync(string token) => await _repositoryAuth.ValidateTokenRegisterAsync(token);
        
    }

}
