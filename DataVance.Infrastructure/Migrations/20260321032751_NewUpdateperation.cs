using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "AccountingOperations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AccountingOperations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AccountingOperations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AccountingOperations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                columns: new[] { "BranchId", "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new Guid("09b4792f-166e-4f33-8b55-5027ebd9ad06"), new DateTime(2026, 3, 21, 6, 27, 48, 55, DateTimeKind.Local).AddTicks(8685), null, null });

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"),
                columns: new[] { "BranchId", "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new Guid("09b4792f-166e-4f33-8b55-5027ebd9ad06"), new DateTime(2026, 3, 21, 6, 27, 48, 55, DateTimeKind.Local).AddTicks(8705), null, null });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 3, 27, 48, 67, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 3, 27, 48, 67, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 3, 27, 48, 67, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("69cad1a0-0b24-4ef8-89ba-eb1ec5e72cd8"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("bdbf5e25-d206-4c18-812c-5539103c4e77"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("c2c159f7-1db5-4ecc-a630-d4f8d88abdf6"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("cb8893fc-215b-4e91-adea-a3f7b8878216"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 3, 27, 48, 67, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 3, 27, 48, 67, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("67933c63-f80b-48c7-9798-aa899c462767"), new Guid("f1680eea-d1ae-4655-a908-a257d230a1c5"), null, new DateTime(2026, 3, 21, 6, 27, 48, 67, DateTimeKind.Local).AddTicks(8500), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("a9859b54-ccee-43af-9bd1-1e537ba0b11a"), new Guid("9ab7c0e2-e8c0-4e82-a58d-a51c48971b28"), null, new DateTime(2026, 3, 21, 6, 27, 48, 67, DateTimeKind.Local).AddTicks(8461), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("69cad1a0-0b24-4ef8-89ba-eb1ec5e72cd8"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("bdbf5e25-d206-4c18-812c-5539103c4e77"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("c2c159f7-1db5-4ecc-a630-d4f8d88abdf6"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("cb8893fc-215b-4e91-adea-a3f7b8878216"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("67933c63-f80b-48c7-9798-aa899c462767"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("a9859b54-ccee-43af-9bd1-1e537ba0b11a"));

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AccountingOperations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AccountingOperations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccountingOperations");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AccountingOperations");

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
    }
}
