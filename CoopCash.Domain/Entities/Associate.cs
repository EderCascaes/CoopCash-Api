

using System.Net;

namespace CoopCash.Domain.Entities
{
    public class Associate : EntityBase
    {
      
        public Associate(Guid id, string name, string email, string cPF, string phoneNumber, Address address)
        {
            this.Id = id; 
            this.Name = name;
            this.Email = email;
            this.Cpf = cPF;
            this.Phone = phoneNumber;
            this.Address = address;
            this.Occupation = "Não Informado";
        }
        // ✅ Construtor sem parâmetros para o EF
        protected Associate() { }

        public string Name { get; set; } = default!;
        public string Rg { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Ativo";
        public decimal MonthlySpending { get; set; }
        public DateTime LastActivity { get; set; }
        public decimal TotalGenerated { get; set; }

        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Cpf { get; set; }
        public decimal? TotalCashback { get; set; }
        public decimal? HousingSubsidy { get; set; }
        public string? MaritalStatus { get; set; }
        public int? BeneficiariesCount { get; set; }
        public string? ReferredBy { get; set; }
        public string? Level { get; set; }
        public decimal? CashbackGenerated { get; set; }
        public decimal? YourDiscount { get; set; }
        public int? Dependents { get; set; }
        public string Occupation { get; set; } = default!;
        public decimal? Income { get; set; }
        public string? Bank { get; set; }
        public string? Agency { get; set; }
        public string? Account { get; set; }

        // Relacionamentos
        public ICollection<AssociateCard> Cards { get; set; } = new List<AssociateCard>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        // 🔗 Relacionamento 1:1
        public Address Address { get; set; } = default!;
    }
}
