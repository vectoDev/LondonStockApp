namespace LondonStock.Application.DTOs.Trades
{
    public class TradeCreateDto
    {
        public string TickerSymbol { get; set; } = null!;
        public decimal Price { get; set; }
        public string Currency { get; set; } = "GBP";
        public decimal Quantity { get; set; }
        public string TransactionType { get; set; } = null!;
    }
}
