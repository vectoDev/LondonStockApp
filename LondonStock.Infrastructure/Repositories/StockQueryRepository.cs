using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using LondonStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Infrastructure.Repositories
{
    public class StockQueryRepository : IStockQueryRepository
    {
        private readonly LondonStockDbContext _context;

        public StockQueryRepository(LondonStockDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> GetByTickerAsync(string tickerSymbol)
        {
            return await _context.Stocks
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.TickerSymbol == tickerSymbol);
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetByRangeAsync(string[] tickers)
        {
            return await _context.Stocks
                .AsNoTracking()
                .Where(s => tickers.Contains(s.TickerSymbol))
                .ToListAsync();
        }

        public async Task<decimal> GetAveragePriceAsync(Guid stockId)
        {
            var trades = await _context.Trades
                .Where(t => t.StockId == stockId)
                .ToListAsync();

            return trades.Any() ? trades.Average(t => t.Price) : 0m;
        }

        public async Task<decimal> GetTotalVolumeAsync(Guid stockId)
        {
            var trades = await _context.Trades
                .Where(t => t.StockId == stockId)
                .ToListAsync();

            return trades.Any() ? trades.Sum(t => t.Quantity) : 0m;
        }
    }
}
