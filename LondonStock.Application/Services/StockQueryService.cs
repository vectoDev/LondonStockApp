using LondonStock.Application.DTOs.Stocks;
using LondonStock.Application.Interfaces;
using LondonStock.Application.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace LondonStock.Application.Services
{
    public class StockQueryService : IStockQueryService
    {
        private readonly IStockQueryRepository _stockRepo;
        private readonly ICacheService _cache;
        private readonly ILogger<StockQueryService> _logger;

        public StockQueryService(
            IStockQueryRepository stockRepo,
            ICacheService cache,
            ILogger<StockQueryService> logger)
        {
            _stockRepo = stockRepo;
            _cache = cache;
            _logger = logger;
        }

        public async Task<StockDto> GetStockAsync(string ticker)
        {
            var cacheKey = $"stock:{ticker}";
            if (_cache.Get<StockDto>(cacheKey) is StockDto cached)
            {
                _logger.LogInformation("Cache hit for stock {Ticker}", ticker);
                return cached;
            }
            _logger.LogInformation("Cache miss for stock {Ticker}, fetching from DB", ticker);
            var stock = await _stockRepo.GetByTickerAsync(ticker);
            if (stock == null)
            {
                _logger.LogWarning("Stock not found: {Ticker}", ticker);
                throw new KeyNotFoundException($"Stock '{ticker}' not found.");
            }
            var avg = await _stockRepo.GetAveragePriceAsync(stock.Id);
            var vol = await _stockRepo.GetTotalVolumeAsync(stock.Id);
            var dto = new StockDto
            {
                TickerSymbol = stock.TickerSymbol,
                AvgPrice = avg,
                TotalVolume = vol
            };
            _cache.Set(cacheKey, dto, TimeSpan.FromSeconds(30));
            return dto;
        }

        public async Task<IEnumerable<StockDto>> GetAllStocksAsync()
        {
            var stocks = await _stockRepo.GetAllAsync();
            _logger.LogInformation("Fetched {Count} stocks from DB", stocks.Count());

            return await MapStocksToDto(stocks);
        }

        public async Task<IEnumerable<StockDto>> GetStocksByRangeAsync(IEnumerable<string> tickers)
        {
            var stocks = await _stockRepo.GetByRangeAsync(tickers.ToArray());
            _logger.LogInformation("Fetched {Count} stocks for range query", stocks.Count());

            return await MapStocksToDto(stocks);
        }

        private async Task<IEnumerable<StockDto>> MapStocksToDto(IEnumerable<Domain.Entities.Stock> stocks)
        {
            var result = new List<StockDto>();
            foreach (var stock in stocks)
            {
                var avg = await _stockRepo.GetAveragePriceAsync(stock.Id);
                var vol = await _stockRepo.GetTotalVolumeAsync(stock.Id);
                result.Add(new StockDto
                {
                    TickerSymbol = stock.TickerSymbol,
                    AvgPrice = avg,
                    TotalVolume = vol
                });
            }

            return result;
        }
    }
}
