using LondonStock.Domain.Entities;

namespace LondonStock.Application.Interfaces.Repositories
{
    public interface ILoginTokenRepository
    {
        Task AddAsync(LoginToken token);
        Task<LoginToken?> GetByTokenAsync(string rawRefreshToken);
        Task UpdateAsync(LoginToken token);
        Task RevokeAsync(LoginToken token);
        Task RemoveExpiredAsync();
    }
}
