using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LondonStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "$2a$11$HtCGhcfwCsBlks4SOQGlB.IcPBSM4hz6fqeUKrEFHL52dA.sDRkzC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "PasswordHash",
                value: "$2a$11$AVcQ/Aq7BgXHvHG45paOTOV.0TKpL.vJTyxfDqb2bdp7dRuQJ1.lC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "PasswordHash",
                value: "$2a$11$AVcQ/Aq7BgXHvHG45paOTOV.0TKpL.vJTyxfDqb2bdp7dRuQJ1.lC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "PasswordHash",
                value: "$2a$11$7fI5W44S8yKc0Q2rXy2wAeTrSYq2yNm9TQH4CzPjv1SMi5d1JfmiG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "PasswordHash",
                value: "$2a$11$Z9wEhwFeZ9uS3Dd4mRjqjO6zIhvO5oQkDgKkWn07yE1n8LJr7wI5S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "PasswordHash",
                value: "$2a$11$Z9wEhwFeZ9uS3Dd4mRjqjO6zIhvO5oQkDgKkWn07yE1n8LJr7wI5S");
        }
    }
}
