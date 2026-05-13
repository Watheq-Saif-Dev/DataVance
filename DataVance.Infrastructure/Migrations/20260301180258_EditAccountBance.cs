using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditAccountBance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountBalances",
                table: "AccountBalances");

            migrationBuilder.RenameColumn(
                name: "DebitTotal",
                table: "AccountBalances",
                newName: "LocalDebit");

            migrationBuilder.RenameColumn(
                name: "CreditTotal",
                table: "AccountBalances",
                newName: "LocalCredit");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "AccountBalances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "AccountBalances",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Debit",
                table: "AccountBalances",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountBalances",
                table: "AccountBalances",
                columns: new[] { "AccountId", "CurrencyId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountBalances",
                table: "AccountBalances");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "AccountBalances");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "AccountBalances");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "AccountBalances");

            migrationBuilder.RenameColumn(
                name: "LocalDebit",
                table: "AccountBalances",
                newName: "DebitTotal");

            migrationBuilder.RenameColumn(
                name: "LocalCredit",
                table: "AccountBalances",
                newName: "CreditTotal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountBalances",
                table: "AccountBalances",
                column: "Id");
        }
    }
}
