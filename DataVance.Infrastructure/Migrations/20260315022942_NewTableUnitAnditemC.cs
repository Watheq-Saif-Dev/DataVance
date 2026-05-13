using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableUnitAnditemC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("3f335aec-e3ce-4ba5-83ce-f6edc09772c7"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("6cd1c10d-5e7c-4085-a753-de9a77afd808"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("c705312b-09d3-45c5-8238-8692a7f2b07c"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("dfa037a1-1900-44d2-bd6b-9b66bd492edd"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("89363f04-b328-4d40-87a9-726fa6935fc3"), new Guid("34c67920-8d08-4642-bd5d-4eccded2f3d3"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("c8e791db-ece1-4a32-87ac-15a1a1dd7b50"), new Guid("9dd84cf7-7e66-436d-8dfd-1c45aac4c52e"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3f335aec-e3ce-4ba5-83ce-f6edc09772c7"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("6cd1c10d-5e7c-4085-a753-de9a77afd808"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("c705312b-09d3-45c5-8238-8692a7f2b07c"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("dfa037a1-1900-44d2-bd6b-9b66bd492edd"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("89363f04-b328-4d40-87a9-726fa6935fc3"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("c8e791db-ece1-4a32-87ac-15a1a1dd7b50"));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("2a2008b3-5045-44b7-a683-5fda876ac139"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("4dfe75b5-2bda-47a3-8e9f-60f680eeb3f6"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("5f7c9760-9f6e-448b-bf87-b026b5056107"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("62d910f3-6464-42fe-9b20-652fabcb980a"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("09cf5cfd-9be1-4c54-8733-7ebd9fd54112"), new Guid("ebfdaab0-956e-4523-bc6c-6009cbb8f098"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("f37556ef-68a4-414a-ba25-275432384d73"), new Guid("311a5ee1-4659-4996-a000-eb99b8788a6a"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }
    }
}
