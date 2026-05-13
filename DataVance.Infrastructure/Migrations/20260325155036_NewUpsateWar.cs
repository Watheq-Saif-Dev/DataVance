using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpsateWar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("5e74a121-9bd5-4f7a-b87e-a1acf3725eda"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("62b72640-e1fe-4b9d-9084-66c616c956d7"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("bcae5bf5-eb8e-4d7e-9f86-5a0f1ec5e82b"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d99eec98-bd43-4ecc-8054-3acbc19fa721"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("16518b1c-1672-4008-8523-60ab60131124"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("21321624-1e1c-4ae2-84d8-434d6e75fb27"));

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "ItemUnits");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Warehouses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Warehouses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "UserWarehouses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserWarehouses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserWarehouses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserWarehouses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UserWarehouses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("1d25f295-1b35-4d8c-8c94-f43dd6eb15a4"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("7a2a6bf7-6290-4b11-abe4-b8bf9dd499b6"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("acd09048-32d4-4bcd-8ac2-3ecf58d278e9"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("d40f8f55-4478-45a3-9e60-fd683a65acd8"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"), new Guid("a6e66dcb-f076-4a15-b96d-f8c6125bdefa"), null, new DateTime(2026, 3, 25, 18, 50, 35, 151, DateTimeKind.Local).AddTicks(4232), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"), new Guid("bfaa1482-2abf-43a2-a4c9-e70e42683b2d"), null, new DateTime(2026, 3, 25, 18, 50, 35, 151, DateTimeKind.Local).AddTicks(4254), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("1d25f295-1b35-4d8c-8c94-f43dd6eb15a4"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("7a2a6bf7-6290-4b11-abe4-b8bf9dd499b6"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("acd09048-32d4-4bcd-8ac2-3ecf58d278e9"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d40f8f55-4478-45a3-9e60-fd683a65acd8"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "UserWarehouses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserWarehouses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserWarehouses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserWarehouses");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UserWarehouses");

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "ItemUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 15, 48, 43, 284, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 15, 48, 43, 284, DateTimeKind.Utc).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 15, 48, 43, 284, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("5e74a121-9bd5-4f7a-b87e-a1acf3725eda"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("62b72640-e1fe-4b9d-9084-66c616c956d7"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("bcae5bf5-eb8e-4d7e-9f86-5a0f1ec5e82b"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("d99eec98-bd43-4ecc-8054-3acbc19fa721"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 15, 48, 43, 284, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 15, 48, 43, 284, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("16518b1c-1672-4008-8523-60ab60131124"), new Guid("c1da4f5b-9bf7-4be4-97c9-329a25f0aa6c"), null, new DateTime(2026, 3, 23, 18, 48, 43, 284, DateTimeKind.Local).AddTicks(748), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("21321624-1e1c-4ae2-84d8-434d6e75fb27"), new Guid("4b702dd6-7402-4ccb-8252-acd848967427"), null, new DateTime(2026, 3, 23, 18, 48, 43, 284, DateTimeKind.Local).AddTicks(783), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }
    }
}
