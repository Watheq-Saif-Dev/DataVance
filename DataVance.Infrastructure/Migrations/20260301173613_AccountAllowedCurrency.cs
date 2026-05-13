using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountAllowedCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultCurrencyId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountAllowedCurrencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAllowedCurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountAllowedCurrencies_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DefaultCurrencyId",
                table: "Accounts",
                column: "DefaultCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAllowedCurrencies_AccountId",
                table: "AccountAllowedCurrencies",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_DefaultCurrencyId",
                table: "Accounts",
                column: "DefaultCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_DefaultCurrencyId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountAllowedCurrencies");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_DefaultCurrencyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DefaultCurrencyId",
                table: "Accounts");
        }
    }
}
