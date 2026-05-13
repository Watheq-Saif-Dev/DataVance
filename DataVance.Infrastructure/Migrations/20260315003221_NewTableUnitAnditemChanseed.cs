using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableUnitAnditemChanseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("2e636882-872c-4fa2-baad-20ab8044327b"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("bc6c8d9c-a97c-4b2f-a32a-b15be85798db"));

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "ItemGroups");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Items",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.InsertData(
                table: "GlobalUnits",
                columns: new[] { "Id", "CategoryId", "IsActive", "Name", "Symbol", "UnitCategoryId" },
                values: new object[,]
                {
                    { new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), new Guid("a1b1c1d1-e1f1-4123-8123-000000000001"), true, "حبة", "Pcs", null },
                    { new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), new Guid("a1b1c1d1-e1f1-4123-8123-000000000001"), true, "كرتون", "Ctn", null },
                    { new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), new Guid("a2b2c2d2-e2f2-4123-8123-000000000002"), true, "جرام", "g", null },
                    { new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), new Guid("a2b2c2d2-e2f2-4123-8123-000000000002"), true, "كيلو جرام", "Kg", null }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "Id", "COGSAccountId", "Code", "InventoryAccountId", "IsActive", "Name", "ParentCategoryId", "SalesAccountId" },
                values: new object[] { new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"), null, "FOOD", null, true, "المواد الغذائية", null, null });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("09cf5cfd-9be1-4c54-8733-7ebd9fd54112"), new Guid("ebfdaab0-956e-4523-bc6c-6009cbb8f098"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("f37556ef-68a4-414a-ba25-275432384d73"), new Guid("311a5ee1-4659-4996-a000-eb99b8788a6a"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "Id", "COGSAccountId", "Code", "InventoryAccountId", "IsActive", "Name", "ParentCategoryId", "SalesAccountId" },
                values: new object[,]
                {
                    { new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"), null, "FOOD-CAN", null, true, "المعلبات", new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"), null },
                    { new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"), null, "DAIRY", null, true, "الألبان", new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"), null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Code", "CostMethod", "CurrentCost", "Description", "IsActive", "ItemGroupId", "LastPurchasePrice", "Name", "ReorderPoint", "RequireBatchAndExpiry", "Type", "Weight", "WeightUnit" },
                values: new object[] { new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), null, "RICE-001", 2, 12.50m, null, true, new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"), 12.00m, "أرز بسمتي هندي 5 كيلو", 0m, false, 1, null, null });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("4dfe75b5-2bda-47a3-8e9f-60f680eeb3f6"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("5f7c9760-9f6e-448b-bf87-b026b5056107"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Code", "CostMethod", "CurrentCost", "Description", "IsActive", "ItemGroupId", "LastPurchasePrice", "Name", "ReorderPoint", "RequireBatchAndExpiry", "Type", "Weight", "WeightUnit" },
                values: new object[] { new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), null, "TUNA-001", 1, 5.00m, null, true, new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"), 5.00m, "تونة قودي 150ج", 0m, false, 1, null, null });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("2a2008b3-5045-44b7-a683-5fda876ac139"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("62d910f3-6464-42fe-9b20-652fabcb980a"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("2a2008b3-5045-44b7-a683-5fda876ac139"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("4dfe75b5-2bda-47a3-8e9f-60f680eeb3f6"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("5f7c9760-9f6e-448b-bf87-b026b5056107"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("62d910f3-6464-42fe-9b20-652fabcb980a"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("09cf5cfd-9be1-4c54-8733-7ebd9fd54112"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("f37556ef-68a4-414a-ba25-275432384d73"));

            migrationBuilder.DeleteData(
                table: "GlobalUnits",
                keyColumn: "Id",
                keyValue: new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"));

            migrationBuilder.DeleteData(
                table: "GlobalUnits",
                keyColumn: "Id",
                keyValue: new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"));

            migrationBuilder.DeleteData(
                table: "GlobalUnits",
                keyColumn: "Id",
                keyValue: new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"));

            migrationBuilder.DeleteData(
                table: "GlobalUnits",
                keyColumn: "Id",
                keyValue: new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"));

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"));

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Items",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "ItemGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("2e636882-872c-4fa2-baad-20ab8044327b"), new Guid("bcf56693-e3cf-45f2-9fdd-5a9b28f83696"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("bc6c8d9c-a97c-4b2f-a32a-b15be85798db"), new Guid("84a4f312-910d-4fd9-b8a3-5ef12101c615"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }
    }
}
