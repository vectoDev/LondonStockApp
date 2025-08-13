namespace LondonStock.Application.DTOs.Stocks
{
    public class StockDto
    {
        public string TickerSymbol { get; set; } = null!;
        public decimal AvgPrice { get; set; }
        public decimal TotalVolume { get; set; }
    }
}
