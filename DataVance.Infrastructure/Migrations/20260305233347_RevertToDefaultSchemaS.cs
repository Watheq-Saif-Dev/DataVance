using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RevertToDefaultSchemaS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AccountingRuleLines",
                schema: "accounting",
                newName: "AccountingRuleLines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "accounting");

            migrationBuilder.RenameTable(
                name: "AccountingRuleLines",
                newName: "AccountingRuleLines",
                newSchema: "accounting");
        }
    }
}
