using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using LondonStock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LondonStockDbContext _context;
        public UserRepository(LondonStockDbContext context) => _context = context;

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
