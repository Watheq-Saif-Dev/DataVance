using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("0a00ee58-0654-468a-bf4f-9e3d317aff72"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("4d0c5474-7cf5-441f-a564-10b6472442d1"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("0a00ee58-0654-468a-bf4f-9e3d317aff72"), new Guid("3b07854d-167b-40c5-b0d1-04185b0973b9"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("4d0c5474-7cf5-441f-a564-10b6472442d1"), new Guid("c1b56e6a-fb0c-4a05-b224-afe711fed72b"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }
    }
}
