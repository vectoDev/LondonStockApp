using LondonStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;

namespace LondonStock.Infrastructure.Data
{
    public class LondonStockDbContext : DbContext
    {
        public LondonStockDbContext(DbContextOptions<LondonStockDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LoginToken> LoginTokens { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LondonStockDbContext).Assembly);
        }

    }
}
