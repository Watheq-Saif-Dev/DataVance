using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableUnitAnditemChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemCategories");

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

            migrationBuilder.DropColumn(
                name: "BaseUnitName",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Items",
                newName: "ItemGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                newName: "IX_Items_ItemGroupId");

            migrationBuilder.AddColumn<Guid>(
                name: "GlobalUnitId",
                table: "ItemUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsBaseUnit",
                table: "ItemUnits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentCost",
                table: "Items",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LastPurchasePrice",
                table: "Items",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    COGSAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemGroups_ItemGroups_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ItemGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPrices_ItemUnits_ItemUnitId",
                        column: x => x.ItemUnitId,
                        principalTable: "ItemUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UnitCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalUnits_UnitCategories_UnitCategoryId",
                        column: x => x.UnitCategoryId,
                        principalTable: "UnitCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("2e636882-872c-4fa2-baad-20ab8044327b"), new Guid("bcf56693-e3cf-45f2-9fdd-5a9b28f83696"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("bc6c8d9c-a97c-4b2f-a32a-b15be85798db"), new Guid("84a4f312-910d-4fd9-b8a3-5ef12101c615"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnits_GlobalUnitId",
                table: "ItemUnits",
                column: "GlobalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalUnits_UnitCategoryId",
                table: "GlobalUnits",
                column: "UnitCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentCategoryId",
                table: "ItemGroups",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrices_ItemUnitId",
                table: "ItemPrices",
                column: "ItemUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemGroups_ItemGroupId",
                table: "Items",
                column: "ItemGroupId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnits_GlobalUnits_GlobalUnitId",
                table: "ItemUnits",
                column: "GlobalUnitId",
                principalTable: "GlobalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemGroups_ItemGroupId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnits_GlobalUnits_GlobalUnitId",
                table: "ItemUnits");

            migrationBuilder.DropTable(
                name: "GlobalUnits");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "ItemPrices");

            migrationBuilder.DropTable(
                name: "UnitCategories");

            migrationBuilder.DropIndex(
                name: "IX_ItemUnits_GlobalUnitId",
                table: "ItemUnits");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("2e636882-872c-4fa2-baad-20ab8044327b"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("bc6c8d9c-a97c-4b2f-a32a-b15be85798db"));

            migrationBuilder.DropColumn(
                name: "GlobalUnitId",
                table: "ItemUnits");

            migrationBuilder.DropColumn(
                name: "IsBaseUnit",
                table: "ItemUnits");

            migrationBuilder.DropColumn(
                name: "CurrentCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastPurchasePrice",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemGroupId",
                table: "Items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "BaseUnitName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COGSAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategories_ItemCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_ParentCategoryId",
                table: "ItemCategories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
