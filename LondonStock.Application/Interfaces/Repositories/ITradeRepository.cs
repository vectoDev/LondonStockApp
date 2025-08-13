using LondonStock.Domain.Entities;

namespace LondonStock.Application.Interfaces.Repositories
{
    public interface ITradeRepository
    {
        Task AddTradeAsync(Trade trade);
        Task<decimal> GetAveragePriceAsync(string ticker);
        Task<decimal> GetTotalVolumeAsync(string ticker);
    }
}
