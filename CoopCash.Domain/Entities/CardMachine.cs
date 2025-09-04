using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopCash.Domain.Entities
{
    public class CardMachine : EntityBase
    {
        public string MerchantName { get; set; } = default!;
        public string MerchantCNPJ { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal CashbackRate { get; set; }
        public string Location { get; set; } = default!;
        public string Status { get; set; } = "Ativo";
        public decimal MonthlyVolume { get; set; }
        public int TotalTransactions { get; set; }
        public DateTime LastTransaction { get; set; }

        // Relacionamento N:N
        public ICollection<AssociateCard> LinkedCards { get; set; } = new List<AssociateCard>();
    }
}
