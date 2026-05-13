using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTax_PurchaseReceiptLines_PurchaseReceiptLineId",
                table: "LinkTax");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkTax_PurchaseReceipts_PurchaseReceiptId",
                table: "LinkTax");

            migrationBuilder.DropIndex(
                name: "IX_SystemSettings_Category_SettingKey",
                table: "SystemSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkTax",
                table: "LinkTax");

            migrationBuilder.DropIndex(
                name: "IX_LinkTax_PurchaseReceiptId",
                table: "LinkTax");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3fd58bfa-ba46-4787-970b-ffd2c8223a32"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("80448700-d62b-433c-931e-b3e631becee0"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ca7cc6c6-d1b1-4a5c-8893-0baeeef53eea"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("e3f5a259-e191-414a-a5d5-f157e0ad7f02"));

            migrationBuilder.DeleteData(
                table: "SystemPages",
                keyColumn: "Id",
                keyValue: new Guid("73256034-77a2-468a-a938-0387e07a3f31"));

            migrationBuilder.DropColumn(
                name: "COGSAccountId",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "InventoryAccountId",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "SalesAccountId",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AccountingRuleLines");

            migrationBuilder.DropColumn(
                name: "PurchaseReceiptId",
                table: "LinkTax");

            migrationBuilder.RenameTable(
                name: "LinkTax",
                newName: "LinkTaxes");

            migrationBuilder.RenameColumn(
                name: "Module",
                table: "SystemPages",
                newName: "Route");

            migrationBuilder.RenameIndex(
                name: "IX_LinkTax_PurchaseReceiptLineId",
                table: "LinkTaxes",
                newName: "IX_LinkTaxes_PurchaseReceiptLineId");

            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SettingKey",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LookupType",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SystemPages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SystemPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SystemPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "SystemPages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModuleName",
                table: "SystemPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ActionId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkTaxes",
                table: "LinkTaxes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PageActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageActions_SystemActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "SystemActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageActions_SystemPages_PageId",
                        column: x => x.PageId,
                        principalTable: "SystemPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxAuthorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAuthorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRecoverable = table.Column<bool>(type: "bit", nullable: false),
                    TaxAuthorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchTaxSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalTaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActiveInBranch = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTaxSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchTaxSetting_TaxCodes_TaxCodeId",
                        column: x => x.TaxCodeId,
                        principalTable: "TaxCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTax",
                columns: table => new
                {
                    ItemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalculationOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTax", x => new { x.ItemGroupId, x.TaxCodeId });
                    table.ForeignKey(
                        name: "FK_CategoryTax_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTax_TaxCodes_TaxCodeId",
                        column: x => x.TaxCodeId,
                        principalTable: "TaxCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTaxes",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalculationOrder = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTaxes", x => new { x.ItemId, x.TaxCodeId });
                    table.ForeignKey(
                        name: "FK_ItemTaxes_TaxCodes_TaxCodeId",
                        column: x => x.TaxCodeId,
                        principalTable: "TaxCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaxCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRates_TaxCodes_TaxCodeId",
                        column: x => x.TaxCodeId,
                        principalTable: "TaxCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 21, 14, 13, 736, DateTimeKind.Utc).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 21, 14, 13, 736, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 21, 14, 13, 736, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("07d06c0b-c9da-4145-b81b-600d25f965f0"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("241435c4-e3bb-49de-87ba-414c0469710f"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("3218b355-64ce-4c8a-b126-328a67e3dd6b"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("f54c3aee-d1c2-49b2-aa97-3a8957682aa5"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 21, 14, 13, 736, DateTimeKind.Utc).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 21, 14, 13, 736, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("9495c528-ac97-4dc3-9d4a-e5a9ddc615fd"), new DateTime(2026, 4, 4, 0, 14, 13, 736, DateTimeKind.Local).AddTicks(4943) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("870362b2-9f27-4766-9882-cb11946b5fd6"), new DateTime(2026, 4, 4, 0, 14, 13, 736, DateTimeKind.Local).AddTicks(4981) });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ActionId",
                table: "Permissions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchTaxSetting_TaxCodeId",
                table: "BranchTaxSetting",
                column: "TaxCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTax_TaxCodeId",
                table: "CategoryTax",
                column: "TaxCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTaxes_TaxCodeId",
                table: "ItemTaxes",
                column: "TaxCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_ActionId",
                table: "PageActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_PageActions_PageId",
                table: "PageActions",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_TaxCodeId",
                table: "TaxRates",
                column: "TaxCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTaxes_PurchaseReceiptLines_PurchaseReceiptLineId",
                table: "LinkTaxes",
                column: "PurchaseReceiptLineId",
                principalTable: "PurchaseReceiptLines",
                principalColumn: "Id");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTaxes_PurchaseReceiptLines_PurchaseReceiptLineId",
                table: "LinkTaxes");


            migrationBuilder.DropTable(
                name: "BranchTaxSetting");

            migrationBuilder.DropTable(
                name: "CategoryTax");

            migrationBuilder.DropTable(
                name: "ItemTaxes");

            migrationBuilder.DropTable(
                name: "PageActions");

            migrationBuilder.DropTable(
                name: "TaxAuthorities");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropTable(
                name: "TaxCodes");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ActionId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkTaxes",
                table: "LinkTaxes");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("07d06c0b-c9da-4145-b81b-600d25f965f0"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("241435c4-e3bb-49de-87ba-414c0469710f"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3218b355-64ce-4c8a-b126-328a67e3dd6b"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("f54c3aee-d1c2-49b2-aa97-3a8957682aa5"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SystemPages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SystemPages");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SystemPages");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "SystemPages");

            migrationBuilder.DropColumn(
                name: "ModuleName",
                table: "SystemPages");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "LinkTaxes",
                newName: "LinkTax");

            migrationBuilder.RenameColumn(
                name: "Route",
                table: "SystemPages",
                newName: "Module");

            migrationBuilder.RenameIndex(
                name: "IX_LinkTaxes_PurchaseReceiptLineId",
                table: "LinkTax",
                newName: "IX_LinkTax_PurchaseReceiptLineId");

            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "SystemSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SettingKey",
                table: "SystemSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LookupType",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "SystemSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SystemSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "COGSAccountId",
                table: "ItemGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryAccountId",
                table: "ItemGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalesAccountId",
                table: "ItemGroups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "AccountingRuleLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseReceiptId",
                table: "LinkTax",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkTax",
                table: "LinkTax",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                columns: new[] { "COGSAccountId", "CreatedAt", "InventoryAccountId", "SalesAccountId" },
                values: new object[] { null, new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8466), null, null });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                columns: new[] { "COGSAccountId", "CreatedAt", "InventoryAccountId", "SalesAccountId" },
                values: new object[] { null, new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8468), null, null });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                columns: new[] { "COGSAccountId", "CreatedAt", "InventoryAccountId", "SalesAccountId" },
                values: new object[] { null, new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8470), null, null });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("3fd58bfa-ba46-4787-970b-ffd2c8223a32"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("80448700-d62b-433c-931e-b3e631becee0"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("ca7cc6c6-d1b1-4a5c-8893-0baeeef53eea"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("e3f5a259-e191-414a-a5d5-f157e0ad7f02"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.InsertData(
                table: "SystemPages",
                columns: new[] { "Id", "DisplayName", "Module", "Name" },
                values: new object[] { new Guid("73256034-77a2-468a-a938-0387e07a3f31"), "المخازن", "Warehouses", "Warehouses" });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("7777b2ee-b679-401a-aeab-f7060875ed0d"), new DateTime(2026, 3, 27, 1, 34, 56, 67, DateTimeKind.Local).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("ef7953b9-4396-4ac1-ad64-077f872d6faf"), new DateTime(2026, 3, 27, 1, 34, 56, 67, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_Category_SettingKey",
                table: "SystemSettings",
                columns: new[] { "Category", "SettingKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinkTax_PurchaseReceiptId",
                table: "LinkTax",
                column: "PurchaseReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTax_PurchaseReceiptLines_PurchaseReceiptLineId",
                table: "LinkTax",
                column: "PurchaseReceiptLineId",
                principalTable: "PurchaseReceiptLines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTax_PurchaseReceipts_PurchaseReceiptId",
                table: "LinkTax",
                column: "PurchaseReceiptId",
                principalTable: "PurchaseReceipts",
                principalColumn: "Id");
        }
    }
}
