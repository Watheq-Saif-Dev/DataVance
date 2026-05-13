using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Unique_Mapping_Per_Branch",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("42116442-9038-4951-b94d-07fe2b3ecd1d"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("96c6933b-6f0a-4791-9f67-5add100dd49e"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ce7471fa-8268-459f-96ec-2a04a2135797"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d0f56e8a-7e14-4cba-bf7b-219130a7e24a"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("1088b7c5-3ed1-45d8-aa2a-36764908e2f1"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("5309135e-232d-40c6-97b2-5e24cda06886"));

            migrationBuilder.AddColumn<decimal>(
                name: "HeaderDiscount",
                table: "PurchaseReceipts",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmountForUnit",
                table: "PurchaseReceiptLines",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReferenceId",
                schema: "Accounting",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseId",
                schema: "Accounting",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: true);

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_PurchaseReceiptLines_ItemId",
            //    table: "PurchaseReceiptLines",
            //    column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Mapping_Per_Branch",
                schema: "Accounting",
                table: "AccountMappings",
                columns: new[] { "ReferenceId", "AccountSourceType", "Purpose", "BranchId" },
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PurchaseReceiptLines_Items_ItemId",
            //    table: "PurchaseReceiptLines",
            //    column: "ItemId",
            //    principalTable: "Items",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PurchaseReceiptLines_Items_ItemId",
            //    table: "PurchaseReceiptLines");

            //migrationBuilder.DropIndex(
            //    name: "IX_PurchaseReceiptLines_ItemId",
            //    table: "PurchaseReceiptLines");

            migrationBuilder.DropIndex(
                name: "IX_Unique_Mapping_Per_Branch",
                schema: "Accounting",
                table: "AccountMappings");

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

            migrationBuilder.DropColumn(
                name: "HeaderDiscount",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "DiscountAmountForUnit",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReferenceId",
                schema: "Accounting",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("42116442-9038-4951-b94d-07fe2b3ecd1d"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("96c6933b-6f0a-4791-9f67-5add100dd49e"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("ce7471fa-8268-459f-96ec-2a04a2135797"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("d0f56e8a-7e14-4cba-bf7b-219130a7e24a"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("1088b7c5-3ed1-45d8-aa2a-36764908e2f1"), new Guid("b0990d7c-c1a1-4586-b1db-a78b0eb6a817"), null, new DateTime(2026, 3, 19, 0, 59, 17, 707, DateTimeKind.Local).AddTicks(2990), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("5309135e-232d-40c6-97b2-5e24cda06886"), new Guid("5ba87c61-0c31-4314-af2c-0591aa55a7c0"), null, new DateTime(2026, 3, 19, 0, 59, 17, 707, DateTimeKind.Local).AddTicks(3020), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Mapping_Per_Branch",
                schema: "Accounting",
                table: "AccountMappings",
                columns: new[] { "ReferenceId", "AccountSourceType", "Purpose", "BranchId" },
                unique: true);
        }
    }
}
