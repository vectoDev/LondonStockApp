using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LondonStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Stocks_StockId",
                table: "Trades");

            migrationBuilder.AddColumn<Guid>(
                name: "StockId1",
                table: "Trades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Trades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Currency", "TickerSymbol", "TotalUnits", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Barclays PLC", "GBP", "BARC", 50000m, new DateTime(2025, 8, 11, 16, 39, 24, 524, DateTimeKind.Utc).AddTicks(5000) },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "HSBC Holdings PLC", "GBP", "HSBA", 80000m, new DateTime(2025, 8, 11, 16, 39, 24, 524, DateTimeKind.Utc).AddTicks(5201) },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "BP PLC", "GBP", "BP", 65000m, new DateTime(2025, 8, 11, 16, 39, 24, 524, DateTimeKind.Utc).AddTicks(5203) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "PasswordHash", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 8, 11, 16, 39, 24, 778, DateTimeKind.Utc).AddTicks(5526), "$2a$11$PX3BhlPVDxWiA3nd4mmNdeeKgkwh0RCdrEPrxVPZpEucY1Y3PLEpq", 1, "admin" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 8, 11, 16, 39, 24, 778, DateTimeKind.Utc).AddTicks(5673), "$2a$11$GEruSPGPIMqhZw2dCnIcUOGB7YGgmo1SdDkse4fKHsfr4GogsO.k2", 2, "broker1" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 8, 11, 16, 39, 24, 778, DateTimeKind.Utc).AddTicks(5674), "$2a$11$GEruSPGPIMqhZw2dCnIcUOGB7YGgmo1SdDkse4fKHsfr4GogsO.k2", 2, "broker2" }
                });

            migrationBuilder.InsertData(
                table: "LoginTokens",
                columns: new[] { "Id", "CreatedAt", "ExpiresAt", "RevokedAt", "TokenHash", "UserId" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 8, 11, 16, 39, 24, 519, DateTimeKind.Utc).AddTicks(6545), new DateTime(2025, 8, 18, 16, 39, 24, 519, DateTimeKind.Utc).AddTicks(6698), null, "$2a$11$duFNZ1jH55jvcAfRI1HiUOnamCFZkStVm0L83NxacOIxs86anJqYO", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 8, 11, 16, 39, 24, 520, DateTimeKind.Utc).AddTicks(1891), new DateTime(2025, 8, 18, 16, 39, 24, 520, DateTimeKind.Utc).AddTicks(1894), null, "$2a$11$TR5J7IpLp7OB0md2eWOoaORgOo9tynj8iwvusgchCfYVaZOJjLCQe", new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "BrokerId", "CreatedAt", "Currency", "Price", "Quantity", "StockId", "StockId1", "TransactionType", "UserId" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 8, 11, 16, 39, 24, 534, DateTimeKind.Utc).AddTicks(1537), "GBP", 150.25m, 100m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null, 1, null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 8, 11, 16, 39, 24, 534, DateTimeKind.Utc).AddTicks(1677), "GBP", 450.75m, 50m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_StockId1",
                table: "Trades",
                column: "StockId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Stocks_StockId",
                table: "Trades",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Stocks_StockId1",
                table: "Trades",
                column: "StockId1",
                principalTable: "Stocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Users_UserId",
                table: "Trades",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Stocks_StockId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Stocks_StockId1",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Users_UserId",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_StockId1",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_UserId",
                table: "Trades");

            migrationBuilder.DeleteData(
                table: "LoginTokens",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "LoginTokens",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DropColumn(
                name: "StockId1",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trades");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Stocks_StockId",
                table: "Trades",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
