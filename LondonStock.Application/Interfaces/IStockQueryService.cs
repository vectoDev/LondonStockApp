using LondonStock.Application.DTOs.Stocks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LondonStock.Application.Interfaces
{
    public interface IStockQueryService
    {
        Task<StockDto> GetStockAsync(string ticker);
        Task<IEnumerable<StockDto>> GetAllStocksAsync();
        Task<IEnumerable<StockDto>> GetStocksByRangeAsync(IEnumerable<string> tickers);
    }
}
