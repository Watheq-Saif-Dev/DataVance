using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSecuritySystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("11223344-5566-7788-9900-aabbccddeeff"), null, "AdminSuper", "SUPERADMIN_ERP" });

            migrationBuilder.InsertData(
                table: "SystemPages",
                columns: new[] { "Id", "DisplayName", "Module", "Name" },
                values: new object[] { new Guid("73256034-77a2-468a-a938-0387e07a3f31"), "المخازن", "Warehouses", "Warehouses" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanEdit", "CanPrint", "CanView", "PageId", "RoleId" },
                values: new object[] { new Guid("26584285-d852-474c-9f89-70580879612c"), true, true, true, true, true, new Guid("73256034-77a2-468a-a938-0387e07a3f31"), new Guid("11223344-5566-7788-9900-aabbccddeeff") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("26584285-d852-474c-9f89-70580879612c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11223344-5566-7788-9900-aabbccddeeff"));

            migrationBuilder.DeleteData(
                table: "SystemPages",
                keyColumn: "Id",
                keyValue: new Guid("73256034-77a2-468a-a938-0387e07a3f31"));
        }
    }
}
