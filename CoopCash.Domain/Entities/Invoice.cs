using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopCash.Domain.Entities
{
    public class Invoice : EntityBase
    {
        public string Number { get; set; } = default!;
        public string Company { get; set; } = default!;
        public string Cnpj { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Amount { get; set; }
        public decimal CashbackRate { get; set; }
        public decimal CashbackAmount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Processando";
        public string UploadMethod { get; set; } = "file";

        public Guid? AssociateId { get; set; }
        public Associate? Associate { get; set; }

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

}
