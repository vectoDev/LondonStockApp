using LondonStock.Application.DTOs.Stocks;
using LondonStock.Application.Interfaces;
using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace LondonStock.Application.Services
{
    public class StockCommandService : IStockCommandService
    {
        private readonly IStockQueryRepository _stockQueryRepo;
        private readonly IStockCommandRepository _stockCommandRepo;
        private readonly ILogger<StockCommandService> _logger;

        public StockCommandService(
            IStockQueryRepository stockQueryRepo,
            IStockCommandRepository stockCommandRepo,
            ILogger<StockCommandService> logger)
        {
            _stockQueryRepo = stockQueryRepo;
            _stockCommandRepo = stockCommandRepo;
            _logger = logger;
        }

        public async Task<Guid> CreateStockAsync(StockCreateDto dto)
        {
            _logger.LogInformation("Attempting to create stock {Ticker}"
                , dto.TickerSymbol);

            var existing = await _stockQueryRepo.GetByTickerAsync(dto.TickerSymbol);
            if (existing != null)
            {
                _logger.LogWarning("Stock creation failed: {Ticker} already exists", dto.TickerSymbol);
                throw new InvalidOperationException($"Stock with ticker '{dto.TickerSymbol}' already exists.");
            }
            var stock = new Stock
            {
                Id = Guid.NewGuid(),
                TickerSymbol = dto.TickerSymbol.ToUpper(),
                CompanyName = dto.CompanyName,
                Currency = dto.Currency,
                TotalUnits = dto.TotalUnits,
                UpdatedAt = DateTime.UtcNow
            };

            await _stockCommandRepo.AddStockAsync(stock);
            _logger.LogInformation("Stock {Ticker} created successfully with Id {Id}"
                , stock.TickerSymbol, stock.Id);
            return stock.Id;
        }

        public async Task DeleteStockAsync(string tickerSymbol)
        {
            _logger.LogInformation("Attempting to delete stock {Ticker}", tickerSymbol);
            var stock = await _stockQueryRepo.GetByTickerAsync(tickerSymbol);
            if (stock == null)
            {
                _logger.LogWarning("Stock deletion failed: {Ticker} not found", tickerSymbol);
                throw new KeyNotFoundException($"Stock '{tickerSymbol}' not found.");
            }
            await _stockCommandRepo.DeleteStockAsync(stock);
            _logger.LogInformation("Stock {Ticker} deleted successfully", tickerSymbol);
        }
    }
}
