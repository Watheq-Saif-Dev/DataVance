using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateaccou : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("39649c5f-4226-4021-b384-815706297100"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("429347aa-74bd-4c89-8fa3-7e8ccf93dc9b"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("42f7d030-bb27-48d0-9aad-4a48b6a059fd"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("e9cae1f6-69ca-4ff3-b16c-30a0696a2047"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("0e5aad31-ba34-4a52-85f0-707c3253b21d"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("381c9488-ea30-4677-99d0-ec795f148928"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2026, 3, 19, 1, 18, 19, 494, DateTimeKind.Utc).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 18, 19, 494, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 18, 19, 494, DateTimeKind.Utc).AddTicks(582));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("39649c5f-4226-4021-b384-815706297100"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("429347aa-74bd-4c89-8fa3-7e8ccf93dc9b"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("42f7d030-bb27-48d0-9aad-4a48b6a059fd"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("e9cae1f6-69ca-4ff3-b16c-30a0696a2047"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 18, 19, 494, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 18, 19, 494, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("0e5aad31-ba34-4a52-85f0-707c3253b21d"), new Guid("cdb54f23-3ef1-4256-9d67-89fe1268abe7"), null, new DateTime(2026, 3, 19, 4, 18, 19, 494, DateTimeKind.Local).AddTicks(235), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("381c9488-ea30-4677-99d0-ec795f148928"), new Guid("bbd65ce4-c88b-4bb8-af05-8577915ea4d7"), null, new DateTime(2026, 3, 19, 4, 18, 19, 494, DateTimeKind.Local).AddTicks(318), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }
    }
}
