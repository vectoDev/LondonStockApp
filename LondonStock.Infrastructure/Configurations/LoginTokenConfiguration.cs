using LondonStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonStock.Infrastructure.Configurations
{
    public class LoginTokenConfiguration : IEntityTypeConfiguration<LoginToken>
    {
        public void Configure(EntityTypeBuilder<LoginToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                   .WithMany(u => u.LoginTokens)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.TokenHash)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Static token hashes (generated once beforehand)
            const string token1Hash = "$2a$11$VcEJujMbM1p09ZzqEGFGKuBvQhGuAcdAoBzUJeOwvJ8z7x4g.8Q4m"; // BCrypt for "dummy-token-1"
            const string token2Hash = "$2a$11$dl2kF7IoZzPl5GqZV3JbOehY8DJqF4NQ5dw2EHVVbP1hZrs0aKnD2"; // BCrypt for "dummy-token-2"

            var fixedCreatedAt = new DateTime(2025, 08, 11, 0, 0, 0, DateTimeKind.Utc);
            var fixedExpiresAt = fixedCreatedAt.AddDays(7);

            builder.HasData(
                new LoginToken
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), // broker1
                    TokenHash = token1Hash,
                    CreatedAt = fixedCreatedAt,
                    ExpiresAt = fixedExpiresAt
                },
                new LoginToken
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"), // broker2
                    TokenHash = token2Hash,
                    CreatedAt = fixedCreatedAt,
                    ExpiresAt = fixedExpiresAt
                }
            );
        }
    }
}
