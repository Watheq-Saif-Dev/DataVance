using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewColForCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromCurrency",
                table: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "ToCurrency",
                table: "ExchangeRates");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "ExchangeRates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentExchangeRate",
                table: "Currencies",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRateUpdate",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "CurrentExchangeRate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastRateUpdate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "FromCurrency",
                table: "ExchangeRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToCurrency",
                table: "ExchangeRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
