namespace CoopCash.Domain.Entities
{
    public class InviteToken: EntityBase
    {
        // Guid Id Token único
        // Registro do token data de creação
        public string Email { get; set; } // E-mail do associado
        public string ContractNumber { get; set; } // Número do contrato
        public string Token { get; set; } = default!;
        public DateTime Expiration { get; set; } // Validade do token (24h)
        public bool Used { get; set; } = false; // Se já foi usado
      
    }
}


