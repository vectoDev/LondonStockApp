using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using LondonStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Infrastructure.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly LondonStockDbContext _context;
        public TradeRepository(LondonStockDbContext context) => _context = context;

        public async Task AddTradeAsync(Trade trade)
        {
            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetAveragePriceAsync(string ticker)
        {
            return await _context.Trades
                .Where(t => t.Stock.TickerSymbol == ticker)
                .AverageAsync(t => t.Price);
        }

        public async Task<decimal> GetTotalVolumeAsync(string ticker)
        {
            return await _context.Trades
                .Where(t => t.Stock.TickerSymbol == ticker)
                .SumAsync(t => t.Quantity);
        }
    }
}
