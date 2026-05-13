using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewCulForoutbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("1df6a5ea-d33f-4eef-bbee-c2569eb05290"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("a2a33344-467a-47f1-8e73-9a1b6f7006d9"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("f9707b34-600d-4957-a8cc-1193f9906cc1"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7aca9a9c-fc12-447e-a775-b676b439f3fa"));

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("b63aa9c2-540a-46a4-ba7a-9e86c066e224"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFromDomain",
                table: "OutboxMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "AccountId", "COGSAccountId", "Code", "InventoryAccountId", "IsActive", "Name", "ParentCategoryId", "SalesAccountId" },
                values: new object[] { new Guid("10f3964d-49e6-4ef1-bdb8-271a67f7f0ec"), new Guid("3e6b0c92-6752-4b7f-98a7-11e35c171a7f"), null, "FRZ-01", null, true, "مواد غذائية - مجمدات", null, null });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("7ebd5226-0517-4251-92af-077e4c613bba"), new Guid("492974d3-67a4-4a2f-b1c9-1aeac68eb6ba"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("8982389a-2df3-44f2-95a8-5d02a32cbb6f"), new Guid("5d14250c-dad9-4bcc-b44d-9188a32b0c6d"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BaseUnitName", "Brand", "CategoryId", "Code", "CostMethod", "Description", "IsActive", "Name", "ReorderPoint", "RequireBatchAndExpiry", "Type", "Weight", "WeightUnit" },
                values: new object[] { new Guid("1c893b0c-b089-4212-9796-18d2d21caf44"), "حبة", null, new Guid("10f3964d-49e6-4ef1-bdb8-271a67f7f0ec"), "ITM-101", 2, null, true, "دجاج ساديا 900 جرام", 10m, true, 1, 900m, "جرام" });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[] { new Guid("c745d774-6e6d-4b05-83cb-6d94a7d1aa78"), "628100112233", 12m, true, true, new Guid("1c893b0c-b089-4212-9796-18d2d21caf44"), "كرتون" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("c745d774-6e6d-4b05-83cb-6d94a7d1aa78"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7ebd5226-0517-4251-92af-077e4c613bba"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("8982389a-2df3-44f2-95a8-5d02a32cbb6f"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1c893b0c-b089-4212-9796-18d2d21caf44"));

            migrationBuilder.DeleteData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("10f3964d-49e6-4ef1-bdb8-271a67f7f0ec"));

            migrationBuilder.DropColumn(
                name: "IsFromDomain",
                table: "OutboxMessages");

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "AccountId", "COGSAccountId", "Code", "InventoryAccountId", "IsActive", "Name", "ParentCategoryId", "SalesAccountId" },
                values: new object[] { new Guid("b63aa9c2-540a-46a4-ba7a-9e86c066e224"), new Guid("d77fa1d6-f620-4204-afd3-8d0545da47d2"), null, "FRZ-01", null, true, "مواد غذائية - مجمدات", null, null });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("a2a33344-467a-47f1-8e73-9a1b6f7006d9"), new Guid("62353440-ae38-4ccf-8dce-1eadaafe336d"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("f9707b34-600d-4957-a8cc-1193f9906cc1"), new Guid("cca44c7d-a86e-444e-843b-8b300a9c2710"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BaseUnitName", "Brand", "CategoryId", "Code", "CostMethod", "Description", "IsActive", "Name", "ReorderPoint", "RequireBatchAndExpiry", "Type", "Weight", "WeightUnit" },
                values: new object[] { new Guid("7aca9a9c-fc12-447e-a775-b676b439f3fa"), "حبة", null, new Guid("b63aa9c2-540a-46a4-ba7a-9e86c066e224"), "ITM-101", 2, null, true, "دجاج ساديا 900 جرام", 10m, true, 1, 900m, "جرام" });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[] { new Guid("1df6a5ea-d33f-4eef-bbee-c2569eb05290"), "628100112233", 12m, true, true, new Guid("7aca9a9c-fc12-447e-a775-b676b439f3fa"), "كرتون" });
        }
    }
}
