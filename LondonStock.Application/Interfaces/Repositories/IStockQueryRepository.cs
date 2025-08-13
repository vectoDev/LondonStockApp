using LondonStock.Domain.Entities;

namespace LondonStock.Application.Interfaces.Repositories
{
    public interface IStockQueryRepository
    {
        Task<Stock?> GetByTickerAsync(string tickerSymbol);
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<IEnumerable<Stock>> GetByRangeAsync(string[] tickers);
        Task<decimal> GetAveragePriceAsync(Guid stockId);
        Task<decimal> GetTotalVolumeAsync(Guid stockId);
    }
}
