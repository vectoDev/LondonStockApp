using LondonStock.Domain.Entities;

namespace LondonStock.Application.Interfaces.Repositories
{
    public interface IStockCommandRepository
    {
        Task AddStockAsync(Stock stock);
        Task DeleteStockAsync(Stock stock);
    }
}
