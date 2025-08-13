using LondonStock.Application.DTOs.Trades;
using LondonStock.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LondonStock.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class TradesController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        private readonly ILogger<TradesController> _logger;

        public TradesController(ITradeService tradeService, ILogger<TradesController> logger)
        {
            _tradeService = tradeService;
            _logger = logger;
        }

        [Authorize(Roles = "Broker")]
        [HttpPost]
        public async Task<IActionResult> CreateTrade([FromBody] TradeCreateDto dto)
        {
            _logger.LogInformation("Broker {User} creating trade for stock {Ticker}",
                User.Identity?.Name, dto.TickerSymbol);
            await _tradeService.CreateTradeAsync(dto);
            _logger.LogInformation("Trade successfully recorded for {Ticker}", dto.TickerSymbol);
            return Ok(new { message = "Trade recorded successfully" });
        }
    }
}
