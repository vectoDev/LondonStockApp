using LondonStock.Application.DTOs.Trades;
using System.Threading.Tasks;

namespace LondonStock.Application.Interfaces
{
    public interface ITradeService
    {
        Task CreateTradeAsync(TradeCreateDto dto);
    }
}
