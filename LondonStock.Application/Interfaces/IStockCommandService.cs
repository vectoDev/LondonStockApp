using LondonStock.Application.DTOs.Stocks;

namespace LondonStock.Application.Interfaces
{
    public interface IStockCommandService
    {
        Task<Guid> CreateStockAsync(StockCreateDto dto);
        Task DeleteStockAsync(string tickerSymbol);
    }
}
