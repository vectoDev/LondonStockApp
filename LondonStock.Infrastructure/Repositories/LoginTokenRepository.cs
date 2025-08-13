using BCrypt.Net;
using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using LondonStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Infrastructure.Repositories
{
    public class LoginTokenRepository : ILoginTokenRepository
    {
        private readonly LondonStockDbContext _context;

        public LoginTokenRepository(LondonStockDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LoginToken token)
        {
            _context.LoginTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<LoginToken?> GetByTokenAsync(string rawRefreshToken)
        {
            var now = DateTime.UtcNow;
            var candidates = await _context.LoginTokens
                .Include(t => t.User)
                .Where(t => t.RevokedAt == null && t.ExpiresAt > now)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            foreach (var t in candidates)
            {
                if (BCrypt.Net.BCrypt.Verify(rawRefreshToken, t.TokenHash))
                    return t;
            }
            return null;
        }

        public async Task UpdateAsync(LoginToken token)
        {
            _context.LoginTokens.Update(token);
            await _context.SaveChangesAsync();
        }

        public async Task RevokeAsync(LoginToken token)
        {
            token.RevokedAt = DateTime.UtcNow;
            _context.LoginTokens.Update(token);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveExpiredAsync()
        {
            var now = DateTime.UtcNow;
            var expired = await _context.LoginTokens
                .Where(t => t.ExpiresAt <= now)
                .ToListAsync();
            if (expired.Count > 0)
            {
                _context.LoginTokens.RemoveRange(expired);
                await _context.SaveChangesAsync();
            }
        }
    }
}
