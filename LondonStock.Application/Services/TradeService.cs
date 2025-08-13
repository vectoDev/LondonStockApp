using LondonStock.Application.DTOs.Trades;
using LondonStock.Application.Extensions;
using LondonStock.Application.Interfaces;
using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LondonStock.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepo;
        private readonly IStockQueryRepository _stockRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TradeService> _logger;

        public TradeService(
            ITradeRepository tradeRepo,
            IStockQueryRepository stockRepo,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TradeService> logger)
        {
            _tradeRepo = tradeRepo;
            _stockRepo = stockRepo;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task CreateTradeAsync(TradeCreateDto dto)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userId = user.GetUserId();

            _logger.LogInformation("User {UserId} attempting to create trade for {TickerSymbol}", userId, dto.TickerSymbol);

            var stock = await _stockRepo.GetByTickerAsync(dto.TickerSymbol);
            if (stock == null)
            {
                _logger.LogWarning("Stock {TickerSymbol} not found", dto.TickerSymbol);
                throw new KeyNotFoundException($"Stock '{dto.TickerSymbol}' not found.");
            }

            if (!Enum.TryParse<TransactionType>(dto.TransactionType, true, out var transactionType))
            {
                _logger.LogWarning("Invalid transaction type {TransactionType} by user {UserId}", dto.TransactionType, userId);
                throw new InvalidOperationException($"Invalid transaction type '{dto.TransactionType}'.");
            }

            var trade = new Domain.Entities.Trade
            {
                Id = Guid.NewGuid(),
                StockId = stock.Id,
                Price = dto.Price,
                Currency = dto.Currency,
                Quantity = dto.Quantity,
                TransactionType = transactionType,
                BrokerId = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _tradeRepo.AddTradeAsync(trade);

            _logger.LogInformation("Trade successfully created by user {UserId} for {TickerSymbol}", userId, dto.TickerSymbol);
        }
    }
}
