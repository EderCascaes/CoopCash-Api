using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopCash.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public string Color { get; set; } = default!;
    }
}
