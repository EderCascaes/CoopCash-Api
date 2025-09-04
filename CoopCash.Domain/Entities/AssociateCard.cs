using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopCash.Domain.Entities
{
    public class AssociateCard : EntityBase
    {       
        public Guid AssociateId { get; set; }
        public Associate Associate { get; set; } = default!;
        public string AssociateName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string FullCardNumber { get; set; } = default!;
        public string CardType { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsVirtual { get; set; }
        public decimal MonthlyLimit { get; set; }
        public decimal UsedLimit { get; set; }

        // Relacionamentos N:N
        public ICollection<CardMachine> LinkedMachines { get; set; } = new List<CardMachine>();
    }
}
