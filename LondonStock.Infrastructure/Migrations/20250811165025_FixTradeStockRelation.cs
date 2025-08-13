using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LondonStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTradeStockRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoginTokens",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedAt", "ExpiresAt", "TokenHash" },
                values: new object[] { new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$VcEJujMbM1p09ZzqEGFGKuBvQhGuAcdAoBzUJeOwvJ8z7x4g.8Q4m" });

            migrationBuilder.UpdateData(
                table: "LoginTokens",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedAt", "ExpiresAt", "TokenHash" },
                values: new object[] { new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$dl2kF7IoZzPl5GqZV3JbOehY8DJqF4NQ5dw2EHVVbP1hZrs0aKnD2" });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "UpdatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "UpdatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "UpdatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$7fI5W44S8yKc0Q2rXy2wAeTrSYq2yNm9TQH4CzPjv1SMi5d1JfmiG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$Z9wEhwFeZ9uS3Dd4mRjqjO6zIhvO5oQkDgKkWn07yE1n8LJr7wI5S" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$Z9wEhwFeZ9uS3Dd4mRjqjO6zIhvO5oQkDgKkWn07yE1n8LJr7wI5S" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoginTokens",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedAt", "ExpiresAt", "TokenHash" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 39, 24, 519, DateTimeKind.Utc).AddTicks(6545), new DateTime(2025, 8, 18, 16, 39, 24, 519, DateTimeKind.Utc).AddTicks(6698), "$2a$11$duFNZ1jH55jvcAfRI1HiUOnamCFZkStVm0L83NxacOIxs86anJqYO" });

            migrationBuilder.UpdateData(
                table: "LoginTokens",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedAt", "ExpiresAt", "TokenHash" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 39, 24, 520, DateTimeKind.Utc).AddTicks(1891), new DateTime(2025, 8, 18, 16, 39, 24, 520, DateTimeKind.Utc).AddTicks(1894), "$2a$11$TR5J7IpLp7OB0md2eWOoaORgOo9tynj8iwvusgchCfYVaZOJjLCQe" });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 11, 16, 39, 24, 524, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 11, 16, 39, 24, 524, DateTimeKind.Utc).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 11, 16, 39, 24, 524, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 16, 39, 24, 534, DateTimeKind.Utc).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 16, 39, 24, 534, DateTimeKind.Utc).AddTicks(1677));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 39, 24, 778, DateTimeKind.Utc).AddTicks(5526), "$2a$11$PX3BhlPVDxWiA3nd4mmNdeeKgkwh0RCdrEPrxVPZpEucY1Y3PLEpq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 39, 24, 778, DateTimeKind.Utc).AddTicks(5673), "$2a$11$GEruSPGPIMqhZw2dCnIcUOGB7YGgmo1SdDkse4fKHsfr4GogsO.k2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 8, 11, 16, 39, 24, 778, DateTimeKind.Utc).AddTicks(5674), "$2a$11$GEruSPGPIMqhZw2dCnIcUOGB7YGgmo1SdDkse4fKHsfr4GogsO.k2" });
        }
    }
}
