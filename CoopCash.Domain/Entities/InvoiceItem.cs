using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopCash.Domain.Entities
{
    public class InvoiceItem : EntityBase
    {
        public string Description { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string Category { get; set; } = default!;

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = default!;
    }
}
