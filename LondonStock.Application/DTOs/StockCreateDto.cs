using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Application.DTOs.Stocks
{
    public class StockCreateDto
    {
        public string TickerSymbol { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string Currency { get; set; } = "GBP";
        public decimal TotalUnits { get; set; }
    }
}

