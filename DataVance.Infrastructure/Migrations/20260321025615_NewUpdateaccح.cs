using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateaccح : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("15b3eccc-6f37-4414-a880-0f7c35c64b9b"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("360b9aa5-a5f1-4abd-b5f0-5e5c16ea5740"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ecfad52b-cf36-48e1-baba-17ef0d6a28bb"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ed13174b-6162-47dd-b05c-ef7818e5c743"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7975c866-5d28-4ed6-ab5a-1d03da34da65"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("eff86cba-db1f-4881-ac8e-544764d63b27"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 2, 56, 12, 789, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 2, 56, 12, 789, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 2, 56, 12, 789, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("9234eb65-8f66-4178-9432-7d265aab5774"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("ab2139f9-8703-4fe2-a657-d3bba5202f30"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("cccfff1d-4c84-4129-a475-3f107560fdac"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("f680d042-3d32-42fd-9976-f5aca9a6ae46"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 2, 56, 12, 789, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 2, 56, 12, 789, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("15703978-20b6-4a3d-addd-1fba215bdf55"), new Guid("6448f11e-85fe-4035-8f2b-84441a457d5d"), null, new DateTime(2026, 3, 21, 5, 56, 12, 789, DateTimeKind.Local).AddTicks(6113), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("7e096da7-47ec-4f8c-90ae-a4152ca3932b"), new Guid("86d930b3-9ee1-4131-b03e-dcfc0d4e4d31"), null, new DateTime(2026, 3, 21, 5, 56, 12, 789, DateTimeKind.Local).AddTicks(6206), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("9234eb65-8f66-4178-9432-7d265aab5774"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ab2139f9-8703-4fe2-a657-d3bba5202f30"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("cccfff1d-4c84-4129-a475-3f107560fdac"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("f680d042-3d32-42fd-9976-f5aca9a6ae46"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("15703978-20b6-4a3d-addd-1fba215bdf55"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7e096da7-47ec-4f8c-90ae-a4152ca3932b"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("15b3eccc-6f37-4414-a880-0f7c35c64b9b"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("360b9aa5-a5f1-4abd-b5f0-5e5c16ea5740"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("ecfad52b-cf36-48e1-baba-17ef0d6a28bb"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("ed13174b-6162-47dd-b05c-ef7818e5c743"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("7975c866-5d28-4ed6-ab5a-1d03da34da65"), new Guid("7fffd1b6-c5d8-4700-bd68-599776213e6d"), null, new DateTime(2026, 3, 21, 4, 24, 6, 248, DateTimeKind.Local).AddTicks(5724), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("eff86cba-db1f-4881-ac8e-544764d63b27"), new Guid("e4579e3b-e537-405d-8c96-9df326580f7c"), null, new DateTime(2026, 3, 21, 4, 24, 6, 248, DateTimeKind.Local).AddTicks(5572), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }
    }
}
