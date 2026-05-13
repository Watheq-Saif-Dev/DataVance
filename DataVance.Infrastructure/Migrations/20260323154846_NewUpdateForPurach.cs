using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateForPurach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"));

            migrationBuilder.DeleteData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("773927bd-80c1-40a9-b644-60a15d35f470"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("afd7f925-36d5-4e98-ab48-a1ee682bdffd"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("c82e8da5-380e-49e6-a085-6c1fbe40d100"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("e78a19c4-f59d-48ac-a1aa-d91f130c1bde"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("d85b41d4-5c9b-40d7-8018-8538298bcd5d"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("d960faf2-9084-4f70-bdd4-ff365b1e10cf"));

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "TaxCodeId",
                table: "PurchaseReceiptLines");

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseReceiptLineId",
                table: "LinkTax",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_LinkTax_PurchaseReceiptLineId",
                table: "LinkTax",
                column: "PurchaseReceiptLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTax_PurchaseReceiptLines_PurchaseReceiptLineId",
                table: "LinkTax",
                column: "PurchaseReceiptLineId",
                principalTable: "PurchaseReceiptLines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTax_PurchaseReceiptLines_PurchaseReceiptLineId",
                table: "LinkTax");

            migrationBuilder.DropIndex(
                name: "IX_LinkTax_PurchaseReceiptLineId",
                table: "LinkTax");

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
                name: "PurchaseReceiptLineId",
                table: "LinkTax");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTax",
                table: "PurchaseReceipts",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "PurchaseReceiptLines",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxCodeId",
                table: "PurchaseReceiptLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AccountingOperations",
                columns: new[] { "Id", "BranchId", "Code", "CreatedAt", "CreatedBy", "IsSystem", "LastModified", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), new Guid("09b4792f-166e-4f33-8b55-5027ebd9ad06"), "PUR_REC", new DateTime(2026, 3, 21, 7, 40, 50, 373, DateTimeKind.Local).AddTicks(1093), null, true, null, "توريد مشتريات" },
                    { new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"), new Guid("09b4792f-166e-4f33-8b55-5027ebd9ad06"), "STK_OUT", new DateTime(2026, 3, 21, 7, 40, 50, 373, DateTimeKind.Local).AddTicks(1126), null, true, null, "صرف مخزني" }
                });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 397, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 397, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 397, DateTimeKind.Utc).AddTicks(9863));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("773927bd-80c1-40a9-b644-60a15d35f470"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("afd7f925-36d5-4e98-ab48-a1ee682bdffd"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("c82e8da5-380e-49e6-a085-6c1fbe40d100"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("e78a19c4-f59d-48ac-a1aa-d91f130c1bde"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 398, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 398, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("d85b41d4-5c9b-40d7-8018-8538298bcd5d"), new Guid("242102ae-3597-4f69-96d0-2a69fe108ef5"), null, new DateTime(2026, 3, 21, 7, 40, 50, 397, DateTimeKind.Local).AddTicks(9676), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("d960faf2-9084-4f70-bdd4-ff365b1e10cf"), new Guid("2e66fb04-d304-46c4-9d02-72daecef3dc6"), null, new DateTime(2026, 3, 21, 7, 40, 50, 397, DateTimeKind.Local).AddTicks(9704), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }
    }
}
