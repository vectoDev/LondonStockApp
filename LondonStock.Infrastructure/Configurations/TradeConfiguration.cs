using LondonStock.Domain.Entities;
using LondonStock.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LondonStock.Infrastructure.Configurations
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Quantity)
                   .HasColumnType("decimal(18,4)");

            builder.Property(x => x.Currency)
                   .HasMaxLength(3)
                   .HasDefaultValue("GBP");

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(t => t.Stock)
                   .WithMany()
                   .HasForeignKey(t => t.StockId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Broker)
                   .WithMany()
                   .HasForeignKey(t => t.BrokerId)
                   .OnDelete(DeleteBehavior.Restrict);

            var staticCreatedAt = new DateTime(2025, 1, 1);

            builder.HasData(
                new Trade
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    StockId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), // Barclays
                    Price = 150.25m,
                    Quantity = 100,
                    Currency = "GBP",
                    TransactionType = TransactionType.Buy,
                    BrokerId = Guid.Parse("22222222-2222-2222-2222-222222222222"), // broker1
                    CreatedAt = staticCreatedAt
                },
                new Trade
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    StockId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), // HSBC
                    Price = 450.75m,
                    Quantity = 50,
                    Currency = "GBP",
                    TransactionType = TransactionType.Sell,
                    BrokerId = Guid.Parse("33333333-3333-3333-3333-333333333333"), // broker2
                    CreatedAt = staticCreatedAt
                }
            );
        }
    }
}
