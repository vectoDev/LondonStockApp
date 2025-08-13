using LondonStock.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole RoleId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Trade> Trades { get; set; } = new List<Trade>();
        public ICollection<LoginToken> LoginTokens { get; set; } = new List<LoginToken>();
    }
}
