using LondonStock.Application.DTOs.Stocks;
using LondonStock.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LondonStock.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockQueryService _stockQueryService;
        private readonly IStockCommandService _stockCommandService;
        private readonly ILogger<StocksController> _logger;

        public StocksController(
            IStockQueryService stockQueryService,
            IStockCommandService stockCommandService,
            ILogger<StocksController> logger)
        {
            _stockQueryService = stockQueryService;
            _stockCommandService = stockCommandService;
            _logger = logger;
        }

        [HttpGet("{ticker}")]
        public async Task<IActionResult> GetStock(string ticker)
        {
            _logger.LogInformation("Fetching stock details for ticker: {Ticker}", ticker);

            var result = await _stockQueryService.GetStockAsync(ticker);
            if (result == null)
            {
                _logger.LogWarning("Stock not found: {Ticker}", ticker);
                return NotFound(new { Message = $"Stock '{ticker}' not found" });
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            _logger.LogInformation("Fetching all stocks");
            var result = await _stockQueryService.GetAllStocksAsync();
            return Ok(result);
        }

        [HttpPost("range")]
        public async Task<IActionResult> GetStocksByRange([FromBody] string[] tickers)
        {
            _logger.LogInformation("Fetching stocks for range: {Tickers}", string.Join(", ", tickers));
            var result = await _stockQueryService.GetStocksByRangeAsync(tickers);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStock([FromBody] StockCreateDto dto)
        {
            _logger.LogInformation("Admin creating stock: {Ticker}", dto.TickerSymbol);
            var stockId = await _stockCommandService.CreateStockAsync(dto);
            return CreatedAtAction(nameof(GetStock), new { ticker = dto.TickerSymbol }, new { Id = stockId });
        }

        [HttpDelete("{ticker}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStock(string ticker)
        {
            _logger.LogInformation("Admin deleting stock: {Ticker}", ticker);
            await _stockCommandService.DeleteStockAsync(ticker);
            return NoContent();
        }

    }
}
