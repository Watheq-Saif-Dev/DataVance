using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateperationl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PurchaseReceipt_BranchId",
                table: "PurchaseReceipts");

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 7, 13, 35, 640, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 7, 13, 35, 640, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("5594bb26-3b80-410a-b7fd-9ed2c5ae7321"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("b4243543-6fcf-45f3-afa1-f63c66f96fb7"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("bc6adfdf-836a-432f-a282-e1810861ed74"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("cf487f2d-cf74-42e5-bfa1-adeee17c2717"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("80031c4f-388e-43d2-b24c-e465c9c9ca2b"), new Guid("a6d7f699-12f3-4385-8059-5d697722e36a"), null, new DateTime(2026, 3, 21, 7, 13, 35, 656, DateTimeKind.Local).AddTicks(5698), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("d1ee2fbf-52ef-459f-9da5-762a6bed62ba"), new Guid("94a476d4-9373-4019-a398-35464736fcaa"), null, new DateTime(2026, 3, 21, 7, 13, 35, 656, DateTimeKind.Local).AddTicks(5670), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("5594bb26-3b80-410a-b7fd-9ed2c5ae7321"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("b4243543-6fcf-45f3-afa1-f63c66f96fb7"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("bc6adfdf-836a-432f-a282-e1810861ed74"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("cf487f2d-cf74-42e5-bfa1-adeee17c2717"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("80031c4f-388e-43d2-b24c-e465c9c9ca2b"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("d1ee2fbf-52ef-459f-9da5-762a6bed62ba"));

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "PurchaseReceipts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 6, 27, 48, 55, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 6, 27, 48, 55, DateTimeKind.Local).AddTicks(8705));

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
    }
}
