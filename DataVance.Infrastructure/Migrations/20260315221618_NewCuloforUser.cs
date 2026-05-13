using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewCuloforUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "LastSelectedBranchName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("176bdaaf-c3a7-47b6-a637-29c75b33a7ae"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("197f589e-2ef1-4190-b898-9803e6583b7e"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("51ef46f9-40b5-4c83-a7f2-e269a6299c01"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("dea72494-1986-4210-9815-023d7092ec14"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("8fc6c991-2122-48c8-b437-6ad6341ac1f7"), new Guid("a9a8f16b-e1d2-4f6f-8091-6f7bc0e5327a"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("9c6ef414-5e4e-4650-b479-cab0ce19cbe0"), new Guid("beb78863-de17-4047-b171-87ba1e235136"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("176bdaaf-c3a7-47b6-a637-29c75b33a7ae"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("197f589e-2ef1-4190-b898-9803e6583b7e"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("51ef46f9-40b5-4c83-a7f2-e269a6299c01"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("dea72494-1986-4210-9815-023d7092ec14"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("8fc6c991-2122-48c8-b437-6ad6341ac1f7"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("9c6ef414-5e4e-4650-b479-cab0ce19cbe0"));

            migrationBuilder.DropColumn(
                name: "LastSelectedBranchName",
                table: "AspNetUsers");

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
    }
}
