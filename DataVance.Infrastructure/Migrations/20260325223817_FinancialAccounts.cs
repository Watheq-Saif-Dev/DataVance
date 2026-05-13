using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinancialAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("15d3a9ca-275e-4de6-af8a-6896cbe4bc02"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3ca338d7-cdae-4952-9e71-88ab3f3519c2"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("728aa60f-a105-40a1-9d42-bc8fcaaba561"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d9c054cc-06d9-43a3-9627-abfaba291e7c"));

            migrationBuilder.AddColumn<Guid>(
                name: "Payment_FinancialAccountId",
                table: "PurchaseReceipts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payment_Method",
                table: "PurchaseReceipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Payment_ReferenceNo",
                table: "PurchaseReceipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinancialAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("08b5d485-ff48-46f0-afeb-d95d37402096"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("2159d348-f2c9-4b33-a206-fbd55a350271"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("7dce793b-bbe9-49fe-8ad5-6bcb6167ae7a"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("9a202bd8-ac76-4a8d-8cdb-73c0afddbc09"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("d8ae8a6a-6c9c-4285-969b-f542062b8236"), new DateTime(2026, 3, 26, 1, 38, 15, 837, DateTimeKind.Local).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("7845a4a1-684d-4727-9232-05d10f004722"), new DateTime(2026, 3, 26, 1, 38, 15, 837, DateTimeKind.Local).AddTicks(4270) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialAccounts");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("08b5d485-ff48-46f0-afeb-d95d37402096"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("2159d348-f2c9-4b33-a206-fbd55a350271"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("7dce793b-bbe9-49fe-8ad5-6bcb6167ae7a"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("9a202bd8-ac76-4a8d-8cdb-73c0afddbc09"));

            migrationBuilder.DropColumn(
                name: "Payment_FinancialAccountId",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "Payment_Method",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "Payment_ReferenceNo",
                table: "PurchaseReceipts");

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("15d3a9ca-275e-4de6-af8a-6896cbe4bc02"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("3ca338d7-cdae-4952-9e71-88ab3f3519c2"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("728aa60f-a105-40a1-9d42-bc8fcaaba561"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("d9c054cc-06d9-43a3-9627-abfaba291e7c"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("9a29feeb-35ad-46fd-a235-e70cd6da8c17"), new DateTime(2026, 3, 25, 20, 23, 46, 638, DateTimeKind.Local).AddTicks(5623) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("b884c9cf-0046-4d78-8533-364acbc80350"), new DateTime(2026, 3, 25, 20, 23, 46, 638, DateTimeKind.Local).AddTicks(5639) });
        }
    }
}
