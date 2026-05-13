using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateacco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("37ec5927-065b-450b-bdd8-5f8af94d00e5"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3bebfc34-40d1-4fe1-be6d-d867c8ff3af3"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("7a0d3dfd-9fcb-4b08-a8f3-26c52562e82f"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("8ba3f8c0-e259-4305-932d-d78e3f184796"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("33ff785d-1609-4971-bbf6-8a909351ecd4"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("886e696c-d07b-4c87-867c-343812d0a8bb"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("1bf84af9-2961-4595-b680-06a10993cf02"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("86f252c1-9ed0-4e83-ad98-9a635a61d65f"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("8af35923-da53-4864-b54c-1660f81c7eef"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("93112bb6-d08f-448a-99fa-46d25c1520bc"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("3cd9993e-8690-4b6f-8ce9-d6e7f4341c49"), new Guid("976f245d-e894-4b0c-a731-cca016c5a097"), null, new DateTime(2026, 3, 19, 4, 45, 13, 855, DateTimeKind.Local).AddTicks(1419), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("7a6e2513-9c90-4c96-82a2-45872f43314c"), new Guid("265c7125-5693-4cb2-9066-138c86cce47f"), null, new DateTime(2026, 3, 19, 4, 45, 13, 855, DateTimeKind.Local).AddTicks(1642), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("1bf84af9-2961-4595-b680-06a10993cf02"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("86f252c1-9ed0-4e83-ad98-9a635a61d65f"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("8af35923-da53-4864-b54c-1660f81c7eef"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("93112bb6-d08f-448a-99fa-46d25c1520bc"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("3cd9993e-8690-4b6f-8ce9-d6e7f4341c49"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7a6e2513-9c90-4c96-82a2-45872f43314c"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 42, 16, 99, DateTimeKind.Utc).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 42, 16, 99, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 42, 16, 99, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("37ec5927-065b-450b-bdd8-5f8af94d00e5"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("3bebfc34-40d1-4fe1-be6d-d867c8ff3af3"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("7a0d3dfd-9fcb-4b08-a8f3-26c52562e82f"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("8ba3f8c0-e259-4305-932d-d78e3f184796"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 42, 16, 99, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 42, 16, 99, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("33ff785d-1609-4971-bbf6-8a909351ecd4"), new Guid("ccf4b2b0-606b-466c-a467-4ddaa56d7f86"), null, new DateTime(2026, 3, 19, 4, 42, 16, 99, DateTimeKind.Local).AddTicks(4155), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("886e696c-d07b-4c87-867c-343812d0a8bb"), new Guid("5b93f93c-0d99-4dd8-a7a8-691ef79fee86"), null, new DateTime(2026, 3, 19, 4, 42, 16, 99, DateTimeKind.Local).AddTicks(4018), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }
    }
}
