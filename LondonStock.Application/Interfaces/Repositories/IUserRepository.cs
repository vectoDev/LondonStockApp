using LondonStock.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LondonStock.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(Guid id);
    }
}
