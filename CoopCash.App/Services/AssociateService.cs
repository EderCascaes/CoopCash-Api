using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Repositories;
using CoopCash.App.Interfaces.Services;
using CoopCash.Domain.Entities;

namespace CoopCash.App.Services
{
    public class AssociateService : IAssociateService
    {
        private readonly IRepository<Associate> _repository;
        private readonly IRepository<InviteToken> _repositoryToken;
        private readonly IRepository<Address> _repositoryAddress;

        public AssociateService(IRepository<Associate> repository, IRepository<InviteToken> repositoryToken, IRepository<Address> repositoryAddress)
        {
            _repository = repository;
            _repositoryToken = repositoryToken;
            _repositoryAddress = repositoryAddress;
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);

            }
            catch (Exception e)
            {

                throw new Exception("Erro ao deletar associado:" + e.Message);
            }

        }

        public async Task<IEnumerable<Associate>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Erro ao buscar lista de associados: " + e.Message);
            }
        }

        public async Task<Associate?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);

            }
            catch (Exception e)
            {

                throw new Exception("Erro ao buscar associado: " + e.Message);
            }
        }

        public async Task<Associate> InsertAsync(AssociateRegister associateDto)
        {
           
            var associateId = Guid.NewGuid();

            var address = new Address(
                associateDto.Street,
                associateDto.Number,
                associateDto.Complement,
                associateDto.Neighborhood,
                associateDto.City,
                associateDto.State,
                associateDto.ZipCode,
                associateId
            );

            var associate = new Associate(
                associateId,
                associateDto.Name,
                associateDto.Email,
                associateDto.Cpf,
                associateDto.PhoneNumber,
                address
            );

            await using var transaction = await _repository.BeginTransactionAsync();
            try
            {
                await _repositoryAddress.InsertInTransactionAsync(address);
                var result = await _repository.InsertInTransactionAsync(associate);
                await _repositoryToken.DeleteAsync(Guid.Parse(associateDto.Token));

                await _repositoryAddress.SaveChangesAsync();
                await _repository.SaveChangesAsync();
                await _repositoryToken.SaveChangesAsync();

                await transaction.CommitAsync();

                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw new Exception("Erro ao inserir associado na base de dados");
            }

        }



        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AssociateRegister associate)
        {
            throw new NotImplementedException();
        }
    }
}
