using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJournalentry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "JournalEntries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "JournalEntries");
        }
    }
}
