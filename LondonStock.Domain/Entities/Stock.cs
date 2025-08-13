using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public string TickerSymbol { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string Currency { get; set; } = "GBP";
        public decimal TotalUnits { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Property
        public ICollection<Trade> Trades { get; set; } = new List<Trade>();
    }
}
