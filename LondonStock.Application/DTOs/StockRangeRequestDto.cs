using System.Collections.Generic;

namespace LondonStock.Application.DTOs.Stocks
{
    public class StockRangeRequestDto
    {
        public List<string> Tickers { get; set; } = new();
    }
}
