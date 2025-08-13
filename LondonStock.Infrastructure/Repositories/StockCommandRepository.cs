using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using LondonStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Infrastructure.Repositories
{
    public class StockCommandRepository : IStockCommandRepository
    {
        private readonly LondonStockDbContext _context;

        public StockCommandRepository(LondonStockDbContext context)
        {
            _context = context;
        }

        public async Task AddStockAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStockAsync(Stock stock)
        {
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }
}
