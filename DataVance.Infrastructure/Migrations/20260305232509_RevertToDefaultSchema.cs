using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RevertToDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "JournalEntries",
                schema: "Finance",
                newName: "JournalEntries");

            migrationBuilder.RenameTable(
                name: "AccountingRules",
                schema: "accounting",
                newName: "AccountingRules");

            migrationBuilder.RenameTable(
                name: "AccountingOperations",
                schema: "accounting",
                newName: "AccountingOperations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.RenameTable(
                name: "JournalEntries",
                newName: "JournalEntries",
                newSchema: "Finance");

            migrationBuilder.RenameTable(
                name: "AccountingRules",
                newName: "AccountingRules",
                newSchema: "accounting");

            migrationBuilder.RenameTable(
                name: "AccountingOperations",
                newName: "AccountingOperations",
                newSchema: "accounting");
        }
    }
}
