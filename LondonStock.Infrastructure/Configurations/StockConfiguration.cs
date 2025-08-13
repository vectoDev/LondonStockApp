using LondonStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LondonStock.Infrastructure.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TickerSymbol)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.CompanyName)
                   .HasMaxLength(100);

            builder.Property(x => x.Currency)
                   .HasMaxLength(3)
                   .HasDefaultValue("GBP");

            builder.Property(x => x.TotalUnits)
                   .HasColumnType("decimal(18,4)");

            builder.Property(x => x.UpdatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            var staticUpdatedAt = new DateTime(2025, 1, 1);

            builder.HasData(
                new Stock
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    TickerSymbol = "BARC",
                    CompanyName = "Barclays PLC",
                    Currency = "GBP",
                    TotalUnits = 50000,
                    UpdatedAt = staticUpdatedAt
                },
                new Stock
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TickerSymbol = "HSBA",
                    CompanyName = "HSBC Holdings PLC",
                    Currency = "GBP",
                    TotalUnits = 80000,
                    UpdatedAt = staticUpdatedAt
                },
                new Stock
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    TickerSymbol = "BP",
                    CompanyName = "BP PLC",
                    Currency = "GBP",
                    TotalUnits = 65000,
                    UpdatedAt = staticUpdatedAt
                }
            );
        }
    }
}
