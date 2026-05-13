using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColBranchUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "UserBranches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "UserBranches");
        }
    }
}
