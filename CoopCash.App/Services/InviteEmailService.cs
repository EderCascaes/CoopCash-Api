using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopCash.App.DTOs;
using CoopCash.App.Interfaces.Repositories;
using CoopCash.App.Interfaces.Services;
using CoopCash.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CoopCash.App.Services
{
    public class InviteEmailService : IInviteEmailService
    {
        private readonly IRepository<InviteToken> _repository;
        private readonly IEmailService _emailService;
        public string _apiBaseUrl { get; set; } = string.Empty;

        public InviteEmailService(IConfiguration configuration, IRepository<InviteToken> repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
            _apiBaseUrl = configuration["BaseUrl_front_end"] ?? throw new Exception("ApiBaseUrl frond-end not configured!");
        }
        public async Task<InviteResponseDto> SendInviteEmailAsync(InviteEmailDto dto)
        {
            // 1️⃣ Criar token
            var token = new InviteToken
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                ContractNumber = dto.ContractNumber,
                Expiration = DateTime.UtcNow.AddHours(96),
                Used = false,
                CreateDate = DateTime.UtcNow,
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            };

            // 2️⃣ Salvar no banco
            await _repository.InsertAsync(token);

            // 3️⃣ Gerar link
            var inviteLink = $"{_apiBaseUrl}/register?token={token.Id}";

            // 4️⃣ Enviar e-mail
            var subject = "Convite para cadastro";
            var body = $@"
            <h3>Olá,</h3>
            <p>Sr(a). {dto.Nome}</p>
            <p>Você foi convidado para se cadastrarna plataforma do CoopCash.</p>
            <p>Clique no link abaixo:</p>
            <a href='{inviteLink}' target='_blank'>Cadastrar</a>
            ";

            await _emailService.SendEmailAsync(dto.Email, subject, body);

            return new InviteResponseDto
            {
                Message = "Convite enviado com sucesso!",
                InviteLink = inviteLink
            };



        }
    }
}
