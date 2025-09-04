using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopCash.Domain.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal CashbackRate { get; set; }
        public string Description { get; set; } = default!;
        public int Rating { get; set; }
        public bool IsPartner { get; set; }
        public string Location { get; set; } = default!;
        public string? Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Distance { get; set; }
        public string? TravelTime { get; set; }
        public string Status { get; set; } = "Ativo";
        public decimal MonthlyVolume { get; set; }
    }

}
