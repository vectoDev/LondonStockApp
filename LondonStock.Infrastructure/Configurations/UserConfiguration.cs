using LondonStock.Domain.Entities;
using LondonStock.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonStock.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PasswordHash)
                   .IsRequired();

            builder.Property(x => x.RoleId)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Static hashed passwords (generated once beforehand)
            const string adminHash = "$2a$11$HtCGhcfwCsBlks4SOQGlB.IcPBSM4hz6fqeUKrEFHL52dA.sDRkzC";  // BCrypt for "admin123"
            const string brokerHash = "$2a$11$AVcQ/Aq7BgXHvHG45paOTOV.0TKpL.vJTyxfDqb2bdp7dRuQJ1.lC"; // BCrypt for "broker123"

            var fixedCreatedAt = new DateTime(2025, 08, 11, 0, 0, 0, DateTimeKind.Utc);

            builder.HasData(
                new User
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Username = "admin",
                    PasswordHash = adminHash,
                    RoleId = UserRole.Admin,
                    CreatedAt = fixedCreatedAt
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Username = "broker1",
                    PasswordHash = brokerHash,
                    RoleId = UserRole.Broker,
                    CreatedAt = fixedCreatedAt
                },
                new User
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Username = "broker2",
                    PasswordHash = brokerHash,
                    RoleId = UserRole.Broker,
                    CreatedAt = fixedCreatedAt
                }
            );
        }
    }
}
